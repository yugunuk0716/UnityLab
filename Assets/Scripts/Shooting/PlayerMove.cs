using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.5f;

    private GameManager4 gameManager;

    Vector2 targetPosition = Vector2.zero;

    private void Start()
    {
        gameManager = FindObjectOfType< GameManager4 > ();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            targetPosition.x = Mathf.Clamp(targetPosition.x, gameManager.minPosition.x, gameManager.maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, gameManager.minPosition.y, gameManager.maxPosition.y);

            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPosition, Time.deltaTime* speed);
        }
    }

}