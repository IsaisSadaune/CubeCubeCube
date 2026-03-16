using UnityEngine;
using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using TMPro;
using UnityEngine.UIElements.Experimental;
using System.Collections;
public class UpdateHUB : MonoBehaviour
{
    HubManager hubManager;
    public GameObject[] hubPrefabs;
    public int hubPhase = 0;
    public MMF_Player updateFeedback;
    public MMProgressBar updateBar;
    public TextMeshProUGUI updateText;
    public GameObject updateCanvas;
    private int n;
    public float valueBar;
    bool isUpdating;
    Coroutine updateCoroutine;

    void Start()
    {
        hubManager = GetComponent<HubManager>();
        foreach(GameObject g in hubPrefabs)
        {
            g.SetActive(false);
        }
        UpdateHub();
    }

    void Update()
    {
        if(isUpdating && updateCoroutine ==null)
        {
            updateCoroutine = StartCoroutine(Updating());
        }
        else if(!isUpdating)
        {
            StopCoroutine(Updating());
            updateCoroutine = null;
            updateCanvas.SetActive(false);
        }
    }
    //Lancer la fonction au moment de Load la scène HUB 
    public void UpdateHub()
    {
        switch(hubPhase)
        {
            case 0 :
                if(!hubPrefabs[hubPhase].activeSelf)
                    hubPrefabs[hubPhase].SetActive(true);
            break;
            case 1 :
                LaunchUpdateFeedbacks();
                if(!hubPrefabs[hubPhase].activeSelf)
                    hubPrefabs[hubPhase].SetActive(true);
            break;
            case 2 :
                LaunchUpdateFeedbacks();
                if(!hubPrefabs[hubPhase].activeSelf)
                    hubPrefabs[hubPhase].SetActive(true);
            break;
        }
    }

    void LaunchUpdateFeedbacks()
    {
        SetUpdateText();
        isUpdating = true;
        updateFeedback.PlayFeedbacks();
    }

    void SetUpdateText()
    {
        updateText.text = "Initialisation de la mise à jour 0." + hubPhase.ToString() + ".0" + n;
        n++;
    }

    IEnumerator Updating()
    {
        int speed = 1;
        while(isUpdating)
        {
            if(speed >= 4)
            {
                isUpdating = false;
            }
            yield return new WaitForSeconds(0.1f);
            if(valueBar >= 100)
            {
                valueBar = 0;
                updateBar.UpdateBar(valueBar, 0f, 100f);
                speed++;
            }
            else
            {
                valueBar += 2f * speed;
                updateBar.UpdateBar(valueBar, 0f, 100f);
            }
        }
        
    }
}
