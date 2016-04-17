using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
  public GameObject player;
  public GameObject enemy;
  float nextSpawnTime;
  public float spawnCoolDown;
  public float maxX, maxY, minX, minY;
  public float spawnProgression = 20;
  float nextWaveTime;
  int waveNumber=1;


	// Use this for initialization
	void Start () {
    nextSpawnTime = Time.time;
    nextWaveTime = Time.time + spawnProgression;
    Instantiate(player, Vector3.zero, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
    if (Time.time > nextWaveTime)
    {
      waveNumber++;
      nextWaveTime = Time.time + spawnProgression;
    }
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      SceneManager.LoadScene(0);
    }
	    if (Time.time > nextSpawnTime)
    {
      nextSpawnTime = Time.time + spawnCoolDown;
      SpawnWave(waveNumber);
    }
	}

  void SpawnWave(int numberToSpawn)
  {
    for (int i = numberToSpawn; i >= 0; i--)
    {
      Vector3 temp = Random.onUnitSphere;
      Vector3 pos = new Vector3(temp.x, temp.y, 0f).normalized*10;
      Quaternion rot = Quaternion.identity;
     GameObject obj = (GameObject)Instantiate(enemy, pos, rot);
      obj.GetComponent<Rigidbody>().AddForce(-pos * 10);
    }
  }
}
