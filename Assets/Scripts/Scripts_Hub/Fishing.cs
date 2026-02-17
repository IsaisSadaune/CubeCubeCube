using UnityEngine;
using UnityEngine.UI;

public class Fishing : MonoBehaviour
{
    public GameObject button;
    public GameObject qte;
    public float fillamount = 0;

    private void Start()
    {
        button.SetActive(false);
        qte.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
       button.SetActive(true);
       Activatefish();
    }

    //Script qui permet au joueur d'activer le mini-jeu uniquement dans la zone faite pour
    void Activatefish()
    {
        if (button.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.E))//Robin mettre code à lui là
            { 
                Debug.Log("ça marche pas assez longtemps patron");
                button.SetActive (false);
                FishGame();
            }
        }
    }

    //La cam
    void FishGame()
    {
        qte.SetActive (true);
        if (Input.GetKeyDown(KeyCode.A)) //Robin mettre code à lui là
        {
            fillamount += 2f;
        }

        qte.GetComponent<Image>().fillAmount = fillamount;
    }

    private void OnTriggerExit(Collider other)
    {
        button.SetActive(false);
    }

}
