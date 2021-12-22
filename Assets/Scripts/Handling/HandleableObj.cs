using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleableObj : MonoBehaviour
{

    public Text codeText;    

    Vector3 originPos;
    private void Start()
    {
        originPos = this.transform.position;
    }

    public void BackToOriginPosition()
    {
        this.transform.position = originPos;
    }
}
