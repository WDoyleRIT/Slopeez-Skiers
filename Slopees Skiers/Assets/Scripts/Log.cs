using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class Log : MonoBehaviour
{

    private Game gameManagerRef;
    private float startingX;
    private Vector3 targetPosition;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        gameManagerRef = FindObjectOfType<Game>();
        startingX = transform.position.x;
        targetPosition = new Vector3(startingX, 28.5f, -40.5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position = Vector3.MoveTowards(transform.position, targetPosition, gameManagerRef.objSpeed * Time.deltaTime);
        Vector3 nextPosition = Vector3.MoveTowards(rb.position, targetPosition, gameManagerRef.objSpeed * Time.fixedDeltaTime);
        rb.MovePosition(nextPosition);
        if (transform.position == targetPosition)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the object we bumped into has the "Player" tag
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Player smashed by the log!");
        }
    }
}
