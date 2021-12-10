using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCollisionScript : MonoBehaviour
{
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
            //index
            if (bone.Id == OVRSkeleton.BoneId.Hand_Index3)
            {
                RaycastHit hit;
                Ray ray = new Ray(bone.Transform.position, bone.Transform.right * 0.01f);

                if (Physics.Raycast(ray, out hit))
                {
                    Renderer rend = hit.transform.GetComponent<MeshRenderer>();
                    Texture2D tex = rend.material.mainTexture as Texture2D;

                    Vector2 pixelUV = hit.textureCoord;
                    pixelUV.x *= tex.width;
                    pixelUV.y *= tex.height;
                    //Debug.Log(hit.collider.gameObject.name);
                    Debug.Log($"Collision UV is {pixelUV.x}, {pixelUV.y}");
                    tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, Color.black);
                    tex.Apply();
                }
            }

        }
    }


}
