using UnityEngine;

public class GameManager_Offi : MonoBehaviour
{
    private static GameManager_Offi instance = null;
    public static GameManager_Offi Instance => instance;

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
    }




    public Player p { get; private set; }
    public void SetPlayer(Player p) => this.p = p;

    #region score
    public float recordTempsBoss1 { get; private set; }
    public float recordTempsBoss2 { get; private set; }
    public float recordTempsBoss3 { get; private set; }
    public char rankBoss1 { get; private set; }
    public char rankBoss2 { get; private set; }
    public char rankBoss3 { get; private set; }
    public GameProgression act { get; private set; } = 0;



    // /!\ Fonction à appeler quand le boss est vaincu /!\
    public void UpdateScore(int bossNumber, float time, char rank)
    {
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
    }

    private void Boss1UpdateScores(float time, char rank)
    {
        if (time < recordTempsBoss1)
            recordTempsBoss1 = time;
        rankBoss1 = BestRank(rankBoss1, rank);

        if (act == 0)
            act++;
    }
    private void Boss2UpdateScores(float time, char rank)
    {
        if (time < recordTempsBoss2)
            recordTempsBoss2 = time;
        rankBoss2 = BestRank(rankBoss2, rank);
        if (act == GameProgression.Boss1Beaten)
            act++;
    }
    private void Boss3UpdateScores(float time, char rank)
    {
        if (time < recordTempsBoss3)
            recordTempsBoss3 = time;
        rankBoss3 = BestRank(rankBoss3, rank);
        if (act == GameProgression.Boss2Beaten)
            act++;
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
        if (a < b)
            return b;
        return a;
    }
    #endregion

    public enum GameProgression
    {
        Start = 0,
        Boss1Beaten = 1,
        Boss2Beaten = 2,
        Boss3Beaten = 3,
    }

    #region stats
    //Statistiques
    public int NbParry { get; private set; } = 0;
    public int NbHeal { get; private set; } = 0;
    public float RagePerdue { get; private set; } = 0f;
    public float Temps { get; private set; } = 0f;

    /// <summary>
    /// Appeler cette fonction pour remettre les stats du joueur à 0 (à activer avant chaque debut de combat)
    /// </summary>
    public void ResetStats()
    {
        NbParry = 0;
        NbHeal = 0;
        Temps = 0f;
        RagePerdue = 0f;
    }



    public void IncreaseTimer()
    {
        if (Time.timeScale != 0f)
        {
            Temps += Time.deltaTime;
        }
    }
    public void AddStatParry()
    {
        NbParry++;
    }
    public void AddHeal()
    {
        NbHeal++;
    }
    public void AddRagePerdue()
    {
        RagePerdue++;
    }

    #endregion


}
