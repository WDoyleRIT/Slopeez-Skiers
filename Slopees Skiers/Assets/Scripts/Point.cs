using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Point : MonoBehaviour
{

    private int score;
    private TextMeshProUGUI pointText;
    private Game gameManagerRef;
    Color textColor;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerRef = FindObjectOfType<Game>();
    }

    public void Initialize(int score)
    {
        this.score = score;
        pointText = GetComponent<TextMeshProUGUI>();
        pointText.text = "+" + score.ToString();
        textColor = pointText.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerRef.isPaused)
        {
            Destroy(gameObject);
        }

        this.transform.position += new Vector3(0, 20.0f * Time.deltaTime, 0);
        textColor.a -= 1.0f * Time.deltaTime;
        pointText.color = textColor;
        if (textColor.a <= 0.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
