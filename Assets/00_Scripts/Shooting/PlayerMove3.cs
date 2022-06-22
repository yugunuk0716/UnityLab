using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove3 : MonoBehaviour
{
    private float speed = 2f;
    [SerializeField]
    private Transform firePosition;
    [SerializeField]
    private GameObject bulletPrfab;

    private GameManager3 gameManager;
    private Collider2D col;
    private SpriteRenderer spriteRenderer;

    Vector2 targetPosition = Vector2.zero;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager3>();
        col = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(Fire());
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, -1, 0);

            targetPosition.x = Mathf.Clamp(targetPosition.x, (-10) + gameManager.minPosition.x, (-10) + gameManager.maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, (-3) + gameManager.minPosition.y, (-3) + gameManager.maxPosition.y);

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
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
            Destroy(collision.gameObject);
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