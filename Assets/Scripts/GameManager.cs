using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    public List<string> realAnswerList = new List<string>();
    public List<string> userAnswerList = new List<string>();



    private void Awake()
    {
        instance = this;
    }



}
