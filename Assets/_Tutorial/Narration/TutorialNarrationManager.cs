using DG.Tweening;
using MoreMountains.Feedbacks;
using System.Collections;
using UnityEngine;

public class TutorialNarrationManager : MonoBehaviour
{
    private int numberParryProc = 0;

    public int tutostate { get; private set; } = 0;
    [SerializeField] private MMF_Player cinematic1;
    [SerializeField] private MMF_Player cinematic2;
    [SerializeField] private MMF_Player cinematic3;
    [SerializeField] private MMF_Player cinematic6;
    [SerializeField] private MMF_Player cinematic8;

    [SerializeField] private HP_GlitchTuto glitchCubeDestroyed;

    [SerializeField] private RoomToLock walls3;
    [SerializeField] private MMF_Player cinematic3Finished;
    [SerializeField] private RoomToLock walls4;
    [SerializeField] private RoomToLock walls6;

    [SerializeField] private RoomToLock walls8;
    [SerializeField] private HP_GlitchTuto CubeNeedToMove;

    [SerializeField] private Transform RespawnZ6;
    [SerializeField] private RespawnBoxScript respawn;

    private void OnEnable()
    {
        glitchCubeDestroyed.GlitchDestroyed += Tuto3CorruptionVaincue;
    }


    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0f);
        Tuto1();
    }

    [ContextMenu("DebugProcNarraCheck")]
    public void NarraByPass() => tutostate++;

    public void Tuto1()
    {
        if (tutostate == 0)
        {
            Debug.Log("Cinématique 1 tuto");
            tutostate = 1;
            cinematic1.PlayFeedbacks();
        }
    }

    public void Tuto2()
    {
        if (tutostate <= 1)
        {
            Debug.Log("Cinématique 2 en arriere plan");
            tutostate = 2;
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
            walls3.EnteredInRoom();
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
            tutostate = 4;
            walls4.EnteredInRoom();
            Debug.Log("Le joueur entre dans la salle 4");
            numberParryProc = 0;
            GameManager_Offi.Instance.p.playerUsedParry += Tuto4ParryProc;
        }
    }


    private bool hasEventProc = false;
    public void Tuto4ParryProc()
    {
        numberParryProc++;

        if (tutostate <= 4 && numberParryProc >= 3 && !hasEventProc)
        {
            walls4.UnlockZone();
            hasEventProc = true;
        }
    }

    public void Tuto5()
    {
        if (tutostate <= 4)
        {
            Debug.Log("Passage dans le couloir 5, Glitchs");
            tutostate = 5;
        }
    }

    public void Tuto6()
    {
        if (tutostate <= 5)
        {
            tutostate = 6;
            Debug.Log("Le joueur entre dans la salle 6");
            GameManager_Offi.Instance.p.hps.RageBarFull += Tuto6SuperProc;
            walls6.EnteredInRoom();
            cinematic6.PlayFeedbacks();
            respawn.SetNewSpawnPoint(RespawnZ6);
        }
    }
    public void Tuto6SuperProc()
    {
        if (tutostate <= 6)
        {
            Debug.Log("Cinematique 6 Tuto");
            CubeNeedToMove.transform.DOMoveX(CubeNeedToMove.transform.position.x + 50f, 1f)

                .OnComplete(() =>
                {
                    Destroy(CubeNeedToMove.gameObject);
                    walls6.UnlockZone();
                });
        }
    }
    public void Tuto7()
    {
        if (tutostate <= 6)
        {
            tutostate = 7;
            Debug.Log("Le joueur entre salle 8");
            Debug.Log("Boss Battle");
            //walls8.EnteredInRoom();
            //Tuto8BossVaincu();
            cinematic8.PlayFeedbacks();
            Tuto8BossVaincu();
            walls8.EnteredInRoom();
            StartCoroutine(SimulateBoss());
        }
    }

    private IEnumerator SimulateBoss()
    {
        yield return new WaitForSeconds(3f);
        walls8.UnlockZone();
    }

    public void Tuto8BossVaincu()
    {
        if (tutostate <= 7)
        {
            Debug.Log("BossBattu");
            Debug.Log("Cinematique 8");
            tutostate = 8;
        }
    }
}
