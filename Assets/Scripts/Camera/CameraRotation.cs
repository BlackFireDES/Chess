using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private float _rotateCamera;

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            _rotateCamera = Input.GetAxis("Mouse X");
            transform.Rotate(0, _rotateCamera, 0);
        }
    }
}
