using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private SpriteRenderer render;

    protected virtual void Start()
    {
        gameManager = FindObjectOfType<GameManager4>();
        render = GetComponent<SpriteRenderer>();
    }

    protected virtual void Update()
    {
        if (isDead) return;

        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.localPosition.y < gameManager.minPosition.y - 5f)
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

                Destroy(this.gameObject);
            }
            else
            {
                StartCoroutine(DamageEffect());
            }
        }
    }

    private IEnumerator DamageEffect()
    {
        render.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        render.color = Color.white;
    }
}