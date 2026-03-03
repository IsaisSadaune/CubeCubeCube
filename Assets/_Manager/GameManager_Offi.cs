using DG.Tweening.Core.Easing;
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


    public float recordBoss1 { get; private set; }
    public float recordBoss2 { get; private set; }
    public float recordBoss3 { get; private set; }
    public char rankBoss1 { get; private set; }
    public char rankBoss2 { get; private set; }
    public char rankBoss3 { get; private set; }
    public GameProgression act { get; private set; } = 0;



    // /!\ Fonction à appeler quand le boss est vaincu /!\
    public void UpdateScore(int bossNumber, float time, char rank)
    {
        switch(bossNumber)
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
        if(time < recordBoss1)
            recordBoss1 = time;
        rankBoss1 = BestRank(rankBoss1, rank);

        if (act == 0) 
            act++;
    }
    private void Boss2UpdateScores(float time, char rank)
    {
        if(time < recordBoss2)
            recordBoss2 = time;
        rankBoss2 = BestRank(rankBoss2, rank);
        if (act == GameProgression.Boss1Beaten)
            act++;
    }
    private void Boss3UpdateScores(float time, char rank)
    {
        if(time < recordBoss3)
            recordBoss3 = time;
        rankBoss3 = BestRank(rankBoss3, rank);
        if (act == GameProgression.Boss2Beaten)
            act++;
    }

    private char BestRank(char a, char b)
    {
        if(a != 'A' && a != 'B' && a != 'C' && a != 'D' && a != 'S')
        {
            Debug.LogWarning("ERREUR, LE RANG " + a + "EST INVALIDE");
            return 'D';
        }
        if(b != 'A' && b != 'B' && b != 'C' && b != 'D' && b != 'S')
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

    public enum GameProgression
    {
        Start = 0,
        Boss1Beaten = 1,
        Boss2Beaten = 2,
        Boss3Beaten = 3,
    }
}
