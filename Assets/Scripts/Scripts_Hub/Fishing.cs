using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Fishing : MonoBehaviour
{
    private Player player = Player.Instance;

    public GameObject button;
    public GameObject qte;
    public GameObject text;
    public Animator fish;

    private float fillamount = 0;
    private int coins = 0;
    private int page = 0;
    private bool hasWin = false;

    private void Start()
    {
        button.SetActive(false);
        qte.SetActive(false);
        text.SetActive(false);    
    }

    private void Update()
    {
        if(fillamount < 1 && fillamount >= 0)
        {
            fillamount -= 0.0025f;
            qte.GetComponent<Image>().fillAmount = fillamount;
        }
        if (button.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.E))//Robin mettre code à lui là
            {
                button.SetActive(false);
                FishGame();
            }
        }

        if (Input.GetKeyDown(KeyCode.A)) //Robin mettre code à lui là
        {
            if (qte.activeSelf == true)
            {
                Debug.Log("babybel");
                fillamount += 0.1f;
                qte.GetComponent<Image>().fillAmount = fillamount;
            }
        }

        if (fillamount >= 1)
        {
            fillamount = 0;
            qte.SetActive(false);
            fish.SetBool("fishingWin", true);
            page++;
            Win();
            hasWin = true;
        }

        if (Input.GetKeyDown(KeyCode.S) && hasWin) //Robin mettre code à lui là
        {
            page++;
            Win();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
       button.SetActive(true);

    }



    //La cam bouge là mais faut demander à Tom
    void FishGame()
    {
        Player.Instance.playerInput.SwitchCurrentActionMap("UI");
        qte.SetActive (true);
        fillamount = 0;
    }

    void Win()
    {   

        if(page == 1)
        {
            text.SetActive(true);
        }

        if(page == 2)
        {
            if(coins == 0)
            {
                //changer le texte affiché
            }
            fish.SetFloat("fishGet", 1);
            fish.SetBool("fishingWin", false);
            coins++;
        }

        if(page == 3)
        {
            text.SetActive(false);
            ExitFishing();
        }
    }

    void ExitFishing()
    {
        hasWin = false;
        page = 0;
        button.SetActive(true);
        fish.SetFloat("fishGet", 0);
        Player.Instance.playerInput.SwitchCurrentActionMap("Gameplay");
        fillamount = 0;
        //redonner contrôle au joueur
    }

    private void OnTriggerExit(Collider other)
    {
        button.SetActive(false);
    }
}