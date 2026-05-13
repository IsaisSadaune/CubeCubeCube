using MoreMountains.Feedbacks;
using System.Collections;
using UnityEngine;

public class TutorialNarrationManager : MonoBehaviour
{


    public int tutostate { get; private set; } = 0;
    [SerializeField] private MMF_Player cinematic1;
    [SerializeField] private MMF_Player cinematic2;
    [SerializeField] private MMF_Player cinematic3;

    [SerializeField] private HP_GlitchTuto glitchCubeDestroyed;

    [SerializeField] private Tuto_Cinematic3 walls3;
    [SerializeField] private MMF_Player cinematic3Finished;
    [SerializeField] private MMF_Player cinematic5;
    [SerializeField] private MMF_Player cinematic6;

    private void OnEnable()
    {
        glitchCubeDestroyed.GlitchDestroyed += Tuto3CorruptionVaincue;
    }


    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
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
            cinematic1.PlayFeedbacks();
        }
    }

    public void Tuto2()
    {
        if (tutostate <= 1)
        {
            Debug.Log("Cinématique 2 en arriere plan");
            tutostate=2;
            cinematic2.PlayFeedbacks();
        }
    }

    public void Tuto3()
    {
        if (tutostate <= 2)
        {
            tutostate = 3;
            Debug.Log("Le joueur entre dans la salle 3");
            cinematic3.PlayFeedbacks();
            Debug.Log("fermetureSalle3");
            walls3.PlayCinematic();
        }
    }
    public void Tuto3CorruptionVaincue()
    {
        if (tutostate <= 3)
        {
            cinematic3Finished.PlayFeedbacks();
            Debug.Log("ouverture portes");
            walls3.UnlockZone();
            Debug.Log("ouverture portes");
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
