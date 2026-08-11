using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private float rotationSpeed = 150f;
    private Game gameManagerRef;
    private float startingX;
    private Vector3 targetPosition;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManagerRef = FindObjectOfType<Game>();
        startingX = transform.position.x;
        targetPosition = new Vector3(startingX, 29.5f, -40.5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!gameManagerRef.isPaused)
        {
            //Debug.Log("Object speed:" + gameManagerRef.objSpeed);
            Quaternion deltaRotation = Quaternion.Euler(Vector3.left * rotationSpeed * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
            Vector3 nextPosition = Vector3.MoveTowards(rb.position, targetPosition, gameManagerRef.objSpeed * Time.fixedDeltaTime);
            rb.MovePosition(nextPosition);
            if (transform.position == targetPosition)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the object we bumped into has the "Player" tag
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Kaching!");
            gameManagerRef.score += 20;
            Destroy(this.gameObject);
        }
    }
}
