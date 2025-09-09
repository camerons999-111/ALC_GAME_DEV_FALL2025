using UnityEngine;

public class Move_Up : MonoBehaviour
{
    public float speed;

void Update()
{  
    // moves the balloon up on the y axis at a set rate of speed
    transform.Translate(Vector3.up * speed * Time.deltaTime);
}

}

