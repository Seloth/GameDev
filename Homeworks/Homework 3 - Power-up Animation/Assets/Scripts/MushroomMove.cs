using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomMove : MonoBehaviour
{

	[SerializeField]
	[Range(0, 5)]
	private float moveSpeed = 2;

	[SerializeField]
	[Range(0.1f, 2)]
	public float gravity = 0.5f;

	private Vector2 velocity = Vector2.zero;

	private new Rigidbody2D rigidbody;

	// Start is called before the first frame update
	void Start()
    {
		rigidbody = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{

		velocity.x = 1;
		velocity.y -= gravity * Time.deltaTime;

		rigidbody.MovePosition(rigidbody.position + velocity * moveSpeed * Time.deltaTime);

	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Floor"))
		{
			velocity.y = 0;
		}

		if (collision.gameObject.CompareTag("Box"))
		{
			var normal = collision.contacts[0].normal;
			if (normal.y > 0)
			{
				velocity.y = 0;
			}
		}
	}
}
