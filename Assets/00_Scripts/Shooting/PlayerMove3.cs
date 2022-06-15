using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove3 : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.5f;
    [SerializeField]
    private Transform firePosition;
    [SerializeField]
    private GameObject bulletPrfab;

    private GameManager4 gameManager;
    private Collider2D col;
    private SpriteRenderer spriteRenderer;

    Vector2 targetPosition = Vector2.zero;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager4>();
        col = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(Fire());
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            targetPosition.x = Mathf.Clamp(targetPosition.x, gameManager.minPosition.x, gameManager.maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, gameManager.minPosition.y, gameManager.maxPosition.y);

            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPosition, Time.deltaTime * speed);
        }
    }

    IEnumerator Fire()
    {
        while (true)
        {

            GameObject.Instantiate(bulletPrfab, firePosition.position, Quaternion.identity);

            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator Revive()
    {
        col.enabled = false;
        int count = 0;
        while (count < 5)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.25f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.25f);
            count++;
        }
        col.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (gameManager.life > 0)
            {
                gameManager.life--;
                gameManager.UpdateLife();
                StartCoroutine(Revive());
            }
            else
            {
                //게임오버
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}