using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandTrackingUI : MonoBehaviour
{
    /*
     * This script is used to set the input module ray transform to the hand's pointer pose for handtracked UI input
     */
    public OVRHand hand;
    public OVRInputModule inputModule;

    // Start is called before the first frame update
    public void Start()
    {
        inputModule.rayTransform = hand.PointerPose;  
    }
}
