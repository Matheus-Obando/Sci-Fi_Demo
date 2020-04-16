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

            if (Input.GetKeyDown(KeyCode.E))
            {
                Player player = other.GetComponent<Player>();
                if (player != null)
                {
                    player.hasCoins = true;
                    AudioSource.PlayClipAtPoint(m_coinPickup, transform.position, 1f);
                    UIManager uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

                    if (uiManager != null)
                    {
                        uiManager.CollectedCoin();
                    }

                    Destroy(this.gameObject);
                }
            }
        }
    }
}
