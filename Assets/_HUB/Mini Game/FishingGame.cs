using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class FishingGame : MonoBehaviour
{
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
        if(Input.GetKey(KeyCode.Space) || Input.GetButton("")&& FishGameActivated)
        {
            fishingScore += 2;
        }


    }
    public void EnterFishGame()
    {
        fishGameCanvas.SetActive(true);
    }
}
