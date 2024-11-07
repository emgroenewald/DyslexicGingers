using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightFocus : MonoBehaviour
{
    public Light flashlight; 
    public Camera playerCamera; 

   
    public float defaultRange = 20f;
    public float focusedRange = 50f;
    public float defaultSpotAngle = 60f;
    public float focusedSpotAngle = 20f; 
    public float defaultFOV = 60f;
    public float focusedFOV = 40f;
    public float defaultIntensity = 1f;
    public float focusedIntensity = 2.5f;
    public float zoomSpeed = 5f; 
   
    private bool isFocusing = false;

    void Update()
    {
        
        if (Input.GetMouseButtonDown(1))
        {
            isFocusing = true;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            isFocusing = false;
        }

        
        if (isFocusing)
        {
            flashlight.range = Mathf.Lerp(flashlight.range, focusedRange, Time.deltaTime * zoomSpeed);
            flashlight.spotAngle = Mathf.Lerp(flashlight.spotAngle, focusedSpotAngle, Time.deltaTime * zoomSpeed);
            flashlight.intensity = Mathf.Lerp(flashlight.intensity, focusedIntensity, Time.deltaTime * zoomSpeed);
            playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, focusedFOV, Time.deltaTime * zoomSpeed);

        }
        else
        {
            flashlight.range = Mathf.Lerp(flashlight.range, defaultRange, Time.deltaTime * zoomSpeed);
            flashlight.spotAngle = Mathf.Lerp(flashlight.spotAngle, defaultSpotAngle, Time.deltaTime * zoomSpeed);
            flashlight.intensity = Mathf.Lerp(flashlight.intensity, defaultIntensity, Time.deltaTime * zoomSpeed);
            playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, defaultFOV, Time.deltaTime * zoomSpeed);
        }
    }
}
