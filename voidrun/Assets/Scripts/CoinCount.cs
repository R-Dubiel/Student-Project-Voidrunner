using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
 
public class CoinCount : MonoBehaviour
{  
    public static CoinCount instance;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI highscoreText;

    int score = 0;
    int highscore = 0;
 
    void Awake()
    {
        instance = this;
    }
 
    void Start()
    {
        // intalize text
        highscore = PlayerPrefs.GetInt("highscore", 0);
        coinText.text = "COINS: 0";
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
    }
   
    // update text
    public void updateCoinCount(){
        score += 1;
        coinText.text = "COINS: " + score.ToString();
        if (highscore < score)
            PlayerPrefs.SetInt("highscore", score);
    }
}
 

