using System.Collections;
using DG.Tweening;
using Unity.Behavior;
using Unity.VisualScripting;
using UnityEngine;

public class RetroBoss : MonoBehaviour
{
    private static RetroBoss _instance = null;
    public static RetroBoss Instance => _instance;
    public int bonk {get; set;}
    public GameObject pongEndPos {get; set;}

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
        Instantiate(prefab, new Vector3(pos.x, pos.y + 16, pos.z), prefab.transform.rotation);
        return prefab;
    }

    public GameObject asteroidPattern(GameObject prefab, Vector3 pos)
    {
        Instantiate(prefab, pos, prefab.transform.rotation);
        return prefab;
    }

    public GameObject bombPattern(GameObject prefab)
    {
        GameObject bomb = Instantiate(prefab, transform.position, prefab.transform.rotation);
        return bomb;
    }
    public void Explosion(GameObject prefab)
    {
        Instantiate(prefab, new Vector3(transform.position.x, 0.75f, transform.position.z), prefab.transform.rotation);
    }

    public GameObject Hadouken(GameObject prefab, float speed)
    {
        GameObject fireball = Instantiate(prefab, transform.position, prefab.transform.rotation);

        Vector3 dir = (Player.Instance.transform.position - fireball.transform.position).normalized;

        fireball.GetComponent<Rigidbody>().AddForce(dir * speed, ForceMode.Impulse);
        return fireball;
    }
}