using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    public int coin = 0;
    public int hintItemCount = 0;


    private void Awake()
    {
        coin = PlayerPrefs.GetInt("coin", coin);
        hintItemCount = PlayerPrefs.GetInt("hint", hintItemCount);
    }



    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("coin", coin);
        PlayerPrefs.SetInt("hint", hintItemCount);
    }

    

}
