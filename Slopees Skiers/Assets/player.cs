using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class player : MonoBehaviour
{
    enum PlayerState
    {
        Idle,
        MovingLeft,
        MovingRight,
        Jumping,
        Falling,
        Dead
    }

    [SerializeField] private GameObject playerCharacter;
    private PlayerState currentState; 
    private float jumpHeight = 5f;
    private float startingElevation;
    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.Idle;
        startingElevation = playerCharacter.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        //State machine for player movement! (right should be minus , left should be plus)
        switch (currentState)
        {
            case PlayerState.Idle:
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    currentState = PlayerState.Jumping;
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        currentState = PlayerState.MovingLeft;
                    }
                    if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        currentState = PlayerState.MovingRight;
                    }
                }
                break;
            case PlayerState.MovingLeft:
                playerCharacter.transform.Translate(Vector3.right * Time.deltaTime * 20f);
                if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    currentState = PlayerState.Jumping;
                }
                else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
                {
                    if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                    {
                        currentState = PlayerState.MovingRight;
                    }
                    else
                    {
                        currentState = PlayerState.Idle;
                    }
                }
                break;
            case PlayerState.MovingRight:
                playerCharacter.transform.Translate(Vector3.left * Time.deltaTime * 20f);
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    currentState = PlayerState.Jumping;
                }
                else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
                {
                    if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                    {
                        currentState = PlayerState.MovingLeft;
                    }
                    else
                    {
                        currentState = PlayerState.Idle;
                    }
                }
                break;
            case PlayerState.Jumping:
                playerCharacter.transform.position = new Vector3(playerCharacter.transform.position.x, 
                    playerCharacter.transform.position.y + 0.05f, playerCharacter.transform.position.z);
                if(playerCharacter.transform.position.y >= startingElevation + jumpHeight)
                {
                    currentState = PlayerState.Falling;
                }
                break;
            case PlayerState.Falling:
                playerCharacter.transform.position = new Vector3(playerCharacter.transform.position.x,
                    playerCharacter.transform.position.y - 0.05f, playerCharacter.transform.position.z);
                if (playerCharacter.transform.position.y <= startingElevation)
                {
                    currentState = PlayerState.Idle;
                }
                break;
        }
  
        Debug.Log("Current State: " + currentState);
    }
}
