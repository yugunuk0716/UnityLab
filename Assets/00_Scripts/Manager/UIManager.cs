using DG.Tweening;
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


    public Button minMaxButton;
    public Image middle;
    public Image bottom;
    public Image topBG;
    // -700?? Y?? ?̵?

    private bool isDowned;


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

        minMaxButton.onClick.AddListener(() => ChangeTextBoxSize());

    }

    private void ChangeTextBoxSize()
    {

        Text t = minMaxButton.GetComponentInChildren<Text>();
        t.text = isDowned ? "??" : "??";

        DOTween.To(() => middle.transform.position, value => middle.transform.position = value, isDowned ? new Vector3(middle.transform.position.x, middle.transform.position.y + 700f, 0f) : new Vector3(middle.transform.position.x, middle.transform.position.y - 700f, 0f), 0.8f);
        DOTween.To(() => bottom.transform.position, value => bottom.transform.position = value, isDowned ? new Vector3(bottom.transform.position.x, bottom.transform.position.y + 700f, 0f) : new Vector3(bottom.transform.position.x, bottom.transform.position.y - 700f, 0f), 0.8f);
        DOTween.To(() => topBG.rectTransform.sizeDelta, value => topBG.rectTransform.sizeDelta = value, isDowned ? new Vector2(topBG.rectTransform.sizeDelta.x, 1050f) : new Vector2(topBG.rectTransform.sizeDelta.x, 1700f), 0.8f);
        DOTween.To(() => StageManager.instance.currentBase.rectTransform.offsetMin, value => StageManager.instance.currentBase.rectTransform.offsetMin = value, isDowned ? new Vector2(StageManager.instance.currentBase.rectTransform.offsetMin.x, 55f) : new Vector2(StageManager.instance.currentBase.rectTransform.offsetMin.x, -550f), 0.8f);
        isDowned = !isDowned;
      
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
