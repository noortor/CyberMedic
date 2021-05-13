using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    private string scene;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
        scene = "";
    }

    public void StartGame()
    {
        SceneManager.LoadScene("TitleScene");
    }
    public void EnterDialogueScene(string sceneName)
    {
        scene = sceneName;
        SceneManager.LoadScene("Dialogue");
    }
    public void EnterEndScene()
    {
        SceneManager.LoadScene("EndScene");
    }

    public string getScene()
    {
        return scene;
    }
}
