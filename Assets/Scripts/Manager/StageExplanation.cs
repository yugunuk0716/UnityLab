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
        TextAsset fileData = Resources.Load("Explanation" + StageManager.instance.stageIdx) as TextAsset;
        SetStageExplanationText(fileData.text);
    }

    public void SetStageExplanationText(string path)
    {
        string str = path;

        ChangeText(str);
    }
    
    public void ChangeText(string txt)
    {
        explanationText.text = txt;
    }
}
