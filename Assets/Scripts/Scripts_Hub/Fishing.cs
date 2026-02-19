using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Fishing : MonoBehaviour
{
    public GameObject button;
    public GameObject qte;
    public GameObject text;
    public Animator fish;

    private float fillamount = 0;
    private int coins = 0;
    private int page = 0;

    private void Start()
    {
        button.SetActive(false);
        qte.SetActive(false);
        text.SetActive(false);    
    }

    private void OnTriggerEnter(Collider other)
    {
       button.SetActive(true);
       ActivateFishing();
    }

    //Script qui permet au joueur d'activer le mini-jeu uniquement dans la zone faite pour
    void ActivateFishing()
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

    //La cam bouge là mais faut demander à Tom
    void FishGame()
    {
        qte.SetActive (true);
        //le joueur ne peut plus bouger à partir de maintenant
        if (Input.GetKeyDown(KeyCode.A)) //Robin mettre code à lui là
        {
            fillamount += 0.2f;
        }

        qte.GetComponent<Image>().fillAmount = fillamount;

        if(fillamount >= 2)
        {
            Win();
        }
    }

    void Win()
    {
        qte.SetActive(false);
        fish.SetBool("fishingWin", true);

        if(Input.GetKeyDown(KeyCode.S)) //Robin mettre code à lui là
        {
            page ++;
        }

        if(page  == 1)
        {
            text.SetActive(true);
            //changer le texte affiché
        }

        if(page == 2 && coins == 0)
        {
            //changer le texte affiché
        }

        else
        {
            fish.SetFloat("fishGet",2);
            text.SetActive(false);
            ExitFishing();
        }
    }

    void ExitFishing()
    {
        page = 0;
        button.SetActive(true);
        //redonner contrôle au joueur
    }

    private void OnTriggerExit(Collider other)
    {
        button.SetActive(false);
    }
}