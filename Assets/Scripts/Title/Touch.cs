using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Touch : MonoBehaviour
{
    public ParticleSystem normalParticle;
    public ParticleSystem changeParticle;
    public CanvasGroup titleCanvasGroup;


    public void ChangeTitleStart()
    {
        StartCoroutine(ChangeTitle());
    }

    public IEnumerator ChangeTitle()
    {
        ParticleSystem.MainModule normal = normalParticle.main;
        ParticleSystem.MainModule change = changeParticle.main;

        normal.startLifetime = 0.00001f;

        changeParticle.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);

        titleCanvasGroup.DOFade(0,.5f).OnComplete(() =>
        {
            change.startLifetime = 0.00001f;
            normalParticle.gameObject.SetActive(false);
            titleCanvasGroup.gameObject.SetActive(false);
        });
        yield return new WaitForSeconds(4f);
        changeParticle.gameObject.SetActive(false);
    }
}
