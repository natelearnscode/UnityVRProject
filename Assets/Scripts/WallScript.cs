using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        //ContactPoint[] contactPoints = new ContactPoint[collision.contactCount];
        //List<Vector3> pointsOnWall = new List<Vector3>();
        //collision.GetContacts(contactPoints);
        //foreach (ContactPoint contactPoint in contactPoints)
        //{
        //    pointsOnWall.Add(this.transform.InverseTransformPoint(contactPoint.point));
        //}

        //RaycastHit hit;
        
        //Ray ray = new Ray(contactPoints[0].point + contactPoints[0].normal, -contactPoints[0].normal);

        //if (!contactPoints[0].thisCollider.Raycast(ray, out hit, 1.0f))
        //    return;

        ////Debug.Log(hit.point);

        //Renderer rend = this.GetComponent<MeshRenderer>();
        //if (rend == null)
        //    Debug.Log("rend not found");

        //if (rend == null || rend.material == null || rend.material.mainTexture == null)
        //    return;

        //Texture2D tex = rend.material.mainTexture as Texture2D;
        //MeshCollider meshCollider = hit.collider as MeshCollider;

        ////Debug.Log(hit.collider.GetType());
        //Vector2 pixelUV = hit.textureCoord;
        //pixelUV.x *= tex.width;
        //pixelUV.y *= tex.height;
        //Debug.Log($"Collision UV is {(int)pixelUV.x}, {(int)pixelUV.y}");

        ////tex.SetPixel(pixelUV.x, pixelUV.y, Color.black);
        ////tex.Apply();
        //resetColor(tex);
    }

    private void resetColor(Texture2D texture)
    {
        for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
                texture.SetPixel(x, y, Color.blue);
            }
        }
        texture.Apply();
    }
}
