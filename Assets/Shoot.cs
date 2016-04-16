using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

  public GameObject bullet;
  Transform tran;
  Vector3 forward;
  public Transform bulletSpawn;
  public float bulletForce;
  AudioSource aus;

	// Use this for initialization
	void Start () {
    tran = gameObject.GetComponent<Transform>();
    aus = gameObject.GetComponentInParent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetKeyDown(KeyCode.Space))
    {
      Shot();
    }
	}
  void Shot()
  {
    aus.Play();
    forward = transform.TransformDirection(Vector3.up);
    GameObject obj = (GameObject)Instantiate(bullet,bulletSpawn.position,Quaternion.identity);
    Rigidbody rig = obj.GetComponent<Rigidbody>();
    rig.AddForce(forward * bulletForce);
  }
}
