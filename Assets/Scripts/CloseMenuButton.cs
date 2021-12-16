using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMenuButton : MonoBehaviour
{
    /*
     * 
     * Script to close the settings menu
     * 
     */
    public GameObject settingsMenu; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseMenu()
    {
        settingsMenu.GetComponent<Canvas>().enabled = false;
    }
}
