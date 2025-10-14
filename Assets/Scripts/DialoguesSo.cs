using UnityEngine;

[CreateAssetMenu(fileName = "DialoguePhase", menuName = "Dialogues/Phase")]
public class DialoguesSo : ScriptableObject
{
    public string phaseName;
    public Dialogues_Parameters[] parameters;
}
