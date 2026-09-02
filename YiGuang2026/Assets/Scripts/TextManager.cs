using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    [SerializeField] private PlayerDie playerDie;

    private TMP_Text scoreText;
    private TMP_Text hpText;
    private string score = "0";
    private string hp = "3";
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText = transform.Find("ScoreText").GetComponent<TMP_Text>();
        hpText = transform.Find("HPText").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score = gameState.score.ToString();
        scoreText.text = "Score: " + score;

        if ((gameState.hp - playerDie.dieTimes) >= 0)
            hp = (gameState.hp - playerDie.dieTimes).ToString();
        hpText.text = "HP: " + hp;
    }
}
