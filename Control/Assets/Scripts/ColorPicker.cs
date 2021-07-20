using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : MonoBehaviour
{

    public Material[] BodyColorMat;
    Material CurrMat;
    Renderer renderer;

    // Use this for initialization
    void Start()
    {

        renderer = this.GetComponent<Renderer>();

    }

    
    void Update()
    {

    }

   
    public void Mavimtırak()
    {
        renderer.material = BodyColorMat[0];
        CurrMat = renderer.material;
    }

  
    public void SarımsıYeşilimtırak()
    {
        renderer.material = BodyColorMat[1];
        CurrMat = renderer.material;
    }

    public void Black()
    {
        renderer.material = BodyColorMat[2];
        CurrMat = renderer.material;
    }

    public void Green()
    {
        renderer.material = BodyColorMat[3];
        CurrMat = renderer.material;
    }

    public void Red()
    {
        renderer.material = BodyColorMat[4];
        CurrMat = renderer.material;
    }

    public void Original()
    {
        renderer.material = BodyColorMat[5];
        CurrMat = renderer.material;
    }



}