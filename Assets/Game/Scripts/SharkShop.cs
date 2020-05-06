using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkShop : MonoBehaviour
{

	[SerializeField]
	private AudioClip m_winSound;

	private UIManager m_UIManager;

	public void Start()
	{
		m_UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
	}

	public void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player")
		{
			Player player = other.GetComponent<Player>();

			if (player != null)
			{
				if(m_UIManager != null)
				{
					m_UIManager.interactionText.text = string.Format("(E) TO INTERACT");
				}

				if (player.hasCoins && Input.GetKeyDown(KeyCode.E))
				{
					if(m_winSound != null)
					{
						AudioSource.PlayClipAtPoint(m_winSound, transform.position, 1f);
					}

					player.EnableWeapons();
					m_UIManager.RemoveCoin();
					player.hasCoins = false;
					Debug.Log("Get out of here!");
				}
			}
		}
	}

	public void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			m_UIManager.interactionText.text = string.Empty;
		}
	}
	// check for a collision
	// check if the player
	// wait for E key
	// check if the player has a coin
		// remove the coin
		// update the inventory display
		// play win sound

	// Debug get out of here
}
