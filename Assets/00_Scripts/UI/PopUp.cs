using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PopUp : MonoBehaviour
{
    private CanvasGroup canvasGroup; //�гο� �ٿ��� ĵ�����׷�



    protected virtual void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>(); //ĵ���� �׷��� ������
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>(); //������� �������
        }
        //ĵ�����׷� �ʱ�ȭ
        canvasGroup.interactable = false;
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
    }

    public virtual void Open(int closeCount = 1) // UI Ȱ��ȭ �Լ�
    {
        SetAlpha(true);
    }
    public virtual void Close() // UI ��Ȱ��ȭ �Լ�
    {
        SetAlpha(false);
    }
    public virtual void OnClickHomeBtn(string str) // Ȩ��ư �Լ�
    {
        Close();
        SceneManager.LoadScene(str);
        
    }

    public virtual void OnClickRetryBtn() // �ٽý��� �Լ�
    {
        
        Close();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
     
    }


    public virtual void SetAlpha(bool on) //open�� close�� �� ������ �޾� ���ĸ� �ٲ���
    {
        // DG.Tweening.Core.Debugger.LogSafeModeReport(this);
        DOTween.To(() => canvasGroup.alpha, value => canvasGroup.alpha = value, on ? 1f : 0f, 0.8f).OnComplete(() => {
            canvasGroup.interactable = on;
            canvasGroup.blocksRaycasts = on;
        });
    }


}

