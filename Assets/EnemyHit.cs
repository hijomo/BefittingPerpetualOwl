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
    aus.Play();
    if (isLine)
    {
      Destroy(gameObject, 0.75f);
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
    }
    aus.Play();

   
  }
  // Use this for initialization
  void Start () {
    aus = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
