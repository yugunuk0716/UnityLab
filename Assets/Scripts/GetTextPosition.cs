using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GetTextPosition : MonoBehaviour
{
    //테스트 스크립트입니다.
    //public TextMeshProUGUI tmp_text;
    public GameObject testobj;
    public Transform p;
    public string a = "<blink><color=#DCDCDC>asd</color></blink>aaaccc";
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TextMeshProUGUI tmp_text = GameObject.Find("text").GetComponent<TextMeshProUGUI>();
            tmp_text.text = a;
            tmp_text.text = tmp_text.GetParsedText().Replace("<blink>", string.Empty).Replace("</blink>", string.Empty);
            Debug.Log(tmp_text.text.Length);
        }
    }

    /*
    public void MakeAnswerArea(TextMeshProUGUI tmp_text)
    {
        tmp_text.ForceMeshUpdate();
        Vector3[] vertices = tmp_text.mesh.vertices;
        TMP_CharacterInfo charInfo = tmp_text.textInfo.characterInfo[0];
        int vertexIndex = charInfo.vertexIndex;
        Vector2 charMidTopLine = new Vector2((vertices[vertexIndex + 0].x + vertices[vertexIndex + 2].x) / 2, (charInfo.bottomLeft.y + charInfo.topLeft.y) / 2);
        Vector3 worldPos = tmp_text.transform.TransformPoint(charMidTopLine);
        GameObject charPositionGameObj = Instantiate(answerArea, parentTrm);
        charPositionGameObj.transform.position = worldPos;
    }
    */

}
