using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
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
    private Game gameManagerRef;

    [SerializeField] private Material material1;
    [SerializeField] private Material material2;
    [SerializeField] private Material material3;
    [SerializeField] private Material material4;
    [SerializeField] private Material material5;
    [SerializeField] private Material material6;

    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.Idle;
        startingElevation = playerCharacter.transform.position.y;
        movingLeft = false;
        movingRight = false;
        gameManagerRef = FindObjectOfType<Game>();

        Renderer objectRenderer = GetComponent<Renderer>();
        switch (GlobalVar.Instance.selectedCharacter)
        {
            case Character.Red:
                objectRenderer.material = material1;
                break;
            case Character.Orange:
                objectRenderer.material = material2;
                break;
            case Character.Yellow:
                objectRenderer.material = material3;
                break;
            case Character.Green:
                objectRenderer.material = material4;
                break;
            case Character.Blue:
                objectRenderer.material = material5;
                break;
            case Character.Purple:
                objectRenderer.material = material6;
                break;
            default:
                Debug.LogWarning("Invalid character selection. Defaulting to character 1.");
                objectRenderer.material = material1;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerRef.isPaused)
        {
            return;
        }

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
                    playerCharacter.transform.position.y + 0.30f, playerCharacter.transform.position.z);

                if (playerCharacter.transform.position.y >= startingElevation + jumpHeight)
                {
                    currentState = PlayerState.Falling;
                }
                break;
            case PlayerState.Falling:
                playerCharacter.transform.position = new Vector3(playerCharacter.transform.position.x,
                    playerCharacter.transform.position.y - 0.25f, playerCharacter.transform.position.z);

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
            playerCharacter.transform.Translate(Vector3.right * Time.deltaTime * 30f);
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
            playerCharacter.transform.Translate(Vector3.left * Time.deltaTime * 30f);
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
