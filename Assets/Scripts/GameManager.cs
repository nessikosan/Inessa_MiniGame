using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{ 
    
    [SerializeField] private ControllerSam _controllerSam;
    [SerializeField] private GameObject _endScreen;
    [SerializeField] private GameObject _escape;

    
    private void OnEnable()
    {
        _controllerSam.OnKilled += ControllerSamOnKilled;
       
    }
    private void OnDisable()
    {
        _controllerSam.OnKilled -= ControllerSamOnKilled;
        
    }
     
     private void ControllerSamOnKilled()
     {
       _endScreen.SetActive(true);
        _controllerSam.enabled = false;
    }

    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void LevelComplete()
    {
        _escape.SetActive(true);
        _controllerSam.enabled = false;
      
    }

}


