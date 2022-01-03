using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public class CreateAnswer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //print(ReadTxt(1));
        ReadTxt(1);
    }

    // Update is called once per frame
    private string ReadTxt(int stageIdx)
    {
        string filePath = Application.dataPath + "/Resources/text"+ stageIdx + ".txt";
        
        string str = File.ReadAllText(filePath);

        if(str.Contains("<newLine>"))
		{
           str = str.Replace("<newLine>", "^");
		}
        if (str.Contains("<t1>"))
        {
            str = str.Replace("<t1>", "  ");
        }
        if (str.Contains("<t2>"))
        {
            str = str.Replace("<t2>", "    ");
        }
        if (str.Contains("<t3>"))
        {
            str = str.Replace("<t3>", "      ");
        }
        //\W<>=#*

        //string[] strs = str.Split(new string[] { "^","<blink>","</blink>" }, StringSplitOptions.None);
        string[] strs = str.Split('^');
        int idx = 0;
        foreach (var item in strs)
        {
            idx++;
            //print(item);
            AnswerManager.Instance.OutPutText(item,idx);
        }



        return str;
    }
}
//gayjoygo