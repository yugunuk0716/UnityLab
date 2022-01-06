using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextArea : MonoBehaviour, IResettable
{
    public string Answer;
    public int index;
    public bool isUsed = false;
    public bool bCurAnswerisCurrect = false;

    public event EventHandler Death;

    public void Reset()
    {
        
    }
}
