using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollControllerVR : MonoBehaviour
{
    public Material lineMaterial;
    public List<MarionetteVisualsVR> marionetteVisuals = new List<MarionetteVisualsVR>();

    private List<LineRenderer> lines = new List<LineRenderer>();


    void Awake()
    {
        for (int i = 0; i < marionetteVisuals.Count; i++)
        {
            LineRenderer line = marionetteVisuals[i].fingerTip.gameObject.AddComponent<LineRenderer>();
            lines.Add(line);
            line.material = lineMaterial;
            line.startWidth = 0.01f;
            line.endWidth = 0.01f;
            line.startColor = Color.white;
            line.endColor = Color.white;
        }
    }


    void Update()
    {
        for (int i = 0; i < marionetteVisuals.Count; i++)
        {
            lines[i].SetPosition(0, marionetteVisuals[i].fingerTip.position);
            lines[i].SetPosition(1, marionetteVisuals[i].joint.position);
        }
    }

    public void AttachMarionetteToBone(OVRBone bone, Transform marionetteSource)
    {
        marionetteSource.SetParent(bone.Transform);
    }

    public void DetatchmarionetteFromBone(Transform marionetteSource)
    {
        marionetteSource.SetParent(null);
    }
}
