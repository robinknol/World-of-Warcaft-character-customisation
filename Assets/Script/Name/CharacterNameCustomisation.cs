using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class CharacterNameCustomisation : MonoBehaviour
{
    private string regex = @"[A-Za-z]";
    RegexOptions options = RegexOptions.Multiline;
    
    [SerializeField] private Text charatherName;

    private void Start()
    {
        charatherName = this.gameObject.GetComponent<Text>();

        charatherName.text = "";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Backspace();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Enter();
        }
        Reg();
       
    }

    private void Backspace()
    {
        if (charatherName.text.Length != 0)
        {
            charatherName.text = charatherName.text.Substring(0, charatherName.text.Length - 1);
        }
    }

    private void Enter()
    {
        print("User entered their name: " + charatherName.text);
    }

    private void Reg()
    {
        if (charatherName.text.Length < 12)
        {
            foreach (char key in Input.inputString)
            {
                foreach (Match m in Regex.Matches(key.ToString(), regex, options))
                {
                    charatherName.text += key;
                }
            }
        }
    }
}
