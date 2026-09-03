using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OverScene : MonoBehaviour
{
    private TMP_Text tmpText;

    private void Start()
    {
        tmpText = GameObject.Find("Text").GetComponent<TMP_Text>();

        if (GameState.Instance.hp == 0)
            tmpText.text = "你输了！";
        else if (GameState.Instance.score == 3)
            tmpText.text = "你赢了！";

    }
    public void Retry()
    {
        GameState.Instance.RestartGame();
    }
}
