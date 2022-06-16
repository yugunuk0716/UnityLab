using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager2 : GameManager
{
    [SerializeField]
    private GameObject enemyCroissant;

    public Vector2 minPosition;
    public Vector2 maxPosition;

    private void Start()
    {
        StartCoroutine(SpawnCroissant());
    }

    IEnumerator SpawnCroissant()
    {
        while (true)
        {
            float randomX = transform.position.x+Random.Range(-6f, 6f);
            int count = 0;
            while (count < 5)
            {
                Instantiate(enemyCroissant, new Vector2(randomX, 15f), Quaternion.identity);
                yield return new WaitForSeconds(0.2f);
                count++;
            }

            float delay = Random.Range(2f, 5f);
            yield return new WaitForSeconds(delay);
        }
    }
}