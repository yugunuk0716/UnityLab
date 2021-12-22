using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int usedBtnCount; // 사용중인 단어나 문장 버튼

    private void Start()
    {
        usedBtnCount = 0;
    }

    public void UsedBtnCountPlus()
    {
        usedBtnCount++;
        if(usedBtnCount == StageManager.Instance.GetCurStageBtnCount())
        {
            // 여기서 이제 리스트 다 받아 와서 체크

        }
    }

    public void UsedBtnCountMinus()
    {
        usedBtnCount--;
    }
}
