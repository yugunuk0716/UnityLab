using System.Collections;
using System.Collections.Generic;
using System.IO;
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

        string[] strs = str.Split('^');
        int idx = 0;
		foreach (var item in strs)
		{
            idx++;
            print(item);
            AnswerManager.Instance.OutPutText(item,idx);
		}
        return str;
    }
}
