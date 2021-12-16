using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCursor : MonoBehaviour
{
    /*
     * This script is used to rotate the cursor on the UI to face the headset of the user.
     */
    public Transform menuTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rotate cursor to face head
        this.transform.rotation = menuTransform.rotation;
    }
}
