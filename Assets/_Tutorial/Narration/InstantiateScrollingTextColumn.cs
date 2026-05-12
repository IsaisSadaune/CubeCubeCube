using System.Collections;
using UnityEngine;

public class InstantiateScrollingTextColumn : MonoBehaviour
{
    [SerializeField] private GameObject textColumn1, textColumn2, textColumn3, textColumn4;
    [SerializeField] private Transform instPosColumn1, instPosColumn2, instPosColumn3, instPosColumn4;
    public bool enableInstantiation;

    private void Start()
    {
        StartCoroutine(InstantatiateRandomColumn());
        enableInstantiation = true;
    }

    IEnumerator InstantatiateRandomColumn()
    {
        yield return new WaitUntil(() => enableInstantiation);

        switch (Random.Range(1, 5))
        {
            case 1:
                Instantiate(textColumn1, instPosColumn1.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(textColumn2, instPosColumn2.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(textColumn3, instPosColumn3.position, Quaternion.identity);
                break;
            case 4:
                Instantiate(textColumn4, instPosColumn4.position, Quaternion.identity);
                break;

            default:
                break;
        }

        yield return new WaitForSeconds(Random.Range(1f, 1.75f));

        StartCoroutine(InstantatiateRandomColumn());
    }
}
