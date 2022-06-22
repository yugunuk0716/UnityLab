using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager5 : GameManager4
{
    public GameObject eneymyHotdog;

    private void Start()
    {
        UpdateLife();
        UpdateHighScore();
        StartCoroutine(SpawnCroissant());
        StartCoroutine(SpawnHotdog());
    }

    IEnumerator SpawnHotdog()
    {
        while (true)
        {
            float randomX = transform.position.x + Random.Range(minPosition.x, maxPosition.x);
            Instantiate(eneymyHotdog, new Vector2(randomX, 3f), Quaternion.identity);

            yield return new WaitForSeconds(5f);
        }
    }
}
