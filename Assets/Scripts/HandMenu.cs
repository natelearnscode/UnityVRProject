using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMenu : MonoBehaviour
{
    public Transform headsetTransform;
    public GameObject middleFingerMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //using dot product of the headset's forward and hand's up vector we can determine if palm of hand is facing the user
        if(Vector3.Dot(headsetTransform.forward, -this.transform.up) < 0)
        {
            Debug.Log("facing head");
            middleFingerMenu.GetComponent<MeshRenderer>().enabled = true;
            OVRHand hand = GetComponent<OVRHand>();
            OVRSkeleton skeleton = this.GetComponentInChildren<OVRSkeleton>();

            //loop through skeleton of bones to find specific bone
            foreach (OVRBone bone in skeleton.Bones)
            {
                //middle finger
                if (bone.Id == OVRSkeleton.BoneId.Hand_Middle3)
                {
                    Vector3 newMenuPos = bone.Transform.position + (bone.Transform.right * 0.05f);
                    middleFingerMenu.transform.position = newMenuPos;
                    break;
                }
            }
        }
        else
        {
            middleFingerMenu.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
