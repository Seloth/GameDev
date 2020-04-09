using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BoxScript : MonoBehaviour
{
    private bool isEmpty = false;

    void Start()
    {

    }

    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var normal = other.contacts[0].normal;

            if (normal.y > 0)
            {
                if (!isEmpty)
                {
                    GameObject mushroomPrefab = Resources.Load("Prefabs/Mushroom") as GameObject;
                    GameObject mushroom = Instantiate(mushroomPrefab, transform.position + new Vector3(0, 0.15f, 0), Quaternion.identity);
                    isEmpty = true;

                }
            }

        }
    }
}
