using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager3 : GameManager2
{
    public Text lifeText;

    public int life = 2;

    private void Start()
    {
        UpdateLife();
        StartCoroutine(SpawnCroissant());
    }

    public IEnumerator SpawnCroissant()
    {
        while (true)
        {
            float randomX = transform.position.x + Random.Range(minPosition.x, maxPosition.x);
            int count = 0;
            while (count < 5)
            {
                Instantiate(enemyCroissant, new Vector2(randomX, 3f), Quaternion.identity);
                yield return new WaitForSeconds(0.3f);
                count++;
            }

            float delay = Random.Range(2f, 5f);
            yield return new WaitForSeconds(delay);
        }
    }

    public void UpdateLife()
    {
        lifeText.text = string.Format("x {0}", life);
    }
}