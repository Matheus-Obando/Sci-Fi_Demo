using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour
{
    [SerializeField]
    private float m_sensitivity = 1.0f;

    // Update is called once per frame
    void Update()
    {
        float m_mouseY = - Input.GetAxis("Mouse Y");

        Vector3 newRotation = transform.localEulerAngles;
        newRotation.x += m_mouseY * m_sensitivity;
        transform.localEulerAngles = newRotation;
    }
}
