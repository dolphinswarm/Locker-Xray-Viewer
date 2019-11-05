using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARTapToPlaceObject: MonoBehaviour
{
    // Variables
    private ARSessionOrigin arOrigin;
    private Pose placementPose;
    public GameObject placementIndicator;
    private bool placementPoseIsValid = false;

    // Start is called before the first frame update
    void Start()
    {
        arOrigin = FindObjectOfType<ARSessionOrigin>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlacementPose();
        UpdatePlacementIndicator();
    }

    // Update placement indicator
    private void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation); // Replace with up direction
        }

        else
        {
            placementIndicator.SetActive(false);
        }
    }

    // Update the placement pose
    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        arOrigin.GetComponent<ARRaycastManager>().Raycast(screenCenter, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;

        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;

            var cameraTrans = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraTrans.x, 0, cameraTrans.z);
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }
}
