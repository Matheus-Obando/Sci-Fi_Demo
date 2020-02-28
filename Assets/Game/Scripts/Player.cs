using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private CharacterController m_controller;
	[SerializeField]
	private float m_speed = 3.5f;
	private float m_gravity = 9.81f;

	// Start is called before the first frame update
	void Start()
	{
		m_controller = GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void Update()
	{
		float horizontalInput = Input.GetAxis("Horizontal");
		float verticalInput = Input.GetAxis("Vertical");
		Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
		Vector3 velocity = direction * m_speed;
		velocity.y -= m_gravity;

		velocity = transform.transform.TransformDirection(velocity);

		m_controller.Move(velocity * Time.deltaTime);
	}
}