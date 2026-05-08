using UnityEngine;

public class VeilSceneLoadScript : MonoBehaviour
{
    public PreBossUIScript bossUI;

    private void OnTriggerEnter(Collider other)
    {
        bossUI.OpenMenu();
    }
}
