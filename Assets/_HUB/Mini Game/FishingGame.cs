using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class FishingGame : MonoBehaviour
{
    MMF_Player winningGame;
    private int fishingScore;
    private int fishingMaxScore = 100;
    public GameObject fishGameCanvas;
    bool FishGameActivated = false;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("FishingSpot"))
        {
            EnterFishGame();
        }
    }
    void Start()
    {
        fishGameCanvas.SetActive(false);
    }
    void Update()
    {
        if((Input.GetKey(KeyCode.Space) || Input.GetButton("Button South")) && FishGameActivated)
        {
            fishingScore += 2;
        }

        if(fishingScore >= fishingMaxScore)
        {
            WinningGame();
        }
    }
    public void EnterFishGame()
    {
        fishGameCanvas.SetActive(true);
    }

    void WinningGame()
    {
        winningGame.PlayFeedbacks();
    }
}
