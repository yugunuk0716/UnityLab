using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class StageExplanation : MonoBehaviour
{
    public Text explanationText;


    private void Start()
    {
        string path = Application.dataPath + "/Resources/Explanation" + StageManager.instance.stageIdx + ".txt";

        SetStageExplanationText(path);
    }

    public void SetStageExplanationText(string path)
    {
        string str = File.ReadAllText(path);

        ChangeText(str);
    }
    
    public void ChangeText(string txt)
    {
        explanationText.text = txt;
    }
}
