using UnityEngine;
using DG.Tweening;

public class EnableSeeThroughScript : MonoBehaviour
{
    private bool playerBehindBoss;
    public Transform playerPosition, cameraPosition;
    private Material _materialInstance; 
    private RaycastHit hitInfo;
    float opacityValue = 1f; 

    private void Start()
    {
        _materialInstance = GetComponent<Renderer>().material;    
    }

    private void Update()
    {
        if (Physics.Linecast(cameraPosition.position, playerPosition.position, out hitInfo))
        {
            if (hitInfo.collider.CompareTag("Boss"))
                playerBehindBoss = true;
            else
                playerBehindBoss = false;
        }

        if (playerBehindBoss) 
        {
            DOTween.To(() => opacityValue, x => opacityValue = x, 0.8f, 0.2f);
            _materialInstance.SetFloat("_BossOpacity", opacityValue); 
        }
        else
        {
            DOTween.To(() => opacityValue, x => opacityValue = x, 1, 0.2f);
            _materialInstance.SetFloat("_BossOpacity", opacityValue);
        }
    }
}
