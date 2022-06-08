using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove2 : MonoBehaviour
{
    [SerializeField]
    protected float speed = 0.5f;

    [SerializeField]
    private int rewardScore = 100;
    [SerializeField]
    private int hp = 2;

    protected bool isDead = false;

    protected GameManager4 gameManager;
    private SpriteRenderer spriteRenderer;

    protected virtual void Start()
    {
        gameManager = FindObjectOfType<GameManager4>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected virtual void Update()
    {
        if (isDead) return;

        transform.Translate(Vector2.down * speed);

        if (transform.localPosition.y < gameManager.minPosition.y - 2f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            hp--;
            Destroy(collision.gameObject);

            if (hp <= 0)
            {
                isDead = true;
                gameManager.score += rewardScore;
                gameManager.UpdateScore();

                Destroy(this.gameObject, 0.5f);
            }
            else
            {
                StartCoroutine(DamageEffect());
            }
        }
    }

    private IEnumerator DamageEffect()
    {
        spriteRenderer.material.SetColor("_Color", new Color(1f, 1f, 1f, 0f));
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.material.SetColor("_Color", new Color(0f, 0f, 0f, 0f));
    }
}