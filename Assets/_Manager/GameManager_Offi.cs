using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_Offi : MonoBehaviour
{
    private static GameManager_Offi instance = null;
    public static GameManager_Offi Instance => instance;
    public bool hubCinematicPlayed { get; set; }
    public bool bossCinematicPlayed { get; set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

        Screen.SetResolution(1440, 1080, FullScreenMode.FullScreenWindow);
        loadingCube = GetComponentInChildren<LoadingCubeAnim>();

        LoadingScreen = transform.GetChild(0).gameObject;
        LoadingScreen.SetActive(false);
    }



    public Player p { get; private set; }
    public void SetPlayer(Player p) => this.p = p;

    public bool fight { get; private set; } = false;

    #region score
    public float recordTempsBoss1 { get; private set; } = 99999;
    public float recordTempsBoss2 { get; private set; } = 99999;
    public float recordTempsBoss3 { get; private set; } = 99999;
    public char rankBoss1 { get; private set; } = 'D';
    public char rankBoss2 { get; private set; } = 'D';
    public char rankBoss3 { get; private set; } = 'D';
    public GameProgression act { get; private set; } = 0;

    public float GetPBBoss(int number)
    {
        switch (number)
        {
            case 1: return recordTempsBoss1;
            case 2: return recordTempsBoss2;
            case 3: return recordTempsBoss3;
            default:
                Debug.Log("ERREUR");
                return 999999999;
        }
    }



    // /!\ Fonction � appeler quand le boss est vaincu /!\
    public void UpdateScore(int bossNumber, float time, char rank)
    {
        //Debug.Log("UpdateScore");
        switch (bossNumber)
        {
            case 1:
                Boss1UpdateScores(time, rank);
                break;
            case 2:
                Boss2UpdateScores(time, rank);
                break;
            case 3:
                Boss3UpdateScores(time, rank);
                break;
            default:
                Debug.LogWarning("ERREUR, LE BOSS NUMERO " + bossNumber + " N'EXISTE PAS !");
                break;
        }

#if UNITY_EDITOR
        SaveStats();
#endif
    }

    private void Boss1UpdateScores(float time, char rank)
    {
        if (time < recordTempsBoss1)
            recordTempsBoss1 = time;
        rankBoss1 = BestRank(rankBoss1, rank);

        if (act == GameProgression.TutoFinished)
        {
            act++;
            hubCinematicPlayed = false;
            bossCinematicPlayed = false;
        }

    }
    private void Boss2UpdateScores(float time, char rank)
    {
        if (time < recordTempsBoss2)
            recordTempsBoss2 = time;
        rankBoss2 = BestRank(rankBoss2, rank);
        if (act == GameProgression.Boss1Beaten)
        {
            act++;
            hubCinematicPlayed = false;
        }
    }
    private void Boss3UpdateScores(float time, char rank)
    {
        if (time < recordTempsBoss3)
            recordTempsBoss3 = time;
        rankBoss3 = BestRank(rankBoss3, rank);
        if (act == GameProgression.Boss2Beaten)
        {
            act++;
            hubCinematicPlayed = false;
        }
    }

    public void TutoFinished()
    {
        if (act == 0)
        {
            act = GameProgression.TutoFinished;
            hubCinematicPlayed = false;
        }
#if UNITY_EDITOR
        SaveStats();
#endif
    }

    private char BestRank(char a, char b)
    {
        if (a != 'A' && a != 'B' && a != 'C' && a != 'D' && a != 'S')
        {
            Debug.LogWarning("ERREUR, LE RANG " + a + "EST INVALIDE");
            return 'D';
        }
        if (b != 'A' && b != 'B' && b != 'C' && b != 'D' && b != 'S')
        {
            Debug.LogWarning("ERREUR, LE RANG " + b + "EST INVALIDE");
            return 'D';
        }

        if (a == 'S' || b == 'S')
            return 'S';
        if (a > b)
            return b;
        return a;
    }
    #endregion



    #region stats
    //Statistiques
    public int NbParry { get; private set; } = 0;
    public int NbHeal { get; private set; } = 0;
    public float RagePerdue { get; private set; } = 0f;
    public float Temps { get; private set; } = 0f;

    /// <summary>
    /// Appeler cette fonction pour remettre les stats du joueur � 0 (� activer avant chaque debut de combat)
    /// </summary>
    public void ResetStatsCombat()
    {
        NbParry = 0;
        NbHeal = 0;
        Temps = 0f;
        RagePerdue = 0f;
        fight = true;
    }

    public void IncreaseTimer()
    {
        if (Time.timeScale != 0f && fight)
        {
            Temps += Time.deltaTime;
        }
    }
    public void AddStatParry()
    {
        if (fight)
            NbParry++;
    }
    public void AddHeal()
    {
        if (fight)
            NbHeal++;
    }
    public void AddRagePerdue()
    {
        if (fight)
            RagePerdue++;
    }
    public void EndBattle()
    {
        if (fight)
        {
            Debug.Log("desactivate");
            fight = false;
            p.hitbox.enabled = false;
        }
    }

    #endregion

    private void Start()
    {
        Debug.Log("Start temporaire pour reset stats, � placer ailleurs");
        ResetStatsCombat();


        //SaveStats();
        LoadStats();
    }

    public void SaveStats()
    {
        string pb1 = recordTempsBoss1.ToString();
        string pb2 = recordTempsBoss2.ToString();
        string pb3 = recordTempsBoss3.ToString();
        string rank1 = rankBoss1.ToString();
        string rank2 = rankBoss2.ToString();
        string rank3 = rankBoss3.ToString();
        string progression = act.ToString();

        string globalSfxVolume = AudioManager.Instance.globalSfxVolume.ToString();
        string globalMusicVolume = AudioManager.Instance.globalSfxVolume.ToString();


        string saveString = string.Join("\n", pb1, pb2, pb3, rank1, rank2, rank3, progression, globalSfxVolume, globalMusicVolume);
        File.WriteAllText(Application.dataPath + "/save.txt", saveString);
    }

    public void ResetProgression()
    {
        recordTempsBoss1 = 99999;
        recordTempsBoss2 = 99999;
        recordTempsBoss3 = 99999;
        rankBoss1 = 'D';
        rankBoss2 = 'D';
        rankBoss3 = 'D';
        act = 0;
    }

    public void ResetSave()
    {
        ResetProgression();
        SaveStats();
    }


    private void LoadStats()
    {
        string file = File.ReadAllText(Application.dataPath + "/save.txt");

        string[] contents = file.Split("\n");
        recordTempsBoss1 = float.Parse(contents[0]);
        recordTempsBoss2 = float.Parse(contents[1]);
        recordTempsBoss3 = float.Parse(contents[2]);

        rankBoss1 = char.Parse(contents[3]);
        rankBoss2 = char.Parse(contents[4]);
        rankBoss3 = char.Parse(contents[5]);
        act = (GameProgression)System.Enum.Parse(typeof(GameProgression), contents[6]);

        if(float.Parse(contents[7]) != 0)
            AudioManager.Instance.globalSfxVolume = float.Parse(contents[7]);

        if(float.Parse(contents[8]) != 0)
            AudioManager.Instance.globalMusicVolume = float.Parse(contents[8]);
    }
    #region SceneLoading

    private GameObject LoadingScreen;
    private LoadingCubeAnim loadingCube;
    Coroutine loadScene;
    public void LoadCoroutineScene(string sceneName)
    {
        loadScene = StartCoroutine(LoadSceneAsync(sceneName));
    }
    public IEnumerator LoadSceneAsync(string sceneName)
    {
        //Remettre la cinématique longue lorsque le joueur revient au Hub
        if (sceneName != SceneManager.GetActiveScene().name)
        {
            bossCinematicPlayed = false;
        }

        AudioManager.Instance.musicSource.Stop();
        LoadingScreen.SetActive(true);

        yield return new WaitForSeconds(2f);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        yield return new WaitForSeconds(0.5f);
        AudioManager.Instance.PlayMusic(sceneName);
        LoadingScreen.GetComponentInChildren<Canvas>().worldCamera = Camera.main;
        if(sceneName == "MainMenuScene")
        {
            LoadingScreen.GetComponentInChildren<Canvas>().planeDistance = 10f;
        }
        else
        {
            LoadingScreen.GetComponentInChildren<Canvas>().planeDistance = -42f;
        }
        LoadingScreen.SetActive(false);
        loadScene = null;
    }
    #endregion
}


public enum GameProgression
{
    Start = 0, //Lancement du jeu -> Finir Tuto
    TutoFinished = 1, // Finir Tuto -> Battre Boss1
    Boss1Beaten = 2, // Finir Boss1 -> Finir Boss2
    Boss2Beaten = 3, // Zone de fin
    Boss3Beaten = 4, //Inutilis�
}