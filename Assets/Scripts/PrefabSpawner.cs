using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour {

    public GameObject[] points;
    public GameObject Prefab;
    public GameObject ImageTarget;
    public float SpawnDelay;
    public float IncreaseDifficultyDelay;
    public float DifficultyLimit;

    private float nextSpawnTime;
    private float nextIncreaseDifficultyTime;

    // Start is called before the first frame update
    void Start()
    {
        this.nextSpawnTime = -1;
        this.nextIncreaseDifficultyTime = Time.time + this.IncreaseDifficultyDelay;
    }

    void Update()
    {
        if (this.ShouldSpawn()) 
        {
            this.Spawn();
        }
    }

    private bool ShouldSpawn() 
    {
        return Time.time > this.nextSpawnTime;
    }

    private void Spawn() 
    {
        Debug.Log("PrefabSpawner - Spawning!");

        GameObject spawnPoint = this.GetSpawnPoint();
        Transform transform = spawnPoint.transform;

        GameObject gameObject = Instantiate(this.Prefab, transform.position, transform.rotation);
        gameObject.transform.parent = this.ImageTarget.transform;

        this.nextSpawnTime = Time.time + this.SpawnDelay;

        if (this.ShouldIncreaseDifficulty())
        {
            this.IncreaseDifficulty();
        }
    }

    private bool ShouldIncreaseDifficulty() 
    {
        return Time.time > this.nextIncreaseDifficultyTime && this.SpawnDelay > this.DifficultyLimit;
    }

    private void IncreaseDifficulty()
    {
        Debug.Log("PrefabSpawner - Increasing difficulty");
        this.SpawnDelay -= 0.5f;
        this.nextIncreaseDifficultyTime = Time.time + this.IncreaseDifficultyDelay;
    }

    private GameObject GetSpawnPoint() 
    {
        int idx = Random.Range(0, this.points.Length - 1);
        return this.points[idx];
    }
}
