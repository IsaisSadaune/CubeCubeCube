using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour
{

    private int gamePhase;
    public PNJ_Param talkingPNJ;
    private TextMeshProUGUI emptyText;

    void Start()
    {
        gamePhase = 0;
    }

    public bool HasRestrictedDialogues()
    {
        if (talkingPNJ.hasRestriction == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public void Condition()
    {
        if (!HasRestrictedDialogues())
        {
            ShowNonRestrictedDialogue();
        }
        else
        {
            ShowRestrictedDialogue(gamePhase);
        }
    }
    

    void ShowNonRestrictedDialogue()
    {
        //Récupérer la ligne sans rapport avec l'Histoire
    }
    void ShowRestrictedDialogue(int gamePhase)
    {
        //Récupérer les lignes selon la gamePhase
    }


    //Quand tu parles à un PNJ
    //Interact State
    //A-t-il des restrictions de Dialogues ?
    //Si non -> Phrase random
    //Si oui -> Dans quel phase du jeu sommes nous
    //Donner les lignes de dialogues correspondantes
    
    
}
