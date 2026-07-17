using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    private int score = 0;
    private float gameTimer = 0;
    private float interval;
    [SerializeField] private GameObject logPrefab;
    private float timer;
    public float objSpeed;
    // Start is called before the first frame update
    void Start()
    {
        interval = 1f;
        objSpeed = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        gameTimer += Time.deltaTime;
        if(gameTimer >= interval)
        {
            gameTimer = 0;
            SpawnLog();
        }
        //Debug.Log(timer);
    }

    private void SpawnLog()
    {
        float randomX = Random.Range(-7f, 7f);
        Vector3 spawnPosition = new Vector3(randomX, -15.5f, 22.5f);
        Instantiate(logPrefab, spawnPosition, Quaternion.Euler(0f,0f,90f));
    }
}
