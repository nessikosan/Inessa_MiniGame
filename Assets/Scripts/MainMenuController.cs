using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public SamData samData = new SamData();
    [SerializeField] private Button _startGame;
    [SerializeField] private Button _loadGame;

    public void StartGame()
    {
        if (File.Exists(Application.streamingAssetsPath + "GAMEDATE.json"))
        {
            File.Delete(Application.streamingAssetsPath + "GAMEDATE.json");

            Debug.Log("Data reset complete!");
        }
            SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

    public void LoadGame()
    {
        LoadData();
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

            SceneManager.LoadScene(samData.sceneID);
        }
    }

}
