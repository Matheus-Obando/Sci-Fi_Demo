using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour
{
    [SerializeField]
    private float m_sensitivity = 1.0f;

    // Update is called once per frame
    void Update()
    {
        float m_mouseX = Input.GetAxis("Mouse X");

        Vector3 newRotation = transform.localEulerAngles;
        newRotation.y += m_mouseX * m_sensitivity;
        transform.localEulerAngles = newRotation;

        //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + (m_mouseX * m_sensitivity), transform.localEulerAngles.z);
        
    }
}
