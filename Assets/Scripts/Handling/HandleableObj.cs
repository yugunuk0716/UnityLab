using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleableObj : MonoBehaviour
{
    public string codeText;
        
    Vector3 originPos;
    private void Start()
    {
        this.GetComponentInChildren<Text>().text = codeText;

        originPos = this.transform.position;
    }

    public void BackToOriginPosition()
    {
        this.transform.position = originPos;
    }
}
