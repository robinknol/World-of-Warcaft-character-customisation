using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPress : MonoBehaviour
{
    private Button nameRandomizer;
    private Text charatherName;
    public List<string> randomNames = new List<string>();

    private string fileName = "data.json";
    private string path;
    private int num;

    GameData gameData = new GameData();
    private void Start()
    {
        nameRandomizer = this.GetComponent<Button>();
        nameRandomizer.onClick.AddListener(Randomizer);

        charatherName = GameObject.FindGameObjectWithTag("username").GetComponent<Text>();

        charatherName.text = "";

        path = Application.persistentDataPath + "/" + fileName;
        Debug.Log(path);

        for (int i = 0; i < randomNames.Count; i++)
        {
            PlayerName n01 = new PlayerName();
            n01.name = randomNames[i];
            gameData.userName.Add(n01);
        }

        SaveData();
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

                        charatherName.text = gameData.userName[num].name;
                        Debug.Log(gameData.userName[num].name);
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
        num = Random.Range(0, randomNames.Count);
        Debug.Log(num);
        ReadData();
    }
}
