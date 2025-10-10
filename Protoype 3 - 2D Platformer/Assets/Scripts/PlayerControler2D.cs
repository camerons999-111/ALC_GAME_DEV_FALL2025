using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerControler2D : MonoBehaviour
{
    [Header("Player Settings")]
    public float moveSpeed;
    public float jumpForce;
    public bool isGrounded;
    public int bottomBound = -4;
    [Header("Score")]
    public int score; // Store the score value


    public Rigidbody2D rig; //Rigidbody reference
    public TextMeshProUGUI scoreText; //Rigidbody reference

    //Increase the score and update the score test UI
    public void AddScore (int amount)
    {   
        //Add to score
        score += amount;
        //Update score test UI
        scoreText.text = "Score: " + score;
    }

    void FixedUpdate()
    {
        // Gather Inputs
        float moveInput = Input.GetAxisRaw("Horizontal");
        // Make the player move side to side
        rig.linearVelocity = new Vector2(moveInput * moveSpeed, rig.linearVelocity.y);
    }

    void Update()
    {
        // If we press the jump button and we are grounded, then jump.
        if(Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            isGrounded = false; 
            rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // Makes the player jump with all of the force applied
        }
        // If we fall below bottomBount(-4) on the y Axix then game over is triggered.
        if(transform.position.y < bottomBound)
        {
            GameOver();
        }
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        //If player is touching the ground set isGrounded to true.
        if(collision.GetContact(0).normal == Vector2.up)
        {
            isGrounded = true;
        }
    }
    //Called when hit by an Enemy or when we fall off the level
    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
