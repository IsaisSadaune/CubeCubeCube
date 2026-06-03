using System.Collections;
using DG.Tweening;
using MoreMountains.Feedbacks;
using UnityEngine;

public class BossTuto : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private float cubeSpeed = 10f;
    [SerializeField] private MMF_Player deathFeedbackBossTuto;
    bool pattern1 = false;
    bool pattern2 = true;
    bool feedbackPlayed = false;
    Boss_Variables variables;
    void Start()
    {
        variables = GetComponent<Boss_Variables>();
    }
    public void StartBattle()
    {
        StartCoroutine(Patterns());
    }
    private void Update()
    {
        if(variables.HP <= 0 && feedbackPlayed)
        {
            deathFeedbackBossTuto.PlayFeedbacks();
            feedbackPlayed = true;
        }
    }

    void SendCubesAway()
    {
        //Envoyez des cubes tout partout
        int directions = 15;

        for (int i = 0; i < directions; i++)
        {
            float angle = i * (360f / directions);

            Vector3 dir = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;

            GameObject cube = Instantiate(cubePrefab, transform.position, Quaternion.identity);
            cube.transform.position = new Vector3(transform.position.x, transform.position.y - 3, transform.position.z);

            cube.transform.DOMove(transform.position + dir * 50f, 3f).SetEase(Ease.Linear).OnComplete(()=> Destroy(cube));
        }
    }
    IEnumerator Patterns()
    {
        yield return new WaitForSeconds(1.5f);
        while (variables.HP > 0)
        {
            if (!pattern1)
            {
                pattern1 = true;
                for (int i = 0; i < 2; i++)
                {
                    yield return transform.DOMoveY(20f, 0.5f)
                        .SetEase(Ease.Linear)
                        .WaitForCompletion();

                    yield return transform.DOMoveY(13f, 0.2f)
                        .SetEase(Ease.Linear)
                        .WaitForCompletion();
                }
                pattern2 = false;
            }
            else if (!pattern2)
            {
                pattern2 = true;

                yield return transform.DOScale(0.75f, 0.5f)
                    .WaitForCompletion();

                yield return transform.DOScale(2f, 0.2f)
                    .WaitForCompletion();

                SendCubesAway();
                pattern1 = false;
            }

            yield return transform.DORotate(new Vector3(0f, 180f, 0f),0.5f,RotateMode.LocalAxisAdd).WaitForCompletion();
            yield return new WaitForSeconds(1f);
        }
    }
}
