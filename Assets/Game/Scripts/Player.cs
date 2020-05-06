using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private CharacterController m_controller;
	[SerializeField]
	private GameObject m_muzzleEffects;
	[SerializeField]
	private float m_speed = 3.5f;
	[SerializeField]
	private GameObject m_hitMarker;
	[SerializeField]
	private AudioSource m_shootAudio;
	[SerializeField]
	private GameObject m_weapon;

	private float m_gravity = 9.81f;
	private ParticleSystem m_MuzzleLight;
	private ParticleSystem m_MuzzleTrail;

	[SerializeField]
	private int m_currentAmmo;
	[SerializeField]
	private int m_maxAmmo = 100;

	private bool m_isReloading = false;

	private UIManager m_uiManager;

	public bool hasCoins = false;
	// Start is called before the first frame update
	void Start()
	{
		m_controller = GetComponent<CharacterController>();
		m_MuzzleLight = m_muzzleEffects.GetComponent<ParticleSystem>();
		m_MuzzleTrail = m_muzzleEffects.GetComponentInChildren<ParticleSystem>();
		m_currentAmmo = m_maxAmmo;

		// Disable mouse cursor on screen
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;

		m_uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
	}

	private void Movement()
	{
		float horizontalInput = Input.GetAxis("Horizontal");
		float verticalInput = Input.GetAxis("Vertical");
		Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
		Vector3 velocity = direction * m_speed;
		velocity.y -= m_gravity;

		velocity = transform.transform.TransformDirection(velocity);

		m_controller.Move(velocity * Time.deltaTime);
	}

	private void Fire()
	{
		if (Input.GetMouseButton(0) && m_weapon.activeSelf && m_currentAmmo > 0)
		{
			Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
			RaycastHit hitInfo;
			//m_muzzleEffects.SetActive(true);
			var lightEmission = m_MuzzleLight.emission;
			var trailEmission = m_MuzzleTrail.emission;
			lightEmission.enabled = true;
			trailEmission.enabled = true;

			--m_currentAmmo;
			m_uiManager.UpdateAmmo(m_currentAmmo);

			if (!m_shootAudio.isPlaying)
			{
				m_MuzzleLight.Play();
				m_MuzzleTrail.Play();
				//m_muzzleEffects.GetComponent<ParticleSystem>().Play();
				m_shootAudio.Play();
			}

			if (Physics.Raycast(rayOrigin, out hitInfo))
			{
				Debug.Log("Hit: " + hitInfo.transform.name);
				GameObject hitMarker = (GameObject)Instantiate(m_hitMarker, hitInfo.point, Quaternion.identity);
				Destroy(hitMarker, 1f);

				Destructable destructableObject = hitInfo.transform.GetComponent<Destructable>();

				if (destructableObject != null)
				{
					destructableObject.DestroyObject();
				}
			}
		}

		else if (Input.GetMouseButtonUp(0) | m_currentAmmo <= 0)
		{
			var lightEmission = m_MuzzleLight.emission;
			var trailEmission = m_MuzzleTrail.emission;
			lightEmission.enabled = false;
			trailEmission.enabled = false;
			m_MuzzleLight.Stop();
			m_MuzzleTrail.Stop();
			//m_muzzleEffects.SetActive(false);
			m_shootAudio.Stop();
		}
	}

	IEnumerator Reload()
	{
		yield return new WaitForSeconds(1.5f);
		m_currentAmmo = m_maxAmmo;
		m_uiManager.UpdateAmmo(m_currentAmmo);
		m_isReloading = false;
	}

	public void EnableWeapons()
	{
		m_weapon.SetActive(true);
	}

	// Update is called once per frame
	void Update()
	{
		Fire();
		Movement();

		// Enable Mouse Cursor if needed
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}

		if (Input.GetKeyDown(KeyCode.R) && !m_isReloading)
		{
			m_isReloading = true;
			StartCoroutine(Reload());
		}

	}
}