using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    protected float speed = 0.5f;

    protected bool isDead = false;

    protected GameManager gameManager;

    protected virtual void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    protected virtual void Update()
    {
        if (isDead) return;

        transform.Translate(Vector2.down* speed);

        if (transform.localPosition.y<gameManager.minPosition.y - 2f)
        {
            Destroy(gameObject);
        }
    }
}