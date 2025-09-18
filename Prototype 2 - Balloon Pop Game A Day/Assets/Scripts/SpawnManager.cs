using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    public GameObject[] balloonPrefabs;
    public float startDelay = 0.5f;
    public float spawnInterval = 1.5f;
    public float xRange = 10.0f;




    void Start()
    {
        InvokeRepeating("SpawnRandomBalloon", startDelay, spawnInterval);
    }

    void SpawnRandomBalloon()
    {
        // Get a random position ont he x-axis
        Vector3 spawnPos = new Vector3(Random.Range(-xRange, xRange), 0, 0);
        // Pick a random Balloon from the Balloon array
        int balloonIndex = Random.Range(0, balloonPrefabs.Length);
        // Spawn random  Balloon at the spawn point
        Instantiate(balloonPrefabs[balloonIndex], spawnPos, balloonPrefabs[balloonIndex].transform.rotation);
    }
}
