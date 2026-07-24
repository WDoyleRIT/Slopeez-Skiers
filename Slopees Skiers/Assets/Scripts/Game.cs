using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{

    private int score = 0;
    private float gameTimer = 0;
    private float cycleTimer = 0;
    private float interval;
    private float speedCycle;
    [SerializeField] private GameObject logPrefab;
    [SerializeField] private Button pauseButton;
    [SerializeField] private TextMeshProUGUI pauseText;
    [SerializeField] private GameObject shaderPanel;
    [SerializeField] private TextMeshProUGUI gameText;
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

        interval = 1f;
        objSpeed = 20f;
        speedCycle = 3f;

        gameText.gameObject.SetActive(false);
        shaderPanel.SetActive(false);
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
                SpawnLog();
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
        //Debug.Log(timer);
    }

    private void SpawnLog()
    {
        float randomX = Random.Range(-7f, 7f);
        Vector3 spawnPosition = new Vector3(randomX, -15.5f, 22.5f);
        switch (Random.Range(1, 3))
        {
            case 1: Instantiate(logPrefab, spawnPosition, Quaternion.Euler(0f, 0f, 90f));
                break;
            case 2:
                break;
        }
        Debug.Log(Random.Range(1, 3));
    }

    private void PauseGame(bool pausePressed)
    {
        isPaused = pausePressed;
        if (isPaused)
        {
            gameText.text = "Game Paused";
            gameText.gameObject.SetActive(true);
            pauseText.text = "Unpause";
            shaderPanel.SetActive(true);
        }
        else
        {
            pauseText.text = "Pause";
            gameText.gameObject.SetActive(false);
            shaderPanel.SetActive(false);
        }
    }

    public void GameOver()
    {
        isPaused = true;

        gameText.text = "Game Over!";
        gameText.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        shaderPanel.SetActive(true);
    }
}
