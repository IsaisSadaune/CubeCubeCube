using System.Collections;
using DG.Tweening;
using Unity.Behavior;
using UnityEngine;

public class RetroBoss : MonoBehaviour
{
    private static RetroBoss _instance = null;
    public static RetroBoss Instance => _instance;
    public int bonk = 0;
    public GameObject pongEndPos;
    public int pacmanMoveNbr = 5;
    private int actualMoveNbr;
    private bool isMoving = false;

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
            isMoving = true;
            actualMoveNbr++;

            float dx = transform.position.x - Player.Instance.transform.position.x;
            float dz = transform.position.z - Player.Instance.transform.position.z;

            float durationX = Mathf.Abs(dx) / 20f;
            float durationZ = Mathf.Abs(dz) / 20f;

            if (Mathf.Abs(dx) <= Mathf.Abs(dz) && dx != 0)
            {
                transform.DOMoveX(Player.Instance.transform.position.x, durationX).SetEase(Ease.Linear);
                yield return new WaitForSeconds(durationX);
                transform.DOMoveZ(Player.Instance.transform.position.z, durationZ).SetEase(Ease.Linear);
                yield return new WaitForSeconds(durationZ);
            }
            else if (dz != 0)
            {
                transform.DOMoveZ(Player.Instance.transform.position.z, durationZ).SetEase(Ease.Linear);
                yield return new WaitForSeconds(durationZ);
                transform.DOMoveX(Player.Instance.transform.position.x, durationX).SetEase(Ease.Linear);
                yield return new WaitForSeconds(durationX);
            }
        }
        actualMoveNbr = 0;
        isMoving = false;
    }
}