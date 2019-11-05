using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARTapToPlaceAtCamera : MonoBehaviour
{
    // Variables
    public List<GameObject> lockers;
    public GameObject locker1;
    public GameObject locker2;
    public GameObject locker3;
    public GameObject locker4;

    // Start is called before the first frame update
    void Start()
    {
        // Add all the locker prefabs to a list
        lockers.Add(locker1);
        lockers.Add(locker2);
        lockers.Add(locker3);
        lockers.Add(locker4);
    }

    // Update is called once per frame
    void Update()
    {
        // If touching the screen, place the object at the camera
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Select a random locker from the locker list
            GameObject locker = lockers[Random.Range(0, lockers.Count)];

            // Get offset and rotation of locker
            Vector3 lockerPosition = Camera.current.transform.position + (Camera.current.transform.forward * 1.25f); // Move locker forward
            Vector3 old = Camera.current.transform.rotation.eulerAngles;
            Quaternion lockerRotation = Quaternion.Euler(new Vector3(old.x * -1.0f, old.y + 180.0f, old.z * -1.0f)); // Turn locker 180 degrees on y-axis

            //Instantiate(locker, lockerPosition, Quaternion.Euler(lockerRotation));
            Instantiate(locker, lockerPosition, lockerRotation);
        }
    }
}
