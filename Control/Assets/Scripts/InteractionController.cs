using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.Interaction.Toolkit.AR;

[Serializable]
public class ARObjectPlacedEvent : UnityEvent<InteractionController, GameObject> { }
public class InteractionController : ARBaseGestureInteractable
{
    
    [SerializeField]
        GameObject m_PlacementPrefab;
        /// <summary>
        /// A <see cref="GameObject"/> For placing when a raycast from a user touch hits a plane.
        /// </summary>
        public GameObject placementPrefab
        {
            get => m_PlacementPrefab;
            set => m_PlacementPrefab = value;
        }

        [SerializeField] private GameObject crosshair;
        [SerializeField]
        ARObjectPlacedEvent m_OnObjectPlaced = new ARObjectPlacedEvent();

        /// <summary>
        /// When the interactable places a new <see cref="GameObject"/> in the world.
        /// </summary>
        public ARObjectPlacedEvent onObjectPlaced
        {
            get => m_OnObjectPlaced;
            set => m_OnObjectPlaced = value;
        }

        static readonly List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();
        static GameObject s_TrackablesObject;

        private Pose pose;
        
        /// <param name="gesture">The current gesture.</param>
        /// <returns>Returns <see langword="true"/> if the manipulation can be started. Returns <see langword="false"/> otherwise.</returns>
        protected override bool CanStartManipulationForGesture(TapGesture gesture)
        {
           
            if (gesture.targetObject == null || gesture.targetObject.layer == 9) // TODO Placement gesture layer check should be configurable
                return true;

            return false;
        }

        bool IsPointerOverUI(TapGesture touch)
        {
            PointerEventData eventData = new PointerEventData(EventSystem.current);
            eventData.position = new Vector2(touch.startPosition.x, touch.startPosition.y);
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);
            return results.Count > 0;
        }

        private void FixedUpdate()
        {
            if(crosshair.activeSelf)   
                CrosshairCalculation();
        }

        void CrosshairCalculation()
        {
            Vector3 origin = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0));
            

            if (GestureTransformationUtility.Raycast(origin, s_Hits, TrackableType.PlaneWithinPolygon))
            {
                pose = s_Hits[0].pose;
                crosshair.transform.position = pose.position;
                crosshair.transform.eulerAngles = new Vector3(90,0,0);
            }
        }

        public void onFinishPlacement()
        {
            crosshair.SetActive(false);
        }
        
       
        /// <param name="gesture">The current gesture.</param>
        protected override void OnEndManipulation(TapGesture gesture)
        {
            
            if (gesture.isCanceled || !crosshair.activeSelf)
                return;

            
            if (gesture.targetObject != null && gesture.targetObject.layer != 9) // TODO Placement gesture layer check should be configurable
                return;

            if (IsPointerOverUI(gesture))
                return;
            if (GestureTransformationUtility.Raycast(gesture.startPosition, s_Hits, TrackableType.PlaneWithinPolygon))
            {
                var hit = s_Hits[0];
                if (Vector3.Dot(Camera.main.transform.position - hit.pose.position,
                                 hit.pose.rotation * Vector3.up) < 0)
                             return;
                GameObject placementObject = Instantiate(DataHandler.Instance.GetFurniture(), pose.position, pose.rotation);
                var anchorObject = new GameObject("PlacementAnchor");
                anchorObject.transform.position = hit.pose.position;
                anchorObject.transform.rotation = hit.pose.rotation;
                placementObject.transform.parent = anchorObject.transform;
                m_OnObjectPlaced?.Invoke(this, placementObject);
            }

        }
    }