using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class CharatherNameCustomisation : MonoBehaviour
{
    private string regexCap = @"[A-Z]";
    private string regexLow = @"[a-z]";
    RegexOptions options = RegexOptions.Multiline;

    private Text charatherName;

    private void Start()
    {
        charatherName = gameObject.GetComponent<Text>();

    }

    private void Update()
    {
        if (charatherName.text.Length < 10)
        {
            foreach (char key in Input.inputString)
            {
                if (key == '\b') // has backspace/delete been pressed?
                {
                    if (charatherName.text.Length != 0)
                    {
                        charatherName.text = charatherName.text.Substring(0, charatherName.text.Length - 1);
                    }
                }
                else if ((key == '\n') || (key == '\r')) // enter/return
                {
                    print("User entered their name: " + charatherName.text);
                }
                else
                {
                    foreach (Match m in Regex.Matches(key.ToString(), regexCap, options))
                    {
                        charatherName.text += key;
                    }

                    foreach (Match m in Regex.Matches(key.ToString(), regexLow, options))
                    {
                        charatherName.text += key;
                    }
                }
            }
        }
    }
}
