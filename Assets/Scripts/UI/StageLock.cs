using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageLock : MonoBehaviour
{
    public void SaveData(int stageNum) 
    {
        PlayerPrefs.SetInt($"{stageNum}", 1);
    }

    public void SaveData( bool isInGame)
    {
        int value = 0;
        if (isInGame) 
        {
            value = 1;
        }
        else
        {
            value = 0;
        }
         PlayerPrefs.SetInt("IsInGame", value);
    }


    public int LoadData(int stageNum)
    {
        
        return PlayerPrefs.GetInt($"{stageNum}");
    }

    public int LoadData(string name) 
    {
        return PlayerPrefs.GetInt(name);
    }



    private void OnApplicationQuit()
    {
        SaveData(false);
    }
}
