using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCollisionScript : MonoBehaviour
{
    /*
     * 
     * This script handles the collision between fingers on the hand and the wall
     * 
     */

    public Material handMaterial;
    public LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OVRSkeleton skeleton = this.GetComponentInChildren<OVRSkeleton>();
        // loop through skeleton of bones to find specific bone
        foreach (OVRBone bone in skeleton.Bones)
        {
            // shoot ray from finger tip
            if ( bone.Id == OVRSkeleton.BoneId.Hand_IndexTip)
            {
                ShootFingerRay(bone);
            }

        }
    }

    //This method is used to shoot a ray from the finger to the wall and draw on it
    void ShootFingerRay(OVRBone finger)
    {
        float rayDistance = 0.1f;
        RaycastHit hit;
        Ray ray = new Ray(finger.Transform.position, finger.Transform.right);

        this.lineRenderer.SetPosition(0, finger.Transform.position);
        this.lineRenderer.SetPosition(1, finger.Transform.position + (finger.Transform.right  * rayDistance));

        //only paint if raycast hits a paintable object
        if (Physics.Raycast(ray, out hit, rayDistance) && hit.transform.gameObject.GetComponent<Paintable>())
        {
            // get walls material
            Renderer rend = hit.transform.GetComponent<MeshRenderer>();
            if (rend == null || rend.material == null || rend.material.mainTexture == null)
                return;

            Texture2D tex = rend.material.mainTexture as Texture2D;

            //get hands color
            Color handColor = handMaterial.color;

            Vector2 pixelUV = hit.textureCoord;
            pixelUV.x *= tex.width;
            pixelUV.y *= tex.height;
            DrawCircle(pixelUV.x, pixelUV.y, handColor, tex);
        }

        //helper method used to draw a cirle on the texture so we aren't just changing one pixel's color
        void DrawCircle(float x, float y, Color color, Texture2D tex, float r = 5.0f)
        {
            double i, angle, x1, y1;

            for (i = 0; i < 360; i += 0.1)
            {
                angle = i;
                x1 = r * Math.Cos(angle * Math.PI / 180);
                y1 = r * Math.Sin(angle * Math.PI / 180);
                if (x1 > 0)
                {
                    for (float j = x; j < x + x1; j++)
                    {
                        if (y1 > 0)
                        {
                            for (float k = y; k < y + y1; k++)
                            {
                                tex.SetPixel((int)j, (int)k, color);
                            }
                        }
                        else
                        {
                            for (float k = y; k > y + y1; k--)
                            {
                                tex.SetPixel((int)j, (int)k, color);
                            }
                        }
                    }
                } 
                else
                {
                    for (float j = x; j > x + x1; j--)
                    {
                        if (y1 > 0)
                        {
                            for (float k = y; k < y + y1; k++)
                            {
                                tex.SetPixel((int)j, (int)k, color);
                            }
                        }
                        else
                        {
                            for (float k = y; k > y + y1; k--)
                            {
                                tex.SetPixel((int)j, (int)k, color);
                            }
                        }
                    }
                }
            }
            tex.Apply();
        }
    }
}
