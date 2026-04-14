using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuTextScript : MonoBehaviour
{
    [SerializeField] private List<string> replacementsTexts; 
    private TMP_Text text;

    private void Start()
    {
        text = GetComponent<TMP_Text>();
        ChangeMainMenuText();
    }

    void ChangeMainMenuText()
    {
        string ReplacementTextSelected = replacementsTexts[Random.Range(0, replacementsTexts.Count)];
        text.SetText(ReplacementTextSelected);
    }
}
