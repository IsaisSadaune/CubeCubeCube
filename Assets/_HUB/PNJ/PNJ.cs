using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class PNJ : MonoBehaviour
{
    public string dialogueText;
    [SerializeField] public Sprite pnj_Sprite;
    public float delay;
    public TextMeshProUGUI emptyDialogueText;
    public TextMeshProUGUI emptyNameText;
    public bool textEnded {get; set;}
    Coroutine dialogueCoroutine;

    public void ShowText()
    {
        if(dialogueCoroutine == null)
            dialogueCoroutine = StartCoroutine(LetterByLetter());
        else
            StopCoroutine(LetterByLetter());
            dialogueCoroutine = null;
    }


    IEnumerator LetterByLetter()
    {
        emptyDialogueText.enableAutoSizing = true;
        emptyDialogueText.color = new Color(emptyDialogueText.color.r, emptyDialogueText.color.g, emptyDialogueText.color.b, 0f);
        emptyDialogueText.text = dialogueText;

        yield return null;
        yield return null;
        
        if(emptyDialogueText.fontSize > 30)
            emptyDialogueText.fontSize = 30f;
    
        float lockedFontSize = emptyDialogueText.fontSize;

        emptyDialogueText.enableAutoSizing = false;
        emptyDialogueText.fontSize = lockedFontSize;

        emptyDialogueText.color = new Color(emptyDialogueText.color.r, emptyDialogueText.color.g, emptyDialogueText.color.b, 1f);
        emptyDialogueText.text = "";

        for(int i = 0; i < dialogueText.Length; i++)
        {
            emptyDialogueText.text += dialogueText[i];
            yield return new WaitForSeconds(delay);
        }
        textEnded = true;
    }
}
