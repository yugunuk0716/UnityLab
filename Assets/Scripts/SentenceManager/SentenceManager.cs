using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SentenceManager : MonoBehaviour
{
    public InputField inputString;
    public InputField inputTab;
    public List<GameObject> colors;
    public Button IsAnswer;
    public Button IsSpace;
    public Button IsNewLine;
    public Button setText;
    public Button toJson;
    public Text test;

    public string resultText;

    public bool isAnswerboolen = false;
    public bool isSpaceboolen = false;
    public bool isNewLineBoolen = false;

    public string colorcode = null;

    public int fileindex = 0;


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
        else if(index == 2)
        {
            if (!isNewLineBoolen)
                color = Color.green;
            else
                color = Color.red;
            isNewLineBoolen = !isNewLineBoolen;
            IsNewLine.GetComponent<Image>().color = color;
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

        if (isNewLineBoolen)
            str += "<newLine>";

        if (!inputTab.text.Equals("0"))
            str += $"<{int.Parse(inputTab.text)}>";

        if (isAnswerboolen)
            str +="<blink>" + AnswerCheck.Instance.SetTextColor(inputString.text, colorcode) + "</blink>";
        else
            str += AnswerCheck.Instance.SetTextColor(inputString.text, colorcode);


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

    public void ToTextFileSave()
    {
        File.WriteAllText(Application.dataPath + $"/04.textfiles/text{fileindex}.txt", resultText);
        Debug.Log("저장 완료, 저장된 내용:" + File.ReadAllText(Application.dataPath + $"/04.textfiles/text{fileindex}.txt"));
        fileindex++;
    }
}
