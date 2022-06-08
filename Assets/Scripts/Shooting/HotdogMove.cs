using System.Collections;
using System.Collections.Generic;
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
        transform.Translate(Vector2.right * speed);
        if (transform.localPosition.x > gameManager.maxPosition.x + 1f)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator Fire()
    {
        yield return new WaitForSeconds(2f);

        Instantiate(bulletMustard, transform.localPosition, Quaternion.Euler(0f, 0f, 180f));
    }
}
