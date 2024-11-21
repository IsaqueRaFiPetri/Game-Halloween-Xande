using UnityEngine;

public class Spawners : MonoBehaviour
{
    public float spawningRate = 5f;
    public GameObject[] enemyPrefab;
    public Transform[] spawnPoints;

    float lastSpawnTime;

    // Update is called once per frame
    void Update()
    {
        if(lastSpawnTime + spawningRate < Time.time)
        {
            var randomSpawnPoints = spawnPoints[Random.Range(0, spawnPoints.Length - 1)];
            var randomEnemy = enemyPrefab[Random.Range(0, spawnPoints.Length - 1)];
            Instantiate(randomEnemy, randomSpawnPoints.position, Quaternion.identity);
            lastSpawnTime = Time.time;
            spawningRate *= 0.98f;
        }
    }
}
//https://www.youtube.com/watch?v=rWubVoGhFVs