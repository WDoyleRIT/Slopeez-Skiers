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
    [SerializeField] private Button redButton;
    [SerializeField] private Button orangeButton;
    [SerializeField] private Button yellowButton;
    [SerializeField] private Button greenButton;
    [SerializeField] private Button blueButton;
    [SerializeField] private Button purpleButton;
    [SerializeField] private Button startButton;

    //[SerializeField] private Button settingsButton;

    // Start is called before the first frame update
    void Start()
    {
        ChangeHomeState(HomeState.MainMenu);

        if (playButton != null)
        {
            playButton.onClick.AddListener(PlayButton);
        }

        if (redButton != null) { 
        redButton.onClick.AddListener(() => SetCharacter(0));
        }
        if (orangeButton != null) { 
        orangeButton.onClick.AddListener(() => SetCharacter(1));
        }
        if (yellowButton != null)
        {
        yellowButton.onClick.AddListener(() => SetCharacter(2));
        }
        if (greenButton != null)
        {
        greenButton.onClick.AddListener(() => SetCharacter(3));
        }
        if (blueButton != null)
        {
        blueButton.onClick.AddListener(() => SetCharacter(4));
        }
        if (purpleButton != null)
        {
        purpleButton.onClick.AddListener(() => SetCharacter(5));
        }

        if(startButton != null)
        {
            startButton.onClick.AddListener(StartGame);
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
                redButton.gameObject.SetActive(false);
                orangeButton.gameObject.SetActive(false);
                yellowButton.gameObject.SetActive(false);
                greenButton.gameObject.SetActive(false);
                blueButton.gameObject.SetActive(false);
                purpleButton.gameObject.SetActive(false);
                break;
            case HomeState.CharSelect:
                titleText.gameObject.SetActive(false);
                playButton.gameObject.SetActive(false);
                charText.gameObject.SetActive(true);
                redButton.gameObject.SetActive(true);
                orangeButton.gameObject.SetActive(true);
                yellowButton.gameObject.SetActive(true);
                greenButton.gameObject.SetActive(true);
                blueButton.gameObject.SetActive(true);
                purpleButton.gameObject.SetActive(true);
                break;
            case HomeState.Settings:
                titleText.gameObject.SetActive(false);
                playButton.gameObject.SetActive(false);
                charText.gameObject.SetActive(false);
                redButton.gameObject.SetActive(false);
                orangeButton.gameObject.SetActive(false);
                yellowButton.gameObject.SetActive(false);
                greenButton.gameObject.SetActive(false);
                blueButton.gameObject.SetActive(false);
                purpleButton.gameObject.SetActive(false);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
