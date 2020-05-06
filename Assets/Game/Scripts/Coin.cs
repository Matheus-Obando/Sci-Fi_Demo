using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //Check for Collision (OnTrigger)
    //Check if player
    //Check for e key press
    //give player the coin
    //destroy the coin
    [SerializeField]
    private AudioClip m_coinPickup;
    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            UIManager uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
            uiManager.interactionText.text = string.Format("(E) TO COLLECT COIN");

            if (Input.GetKeyDown(KeyCode.E))
            {
                Player player = other.GetComponent<Player>();
                if (player != null)
                {
                    player.hasCoins = true;
                    AudioSource.PlayClipAtPoint(m_coinPickup, transform.position, 1f);

                    if (uiManager != null)
                    {
                        uiManager.CollectedCoin();
                    }
                    uiManager.interactionText.text = string.Empty;
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
