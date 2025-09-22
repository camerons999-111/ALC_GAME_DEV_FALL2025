using UnityEngine;

public class Move_Up : MonoBehaviour
{
    public float speed;
    public float upperBound = 15.0f;
    public ScoreManager scoreManager;
    public Balloon balloon;


void Start()
{
    scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    balloon = GetComponent<Balloon>();
}

void Update()
{  
    // moves the balloon up on the y axis at a set rate of speed
    transform.Translate(Vector3.up * speed * Time.deltaTime);

    if(transform.position.y >= upperBound)
    {
        scoreManager.DecreaseScoreText(balloon.scoreToGive);
        Destroy(gameObject);
    }
}

}

