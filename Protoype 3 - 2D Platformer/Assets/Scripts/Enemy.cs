using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    public float moveSpeed; // How fast they move
    public Vector3 moveOffset; // Enemy Direction
    public Vector3 startPos; // Start Position
    public Vector3 targetPos; // Target Position



    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        targetPos = startPos;
    }


    // Update is called once per Frame
    void Update()
    {
        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        // Are we at the target position
        if(transform.position == targetPos)
        {
            // Is our target pos our start pos? if so, set it to be the other one.
            if(targetPos == startPos)
            {
                targetPos = startPos + moveOffset;
            }
            // Otherwise do the opposite.
            else
            {
                targetPos = startPos;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Did the player hit us?
        if(collision.CompareTag("Player"))
        {
            // Trigger the game over start om the player
            collision.GetComponent<PlayerControler2D>().GameOver();
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 from;
        Vector3 to;

        if(Application.isPlaying)
        {
            from = startPos;
        }
        else
        {
            from = transform.position;
        }

        to = from + moveOffset;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(from, to);
        Gizmos.DrawWireSphere(to, 0.2f);
        Gizmos.DrawWireSphere(from, 0.2f);
    }
}
