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
    private Image image;

    protected virtual void Start()
    {
        gameManager = FindObjectOfType<GameManager>() as GameManager4;
        image = GetComponent<Image>();
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
        image.color = new Color(1f, 1f, 1f, 0f);
        yield return new WaitForSeconds(0.1f);
        image.color = new Color(0f, 0f, 0f, 0f);
    }
}