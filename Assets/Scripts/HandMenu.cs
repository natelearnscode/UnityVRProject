using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMenu : MonoBehaviour
{
    public Transform headsetTransform;
    public GameObject middleFingerMenu;

    public Texture2D wallTexture;

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
            //Debug.Log("facing head");

            /* show finger menu options */

            middleFingerMenu.GetComponent<Canvas>().enabled = true;
            OVRHand hand = this.GetComponentInChildren<OVRHand>();
            OVRSkeleton skeleton = this.GetComponentInChildren<OVRSkeleton>();
            // loop through skeleton of bones to find specific bone and display menu
            foreach (OVRBone bone in skeleton.Bones)
            {
                //middle finger
                if (bone.Id == OVRSkeleton.BoneId.Hand_Middle3)
                {
                    Vector3 newMenuPos = bone.Transform.position + (bone.Transform.right * 0.05f);
                    middleFingerMenu.transform.position = newMenuPos;

                    //rotate to face head
                    Vector3 targetDirection = middleFingerMenu.transform.position - headsetTransform.position;
                    middleFingerMenu.transform.rotation = Quaternion.LookRotation(targetDirection);
                    break;
                }
            }

            /* check if any fingers are being pinched and open menu */

            if(hand.GetFingerIsPinching(OVRHand.HandFinger.Middle))
            {
                resetColor(this.wallTexture);
            }
            //else if (hand.GetFingerIsPinching(OVRHand.HandFinger.Middle))
            //{

            //}
            //else if (hand.GetFingerIsPinching(OVRHand.HandFinger.Ring))
            //{

            //}
            //else if (hand.GetFingerIsPinching(OVRHand.HandFinger.Pinky))
            //{

            //}

        }
        else
        {
            // hand is not facing user
            middleFingerMenu.GetComponent<Canvas>().enabled = false;
        }
    }

    private void resetColor(Texture2D texture)
    {
        for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
                texture.SetPixel(x, y, Color.white);
            }
        }
        texture.Apply();
    }
}
