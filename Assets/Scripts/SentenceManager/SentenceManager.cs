using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SentenceManager : MonoBehaviour
{
    public InputField inputString;
    public List<GameObject> colors;
    public Button IsAnswer;
    public Button IsSpace;
    public Button setText;
    public Button toJson;
    public Text test;

    public string resultText;

    public bool isAnswerboolen = false;
    public bool isSpaceboolen = false;

    public string colorcode = null;


    /*   public void Update()
       {
           if (colorcode != null)
               inputString.text = $"<color = #{colorcode}>{inputString.text}</color>";
       }
   */
    public void SetIsAnswerOrSpace(int index)
    {
        Color color;


        if(index == 0)
        {
            if (!isAnswerboolen)
                color = Color.green;
            else
                color = Color.red;
            isAnswerboolen = !isAnswerboolen;
            IsAnswer.GetComponent<Image>().color = color;
        }
        else if(index == 1)
        {
            if (!isSpaceboolen)
                color = Color.green;
            else
                color = Color.red;
            isSpaceboolen = !isSpaceboolen;
            IsSpace.GetComponent<Image>().color = color;
        }
    }

    public void SelectColor(int index)
    {
        colorcode ="#" + ColorUtility.ToHtmlStringRGB(colors[index].GetComponent<Image>().color);
        TypingChangeColor();
    }

    public void SetText()
    {
        string str = null;

        if (isSpaceboolen)
            str += " ";
        else
            str += "";

        if (isAnswerboolen)
            str +="<blink>" + AnswerCheck.Instance.SetTextColor(inputString.text, colorcode) + "</blink>";
        else
            str +=AnswerCheck.Instance.SetTextColor(inputString.text, colorcode);

        resultText += str;
        test.text = resultText;
    }

    public void TypingChangeColor()
    {
        if (colorcode == null)
        {
            Debug.Log("컬러가 정해지지 않았습니다");
            return;
        }
            
        Color color;    
        ColorUtility.TryParseHtmlString(colorcode,out color);
        inputString.GetComponent<Image>().color = color;
    }
}
