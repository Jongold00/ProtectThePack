using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUIHandler : MonoBehaviour
{
    static MainMenuUIHandler instance;

    [SerializeField]
    GameObject[] mainMenuLayers;




    public static MainMenuUIHandler GetInstance()
    {
        if (!instance)
        {
            instance = GameObject.FindObjectOfType<MainMenuUIHandler>();
        }
        return instance;
    }

    public void Awake()
    {
    }


    public void Start()
    {

    }

    public void OnLayerToggle(int layerIndex)
    {
        for (int i = 0; i < mainMenuLayers.Length; i++)
        {
            if (i == layerIndex)
            {
                mainMenuLayers[i].SetActive(true);
            }
            else
            {
                mainMenuLayers[i].SetActive(false);
            }
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
    
}
