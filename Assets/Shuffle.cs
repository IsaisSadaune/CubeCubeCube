using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuffle : MonoBehaviour
{
    [SerializeField]
    List<GameObject> Pivots = new List<GameObject>();

    [SerializeField]
    int rotations = 15;

    private void Start()
    {
        StartCoroutine(ShuffleCube());
    }

    IEnumerator ShuffleCube()
    {
        rotations--;
        Pivots[Random.Range(0, Pivots.Count - 1)].GetComponent<AxesPivot>().Rotate(0.025f);

        yield return new WaitForSeconds(0.05f);
        
        if (rotations > 0)
        {
            StartCoroutine(ShuffleCube());
        }
    }
}
