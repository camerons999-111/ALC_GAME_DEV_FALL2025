using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("Coin Attributes")]

    public int scoreToGive;  // How many points do we give the player
    private float startYPos; // Coin start position on the y-axis
    public float bobHeight; // How high the coin will bob
    public float bobSpeed; // How fast the coin will bob


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            // Increase Score
            collision.GetComponent<PlayerControler2D>().AddScore(scoreToGive);
            // Destroy the coin
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        startYPos = transform.position.y; // Set the start position o the current position
    }

    // Update is called once per frame
    void Update()
    {
        // Move the coin up and down aka make the coin bob
        float newY = startYPos + (Mathf.Sin(Time.time * bobSpeed) * bobHeight);
        transform.position = new Vector3(transform.position.x, newY, 0);
    }
}
