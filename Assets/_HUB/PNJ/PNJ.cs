using System.Collections;
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
    public void ShowText()
    {
        StartCoroutine(LetterByLetter());
    }

    IEnumerator LetterByLetter()
    {
        for(int i = 0; i < dialogueText.Length; i++)
        {
            emptyDialogueText.text += dialogueText[i];
            yield return new WaitForSeconds(delay);
        }
        textEnded = true;
    }
}
