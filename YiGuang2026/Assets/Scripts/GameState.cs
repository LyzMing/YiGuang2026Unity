using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public int score = 0;
    public int hp = 3;
    public static GameState Instance; // 单例

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("OverScene");
    }

    public void RestartGame()
    {
        score = 0;
        hp = 3;

        SceneManager.LoadScene("Scene1");
    }
}
