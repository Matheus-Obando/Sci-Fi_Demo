using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMarkerCleanUp : MonoBehaviour
{
    [SerializeField]
    private float m_Lifetime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MarkerLifeTime(m_Lifetime));
    }

    private IEnumerator MarkerLifeTime(float lifetime)
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(this.gameObject);

    }
}
