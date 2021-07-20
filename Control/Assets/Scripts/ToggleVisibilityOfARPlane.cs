using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class ToggleVisibilityOfARPlane : MonoBehaviour
{
    [SerializeField]
    Sprite[] sprite;
    [SerializeField]
    Image ButtonsImage;
    ARPlaneManager planeManager;
    private ARRaycastManager _raycastManager;
    
    void Awake(){
        _raycastManager = GetComponent<ARRaycastManager>();
        planeManager = GetComponent<ARPlaneManager>();

    }
    public void TogglePlaneDetection()
    {
        
        planeManager.enabled = !planeManager.enabled;
        foreach(ARPlane planes in planeManager.trackables)
        {
            planes.gameObject.SetActive(planeManager.enabled);
        }
}
}
