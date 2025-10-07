using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_Manager : MonoBehaviour
{
    public Image dialogue_Background;
    private Player player;
    public Coroutine CoroutineLetters;
    public void Awake()
    {
        player = GetComponent<Player>();
        dialogue_Background.enabled = false;
    }

    public void SetDialogue()
    {
        dialogue_Background.enabled = true;
        player.emptyText.enabled = true;
        CoroutineLetters = StartCoroutine(LetterPerLetter());
    }

    public IEnumerator LetterPerLetter()
    {
        string dialogueLine = player.dialogue_Parameters.dialogue_content[player.dialogue_Parameters.dialogue_Index];
        player.emptyText.text = ""; // Assure-toi de vider le texte au départ

        for (int i = 0; i < dialogueLine.Length; i++)
        {
            player.emptyText.text += dialogueLine[i];
            yield return new WaitForSeconds(player.timeBetweenLetter);
        }
    }
}
