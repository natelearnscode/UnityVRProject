using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SetPointerToFinger : MonoBehaviour
{
    /*
     * This script is used to set the ray transform of the input module to a finger for UI input.
     * 
     */
    public GameObject hand;
    public OVRGazePointer gazePointer;
    // Start is called before the first frame update
    void Start()
    {
        OVRInputModule ovrInputModule = this.GetComponent<OVRInputModule>();
        OVRSkeleton skeleton = hand.GetComponentInChildren<OVRSkeleton>();
        // loop through skeleton of bones to find specific bone
        foreach (OVRBone bone in skeleton.Bones)
        {
            // shoot ray for each finger tip
            if (bone.Id == OVRSkeleton.BoneId.Hand_IndexTip)
            {
                ovrInputModule.rayTransform = bone.Transform;
            }

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
