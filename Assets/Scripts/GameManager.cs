using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

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
    }

    public void StartGame()
    {
        SceneManager.LoadScene("TitleScene");
    }
    public void EnterDialogueScene()
    {
        SceneManager.LoadScene("xavier1_1");
    }
    public void EnterEndScene()
    {
        SceneManager.LoadScene("EndScene");
    }
}
