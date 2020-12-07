using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateName : MonoBehaviour
{
    private Button nameRandomizer;
    private Text charatherName;
    public List<string> randomNamesMale = new List<string>();
    public List<string> randomNamesFemale = new List<string>();

    private void Start()
    {
        nameRandomizer = this.GetComponent<Button>();
        //nameRandomizer.onClick.AddListener(GenerateRandomName(true);
    }
    public void GenerateRandomName(bool isMale)
    {
        string generatedName = "";

        do
        {
            if (isMale)
            {
                generatedName = GenerateNameFromList(randomNamesMale);
            }
            else
            {
                generatedName = GenerateNameFromList(randomNamesFemale);
            }
        } while (!IsNameValid(generatedName));


    }
    
    private bool IsNameValid(string newName)
    {
        bool isValid = true;

        //if (listWithChosenNames.Contains(newName))
        //{​​​​​​​​
        //	isValid = false;
        //}​​​​​​​​

        return isValid;
    }

    private string GenerateNameFromList(List<string> names)
    {
        int randomIndex = Random.Range(0, names.Count);
        return names[randomIndex];
    }
}
