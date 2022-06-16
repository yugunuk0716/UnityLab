using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.5f;

    private GameManager1 gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>() as GameManager1;
    }

    private void Update()
    {
        transform.Translate(Vector2.up * speed);

        if (transform.position.y > gameManager.maxPosition.y + 2f)
        {
            Destroy(gameObject);
        }
    }
}