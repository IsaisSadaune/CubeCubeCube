using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Player : MonoBehaviour
{
    [SerializeField] private Boss_Variables bv;
    [SerializeField] private GameObject hpPrefab;
    [SerializeField] private TextMeshProUGUI timer;
    private List<GameObject> fullHPs = new();
    private int pointeur;

    private float time;
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
    public void RemoveHP(int x)
    {
        if (pointeur >= 0)
            while (x > 0)
            {
                fullHPs[pointeur].SetActive(false);
                x--;
                pointeur--;
                if (pointeur < 0) break;
            }
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
        time = 0;
        timer.text = time.ToString();
    }
    private void Update()
    {
        if ((UnityEngine.Object)bv != null && bv.HP > 0)
        {
            time += Time.deltaTime;
            timer.text = time.ToString("f2");
        }
    }

}
