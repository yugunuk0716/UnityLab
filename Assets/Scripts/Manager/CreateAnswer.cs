using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class CreateAnswer : MonoBehaviour
{
    [SerializeField] private GameObject buttonParent;
    [SerializeField] private GameObject parent;
    [SerializeField] private GameObject basePrefab;
    [SerializeField] private GameObject buttonPrefab;

    private List<GameObject> scriptsArray = new List<GameObject>();
    void Start()
    {
		for (int i = 0; i < StageManager.instance.stageInScriptsCount[StageManager.instance.stageIdx]; i++)
		{
            CreateBase(i + 1);
        }
    }

    private void CreateBase(int i)
    {
        GameObject buttonObj = Instantiate(buttonPrefab, buttonParent.transform);
        GameObject baseObj = Instantiate(basePrefab, parent.transform);
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
        ReadTxt($"{idx}-{StageManager.instance.stageInScriptsCount[i]}", baseParent);
    }

    private string ReadTxt(string stageIdx,GameObject parent)
    {
        string filePath = Application.dataPath + "/Resources/Question " + stageIdx + ".txt";

        print(filePath);
        string str = File.ReadAllText(filePath);

        if(str.Contains("<newLine>"))
		{
           str = str.Replace("<newLine>", "^");
		}
        if (str.Contains("<1>"))
        {
            str = str.Replace("<1>", "  ");
        }
        if (str.Contains("<2>"))
        {
            str = str.Replace("<2>", "    ");
        }
        if (str.Contains("<3>"))
        {
            str = str.Replace("<3>", "      ");
        }
        if (str.Contains("<4>"))
        {
            str = str.Replace("<4>", "        ");
        }
        //\W<>=#*

        string[] strs = str.Split('^');
        int idx = 0;
        foreach (var item in strs)
        {
            idx++;
            AnswerManager.Instance.OutPutText(item,idx, parent);
        }
        return str;
    }
}
