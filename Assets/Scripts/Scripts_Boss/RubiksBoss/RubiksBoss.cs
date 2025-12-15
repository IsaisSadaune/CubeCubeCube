using System.Collections.Generic;
using UnityEngine;

public class RubiksBoss : MonoBehaviour
{
    public List<GameObject> cubes = new List<GameObject>();

    static RubiksBoss _instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        
        for(int i =0; i < transform.childCount; i++)
        {
            cubes.Add(transform.GetChild(i).gameObject);
        }
    }

}
