using UnityEngine;

public class DetectorBoss : MonoBehaviour
{
    [SerializeField] private Boss_Variables bv;


    private void OnTriggerEnter(Collider other)
    {
        if(bv.isHardDestroying && other.CompareTag("Ground"))
        {
            other.transform.parent.GetComponent<SlabController>().HardDisparition();
        }
        else if(bv.isDestroying && other.CompareTag("Ground"))
        {
            //Debug.Log("detection par boss");
            other.transform.parent.GetComponent<SlabController>().Destroyed();
        }
    }

}
