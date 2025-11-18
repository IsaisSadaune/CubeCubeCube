using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class tmp_Test : MonoBehaviour
{
    public List<GameObject> cubes = new List<GameObject>();

    void Start()
    {
        for(int i = 0; i < gameObject.transform.childCount; i++)
        {
            for(int j = 0; i < gameObject.transform.GetChild(i).transform.childCount; j++)
            {
                cubes.Add(gameObject.transform.GetChild(i).transform.GetChild(j).transform.GetComponent<GameObject>());
            }
        }
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.Backspace))
        {
            LaunchCube();
        }
    }

    void LaunchCube()
    {
        foreach(GameObject cub in cubes)
        {
            Rigidbody rb;
            rb = cub.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.forward * 5, ForceMode.Impulse);
        }
    }
}
