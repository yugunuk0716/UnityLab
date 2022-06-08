using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.5f;

    private GameManager4 gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager4>();
    }

    private void Update()
    {
        transform.Translate(Vector2.up * speed);

        if (transform.localPosition.y > gameManager.maxPosition.y + 2f)
        {
            Destroy(gameObject);
        }
    }
}