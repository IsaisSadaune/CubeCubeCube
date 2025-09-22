using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class TerrainManager : MonoBehaviour
{
    [SerializeField] private List<SlabController> terrain;


    private void Start()
    {
        DeleteTerrain();
    }
    public void DeleteTerrain()
    {
        foreach(var t in terrain)
        {
            t.Disparition();
            StartCoroutine(CooldownCreateTerrain());
        }
    }

    private IEnumerator CooldownCreateTerrain()
    {
        yield return new WaitForSeconds(3f);
        foreach(var t in terrain)
        {
            t.Apparition();
        }
    }

}
