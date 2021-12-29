using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageManager : Singleton<StageManager>
{
    public int stageIdx = 1;

    private Dictionary<int, int> stage_AnswerFiledCount = new Dictionary<int, int>();
    //private int[] stage~~ = new
    //stage[1]
    public Transform btnParent; //버튼 부모
    private Button[] stageBtns; //인게임 이동 버튼들

    private void Start()
    {
        #region 버튼 관련
        stageBtns = btnParent.GetComponentsInChildren<Button>();

        for (int i = 0; i < stageBtns.Length; i++)
        {
            int idx = i;
            stageBtns[idx].onClick.AddListener(() =>
            {
                stageIdx = i + 1;
                //stageIdx의 답안 카운트 가져오기
                SceneManager.LoadScene("InGame");

            });
        }   
        #endregion
    }

    public int GetCurStageBtnCount()
    {
        return stage_AnswerFiledCount[stageIdx];
    }
}
