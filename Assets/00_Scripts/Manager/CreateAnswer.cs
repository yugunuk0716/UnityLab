using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreateAnswer : MonoBehaviour
{
    [SerializeField] private Transform buttonParent;
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject basePrefab;
    [SerializeField] private GameObject buttonPrefab;

    //보라색만 체크해놨는데 나머지는 알아서 채워 넣으세요
    //회색은 수정중에 있습니다 몰?루요
    //단어 뒤에 공백 하나 들어가야해요
	readonly string[][] wordColor =
	{
		new string[]{ "while ","switch ", "if ", "return ", "yield " ,"for ","foreach ","case ","default "},
	};
    //색깔 순서임
    //Purple =0,
    //Blue, 예약어 색일걸
    //Skyblue, 지역변수 색일걸
    //Yellow, 함수 색일걸
    //TumbleWeed, 문자열
    //Green, 클래스명 색일걸
    //Cyan, Vector 색일걸
    //Gray 디폴트 색일걸
    readonly string[] ColorData = { 
        "#<color=#D8A0DF>", 
        "#<color=#569CDU>", 
        "#<color=#9CDCFE>",
        "#<color=#DCDCAA>",
        "#<color=#D39D85>",
        "#<color=#4EC9B0>",
        "#<color=#B5CEA8>",
        "#<color=#DCDCDC>"};

    private List<GameObject> scriptsArray = new List<GameObject>();
    void Start()
    {


        for (int i = 0; i < StageManager.instance.stageInScriptsCount[StageManager.instance.stageIdx]; i++)
		{
            CreateBase(i + 1);
        }
        TextAsset fileData = Resources.Load("Answer" + StageManager.instance.stageIdx) as TextAsset;
        Debug.Log(fileData.text);
        //string answerTextfilePath = Application.persistentDataPath + "/Resources/Answer" + StageManager.instance.stageIdx + ".txt";
        string answer = fileData.text;

        StartCoroutine(AnswerManager.Instance.AnswerLoad(answer));
    }

    IEnumerator SetScriptsName(string stageIdx, GameObject buttonObj)
    {
        TextAsset fileData = Resources.Load("Question " + stageIdx) as TextAsset;
        string str = fileData.text;
        string[] strs = str.Split(new string[] { "class", ":" }, StringSplitOptions.None);

        TextMeshProUGUI t = buttonObj.GetComponentInChildren<TextMeshProUGUI>();
        t.text = strs[1];
        yield return null;
        t.text = $"{t.GetParsedText().Substring(0, t.GetParsedText().Length - 1)}.cs";
    }

    private void CreateBase(int i)
    {
        GameObject buttonObj = Instantiate(buttonPrefab, buttonParent.transform);
        GameObject baseObj = Instantiate(basePrefab, parent.transform);
        StageManager.instance.currentBase = baseObj.GetComponent<Image>();
        GameObject baseParent = baseObj.transform.Find("Scroll View").gameObject.transform.Find("Viewport").gameObject.transform.Find("Content").gameObject;
            
        scriptsArray.Add(baseObj);
        buttonObj.GetComponent<Button>().onClick.AddListener(() =>
        {
		    for (int i = 0; i < scriptsArray.Count; i++)
		    {
                scriptsArray[i].SetActive(false);
            }
            baseObj.SetActive(true);
        });
        int idx = StageManager.instance.stageIdx;

        StartCoroutine(SetScriptsName($"{idx}-{StageManager.instance.stageInScriptsCount[i]}", buttonObj));
        ReadTxt($"{idx}-{StageManager.instance.stageInScriptsCount[i]}", baseParent);
    }

    private string ReadTxt(string stageIdx,GameObject parent)
    {
        TextAsset fileData = Resources.Load("Question " + stageIdx) as TextAsset;
        Debug.Log(fileData.text);
        string str = fileData.text;

        if (str.Contains("<newLine>")) str = str.Replace("<newLine>", "^");
        if (str.Contains("<1>"))    str = str.Replace("<1>", "  ");
        if (str.Contains("<2>"))    str = str.Replace("<2>", "    ");
        if (str.Contains("<3>"))    str = str.Replace("<3>", "      ");
        if (str.Contains("<4>"))    str = str.Replace("<4>", "        ");

        SetReservedWordColor(str, WordColor.Purple);
        SetReservedWordColor(str, WordColor.Blue);
        SetReservedWordColor(str, WordColor.Skyblue);
        SetReservedWordColor(str, WordColor.Green);
        SetReservedWordColor(str, WordColor.Cyan);
        SetReservedWordColor(str, WordColor.TumbleWeed);
        SetReservedWordColor(str, WordColor.Yellow);

        //\W<>=#*

        string[] strs = str.Split('^');
        int idx = 0;

        foreach (var item in strs)
        {
            idx++;
            AnswerManager.Instance.OutPutText(item,idx, parent);
            StartCoroutine(WaitMilliSec());
        }
        
        return str;
    }

    void SetReservedWordColor(string str,WordColor colorName)
    {
        if (colorName == WordColor.Gray)
        {
            
        }
        if(wordColor.Length <= (int)colorName)
        {
            return;
        }
        for (int j = 0; j < wordColor[(int)colorName].Length; j++)
        {
            if (str.Contains(wordColor[(int)colorName][j]))
            {
                str = str.Replace(wordColor[(int)colorName][j], ColorData[(int)colorName] + wordColor[0][j].Substring(0, wordColor[(int)colorName][j].Length - 1) + "</color>");
            }
        }
    }

    IEnumerator WaitMilliSec()
    {
        yield return new WaitForSeconds(0.1f);
        
        AnswerManager.Instance.nowMaxTextLength = 0;
    }

}
public enum WordColor
{
	Purple = 0,
	Blue,
	Skyblue,
	Yellow,
	TumbleWeed,
	Green,
	Cyan,
	Gray
}
