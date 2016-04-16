using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

  public GameObject bullet;
  Transform tran;
  Vector3 forward;
  public Transform bulletSpawn;
  public float bulletForce;

	// Use this for initialization
	void Start () {
    tran = gameObject.GetComponent<Transform>();
   
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
    forward = transform.TransformDirection(tran.up);
    GameObject obj = (GameObject)Instantiate(bullet,bulletSpawn.position,Quaternion.identity);
    Rigidbody rig = obj.GetComponent<Rigidbody>();
    rig.AddForce(forward * bulletForce);
  }
}
