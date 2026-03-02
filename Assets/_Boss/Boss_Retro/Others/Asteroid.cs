using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = 3f;
    public Player player;
    public GameObject prefabDebris;
    BoxCollider colliderA;
    Bounce bounce;
    Rigidbody rb;
    Vector3 dir;
    Vector3 rota;
    void Start()
    {
        colliderA = GetComponent<BoxCollider>();
        colliderA.enabled = true;
        bounce = GetComponent<Bounce>();
        rb = GetComponent<Rigidbody>();
        dir = player.transform.position - transform.position;
        rb.linearVelocity = transform.forward + dir * speed;  

        bounce.enabled = false;
        rota = Random.onUnitSphere;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rota*2);
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
            for(int i = 0; i < 2; i++)
            {
                GameObject instance = Instantiate(prefabDebris, gameObject.transform.position, prefabDebris.transform.rotation);
                Vector3 randomDir = Random.onUnitSphere;
                randomDir.y = 0f;
                randomDir.Normalize();
                instance.GetComponent<Debris>().Ejection(randomDir);
            }
            Destroy(gameObject);
    }
    #endregion
}
