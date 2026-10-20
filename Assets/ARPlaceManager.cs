using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ARPlaceManager : MonoBehaviour
{
    [SerializeField] private GameObject solarSystemPrefab;
    private GameObject spawnedObject;
    private ARRaycastManager raycastManager;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        Vector2 touchPosition = default;
        bool hasInput = false;

#if UNITY_EDITOR
        // Use Left Mouse Click (0) when testing in the Unity Editor
        if (Input.GetMouseButtonDown(0))
        {
            touchPosition = Input.mousePosition;
            hasInput = true;
        }
#else
        // Use touch on a real phone
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchPosition = Input.GetTouch(0).position;
            hasInput = true;
        }
#endif

        if (hasInput)
        {
            if (raycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = hits[0].pose;

                if (spawnedObject == null)
                {
                    spawnedObject = Instantiate(solarSystemPrefab, hitPose.position, hitPose.rotation);
                }
                else
                {
                    spawnedObject.transform.position = hitPose.position;
                }
            }
        }
    }
}