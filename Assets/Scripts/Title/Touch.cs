using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Touch : MonoBehaviour
{
    public ParticleSystem normalParticle;
    public ParticleSystem changeParticle;
    public CanvasGroup titleCanvasGroup;


    private void Start()
    {
        if (StageManager.instance.isClear)
        {
            titleCanvasGroup.gameObject.SetActive(false);
        }
    }

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
        SoundManager.Instance.PlaySfxSound(SoundManager.Instance.uiSfx, 1);

        yield return new WaitForSeconds(1f);

        titleCanvasGroup.DOFade(0,1f).OnComplete(() =>
        {
            change.startLifetime = 0.00001f;
            normalParticle.gameObject.SetActive(false);
            titleCanvasGroup.gameObject.SetActive(false);
        });
        yield return new WaitForSeconds(4.5f);
        changeParticle.gameObject.SetActive(false);
    }
}
