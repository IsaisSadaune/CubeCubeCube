using System.Collections;
using UnityEngine;

public class SpawnerExplo : MonoBehaviour
{
    //Note : Script à refaire au moindre bug


    [SerializeField] private Rigidbody prefabExplo;
    [SerializeField] private Transform playerPos;
    [SerializeField] private float spawnRadius = 2f; // Rayon de dispersion autour du joueur
    [SerializeField] private float arcHeight = 15f; // Hauteur de l'arc (ajustez pour plus/moins de hauteur)

    private void Start()
    {
        StartCoroutine(SpawnExplo(5));
    }

    private IEnumerator SpawnExplo(int number)
    {
        for (int i = 0; i < number; i++)
        {
            // Spawn à la position du script (transform)
            Rigidbody explo = Instantiate(prefabExplo, transform.position, Quaternion.identity);

            // Position cible avec léger offset aléatoire
            Vector3 targetPos = playerPos.position + new Vector3(
                Random.Range(-spawnRadius, spawnRadius),
                0,
                Random.Range(-spawnRadius, spawnRadius)
            );

            // Calcul de la trajectoire parabolique en cloche
            Vector3 displacement = targetPos - transform.position;
            float horizontalDistance = new Vector3(displacement.x, 0, displacement.z).magnitude;
            float verticalDistance = displacement.y;

            float gravity = Mathf.Abs(Physics.gravity.y);

            // Calcul du temps basé sur la hauteur de l'arc
            float time = Mathf.Sqrt(2 * arcHeight / gravity) + Mathf.Sqrt(2 * (arcHeight - verticalDistance) / gravity);

            // Vélocité horizontale
            Vector3 horizontalVelocity = new Vector3(displacement.x, 0, displacement.z) / time;

            // Vélocité verticale pour atteindre la hauteur d'arc souhaitée
            float verticalVelocity = Mathf.Sqrt(2 * gravity * arcHeight);

            explo.linearVelocity = horizontalVelocity + Vector3.up * verticalVelocity;

            yield return new WaitForSeconds(0.25f);
        }
    }
}