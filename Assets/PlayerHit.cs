using UnityEngine;
using System.Collections;

public class PlayerHit : MonoBehaviour {
  public AudioSource aus;
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
