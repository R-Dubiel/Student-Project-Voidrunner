using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Coin : MonoBehaviour
{
 
    public void OnTriggerEnter(Collider other){
        // Check that the object we collided with is player
        if(other.gameObject.name != "runner"){
            return;
        }
 
        // Add player score
        GameManager.coins += 1;
 
        // Destroy the player
        Destroy(gameObject);
 
        // Update coin count text
        CoinCount.instance.updateCoinCount();
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
}
 

