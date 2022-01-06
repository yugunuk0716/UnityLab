using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;

    public int stageIdx = 1;
    public int[] stageInScriptsCount;
    private int buttonCount;

    public string stageName = "";

    public bool isClear = false;

    public Transform btnParent; //버튼 부모
    public Button[] stageBtns { get; private set; } //인게임 이동 버튼

    private StageLock stageLock;


    private void Awake()
    {
        if(instance != null)
        {
            Destroy(instance.gameObject);
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        stageLock = GetComponent<StageLock>();
        stageInScriptsCount = new int[]
        {
            -1,1,2,3,2,1,2,2,1
        };
        #region 버튼 관련
        stageBtns = btnParent.GetComponentsInChildren<Button>();
        buttonCount = stageBtns.Length;

        for (int i = 0; i < buttonCount; i++)
        {
            int idx = i;

            if ( idx != 0 && stageLock.LoadData(idx) == 0) 
            {
                stageBtns[idx].interactable = false;
            }
            stageBtns[idx].onClick.AddListener(() =>
            {
                SoundManager.Instance.PlaySfxSound(SoundManager.Instance.uiSfx, 1);
                stageIdx = idx + 1;
                stageName = stageBtns[idx].GetComponentInChildren<Text>().text;
                SceneManager.LoadScene("InGame");
            });
        }
        #endregion
    }

    public void SaveData() 
    {
        stageLock.SaveData(stageIdx);
    }
}
