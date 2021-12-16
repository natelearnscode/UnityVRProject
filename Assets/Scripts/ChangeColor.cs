using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    /*
     * This script is used to change the drawging and hand color based off of the rgb sliders in the settings menu
     * 
     */
    public Image image;
    public Material handMaterial;

    public Slider redSlider;
    public Slider blueSlider;
    public Slider greenSlider;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Helper method to change the preview img and drawing color in the settings menu
     public void ChangeImgColor()
    {
        Color newColor = new Color(redSlider.value / 255.0f, greenSlider.value / 255.0f, blueSlider.value / 255.0f);
        image.color = newColor;
        handMaterial.color = newColor;
    }
}
