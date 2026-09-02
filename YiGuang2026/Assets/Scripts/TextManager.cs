using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
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
        score = GameState.Instance.score.ToString();
        scoreText.text = "Score: " + score;

        if (GameState.Instance.hp >= 0)
            hp = GameState.Instance.hp.ToString();
        hpText.text = "HP: " + hp;
    }
}
