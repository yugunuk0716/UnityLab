using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GM : Singleton<GM>
{
    public int usedBtnCount = 0; // ������� �ܾ ���� ��ư
    private int textAreaCount;
    public InGameOpen inGameOpen;

    public TextArea[] textAreas;

    private void Start()
    {
        StartCoroutine(CheckAndSetTextAreaCount());
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (Resources.Load("Stage/Stage " + StageManager.instance.stageIdx) == null)
            {
                UIManager.Instance.OpenPanel("clear");
            }
            else
            {
                inGameOpen.Clear();
            }
            StageManager.instance.isClear = true;
            ItemManager.Instance.canSeeHint = false;
            StageManager.instance.SaveData();
            Debug.Log("�ùķ��̼� ȭ�� �÷���!");
        }
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
            //UIManager.Instance.OpenPanel("clear");
            ItemManager.Instance.coin += 10;
            if (Resources.Load("Stage/Stage " + StageManager.instance.stageIdx) == null)
            {
                UIManager.Instance.OpenPanel("clear");
            }
            else
            {
                inGameOpen.Clear();
            }
            StageManager.instance.isClear = true;
            ItemManager.Instance.canSeeHint = false;
            StageManager.instance.SaveData();
            Debug.Log("�����Դϴ�");
        }
    }

    public TextArea[] GetTextAreas() 
    {
        return textAreas;
    }
}