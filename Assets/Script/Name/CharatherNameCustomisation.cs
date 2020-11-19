using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharatherNameCustomisation : MonoBehaviour
{
    public Text charatherName;
    string temp = "Robin";
    string fileName = "data.json";
    string path;
    int num;

    GameData gameData = new GameData();
    private void Start()
    {
        charatherName = this.Text;

        path = Application.persistentDataPath + "/" + fileName;
        Debug.Log(path);

        gameData.name = "Names";

        PlayerName n01 = new PlayerName();
        n01.name = "Robin";
        gameData.userName.Add(n01);

        PlayerName n02 = new PlayerName();
        n02.name = "Cas";
        gameData.userName.Add(n02);

        SaveData();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReadData();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            num = 0;
            Debug.Log("num = 0");
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            num = 1;
            Debug.Log("num = 1");
        }
    }

    void SaveData()
    {
        JsonWrapper wrapper = new JsonWrapper();
        wrapper.GameData = gameData;
        string contents = JsonUtility.ToJson(wrapper, true);
        System.IO.File.WriteAllText(path, contents);
    }

    void ReadData()
    {
        try
        {
            if(System.IO.File.Exists(path))
            {
                string contents = System.IO.File.ReadAllText(path);
                JsonWrapper wrapper = JsonUtility.FromJson<JsonWrapper>(contents);
                gameData = wrapper.GameData;
                charatherName.text = gameData.name;
                switch (num)
                {
                    case 0:
                        charatherName.text = gameData.userName[0].name;
                        Debug.Log(gameData.userName[0].name);
                        break;
                    case 1:
                        charatherName.text = gameData.userName[1].name;
                        Debug.Log(gameData.userName[1].name);
                        break;
                }
                
                foreach (PlayerName n in gameData.userName)
                {
                    Debug.Log(n.name);
                }
            }
            else
            {
                Debug.Log("there is no Json");
                gameData = new GameData();
            }
        }
        catch(System.Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }
}
