using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestrictRotation : MonoBehaviour
{
    private Transform sniperTransform;
    void Start()
    {
        sniperTransform = GetComponent<Transform>();
    }

    void LateUpdate()
    {
        sniperTransform.transform.eulerAngles = new Vector3(
            sniperTransform.transform.eulerAngles.x,
            sniperTransform.transform.eulerAngles.y,
            0
        );
    }
}
