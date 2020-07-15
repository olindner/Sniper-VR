using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class SniperScopeControl : MonoBehaviour
{
    public Transform scopeTransform;
    public GameObject xrRigGameObject;
    public GameObject scopeRenderingObject;
    private GameObject headsetCamera;
    private List<InputDevice> rightEyeDevice = new List<InputDevice>();
    void Start()
    {
        InputDevices.GetDevicesAtXRNode(XRNode.RightEye, rightEyeDevice);

        XRRig xrScript = xrRigGameObject.GetComponent<XRRig>();
        headsetCamera = xrScript.cameraGameObject;

        scopeRenderingObject.SetActive(false);
    }

    void Update()
    {
        Vector3 rightEyePosition = new Vector3();

        if (rightEyeDevice[0].TryGetFeatureValue(CommonUsages.rightEyePosition, out rightEyePosition))
        {
            bool shouldBeScoped = Vector3.SqrMagnitude(rightEyePosition - scopeTransform.position) < 0.01;

            if (shouldBeScoped && !scopeRenderingObject.activeSelf)
            {
                headsetCamera.SetActive(false);
                scopeRenderingObject.SetActive(true);
                xrRigGameObject.GetComponent<XRRig>().cameraGameObject = scopeRenderingObject;
            }
            if (!shouldBeScoped && scopeRenderingObject.activeSelf)
            {
                headsetCamera.SetActive(true);
                scopeRenderingObject.SetActive(false);
                xrRigGameObject.GetComponent<XRRig>().cameraGameObject = headsetCamera;
            }
        }
    }
}
