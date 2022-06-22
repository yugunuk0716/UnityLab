using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove2 : MonoBehaviour
{
    private float speed = 2f;
    [SerializeField]
    private Transform firePosition;
    [SerializeField]
    private GameObject bulletPrfab;

    private GameManager1 gameManager;

    Vector2 targetPosition = Vector2.zero;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager1>();
        StartCoroutine(Fire());
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0,-1,0);

            targetPosition.x = Mathf.Clamp(targetPosition.x, (-10) + gameManager.minPosition.x, (-10) + gameManager.maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, (-3)+gameManager.minPosition.y, (-3)+gameManager.maxPosition.y);

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

}
