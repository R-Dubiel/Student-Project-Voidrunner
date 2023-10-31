using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool turnLeft, turnRight, jump;
    public float speed = 7.0f;
    private CharacterController charController;
    public Rigidbody rigidBody;
    public bool SpaceToStart = true;

    public GameObject StartScreen;


    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
        SpaceToStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(SpaceToStart)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartScreen.SetActive(false);
                Time.timeScale = 1f;
            }
        }

        turnLeft = Input.GetKeyDown(KeyCode.A);
        turnRight = Input.GetKeyDown(KeyCode.D);
        jump = Input.GetKeyDown(KeyCode.W);

        if(turnLeft){
            transform.Rotate(new Vector3(0f, -90f, 0f));
        }else if(turnRight){
            transform.Rotate(new Vector3(0f, 90f, 0f));
        }else if(jump){
            rigidBody.AddForce(transform.up * 5f, ForceMode.Impulse);
        }

        if(GetComponent<Rigidbody>().position.y < -50f){
            FindObjectOfType<GameManager>().EndGame();
        }

        charController.SimpleMove(new Vector3(0f,0f,0f));
        charController.Move(transform.forward * speed * Time.deltaTime);
        
    }
}
