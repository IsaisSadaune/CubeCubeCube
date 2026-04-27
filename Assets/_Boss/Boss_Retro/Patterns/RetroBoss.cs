using System.Collections;
using DG.Tweening;
using Unity.Behavior;
using UnityEngine;

public class RetroBoss : MonoBehaviour
{
    private static RetroBoss _instance = null;
    public static RetroBoss Instance => _instance;
    public int bonk = 0;
    public float pacManSpeed;
    public GameObject pongEndPos;
    public int pacmanMoveNbr = 5;
    private int actualMoveNbr;
    //private bool isMoving = false;

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            _instance = this;
        }
    }

    public GameObject asteroidPattern(GameObject prefab, Vector3 pos)
    {
        Instantiate(prefab, pos, prefab.transform.rotation);
        return prefab;
    }

    public void StartingPattern()
    {
        StartCoroutine(PacmanPattern());
    }
    public IEnumerator PacmanPattern()
    {
        while (actualMoveNbr < pacmanMoveNbr)
        {
            //isMoving = true;
            actualMoveNbr++;

            Vector3 targetPos = Player.Instance.transform.position;

            float dx = transform.position.x - targetPos.x;
            float dz = transform.position.z - targetPos.z;

            float durationX = Mathf.Abs(dx) / pacManSpeed;
            float durationZ = Mathf.Abs(dz) / pacManSpeed;

            if (Mathf.Abs(dx) >= Mathf.Abs(dz) && dx != 0)
            {
                transform.DOMoveX(targetPos.x, durationX).SetEase(Ease.Linear);
                yield return new WaitForSeconds(durationX);

                float newDz = transform.position.z - targetPos.z;
                float newDurationZ = Mathf.Abs(newDz) / pacManSpeed;

                transform.DOMoveZ(targetPos.z, newDurationZ).SetEase(Ease.Linear);
                yield return new WaitForSeconds(newDurationZ);
            }
            else if (dz != 0)
            {
                transform.DOMoveZ(targetPos.z, durationZ).SetEase(Ease.Linear);
                yield return new WaitForSeconds(durationZ);

                float newDx = transform.position.x - targetPos.x;
                float newDurationX = Mathf.Abs(newDx) / pacManSpeed;

                transform.DOMoveX(targetPos.x, newDurationX).SetEase(Ease.Linear);
                yield return new WaitForSeconds(newDurationX);
            }
        }

        actualMoveNbr = 0;
        //isMoving = false;
    }
}