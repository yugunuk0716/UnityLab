using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int usedBtnCount = 0; // ������� �ܾ ���� ��ư
    private int textAreaCount;

    public GameObject answerParent;
    public TextArea[] textAreas;

    private void Start()
    {
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
                    return;
                }
            }

            UIManager.Instance.OpenPanel("clear");
            StageManager.instance.SaveData();
            Debug.Log("�����Դϴ�");
        }
    }

    public TextArea[] GetTextAreas() 
    {
        return textAreas;
    }
}
