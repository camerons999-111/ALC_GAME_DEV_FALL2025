using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float speed;

    public float rotSpeed;

    public float hInput;

    public float vInput;

    public float jumpForce;

    public Rigidbody playerRB;

    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.up, hInput * rotSpeed * Time.deltaTime); // Left and Right Rotations
        transform.Translate(Vector3.forward * vInput * speed * Time.deltaTime); // Forwards and Backward movements
        
    }
}
