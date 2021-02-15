using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger Instance;

    private const string GAME_SCENE = "GameScene";
    private const string START_MENU_SCENE = "StartMenuScene";

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void LoadGameScene() => SceneManager.LoadScene(GAME_SCENE);
    public void LoadStartMenuScene() => SceneManager.LoadScene(START_MENU_SCENE);

}
