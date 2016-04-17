using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
  public GameObject player;
  public GameObject enemy;
  float nextSpawnTime;
  public float spawnCoolDown;
  public float maxX, maxY, minX, minY;


	// Use this for initialization
	void Start () {
    nextSpawnTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
	if (Time.time > nextSpawnTime)
    {
      nextSpawnTime = Time.time + spawnCoolDown;
      SpawnWave(2);
    }
	}

  void SpawnWave(int numberToSpawn)
  {
    for (int i = numberToSpawn; i >= 0; i--)
    {
      
    }
  }
}
