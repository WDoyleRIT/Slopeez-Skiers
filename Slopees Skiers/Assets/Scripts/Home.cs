using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; // Required for changing scenes
using UnityEngine.UI;

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
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button backButton;
    [SerializeField] private Button slopeesButton;

    [SerializeField] private TextMeshProUGUI settingsText;
    [SerializeField] private TextMeshProUGUI difficultyText;
    [SerializeField] private Button backArrow;
    [SerializeField] private Button nextArrow;
    [SerializeField] private TextMeshProUGUI currentDifficulty;
    [SerializeField] private Image diffIcon;

    [SerializeField] private Sprite beginnerIcon;
    [SerializeField] private Sprite intermediateIcon;
    [SerializeField] private Sprite expertIcon;

    [SerializeField] private TextMeshProUGUI volumeText;
    [SerializeField] private Slider volSlider;
    [SerializeField] private TextMeshProUGUI volValue;


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

        if(settingsButton != null)
        {
            settingsButton.onClick.AddListener(() => ChangeHomeState(HomeState.Settings));
        }

        if(backButton != null)
        {
            backButton.onClick.AddListener(() => ChangeHomeState(HomeState.CharSelect));
        }

        if(slopeesButton != null)
        {
            slopeesButton.onClick.AddListener(() => Application.OpenURL("https://slopees.com/"));
        }   

        if(backArrow != null)
        {
            backArrow.onClick.AddListener(() => ChangeDifficulty(-1));
        }
        if(nextArrow != null)
        {
            nextArrow.onClick.AddListener(() => ChangeDifficulty(1));
        }

        if (volSlider != null)
        {
            volSlider.onValueChanged.AddListener(UpdateVolume);

            // Optional: Initialize the UI text on launch
            volSlider.value = GlobalVar.Instance.volumeLevel; // Set slider to current volume level
            volValue.text = (volSlider.value * 100).ToString("0") + "%";
        }
    }

    private void ChangeDifficulty(int change)
    {


        switch(GlobalVar.Instance.selectedDifficulty)
        {
            case Difficulty.Beginner:
                if (change == 1)
                {
                    GlobalVar.Instance.selectedDifficulty = Difficulty.Intermediate;
                    backArrow.gameObject.SetActive(true);
                    nextArrow.gameObject.SetActive(true);
                    diffIcon.sprite = intermediateIcon;
                }
                else
                {
                    GlobalVar.Instance.selectedDifficulty = Difficulty.Beginner;
                    backArrow.gameObject.SetActive(false);
                    nextArrow.gameObject.SetActive(true);
                    diffIcon.sprite = beginnerIcon;
                }
                break;
            case Difficulty.Intermediate:
                if (change == 1)
                {
                    GlobalVar.Instance.selectedDifficulty = Difficulty.Expert;
                    backArrow.gameObject.SetActive(true);
                    nextArrow.gameObject.SetActive(false);
                    diffIcon.sprite = expertIcon;
                }
                else if (change == -1)
                {
                    GlobalVar.Instance.selectedDifficulty = Difficulty.Beginner;
                    backArrow.gameObject.SetActive(false);
                    nextArrow.gameObject.SetActive(true);
                    diffIcon.sprite = beginnerIcon;
                }
                break;
            case Difficulty.Expert:
                if (change == -1)
                {
                    GlobalVar.Instance.selectedDifficulty = Difficulty.Intermediate;
                    backArrow.gameObject.SetActive(true);
                    nextArrow.gameObject.SetActive(true);
                    diffIcon.sprite = intermediateIcon;
                }
                break;
        }
        currentDifficulty.text = GlobalVar.Instance.selectedDifficulty.ToString();
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

    public void UpdateVolume(float volume)
    {
        GlobalVar.Instance.volumeLevel = volume;
        volValue.text = (volume * 100).ToString("0") + "%";
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
                currentChar.gameObject.SetActive(false);
                settingsButton.gameObject.SetActive(false);
                backButton.gameObject.SetActive(false);
                slopeesButton.gameObject.SetActive(false);
                //
                settingsText.gameObject.SetActive(false);
                difficultyText.gameObject.SetActive(false);
                backArrow.gameObject.SetActive(false);
                nextArrow.gameObject.SetActive(false);
                currentDifficulty.gameObject.SetActive(false);
                diffIcon.gameObject.SetActive(false);
                //
                volumeText.gameObject.SetActive(false);
                volSlider.gameObject.SetActive(false);
                volValue.gameObject.SetActive(false);

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
                currentChar.gameObject.SetActive(true);
                settingsButton.gameObject.SetActive(true);
                backButton.gameObject.SetActive(false);
                slopeesButton.gameObject.SetActive(true);
                //
                settingsText.gameObject.SetActive(false);
                difficultyText.gameObject.SetActive(false);
                backArrow.gameObject.SetActive(false);
                nextArrow.gameObject.SetActive(false);
                currentDifficulty.gameObject.SetActive(false);
                diffIcon.gameObject.SetActive(false);
                //
                volumeText.gameObject.SetActive(false);
                volSlider.gameObject.SetActive(false);
                volValue.gameObject.SetActive(false);

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
                currentChar.gameObject.SetActive(false);
                settingsButton.gameObject.SetActive(false);
                backButton.gameObject.SetActive(true);
                slopeesButton.gameObject.SetActive(false);
                //
                settingsText.gameObject.SetActive(true);
                difficultyText.gameObject.SetActive(true);
                backArrow.gameObject.SetActive(true);
                nextArrow.gameObject.SetActive(true);
                currentDifficulty.gameObject.SetActive(true);
                diffIcon.gameObject.SetActive(true);
                //
                volumeText.gameObject.SetActive(true);
                volSlider.gameObject.SetActive(true);
                volValue.gameObject.SetActive(true);
                //
                ChangeDifficulty(0); // For initialization
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
