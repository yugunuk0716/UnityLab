using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.5f;

    Vector2 targetPosition = Vector2.zero;
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            targetPosition =Input.mousePosition;

			//targetPosition.x = Mathf.Clamp(targetPosition.x, gameManager.minPosition.x, gameManager.maxPosition.x);
			targetPosition.y = Mathf.Clamp(targetPosition.y, 370f, 1540f);

			transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime* speed);
        }
    }

}