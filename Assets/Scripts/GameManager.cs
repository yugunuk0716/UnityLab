using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int usedBtnCount; // ������� �ܾ ���� ��ư

    private void Start()
    {
        usedBtnCount = 0;
    }

    public void UsedBtnCountPlus()
    {
        usedBtnCount++;
        if(usedBtnCount == StageManager.Instance.GetCurStageBtnCount())
        {
            // ���⼭ ���� ����Ʈ �� �޾� �ͼ� üũ

        }
    }

    public void UsedBtnCountMinus()
    {
        usedBtnCount--;
    }
}
