using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMenu : MonoBehaviour
{
    public Transform headsetTransform;
    public GameObject middleFingerMenu;
    public GameObject settingsMenu;
    public OVRHand.Hand handType;
    public Texture2D wallTexture;

    private OVRHand hand;
    private OVRSkeleton skeleton;

    // Start is called before the first frame update
    void Start()
    {
        this.hand = this.GetComponentInChildren<OVRHand>();
        this.skeleton = this.GetComponentInChildren<OVRSkeleton>();
    }

    // Update is called once per frame
    void Update()
    {
        //up vector for right hand is the opposite of what we need so we need to reverse it first
        Vector3 handUpDirection = this.handType == OVRHand.Hand.HandRight ? -this.transform.up : this.transform.up;

        //using dot product of the headset's forward and hand's up vector we can determine if palm of hand is facing the user
        if (Vector3.Dot(headsetTransform.forward, handUpDirection) < 0)
        {
            /* show finger menu options */
            middleFingerMenu.GetComponent<Canvas>().enabled = true;
            DisplayFingerMenus();

            /* check if any fingers are being pinched and open menu */
            //  middle finger menu
            if(this.hand.GetFingerIsPinching(OVRHand.HandFinger.Middle))
            {
                Debug.Log(this.hand.IsDominantHand);
                if(this.handType == OVRHand.Hand.HandRight)
                {
                    resetColor(this.wallTexture);
                }
                else
                {
                    DisplaySettings();
                }
            }
        }
        else
        {
            // hand is not facing user
            middleFingerMenu.GetComponent<Canvas>().enabled = false;
        }
    }

    private void DisplaySettings()
    {
        //float distanceInFront = 1.0f;
        //float distanceBelow = 0.5f;
        //Vector3 settingsNewPos = headsetTransform.position + (headsetTransform.forward * distanceInFront) - (headsetTransform.up * distanceBelow);
        //offset is used to put menu at a small distance away from finger. The left and right hands have opposite right vectors, so we need to reverse the direction of the left hand to use the same math
        Vector3 menuPosOffset = this.handType == OVRHand.Hand.HandLeft ? this.transform.right * 0.5f : -this.transform.right * 0.05f;
        Vector3 newMenuPos = this.transform.position + menuPosOffset;
        settingsMenu.transform.position = newMenuPos;

        //rotate menu to face head
        Vector3 targetDirection = settingsMenu.transform.position - headsetTransform.position;
        settingsMenu.transform.rotation = Quaternion.LookRotation(targetDirection);
    }

    private void DisplayFingerMenus()
    {
        // loop through skeleton of bones to find specific bone and display menu
        foreach (OVRBone bone in this.skeleton.Bones)
        {
            //middle finger
            if (bone.Id == OVRSkeleton.BoneId.Hand_MiddleTip)
            {
                //offset is used to put menu at a small distance away from finger. The left and right hands have opposite right vectors, so we need to reverse the direction of the left hand to use the same math
                Vector3 menuPosOffset = this.handType == OVRHand.Hand.HandLeft ? -bone.Transform.right * 0.05f : bone.Transform.right * 0.05f;
                Vector3 newMenuPos = bone.Transform.position + menuPosOffset;
                middleFingerMenu.transform.position = newMenuPos;

                //rotate menu to face head
                Vector3 targetDirection = middleFingerMenu.transform.position - headsetTransform.position;
                middleFingerMenu.transform.rotation = Quaternion.LookRotation(targetDirection);
                break;
            }
        }
    }

    // helper method to reset color of a texture to a single color
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
