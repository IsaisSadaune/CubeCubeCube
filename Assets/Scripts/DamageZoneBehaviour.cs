using UnityEngine;
using System.Collections;

public class DamageZoneBehaviour : MonoBehaviour
{
    public float TimeActive;

    private void Start()
    {
        if(TimeActive <= 0) TimeActive = 1f;
        StartCoroutine(TimeAlive());
    }
    private IEnumerator TimeAlive()
    {
        yield return new WaitForSeconds(TimeActive);
        Destroy(gameObject);
    }
}
