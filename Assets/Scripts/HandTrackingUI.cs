using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandTrackingUI : MonoBehaviour
{
    public OVRHand hand;
    public OVRInputModule inputModule;

    // Start is called before the first frame update
    public void Start()
    {
        inputModule.rayTransform = hand.PointerPose;  
    }
}
