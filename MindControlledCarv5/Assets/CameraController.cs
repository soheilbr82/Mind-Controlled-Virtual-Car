using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public Transform car;
    public float distance = 6.4f;
    public float height = 1.4f;
    public float rotationDamping = 3.0f;
    public float heightDamping = 2.0f;
    public float zoomRatio = 0.5f;
    public float defaultFOV = 60f;
    private Vector3 rotationVector;

    void LateUpdate()
    {
        if (car != null)
        {
            float wantedAngle = rotationVector.y;
            float wantedHeight = car.position.y + height; //car.position.y + height;
            float myAngle = transform.eulerAngles.y;
            float myHeight = transform.position.y;

            myAngle = Mathf.LerpAngle(myAngle, wantedAngle, rotationDamping * Time.deltaTime);
            myHeight = Mathf.Lerp(myHeight, wantedHeight, heightDamping * Time.deltaTime);

            Quaternion currentRotation = Quaternion.Euler(0, myAngle, 0);
            transform.position = car.position;
            transform.position -= currentRotation * Vector3.forward * distance;
            Vector3 temp = transform.position; //temporary variable so Unity doesn't complain
            temp.y = myHeight;
            transform.position = temp;
            transform.LookAt(car);
        }
    }

    void FixedUpdate()
    {
        if (car != null)
        {
            Vector3 localVelocity = car.InverseTransformDirection(car.GetComponent<Rigidbody>().velocity);
            if (localVelocity.z < -10.5f)
            {
                Vector3 temp = rotationVector; //because temporary variables seem to be removed after a closing bracket "}" we can use the same variable name multiple times.
                temp.y = car.eulerAngles.y + 180;
                rotationVector = temp;
            }
            else
            {
                Vector3 temp = rotationVector;
                temp.y = car.eulerAngles.y;
                rotationVector = temp;
            }
            float acc = car.GetComponent<Rigidbody>().velocity.magnitude;

            GetComponent<Camera>().fieldOfView = defaultFOV + acc * zoomRatio * Time.deltaTime;
        }
    }
}