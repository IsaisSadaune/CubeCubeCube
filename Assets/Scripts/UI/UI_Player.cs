using System.Collections.Generic;
using UnityEngine;

public class UI_Player : MonoBehaviour
{
    [SerializeField] private GameObject hpPrefab;
    private List<GameObject> fullHPs = new();
    private int pointeur;
    public void SetHps(int hpsMax)
    {
        for (int i = 0; i < hpsMax; i++)
        {
            GameObject g = Instantiate(hpPrefab, transform);
            fullHPs.Add(g.transform.GetChild(1).gameObject);
        }
        pointeur = hpsMax - 1;
    }

    [ContextMenu("RemoveHP")]
    public void RemoveHP()
    {
        fullHPs[pointeur].SetActive(false);
        pointeur--;
    }

    [ContextMenu("AddHP")]
    public void AddHP()
    {
        if (pointeur < fullHPs.Count - 1)
        {
            pointeur++;
            fullHPs[pointeur].SetActive(true);
        }
    }


    private void Start()
    {
        SetHps(8);
    }


}
