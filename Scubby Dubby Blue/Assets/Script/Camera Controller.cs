using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform _camera;
    public Transform hand;
    public float cameraSensitivity = 200.0f;
    public float cameraAcceleration = 5.0f;

    private float rotation_x_axis;
    private float rotation_y_axis;


    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        rotation_x_axis += Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;
        rotation_y_axis += Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;

        transform.localRotation = Quaternion.Lerp(transform.localRotation, 
            Quaternion.Euler(0, rotation_y_axis, 0), cameraAcceleration * Time.deltaTime);

        _camera.localRotation = Quaternion.Lerp(_camera.localRotation,
            Quaternion.Euler(-rotation_x_axis, 0, 0), cameraAcceleration * Time.deltaTime);

        rotation_x_axis = Mathf.Clamp(rotation_x_axis, -90f, 90f);

        hand.localRotation = Quaternion.Euler(-rotation_x_axis, rotation_y_axis, 0);

    }
}
