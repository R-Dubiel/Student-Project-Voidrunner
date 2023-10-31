using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameEnded = false;
    public static int coins;

    void Start(){
        coins = 0;
        //temp to stop game from starting immedetly
        Time.timeScale = 0f;
    }

    public void EndGame()
    {
        if(gameEnded == false){
            Debug.Log("GameOver");
            gameEnded = true;
            if(coins > 9) {
                SceneManager.LoadScene("Win");
            }
            else{
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    void Restart()
    {
        gameEnded = false;
        SceneManager.LoadScene("Scene0");
    }


    void OnTriggerEnter(){
        EndGame();
    }


}
