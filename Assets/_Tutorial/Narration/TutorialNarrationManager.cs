using UnityEngine;

public class TutorialNarrationManager : MonoBehaviour
{
    public int tutostate { get; private set; } = 0;

    private void Start()
    {
        Tuto1();
    }

    [ContextMenu("DebugProcNarraCheck")]
    public void NarraByPass() => tutostate++;

    public void Tuto1()
    {
        if (tutostate == 0)
        {
            Debug.Log("Cinématique 1 tuto");
            tutostate=1;
        }
    }

    public void Tuto2()
    {
        if (tutostate <= 1)
        {
            Debug.Log("Cinématique 2 en arriere plan");
            tutostate=2;
        }
    }

    public void Tuto3()
    {
        if (tutostate <= 2)
        {
            Debug.Log("Le joueur entre dans la salle 3");
        }
    }
    public void Tuto3CorruptionVaincue()
    {
        if (tutostate <= 2)
        {
            Debug.Log("Remerciements");
            Debug.Log("Cinématique 3 Tuto");
            tutostate=3;
        }
    }
    public void Tuto4()
    {
        if (tutostate <= 3)
        {
            Debug.Log("Le joueur entre dans la salle 4");
        }
    }
    public void Tuto4DefenseProc()
    {
        if (tutostate <= 3)
        {
            Debug.Log("Cinematique 4 Tuto");
            tutostate=4;
        }
    }

    public void Tuto5()
    {
        if (tutostate <= 4)
        {
            Debug.Log("Passage dans le couloir 5, Glitchs");
        tutostate=5;
    }
}

    public void Tuto6()
    {
        if (tutostate <= 5)
        {
            Debug.Log("Le joueur entre dans la salle 6");
        }
    }
    public void Tuto6SuperProc()
    {
        if (tutostate <= 5)
        {
            Debug.Log("Cinematique 6 Tuto");
            tutostate=6;
        }
    }
    public void Tuto7()
    {
        if (tutostate <= 6)
        {
            Debug.Log("Le joueur entre salle 8");
            Debug.Log("Boss Battle");
        }
    }

    public void Tuto8BossVaincu()
    {
        if (tutostate <= 6)
        {
            Debug.Log("BossBattu");
            Debug.Log("Cinematique 8");
            tutostate=7;
        }
    }
}
