using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour
{
    public float speed = 5f;    Rigidbody rb;   Vector3 rota;    BoxCollider c;

    void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
        c = GetComponent<BoxCollider>();
        rota = Random.onUnitSphere;
        StartCoroutine(enableCollider());
        transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
    }
    void Update()
    {
        transform.Rotate(rota * 3);
    }

    public void Ejection(Vector3 dir)
    {
        rb.linearVelocity = dir.normalized * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Attack"))
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
            Player.Instance.hps.GainMP(1);
            AudioManager.Instance.PlaySound("Asteroids destroyed");
            Destroy(gameObject);
        }
    }

    IEnumerator enableCollider()
    {
        c.enabled = false;
        yield return new WaitForSeconds(0.3f);
        c.enabled = true;
    }
}

