using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneRecognizer : MonoBehaviour
{
    private OVRSkeleton skeleton;
    public List<OVRBone> bones = new List<OVRBone>();
    public List<Vector3> bonePositions = new List<Vector3>();

    
    void Awake()
    {
        skeleton = GetComponentInChildren<OVRSkeleton>();
        bones = new List<OVRBone>(skeleton.Bones);
    }

    
    void Update()
    {
        
    }


    /// <summary>
    /// Get the finger tip positions 
    /// attaching the marionette fingertip transform to 
    /// the bone position
    /// </summary>
    public void GetBonePosition()
    {
        foreach (var bone in bones)
        {

            //if(bone.Id == OVRSkeleton.BoneId.Hand_IndexTip)
            //{
            //    bonePositions.Add(skeleton.transform.InverseTransformPoint(bone.Transform.position));
            //}

            switch (bone.Id)
            {
                case OVRSkeleton.BoneId.Hand_IndexTip:
                    bonePositions.Add(skeleton.transform.InverseTransformPoint(bone.Transform.position));
                    break;
                case OVRSkeleton.BoneId.Hand_MiddleTip:
                    bonePositions.Add(skeleton.transform.InverseTransformPoint(bone.Transform.position));
                    break;
                case OVRSkeleton.BoneId.Hand_PinkyTip:
                    bonePositions.Add(skeleton.transform.InverseTransformPoint(bone.Transform.position));
                    break;
                case OVRSkeleton.BoneId.Hand_RingTip:
                    bonePositions.Add(skeleton.transform.InverseTransformPoint(bone.Transform.position));
                    break;
                case OVRSkeleton.BoneId.Hand_Thumb3:
                    bonePositions.Add(skeleton.transform.InverseTransformPoint(bone.Transform.position));
                    break;

            }

            // Checking to make sure that the boneID in bone, is the same as the
            // bone we've selected in our MarionetteVisuals in the RagdollController
            for(int i = 0; i < bonePositions.Count; i++)
            {
                if(bone.Id == RagdollController.instance.marionetteVisuals[i].boneID)
                {
                    RagdollController.instance.AttachMarionetteToBone(bone, RagdollController.instance.marionetteVisuals[i].fingerTip);
                }
            }
        }
    }
}
