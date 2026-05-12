using System.Collections;
using UnityEngine;

public class InstantiateScrollingTextColumn : MonoBehaviour
{
    [SerializeField] private GameObject textColumn1, textColumn2, textColumn3, textColumn4;
    [SerializeField] private Transform instPosColumn1, instPosColumn2, instPosColumn3, instPosColumn4;
    public bool enableInstantiation;

    private void Start()
    {
        InstantatiateRandomColumn();
    }

    IEnumerator InstantatiateRandomColumn()
    {
        yield return new WaitUntil(() => enableInstantiation);

        Debug.Log("Try Instantiate");

        switch (Random.Range(1, 4))
        {
            case 1:
                Instantiate(textColumn1, instPosColumn1);
                break;
            case 2:
                Instantiate(textColumn2, instPosColumn2);
                break;
            case 3:
                Instantiate(textColumn3, instPosColumn3);
                break;
            case 4:
                Instantiate(textColumn4, instPosColumn4);
                break;
        }

        yield return new WaitForSeconds(Random.Range(0.5f, 1.25f));

        StartCoroutine(InstantatiateRandomColumn());
    }
}
