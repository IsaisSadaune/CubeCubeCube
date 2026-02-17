using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed;
    public Player player;
    public GameObject prefabAsteroid;
    BoxCollider colliderA;
    Bounce bounce;
    Rigidbody rb;
    Vector3 dir;
    bool isDivide;
    void Start()
    {
        colliderA = GetComponent<BoxCollider>();
        StartCoroutine(enableCollider());
        bounce = GetComponent<Bounce>();
        rb = GetComponent<Rigidbody>();
        dir = player.transform.position - transform.position;
        rb.linearVelocity = transform.forward + dir * speed;  

        if(!isDivide)
            bounce.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.one);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = rb.linearVelocity.normalized * speed;
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Wall"))
        {
            bounce.enabled = true;
        }
    }

    IEnumerator enableCollider()
    {
        colliderA.enabled = false;
        yield return new WaitForSeconds(0.5f);
        colliderA.enabled = true;
    }

    #region Damage&Division

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Attack"))
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
            Explosion();
        }
    }

    void Explosion()
    {
        if(isDivide)
            Destroy(gameObject);
        else
        {
            for(int i = 0; i < 2; i++)
            {
                GameObject j = Instantiate(prefabAsteroid);
                List<Vector3> vectors = new List<Vector3>  {Vector3.right, Vector3.left, Vector3.forward, Vector3.back};
                int rdm = Random.Range(0, vectors.Count);

                j.GetComponent<Rigidbody>().linearVelocity = j.GetComponent<Rigidbody>().linearVelocity + vectors[rdm] * (speed + 2);
                j.transform.localScale /= 1.5f;
                j.GetComponent<Asteroid>().isDivide = true;
            }
            Destroy(gameObject);
        }
    }
    #endregion
}
