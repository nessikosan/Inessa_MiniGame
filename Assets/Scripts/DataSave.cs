using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DataSave : MonoBehaviour
{
    public SamData samData = new SamData();

    private void OnEnable()
    {
        LoadData();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            SaveData();
        }
    }

    public void SaveData()
    {
        samData = new SamData(transform.position, gameObject.name, SceneManager.GetActiveScene().buildIndex);

        string json = JsonUtility.ToJson(samData);

        string path = Path.Combine(Application.streamingAssetsPath + "GAMEDATE.json");

        File.WriteAllText(path, json);
    }

    public void LoadData()

    {
        if (File.Exists(Application.streamingAssetsPath + "GAMEDATE.json"))
        {
            string path = Path.Combine(Application.streamingAssetsPath + "GAMEDATE.json");

            samData = JsonUtility.FromJson<SamData>(File.ReadAllText(path));

         
           if (SceneManager.GetActiveScene().buildIndex == samData.sceneID)
           {
               transform.position = samData.Position;
               
           }
        }
    }

}


[Serializable]

public class SamData
{
    public Vector3 Position;
    public string Name;
    public int sceneID;

    public SamData() { }

    public SamData(Vector3 position, string name, int sceneID)
    {
        Position = position;
        Name = name;
        this.sceneID = sceneID;
    }
}
