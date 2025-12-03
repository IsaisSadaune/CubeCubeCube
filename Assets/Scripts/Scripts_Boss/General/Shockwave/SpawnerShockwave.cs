using UnityEngine;

public class SpawnerShockwave : MonoBehaviour
{
    [SerializeField] private GameObject prefabXplus;
    [SerializeField] private GameObject prefabXminus;
    [SerializeField] private GameObject prefabZPlus;
    [SerializeField] private GameObject prefabZMinus;

    [ContextMenu("Spawn Shockwaves")]
    public void SpawnPrefabs()
    {
        Instantiate(prefabXplus, transform.position, prefabXplus.transform.rotation);
        Instantiate(prefabXminus, transform.position, prefabXminus.transform.rotation);
        Instantiate(prefabZMinus, transform.position, prefabZMinus.transform.rotation);
        Instantiate(prefabZPlus, transform.position, prefabZPlus.transform.rotation);
    }
}
