using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Required for changing scenes

enum GameState
{
    Playing,
    Paused,
    GameOver,

    MainMenu,
    Settings,
    CharSelect
}


public class Game : MonoBehaviour
{

    // Not sure if I'll even need this but it might be helpful later on for managing game states
    private GameState currentGameState;
    public int score = 0;
    private float gameTimer = 0;
    private float cycleTimer = 0;
    private float interval;
    private float speedCycle;
    [SerializeField] private GameObject playerObj;
    [SerializeField] private GameObject logPrefab;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private GameObject pointPrefab;
    [SerializeField] private GameObject tubePrefab;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button homeButton;
    [SerializeField] private TextMeshProUGUI pauseText;
    [SerializeField] private GameObject shaderPanel;
    [SerializeField] private TextMeshProUGUI gameText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private Transform gameCanvas;
    [HideInInspector] public bool isPaused = false;
    private float timer;
    public float objSpeed;
    private float incrementSpeed = 5f;
    private float intervalIncrement = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        // 1. Turn off VSync (Must be 0 for targetFrameRate to work)
        QualitySettings.vSyncCount = 0;

        // 2. Set the target frame rate to 60
        Application.targetFrameRate = 60;

        // Interval between spawning objects
        interval = 1f;
        objSpeed = 20f;
        // Interval between speed increases
        speedCycle = 8f;

        gameText.gameObject.SetActive(false);
        finalScoreText.gameObject.SetActive(false);
        homeButton.gameObject.SetActive(false);
        shaderPanel.SetActive(false);
        homeButton.onClick.AddListener(() => SceneManager.LoadScene("HomeScene"));
        pauseButton.onClick.AddListener(() => PauseGame(!isPaused));
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPaused)
        {
            timer += Time.deltaTime;
            gameTimer += Time.deltaTime;
            cycleTimer += Time.deltaTime;
            if (gameTimer >= interval) 
            {
                gameTimer = 0;
                score += 10;
                StartCoroutine(SpawnObject());
            }
            if (cycleTimer >= speedCycle)
            {
                cycleTimer = 0;
                objSpeed += incrementSpeed;
                if (interval >= 0.5f)
                {
                    interval -= intervalIncrement;
                }
            }
        }
        scoreText.text = "Score: \n" + score;
        //Debug.Log(timer);

        if (Input.GetKeyDown(KeyCode.Escape)){
            NewGame();
        }
    }

    private IEnumerator SpawnObject()
    {

        float randomX;
        switch (Random.Range(1, 4))
        {
            case 1:
                randomX = -7f;
                break;
            case 2:
                randomX = 0f;
                break;
            case 3:
                randomX = -7f;
                break;
            default:
                randomX = 0f;
                break;
        }

        Vector3 spawnPositionLog = new Vector3(randomX, -15.5f, 22.5f);
        Vector3 spawnPositionCoin = new Vector3(randomX, -14.5f, 22.5f);

        switch (Random.Range(1, 6))
        {
            // Case 1 and 2: spawn log
            case 1:
            case 2:
                Instantiate(logPrefab, spawnPositionLog, Quaternion.Euler(0f, 0f, 90f));
                break;
            // Case 3: spawn 3 coins
            case 3:
                Instantiate(coinPrefab, spawnPositionCoin, Quaternion.Euler(0f, 0f, 90f));
                yield return new WaitForSeconds(interval / 8);

                Instantiate(coinPrefab, spawnPositionCoin, Quaternion.Euler(0f, 0f, 90f));
                yield return new WaitForSeconds(interval / 8);

                Instantiate(coinPrefab, spawnPositionCoin, Quaternion.Euler(0f, 0f, 90f));
                break;
            // Case 4: spawn 5 coins
            case 4:
                Instantiate(coinPrefab, spawnPositionCoin, Quaternion.Euler(0f, 0f, 90f));
                yield return new WaitForSeconds(interval / 8);

                Instantiate(coinPrefab, spawnPositionCoin, Quaternion.Euler(0f, 0f, 90f));
                yield return new WaitForSeconds(interval / 8);

                Instantiate(coinPrefab, spawnPositionCoin, Quaternion.Euler(0f, 0f, 90f));
                yield return new WaitForSeconds(interval / 8);

                Instantiate(coinPrefab, spawnPositionCoin, Quaternion.Euler(0f, 0f, 90f));
                yield return new WaitForSeconds(interval / 8);

                Instantiate(coinPrefab, spawnPositionCoin, Quaternion.Euler(0f, 0f, 90f));
                break;
            case 5:
                Debug.Log("half pipe will spawn here");
                break;
            default:
                break;
        }

        yield break;
    }

    public void CreatePointVisual(int score)
    {
        GameObject pointVisual = Instantiate(pointPrefab, gameCanvas);
        pointVisual.GetComponent<Point>().Initialize(score);
    }

    private void NewGame()
    {

        Debug.Log("New Game Started");
        score = 0;
        gameTimer = 0;
        cycleTimer = 0;
        objSpeed = 20f;
        interval = 1f;
        isPaused = false;

        gameText.gameObject.SetActive(false);
        finalScoreText.gameObject.SetActive(false);
        shaderPanel.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
        homeButton.gameObject.SetActive(false);
        playerObj.SetActive(true);

        Scene activeScene = SceneManager.GetActiveScene();

        List<GameObject> rootObjects = new List<GameObject>();
        activeScene.GetRootGameObjects(rootObjects);

        foreach (GameObject rootGo in rootObjects)
        {
            if (rootGo.gameObject.CompareTag("Object"))
            {
                Destroy(rootGo);
            }
        }
    }

    private void PauseGame(bool pausePressed)
    {
        isPaused = pausePressed;
        if (isPaused)
        {
            gameText.text = "Game Paused";
            gameText.gameObject.SetActive(true);
            homeButton.gameObject.SetActive(true);
            pauseText.text = "Unpause";
            shaderPanel.SetActive(true);
        }
        else
        {
            pauseText.text = "Pause";
            gameText.gameObject.SetActive(false);
            homeButton.gameObject.SetActive(false);
            shaderPanel.SetActive(false);
        }
    }

    public void GameOver()
    {
        isPaused = true;

        gameText.text = "Game Over!";
        gameText.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        homeButton.gameObject.SetActive(true);
        shaderPanel.SetActive(true);
        finalScoreText.gameObject.SetActive(true);
        finalScoreText.text = "Score: " + score;
    }
}
