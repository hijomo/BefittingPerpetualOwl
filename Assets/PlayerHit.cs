using UnityEngine;
using System.Collections;

public class PlayerHit : MonoBehaviour {
  public AudioSource aus;
  public GameObject fourSideMesh;
  public GameObject threeSideMesh;
  public GameObject twoSideMesh;
  public GameObject curentForm;
  public Material playerMat;
  float nextHit;
  public float hitCoolDown;
  public GameObject hP1;
  public GameObject hP2;
  public GameObject hP3;
  public GameObject hP4;
  void OnTriggerEnter(Collider other)
  {
    if (other.tag=="Bullet" || other.tag =="Enemy")
    {
      aus.Play();
      Destroy(gameObject,2);
      
   
    }
  }

    // Use this for initialization
    void Start () {
    aus = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
