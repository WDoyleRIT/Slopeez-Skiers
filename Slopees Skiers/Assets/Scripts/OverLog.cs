using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverLog : MonoBehaviour
{
    private Game gameManagerRef;
    [SerializeField] MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerRef = FindObjectOfType<Game>();
        meshRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the object we bumped into has the "Player" tag
        if (collision.gameObject.CompareTag("Player"))
        {
            //meshRenderer.enabled = false;
            gameManagerRef.score += 50;
            gameManagerRef.CreatePointVisual(50);
            //Debug.Log("Jumped over log!");
        }
    }
}
