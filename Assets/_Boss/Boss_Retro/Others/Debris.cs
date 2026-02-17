using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody rb;
    BoxCollider c;

    void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
        c = GetComponent<BoxCollider>();
        StartCoroutine(enableCollider());
    }
    void Update()
    {
        transform.Rotate(Vector3.one);
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

