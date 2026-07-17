using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PlayerState
{
    Idle,
    Jumping,
    Falling,
    Dead
}

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject playerCharacter;
    private PlayerState currentState;
    private float jumpHeight = 5f;
    private float slopeLimit = 7f;
    private float startingElevation;
    private bool movingLeft;
    private bool movingRight;
    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.Idle;
        startingElevation = playerCharacter.transform.position.y;
        movingLeft = false;
        movingRight = false;
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
                break;
            case PlayerState.Jumping:
                playerCharacter.transform.position = new Vector3(playerCharacter.transform.position.x,
                    playerCharacter.transform.position.y + 0.05f, playerCharacter.transform.position.z);

                if (playerCharacter.transform.position.y >= startingElevation + jumpHeight)
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

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            movingLeft = true;
        }
        else
        {
            movingLeft = false;
        }

        if (movingLeft && playerCharacter.transform.position.x <= slopeLimit)
        {
            playerCharacter.transform.Translate(Vector3.right * Time.deltaTime * 20f);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            movingRight = true;
        }
        else
        {
            movingRight = false;
        }

        if (movingRight && playerCharacter.transform.position.x >= -slopeLimit)
        {
            playerCharacter.transform.Translate(Vector3.left * Time.deltaTime * 20f);
        }



        //Debug.Log("Current State: " + currentState);
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.CompareTag("Log"))
        {
            currentState = PlayerState.Dead;
            Debug.Log("Player has died!");
            Destroy(gameObject);
        }
    }*/
}
