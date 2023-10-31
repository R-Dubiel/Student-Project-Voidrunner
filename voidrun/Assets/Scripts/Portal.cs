using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{

    private void OnTriggerEnter(Collider other){
        // Check that the object we collided with is player
        if(other.gameObject.name != "runner"){
            return;
        }

        // Add player score
        GameManager.coins += 1;

        StarryPortal();

        // Destroy the player
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0, 90f * Time.deltaTime);
    }

    void StarryPortal(){
        SceneManager.LoadScene("Scene1");
    }

    void HomePortal(){
        SceneManager.LoadScene("Scene0");
    }

}