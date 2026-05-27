using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using System.Collections;
using System.Collections.Generic;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Dice5_Projectiles", story: "[Boss] throw 5 [Projectiles] on [Player] [Zone1] [Zone2] [Zone3] [Zone4]", category: "Action", id: "c11e40b7d2420a0f8a8051811d5bd93b")]
public partial class Dice5ProjectilesAction : Action
{
    [SerializeReference] public BlackboardVariable<Transform> Boss;
    [SerializeReference] public BlackboardVariable<GameObject> Projectiles;
    [SerializeReference] public BlackboardVariable<Transform> Player;
    [SerializeReference] public BlackboardVariable<Transform> Zone1;
    [SerializeReference] public BlackboardVariable<Transform> Zone2;
    [SerializeReference] public BlackboardVariable<Transform> Zone3;
    [SerializeReference] public BlackboardVariable<Transform> Zone4;
    private bool isComplete = false;
    protected override Status OnStart()
    {
        isComplete = false;
        Boss.Value.GetComponent<MonoBehaviour>().StartCoroutine(SpawnExplo(5));
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if(isComplete == true)
            return Status.Success;
        return Status.Running;
    }

    // /!\ Attention, beaucoup d'�l�ments Vibe coded, je sais pas faire de physique correctement /!\

    private float spawnRadius = ConstantsDice.spawnRadius; // Rayon de dispersion autour du joueur
    private float arcHeight = ConstantsDice.arcHeight; // Hauteur de l'arc
    private float timeBetweenTwoSpawns = ConstantsDice.timeBetweenTwoSpawns;
    private float BreakAtTheEnd = ConstantsDice.BreakAtTheEnd;

    private IEnumerator SpawnExplo(int number)
    {
        for (int i = 0; i < number; i++)
        {
            // Spawn � la position du script (transform)

            GameObject explo = MonoBehaviour.Instantiate(Projectiles.Value, Boss.Value.position, Quaternion.identity);
            Debug.Log(explo);
            Rigidbody rb = explo.GetComponent<Rigidbody>();

            // Position cible avec l�ger offset al�atoire
            Vector3 targetPos = Positions()[i] + new Vector3(
                UnityEngine.Random.Range(-spawnRadius, spawnRadius),
                0,
                UnityEngine.Random.Range(-spawnRadius, spawnRadius)
            );

            // Calcul de la trajectoire parabolique en cloche
            Vector3 displacement = targetPos - Boss.Value.transform.position;
            float horizontalDistance = new Vector3(displacement.x, 0, displacement.z).magnitude;
            float verticalDistance = displacement.y;

            float gravity = Mathf.Abs(Physics.gravity.y);

            // Calcul du temps bas� sur la hauteur de l'arc
            float time = Mathf.Sqrt(2 * arcHeight / gravity) + Mathf.Sqrt(2 * (arcHeight - verticalDistance) / gravity);

            // V�locit� horizontale
            Vector3 horizontalVelocity = new Vector3(displacement.x, 0, displacement.z) / time;

            // V�locit� verticale pour atteindre la hauteur d'arc souhait�e
            float verticalVelocity = Mathf.Sqrt(2 * gravity * arcHeight);

            rb.linearVelocity = horizontalVelocity + Vector3.up * verticalVelocity;

            yield return new WaitForSeconds(timeBetweenTwoSpawns);
        }

        yield return new WaitForSeconds(0.5f);
        isComplete = true;
    }

    //private List<Vector3> Positions()
    //{
    //    List<Vector3> t = new();
    //    t.Add(new Vector3(10, -1, -7));
    //    t.Add(new Vector3(10, -1, 17));
    //    t.Add(new Vector3(-11, -1, -7));
    //    t.Add(new Vector3(-11, -1, 17));
    //    t.Add(Player.Value.transform.position);
    //    return t;
    //}

    private List<Vector3> Positions()
    {
        List<Vector3> t = new();
        t.Add(Zone1.Value.position);
        t.Add(Zone2.Value.position);
        t.Add(Zone3.Value.position);
        t.Add(Zone4.Value.position);
        t.Add(Player.Value.position); // pas besoin de .transform, c'est déjà un Transform
        return t;
    }

}

