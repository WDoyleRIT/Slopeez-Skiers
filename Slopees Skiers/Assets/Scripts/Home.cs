using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Required for changing scenes

enum HomeState
{
    MainMenu,
    Settings,
    CharSelect
}

public class Home : MonoBehaviour
{

    private HomeState currentHomeState;
    [SerializeField] private Button playButton;
    [SerializeField] private TextMeshProUGUI titleText;

    [SerializeField] private TextMeshProUGUI charText;
    [SerializeField] private TextMeshProUGUI currentChar;
    [SerializeField] private Button powderButton;
    [SerializeField] private Button skyButton;
    [SerializeField] private Button sunnyButton;
    [SerializeField] private Button freezeButton;
    [SerializeField] private Button bootsButton;
    [SerializeField] private Button heartButton;
    [SerializeField] private Button startButton;
    [SerializeField] private Button homeButton;

    //[SerializeField] private Button settingsButton;

    // Start is called before the first frame update
    void Start()
    {
        ChangeHomeState(HomeState.MainMenu);

        if (playButton != null)
        {
            playButton.onClick.AddListener(PlayButton);
        }

        if (powderButton != null) { 
        powderButton.onClick.AddListener(() => SetCharacter(0));
        }
        if (skyButton != null) { 
        skyButton.onClick.AddListener(() => SetCharacter(1));
        }
        if (sunnyButton != null)
        {
        sunnyButton.onClick.AddListener(() => SetCharacter(2));
        }
        if (freezeButton != null)
        {
        freezeButton.onClick.AddListener(() => SetCharacter(3));
        }
        if (bootsButton != null)
        {
        bootsButton.onClick.AddListener(() => SetCharacter(4));
        }
        if (heartButton != null)
        {
        heartButton.onClick.AddListener(() => SetCharacter(5));
        }

        if(startButton != null)
        {
            startButton.onClick.AddListener(StartGame);
        }

        if(homeButton != null)
        {
            homeButton.onClick.AddListener(() => ChangeHomeState(HomeState.MainMenu));
        }

    }

    private void PlayButton()
    {
        Debug.Log("play button");
        ChangeHomeState(HomeState.CharSelect);
    }

    private void SetCharacter(int character)
    {
        GlobalVar.Instance.selectedCharacter = (Character)character;
        currentChar.text = GlobalVar.Instance.selectedCharacter.ToString();
        Debug.Log("Character set to " + GlobalVar.Instance.selectedCharacter);
    }

    private void StartGame()
    {
        // Load the game scene
        SceneManager.LoadScene("GameScene");
    }

    private void ChangeHomeState(HomeState state)
    {

        currentHomeState = state;
        Debug.Log("State changed to " + state);
        switch (currentHomeState)
        {
            case HomeState.MainMenu:
                titleText.gameObject.SetActive(true);
                playButton.gameObject.SetActive(true);
                charText.gameObject.SetActive(false);
                powderButton.gameObject.SetActive(false);
                skyButton.gameObject.SetActive(false);
                sunnyButton.gameObject.SetActive(false);
                freezeButton.gameObject.SetActive(false);
                bootsButton.gameObject.SetActive(false);
                heartButton.gameObject.SetActive(false);
                startButton.gameObject.SetActive(false);
                homeButton.gameObject.SetActive(false);
                break;
            case HomeState.CharSelect:
                titleText.gameObject.SetActive(false);
                playButton.gameObject.SetActive(false);
                charText.gameObject.SetActive(true);
                powderButton.gameObject.SetActive(true);
                skyButton.gameObject.SetActive(true);
                sunnyButton.gameObject.SetActive(true);
                freezeButton.gameObject.SetActive(true);
                bootsButton.gameObject.SetActive(true);
                heartButton.gameObject.SetActive(true);
                startButton.gameObject.SetActive(true);
                homeButton.gameObject.SetActive(true);
                break;
            case HomeState.Settings:
                titleText.gameObject.SetActive(false);
                playButton.gameObject.SetActive(false);
                charText.gameObject.SetActive(false);
                powderButton.gameObject.SetActive(false);
                skyButton.gameObject.SetActive(false);
                sunnyButton.gameObject.SetActive(false);
                freezeButton.gameObject.SetActive(false);
                bootsButton.gameObject.SetActive(false);
                heartButton.gameObject.SetActive(false);
                startButton.gameObject.SetActive(false);
                homeButton.gameObject.SetActive(false);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
