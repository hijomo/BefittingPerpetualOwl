using UnityEngine;
using System.Collections;

public class EnemyHit : MonoBehaviour {
  public bool isQuad = true;
  public bool isTri;
  public bool isLine;
  public GameObject threeSideMesh;
  public GameObject fourSideMesh;
  public GameObject twoSideMesh;
  public GameObject currentForm;
  public Material ememyMat;
  float nextHit; // timer so you can ony hit the object every .5s
  public float hitCoolDown = 0.5f;
  public AudioSource aus;
  void OnTriggerEnter(Collider other)
  {
    if (other.tag == "PlayerBullet")
    {
      Destroy(other.gameObject);
      ChangeForm();
    }
  }
  void ChangeForm()
  {
    if (Time.time < nextHit) return;
    nextHit = Time.time + hitCoolDown;
    aus.Play();
    if (isLine)
    {
      Destroy(gameObject, 0.75f);
      return;
    }
    if (isTri)
    {
      isTri = false;
      Destroy(currentForm);
      GameObject obj = (GameObject)Instantiate(twoSideMesh, Vector3.zero, Quaternion.identity);
      obj.transform.SetParent(gameObject.transform, false);
      obj.GetComponent<MeshRenderer>().material = ememyMat;
      currentForm = obj;
      isLine = true;
      return;
    }
    if (isQuad)
    {
      isQuad = false;
      Destroy(currentForm);
      GameObject obj = (GameObject)Instantiate(threeSideMesh, Vector3.zero, Quaternion.identity);
      obj.transform.SetParent(gameObject.transform,false);
      obj.GetComponent<MeshRenderer>().material = ememyMat;
      currentForm = obj;
      isTri = true;
      return;
    }
  

   
  }
  // Use this for initialization
  void Start () {
    aus = gameObject.GetComponent<AudioSource>();
    nextHit = Time.time + hitCoolDown;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
