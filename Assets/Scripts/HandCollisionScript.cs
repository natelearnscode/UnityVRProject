using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCollisionScript : MonoBehaviour
{
    public Material handMaterial;
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
            // shoot ray for each finger tip
            if ( bone.Id == OVRSkeleton.BoneId.Hand_Index2)
            {
                ShootFingerRay(bone);
            }

        }
    }

    void ShootFingerRay(OVRBone finger)
    {
        RaycastHit hit;
        Ray ray = new Ray(finger.Transform.position, finger.Transform.right);

        if (Physics.Raycast(ray, out hit, 0.2f))
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
            //Debug.Log(hit.collider.gameObject.name);
            //Debug.Log($"Collision UV is {pixelUV.x}, {pixelUV.y}");
            tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, handColor);
            tex.Apply();
        }
    }
}
