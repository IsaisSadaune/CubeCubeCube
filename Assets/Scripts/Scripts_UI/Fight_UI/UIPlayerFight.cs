using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayerFight : MonoBehaviour
{
    [SerializeField] private int hpAmount;
    [SerializeField] GameObject hpPrefab;
    private List<GameObject> fullHPs = new();
    private int pointeur;
    private UIHeartLossFeedback heartLossScript;

    private void Start()
    {
        SetMaxHps();
    }

    public void SetMaxHps()
    {
        for (int i = 0; i < hpAmount; i++)
        {
            GameObject g = Instantiate(hpPrefab, transform);
            fullHPs.Add(g.transform.GetChild(1).gameObject);
        }
        pointeur = hpAmount - 1;
    }
    
    public void RemoveHP(int x)
    {
        if (pointeur >= 0)
            while (x > 0)
            {
                heartLossScript = fullHPs[pointeur].GetComponent<UIHeartLossFeedback>();
                heartLossScript.TriggerHPLossFeedback();
                x--;
                pointeur--;
                if (pointeur < 0) break;
            }
    }

    public void AddHP()
    {
        if (pointeur < fullHPs.Count - 1)
        {
            pointeur++;
            fullHPs[pointeur].SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            RemoveHP(1); 
        if (Input.GetKeyDown(KeyCode.L))
            AddHP();
    }
}
