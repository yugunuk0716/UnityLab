using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class HintPopUp : PopUp
{
    public Button hintUseButton;
    public Text currentCointText;
    public Button hintCancleButton;
    public Button exceptionCheckButton;
    public GameObject exceptionPanel;

    protected override void Awake()
    {
        base.Awake();

        hintCancleButton.onClick.AddListener(() => { Close(); });
        hintUseButton.onClick.AddListener(() => { UseHintButton(); });
        exceptionCheckButton.onClick.AddListener(() => { exceptionPanel.SetActive(false); });
    }

    public override void Open(int closeCount = 1)
    {
        base.Open(closeCount);
        currentCointText.text = $"보유 코인: {ItemManager.Instance.coin}";
    }

    public override void OnClickHomeBtn(string str)
    {
        base.OnClickHomeBtn(str);
    }

    public void UseHintButton()
    {
        if(ItemManager.Instance.coin >= 10)
        {
            ItemManager.Instance.coin -= 10;
            //여기서 힌트 띄워주기
            ItemManager.Instance.canSeeHint = true;
            print("구매");
            Close();
        }
        else
        {
            if (ItemManager.Instance.canSeeHint)
                return;
            exceptionPanel.SetActive(true);
        }
    }

    
}
