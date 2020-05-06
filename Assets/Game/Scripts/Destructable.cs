using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    [SerializeField]
    private GameObject m_destroyedObject;

    public void DestroyObject()
    {
        Instantiate(m_destroyedObject, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
