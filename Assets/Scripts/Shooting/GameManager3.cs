using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager3 : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyCroissant;

    [SerializeField]
    private Text lifeText;

    public Vector2 minPosition;
    public Vector2 maxPosition;

    public int life = 2;

    private void Start()
    {
        UpdateLife();
        StartCoroutine(SpawnCroissant());
    }

    IEnumerator SpawnCroissant()
    {
        while (true)
        {
            float randomX = Random.Range(-6f, 6f);
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

    public void UpdateLife()
    {
        lifeText.text = string.Format("x {0}", life);
    }
}