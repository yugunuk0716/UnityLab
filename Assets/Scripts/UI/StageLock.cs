using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageLock : MonoBehaviour
{
    public void SaveData(int stageNum) 
    {
        PlayerPrefs.SetInt($"{stageNum}", 1);
    }

    public int LoadData(int stageNum)
    {
        
        return PlayerPrefs.GetInt($"{stageNum}");
    }
}
