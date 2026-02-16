using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using System.Collections;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Dice5_Projectiles", story: "[Boss] throw [x] [Projectiles] on [Player]", category: "Action", id: "c11e40b7d2420a0f8a8051811d5bd93b")]
public partial class Dice5ProjectilesAction : Action
{
    [SerializeReference] public BlackboardVariable<Transform> Boss;
    [SerializeReference] public BlackboardVariable<int> X;
    [SerializeReference] public BlackboardVariable<GameObject> Projectiles;
    [SerializeReference] public BlackboardVariable<Transform> Player;

    private bool isComplete = false;
    protected override Status OnStart()
    {
        isComplete = false;
        Boss.Value.GetComponent<MonoBehaviour>().StartCoroutine(SpawnExplo(X.Value));
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if(isComplete == true)
            return Status.Success;
        return Status.Running;
    }

    // /!\ Éléments Vibe coded /!\

    private float spawnRadius = 2f; // Rayon de dispersion autour du joueur
    private float arcHeight = 15f; // Hauteur de l'arc (ajustez pour plus/moins de hauteur)


    private IEnumerator SpawnExplo(int number)
    {
        for (int i = 0; i < number; i++)
        {
            // Spawn à la position du script (transform)
            GameObject explo = MonoBehaviour.Instantiate(Projectiles.Value, Boss.Value.position, Quaternion.identity);
            Debug.Log(explo);
            Rigidbody rb = explo.GetComponent<Rigidbody>();

            // Position cible avec léger offset aléatoire
            Vector3 targetPos = Player.Value.position + new Vector3(
                UnityEngine.Random.Range(-spawnRadius, spawnRadius),
                0,
                UnityEngine.Random.Range(-spawnRadius, spawnRadius)
            );

            // Calcul de la trajectoire parabolique en cloche
            Vector3 displacement = targetPos - Boss.Value.transform.position;
            float horizontalDistance = new Vector3(displacement.x, 0, displacement.z).magnitude;
            float verticalDistance = displacement.y;

            float gravity = Mathf.Abs(Physics.gravity.y);

            // Calcul du temps basé sur la hauteur de l'arc
            float time = Mathf.Sqrt(2 * arcHeight / gravity) + Mathf.Sqrt(2 * (arcHeight - verticalDistance) / gravity);

            // Vélocité horizontale
            Vector3 horizontalVelocity = new Vector3(displacement.x, 0, displacement.z) / time;

            // Vélocité verticale pour atteindre la hauteur d'arc souhaitée
            float verticalVelocity = Mathf.Sqrt(2 * gravity * arcHeight);

            rb.linearVelocity = horizontalVelocity + Vector3.up * verticalVelocity;

            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(4f);
        isComplete = true;
    }

}

