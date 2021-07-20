using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeeNotSee : MonoBehaviour
{
    public Sprite oldImage;
    
    public Sprite newImage;
    public Image oldImage2;
    public void ImageChange(){

        
        bool clicked = false;
        if (clicked == false){
        oldImage2.sprite = newImage;
        clicked = true;
        }
        else
        {
        oldImage2.sprite = oldImage ;

        clicked = false;
        }

    }

}