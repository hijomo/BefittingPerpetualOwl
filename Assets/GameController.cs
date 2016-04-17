using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
  PlayerHit playerHit;
  public Text scoreText;
  public GameObject player;
  public GameObject enemy;
  float nextSpawnTime;
  public float spawnCoolDown;
  public float maxX, maxY, minX, minY;
  public float spawnProgression = 20;
  float nextWaveTime;
  int waveNumber = 1;
  int score = 0;
  int nextLevelup= 500;
  public int levelUpCoolDown = 500;
 


	// Use this for initialization
	void Start () {
    nextSpawnTime = Time.time;
    nextWaveTime = Time.time + spawnProgression;
    GameObject obj =(GameObject)Instantiate(player, Vector3.zero, Quaternion.identity);
    playerHit = obj.GetComponent<PlayerHit>();
    
	}
	
	// Update is called once per frame
	void Update () {

    if (Input.GetKeyDown(KeyCode.T)|| score > nextLevelup)
    {
      nextLevelup = score + levelUpCoolDown;
      playerHit.FormUp();
    }
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
    UpdateUI();
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
  public void AddScore(int points)
  {
    score += points;
  }
  void UpdateUI()
  {
    scoreText.text = score.ToString();
  }
}
