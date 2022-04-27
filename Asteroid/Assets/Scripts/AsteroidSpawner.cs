using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public Asteroid asteroidPrefab;
    public float trajectoryVariance = 15.0f;
    public float spawnRate = 2.0f;
    public float spawnDistance = 12.0f;
    public float spawnAmount = 1.0f;
    // Start is called before the first frame update
    private void Start()
    {
        //to keep repeating the spawning action
        InvokeRepeating(nameof(Spawn),this.spawnRate,this.spawnRate);
        

    }

    //to spawn asteroid
    private void Spawn()
    {
        for (int i =0; i < this.spawnAmount; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;  //to spawn at the edge
            Vector3 spawnPoint = spawnDirection + this.transform.position;  //to randomly spawn at a point which have a distance from player

            float variance = Random.Range(-this.trajectoryVariance, this.trajectoryVariance); //movement of the steroid
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward); //move the steroid in a random angle

            Asteroid asteroid = Instantiate(this.asteroidPrefab, spawnPoint, rotation); //initiate/create asteroid
            asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize); //determine a random size for the asteroid
            asteroid.SetTrajectory(rotation * -spawnDirection); //to move the asteroid towards player
        }

    }

    
}
