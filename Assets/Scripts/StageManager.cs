using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageManager : Singleton<StageManager>
{

    /// <summary>
    /// 이 변수로 인게임에서 조절을 해주면 되지 않을까 1부터 시작함
    /// </summary>
    public int stageIdx = 1;

    public Transform btnParent; //버튼 부모
    private Button[] stageBtns; //인게임 이동 버튼들

    private void Awake()
    {
        


    }

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
                SceneManager.LoadScene("InGame");
            });
        }
        #endregion


    }
}
