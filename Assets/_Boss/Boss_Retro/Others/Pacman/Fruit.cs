using System;
using Unity.VisualScripting;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Boss"))
        {
            gameObject.SetActive(false);
        }
    }
}
