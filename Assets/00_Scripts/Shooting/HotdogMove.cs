using System.Collections;
using UnityEngine;

public class HotdogMove : EnemyMove
{
    [SerializeField]
    private GameObject bulletMustard; 

    protected override void Start()
    {
        base.Start();
        StartCoroutine(Fire());
    }

    protected override void Update()
    {
        if (isDead) return;
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        transform.Translate(Vector2.down * 0.3f * Time.deltaTime);
        if (transform.localPosition.x > gameManager.maxPosition.x - 5f)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator Fire()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("¤¾¤·");
        Instantiate(bulletMustard, transform.position, Quaternion.Euler(0f, 0f, 180f));
    }
}
