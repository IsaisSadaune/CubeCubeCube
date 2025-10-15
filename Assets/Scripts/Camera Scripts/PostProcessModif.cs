using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessModif : MonoBehaviour
{
    [SerializeField] private Volume v;
    private float speed = 10f;


    private IEnumerator test()
    {
        if (v.profile.TryGet(out LensDistortion ld))
        {
            float x = 1f;
            while (x > 0f)
            {
                ld.intensity.value = x;
                ld.scale.value = x;
                x -= 0.01f * Time.deltaTime * speed;
                yield return new WaitForEndOfFrame();
            }
        }
        StartCoroutine(test2());
    }

    private IEnumerator test2()
    {
        float x = 0f;
        if (v.profile.TryGet(out LensDistortion ld))
        {
            while (x < 1f)
            {
                ld.intensity.value = x;
                ld.scale.value = x;
                x += 0.01f * Time.deltaTime * speed;
                yield return new WaitForEndOfFrame();
            }
        }
        StartCoroutine(test());
    }

    private void Start()
    {
        StartCoroutine(test());
    }
}
