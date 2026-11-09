using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverTube : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] Material goodMaterial;
    [SerializeField] Material badMaterial;
    void Start()
    {
        meshRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(GlobalVar.Instance.isGrinding)
        {
            meshRenderer.material = goodMaterial;
        }
        else
        {
            meshRenderer.material = badMaterial;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the object we bumped into has the "Player" tag
        if (collision.gameObject.CompareTag("Player"))
        {
            GlobalVar.Instance.isGrinding = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Check if the object we bumped into has the "Player" tag
        if (collision.gameObject.CompareTag("Player"))
        {
            
            // To Do: Make player snap to center of tube upon landing on one
            collision.gameObject.transform.position = new Vector3(transform.position.x, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z);

            GlobalVar.Instance.isGrinding = false;
            Player playerScript = collision.gameObject.GetComponent<Player>();
            if(playerScript.currentState != PlayerState.Jumping)
            {
                playerScript.currentState = PlayerState.Falling;
            }
        }
    }
}
