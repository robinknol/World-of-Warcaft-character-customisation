using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    float rotateSpeed = 200;

    private void OnMouseDrag()
    {
        float rotateX = Input.GetAxis("Mouse X") * rotateSpeed * Mathf.Deg2Rad;
        float rotateY = Input.GetAxis("Mouse Y") * rotateSpeed * Mathf.Deg2Rad;

        transform.Rotate(Vector3.up, -rotateX);
        transform.Rotate(Vector3.right, rotateY);
    }
}
