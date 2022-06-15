using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public Transform panelParent;
    public MenuPopUp menuPopUp;
    public ClearPopUp clearPopUp;
    public HintPopUp hintPopUp;
    public TextInfoPopUp tInfoPopUp;


    public Button hintButton;
    public Button menuBtn;
    public Fade fade;

    private CanvasGroup cv;
    public Dictionary<string, PopUp> panelDic = new Dictionary<string, PopUp>();
    Stack<PopUp> panelStack = new Stack<PopUp>();


    void Start()
    {
        fade = GetComponent<Fade>();
        cv = panelParent.GetComponent<CanvasGroup>();
        if (cv == null)
        {
            cv = panelParent.gameObject.AddComponent<CanvasGroup>();
        }
        cv.alpha = 0;
        cv.interactable = false;
        cv.blocksRaycasts = false;

        panelDic.Add("inGameMenu", Instantiate(menuPopUp, panelParent));
        panelDic.Add("clear", Instantiate(clearPopUp, panelParent));
        panelDic.Add("hint", Instantiate(hintPopUp, panelParent));
        panelDic.Add("tInfo", Instantiate(tInfoPopUp, panelParent));

        hintButton.onClick.AddListener(() => 
        {
            OpenPanel("hint");
        });
        menuBtn.onClick.AddListener(() => 
        {
            OpenPanel("inGameMenu");
        }); 
    }


    public void OpenPanel(string name, int closeCount = 1) 
    {
        if (panelStack.Count == 0)
        {
            cv.alpha = 1f;
            cv.interactable = true;
            cv.blocksRaycasts = true;
        }
        panelStack.Push(panelDic[name]);
        panelDic[name].Open(closeCount);
    }

    public void ClosePanel() 
    {
        panelStack.Pop().Close();
        if (panelStack.Count == 0)
        {
            cv.alpha = 0f;
            cv.interactable = false;
            cv.blocksRaycasts = false;
        }
    }

}
