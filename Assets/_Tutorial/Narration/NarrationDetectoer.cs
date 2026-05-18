using UnityEngine;

public class NarrationDetectoer : MonoBehaviour
{
    [SerializeField] private TutorialNarrationManager narrationmanager;
    [SerializeField] private int cinematicCheckNumber;

    private void ProcNarration()
    {
        switch (cinematicCheckNumber)
        {
            case 0:
                narrationmanager.Tuto1();
                break;
            case 1:
                narrationmanager.Tuto2();
                break;
            case 2:
                narrationmanager.Tuto3();
                break;
            case 3:
                narrationmanager.Tuto4();
                break;
            case 4:
                narrationmanager.Tuto5();
                break;
            case 5:
                narrationmanager.Tuto6();
                break;
            case 6:
                narrationmanager.Tuto7();
                break;
            default:
                Debug.Log("pas vaide");
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            ProcNarration();
    }
}
