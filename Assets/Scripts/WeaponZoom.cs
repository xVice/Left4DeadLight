using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera FPSCamera;
    [SerializeField] float unzoomedFOV = 85f;
    [SerializeField] float zoomedInFOV = 20f;

    

    bool zoomedInToggle = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if(zoomedInToggle == false)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }
    }

    private void OnDisable()
    {
        ZoomOut();
    }

    private void ZoomOut()
    {
        zoomedInToggle = false;
        FPSCamera.fieldOfView = unzoomedFOV;
    }

    private void ZoomIn()
    {
        zoomedInToggle = true;
        FPSCamera.fieldOfView = zoomedInFOV;
    }
}
