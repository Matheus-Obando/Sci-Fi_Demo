using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text m_ammoText;
    [SerializeField]
    private GameObject m_coin;
    public void UpdateAmmo(int count)
    {
        m_ammoText.text = string.Format("Ammo: {0}", count);
    }

    public void CollectedCoin()
    {
        m_coin.SetActive(true);
    }
}
