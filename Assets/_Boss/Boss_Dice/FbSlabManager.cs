using MoreMountains.Feedbacks;
using UnityEngine;

public class FbSlabManager : MonoBehaviour
{
    [SerializeField] MMF_Player slabColorChangePattern3;
    [SerializeField] MMF_Player slabColorChangePattern2_1;
    [SerializeField] MMF_Player slabColorChangePattern2_2;
    [SerializeField] MMF_Player slabToGround;
    [SerializeField] MMF_Player slabComeBack;

    public void ChangeColorSlab() => slabColorChangePattern3.PlayFeedbacks();
    public void ChangeColorSlab2_1() => slabColorChangePattern2_1.PlayFeedbacks();
    public void ChangeColorSlab2_2() => slabColorChangePattern2_2.PlayFeedbacks();

    public void SlabToGround() => slabToGround.PlayFeedbacks();
    public void SlabComeBack() => slabComeBack.PlayFeedbacks();
}
