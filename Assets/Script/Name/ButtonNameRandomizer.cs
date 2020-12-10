using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonNameRandomizer : MonoBehaviour
{
    private Button nameRandomizer;
    private Text charatherName;
    public List<string> randomNamesMale = new List<string>();
    public List<string> randomNamesFemale = new List<string>();

    public bool isMale = true;
    private string userName = "username";
    private string fileName = "data.json";
    private string path;
    private int num;

    GameData gameData = new GameData();
    private void Start()
    {
        nameRandomizer = this.GetComponent<Button>();
        nameRandomizer.onClick.AddListener(Randomizer);

        charatherName = GameObject.FindGameObjectWithTag(userName).GetComponent<Text>();

        path = Application.persistentDataPath + "/" + fileName;
        Debug.Log(path);

        RandomNameJsonSaver();

        SaveData();
    }

    private void RandomNameJsonSaver()
    {

        for (int i = 0; i < randomNamesMale.Count; i++)
        {
            PlayerName n01 = new PlayerName();
            n01.name = randomNamesMale[i];
            gameData.male.Add(n01);
        }

        for (int i = 0; i < randomNamesFemale.Count; i++)
        {
            PlayerName n02 = new PlayerName();
            n02.name = randomNamesFemale[i];
            gameData.female.Add(n02);
        }

        /*
        for (int i = 0, j = 0; i < randomNamesMale.Count && j < randomNamesFemale.Count; i++, j++)
        {
            PlayerName n01 = new PlayerName();
            PlayerName n02 = new PlayerName();
            n01.name = randomNamesMale[i];
            gameData.male.Add(n01);
            n02.name = randomNamesFemale[j];
            gameData.female.Add(n02);
        }
        */
    }
    void ReadData()
    {
        try
        {
            if (System.IO.File.Exists(path))
            {
                string contents = System.IO.File.ReadAllText(path);
                JsonWrapper wrapper = JsonUtility.FromJson<JsonWrapper>(contents);
                gameData = wrapper.GameData;

                if (isMale == true)
                {
                    charatherName.text = gameData.male[num].name;
                    Debug.Log(gameData.male[num].name);
                }
                else
                {
                    charatherName.text = gameData.female[num].name;
                    Debug.Log(gameData.female[num].name);
                }
            }
            else
            {
                Debug.Log("there is no Json");
                gameData = new GameData();
            }
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }

    void SaveData()
    {
        JsonWrapper wrapper = new JsonWrapper();
        wrapper.GameData = gameData;
        string contents = JsonUtility.ToJson(wrapper, true);
        System.IO.File.WriteAllText(path, contents);
    }

    private void Randomizer()
    {
        if (isMale == true)
        {
            num = Random.Range(0, randomNamesMale.Count);
        }
        else
        {
            num = Random.Range(0, randomNamesFemale.Count);
        }
        Debug.Log(num);
        ReadData();
    }
}
