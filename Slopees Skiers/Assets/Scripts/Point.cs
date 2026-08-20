using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Point : MonoBehaviour
{

    private int score;
    private TextMeshProUGUI pointText;
    Color textColor;

    // Start is called before the first frame update
    void Start()
    {
        
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
        this.transform.position += new Vector3(0, 10.0f * Time.deltaTime, 0);
        textColor.a -= 1.0f * Time.deltaTime;
        pointText.color = textColor;
        if (textColor.a <= 0.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
