using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class EffectManager : Singleton<EffectManager>
{
    public GameObject fullImageBase;

    #region CamEffect
    public CinemachineVirtualCamera vCam;

    CinemachineBasicMultiChannelPerlin cmPerlin;
    Tween camTween = null;
    #endregion

    public Sprite bloodScreenImage;


    private void Start()
    {
        cmPerlin = vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void SetCamShake(float duration, float power = 0.5f) 
    {
        if (camTween != null && camTween.IsActive())
        {
            camTween.Kill();
        }

        cmPerlin.m_AmplitudeGain = power;
        camTween = DOTween.To(() => cmPerlin.m_AmplitudeGain, value => cmPerlin.m_AmplitudeGain = value, 0, duration);
    }

    public void FalseEffect(float duration = 1.5f) //박스 사망시 이펙트
    {
        
        fullImageBase.GetComponent<SpriteRenderer>().sprite = bloodScreenImage;
     
        Invoke(nameof(SetImageFalse), duration);
    }

    private void SetImageFalse()// 일정 시간 후에 sprite가 들어있는 게임 오브젝트를 비활성화
    {
        fullImageBase.SetActive(false);
    }

}
