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

  public Text centreText;
  bool startState;
  bool gameOverState;
  float resetTime;
  public float spawnForce = 9f;
 


	// Use this for initialization
	void Start ()
  {
    startState = true;
    centreText.gameObject.SetActive(true);
    centreText.text = ("Press any key to start");
  }
	
	// Update is called once per frame
	void Update ()
  {
    
    if (Input.anyKeyDown && startState)
    {
      startState = false;
      centreText.gameObject.SetActive(false);
      nextSpawnTime = Time.time;
      nextWaveTime = Time.time + spawnProgression;
      GameObject obj = (GameObject)Instantiate(player, Vector3.zero, Quaternion.identity);
      playerHit = obj.GetComponent<PlayerHit>();
    }
    if (startState) return;
    if (score > nextLevelup)
    {
      nextLevelup = score + levelUpCoolDown;
      if (playerHit != null)
      {
        playerHit.FormUp();
      }
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
    if (gameOverState && Time.time > resetTime)
    {
      SceneManager.LoadScene(0);
    }
    UpdateUI();
	}
  
  void SpawnWave(int numberToSpawn)
  {
    for (int i = numberToSpawn; i >= 0; i--)
    {
      spawnForce += 0.5f;
      Vector3 temp = Random.onUnitSphere; 
      Vector3 pos = new Vector3(temp.x, temp.y, 0f).normalized*10;
      Quaternion rot = Quaternion.identity;
      GameObject obj = (GameObject)Instantiate(enemy, pos, rot);
      obj.GetComponent<Rigidbody>().AddForce(-pos * spawnForce);
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

  public void GameOver()
  {
    gameOverState = true;
    resetTime = Time.time + 4f;
    centreText.gameObject.SetActive(true);
    centreText.text = ("Game Over\r\nRestart soon");
  }
}