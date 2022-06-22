using System.Collections;
using UnityEngine;

public class GameManager2 : GameManager1
{
    public GameObject enemyCroissant;

    private void Start()
    {
        StartCoroutine(SpawnCroissant());
    }

    IEnumerator SpawnCroissant()
    {
        while (true)
        {
            float randomX = transform.position.x + Random.Range(minPosition.x, maxPosition.x);
            int count = 0;
            while (count < 3)
            {
                Instantiate(enemyCroissant, new Vector2(randomX, 3f), Quaternion.identity);
                yield return new WaitForSeconds(0.3f);
                count++;
            }

            float delay = Random.Range(2f, 5f);
            yield return new WaitForSeconds(delay);
        }
    }
}