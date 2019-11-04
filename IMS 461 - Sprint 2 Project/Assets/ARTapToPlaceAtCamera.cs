using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARTapToPlaceAtCamera : MonoBehaviour
{
    // Variables
    public GameObject locker;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        // If touching the screen, place the object at the camera
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Get offset and rotation of locker
            Vector3 lockerPosition = Camera.current.transform.position + (0.5f * Camera.current.transform.forward); // Move locker forward
            Vector3 old = Camera.current.transform.rotation.eulerAngles;
            Quaternion lockerRotation = Quaternion.Euler(new Vector3(old.x * -1, old.y + 180, old.z * -1)); // Turn locker 180 degrees on y-axis

            //Instantiate(locker, lockerPosition, Quaternion.Euler(lockerRotation));
            Instantiate(locker, lockerPosition, lockerRotation);
        }
    }
}
