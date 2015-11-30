using UnityEngine;
using System.Collections;

public class CameraMechanics : MonoBehaviour {
    public float cameraXSensitivity = 25f;
    public float cameraYSensitivuty = 25f;
    public float cameraSmoothing = 10f;
    public float cameraMoveSmoothing = 10f;


    CameraCollision collisionCheck;
    Transform target;
    float distanceFromTarget = -5;
    Vector3 oldRotation;

    void Start()
    {
        target = transform.parent;
        transform.parent = null;
        distanceFromTarget = -(target.position - transform.position).magnitude;
        oldRotation = transform.eulerAngles;
        collisionCheck = GetComponent<CameraCollision>();
    }

    void Update()
    {
        lookHorizontal(Input.GetAxis("Mouse X"));
        lookVertical(Input.GetAxis("Mouse Y"));
        updateCameraRotation();
        updateCameraPosition();

    }

    public void setTargetFollow(Transform targetFollow)
    {
        this.target = targetFollow;
    }

    public Transform getTargetFollow()
    {
        return target;
    }

    public float getCurrentMagnitude()
    {
        return distanceFromTarget;
    }

    void updateCameraRotation()
    {
        Quaternion goalRotation = Quaternion.Euler(oldRotation.x, oldRotation.y, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, goalRotation, Time.deltaTime * cameraSmoothing);
        oldRotation = transform.rotation.eulerAngles;
    }

    void updateCameraPosition()
    {
        float distance = distanceFromTarget;
        if (collisionCheck.cameraIsColliding)
        {
            distance = collisionCheck.collisionDistance;
        }
        Vector3 goalPosition = target.position + transform.forward * distance;
        transform.position = Vector3.Slerp(transform.position, goalPosition, Time.deltaTime * cameraMoveSmoothing);
    }

    void lookHorizontal(float horizontalInput)
    {
        print(horizontalInput);
        oldRotation += Vector3.up * horizontalInput * cameraXSensitivity * Time.deltaTime;

    }

    void lookVertical(float verticalInput)
    {
        print(verticalInput);
        oldRotation += Vector3.left * verticalInput * cameraYSensitivuty * Time.deltaTime;
    }
}
