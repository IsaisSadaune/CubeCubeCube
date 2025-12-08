using UnityEngine;

public class DetectorBoss : MonoBehaviour
{
    [SerializeField] private Boss_Variables bv;


    private void OnTriggerEnter(Collider other)
    {
        if(bv.isSlimy && other.CompareTag("Ground"))
        {
            //Debug.Log("detection par boss");
            other.transform.parent.GetComponent<SlabController>().Slimed();
        }
        if(bv.isDestroying && other.CompareTag("Ground"))
        {
            //Debug.Log("detection par boss");
            other.transform.parent.GetComponent<SlabController>().Destroyed();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            other.transform.parent.GetComponent<SlabController>().StopSlimed();
        }
    }
}
