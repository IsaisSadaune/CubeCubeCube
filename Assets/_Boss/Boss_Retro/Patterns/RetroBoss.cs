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
    public GameObject tetrisPiece(GameObject prefab, Vector3 pos)
    {
        Instantiate(prefab, new Vector3(pos.x, pos.y + 8, pos.z), prefab.transform.rotation);
        return prefab;
    }

    public GameObject asteroidPattern(GameObject prefab, Vector3 pos)
    {
        Instantiate(prefab, pos, prefab.transform.rotation);
        return prefab;
    }
}