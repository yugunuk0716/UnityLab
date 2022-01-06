using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int usedBtnCount = 0; // ������� �ܾ ���� ��ư
    private int textAreaCount;

    public TextArea[] textAreas;

    private void Start()
    {
        StartCoroutine(CheckAndSetTextAreaCount());
    }

    IEnumerator CheckAndSetTextAreaCount()
    {
        yield return new WaitForSeconds(0.3f);

        textAreas = FindObjectsOfType<TextArea>();
        textAreaCount = textAreas.Length;
    }

    public void UsedBtnCountPlus()
    {
        usedBtnCount++;
        CheckClear();
    }

    public void CheckClear()
    {
        if (usedBtnCount == textAreaCount)
        {
            usedBtnCount = 0; // �����̵� �ƴϵ� ����� ���� 0���� �ʱ�ȭ ���ֱ�!

            foreach (TextArea item in GetTextAreas())
            {
                if (!item.bCurAnswerisCurrect)
                {
                    AnswerCheck.Instance.TextAreaClear();
                    //EffectManager.Instance.SetCamShake(1);
                    EffectManager.Instance.FalseEffect();
                    return;
                }
            }
            StageManager.instance.isClear = true;
            UIManager.Instance.OpenPanel("clear");
            StageManager.instance.SaveData(false);
            Debug.Log("�����Դϴ�");
        }
    }

    public TextArea[] GetTextAreas() 
    {
        return textAreas;
    }
}
