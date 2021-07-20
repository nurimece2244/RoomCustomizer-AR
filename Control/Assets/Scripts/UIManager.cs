using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;

    public Transform selectionPoint;
    
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();
            }
            return instance;
        }
        
    }
    
    
    void Start()
    {
        
        m_Raycaster = GetComponent<GraphicRaycaster>();
        
        
        m_EventSystem = GetComponent<EventSystem>();
        
       
        m_PointerEventData = new PointerEventData(m_EventSystem);
        
        
        m_PointerEventData.position = selectionPoint.position;
        
    }

    public bool OnEntered(GameObject button)
    {
        
        List<RaycastResult> results = new List<RaycastResult>();
     
       
        m_Raycaster.Raycast(m_PointerEventData, results);

        
        foreach (RaycastResult result in results)
        {
            if (result.gameObject == button)
            {
                return true;
            }
        }
        return false;
    }

}
