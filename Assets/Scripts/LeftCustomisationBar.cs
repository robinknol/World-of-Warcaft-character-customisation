using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LeftCustomisationBar : MonoBehaviour
{
    public void SetText(string text)
    {
        SkinColorText txt = transform.Find("Text").GetComponent<SkinColorText>();
        txt.text = text;
    }
}
