using UnityEngine;
using System.Collections;

public class PlayerHit : MonoBehaviour {
  public bool isQuad ;
  public bool isTri = true;
  public bool isLine;
  public AudioSource aus;
  public GameObject fourSideMesh;
  public GameObject threeSideMesh;
  public GameObject twoSideMesh;
  public GameObject currentForm;
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
      FormDown();
      //form down
   
    }
  }



    // Use this for initialization
    void Start () {
    aus = gameObject.GetComponent<AudioSource>();
	}
  public void FormUp()
  {

    if (isLine)
    {
      isLine = false;
      Destroy(currentForm);
      GameObject obj = (GameObject)Instantiate(threeSideMesh, Vector3.zero, Quaternion.identity);
      obj.transform.SetParent(gameObject.transform, false);
      obj.GetComponent<MeshRenderer>().material = playerMat;
      currentForm = obj;
      Quaternion hardpointrotation1 = Quaternion.Euler(0f, 0f, 0f);
      Quaternion hardpointrotation2 = Quaternion.Euler(0f, 0f, 120f);
      Quaternion hardpointrotation3 = Quaternion.Euler(0f, 0f, 240f);
      gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(Vector3.zero);
      hP1.SetActive(true);
      hP1.GetComponent<Transform>().rotation = hardpointrotation1;
      hP2.SetActive(true);
      hP2.GetComponent<Transform>().rotation = hardpointrotation2;
      hP3.SetActive(true);
      hP3.GetComponent<Transform>().rotation = hardpointrotation3;
      hP4.SetActive(false);
      isTri = true;
      return;
    }
    if (isTri)
    {
      isTri = false;
      Destroy(currentForm);
      GameObject obj = (GameObject)Instantiate(fourSideMesh, Vector3.zero, Quaternion.identity);
      obj.transform.SetParent(gameObject.transform, false);
      obj.GetComponent<MeshRenderer>().material = playerMat;
      currentForm = obj;
      Quaternion hardpointrotation1 = Quaternion.Euler(0f, 0f, 0f);
      Quaternion hardpointrotation2 = Quaternion.Euler(0f, 0f, 90f);
      Quaternion hardpointrotation3 = Quaternion.Euler(0f, 0f, 180f);
      Quaternion hardpointrotation4 = Quaternion.Euler(0f, 0f, 270f);
      gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(Vector3.zero);
      hP1.SetActive(true);
      hP1.GetComponent<Transform>().rotation = hardpointrotation1;
      hP2.SetActive(true);
      hP2.GetComponent<Transform>().rotation = hardpointrotation2;
      hP3.SetActive(true);
      hP3.GetComponent<Transform>().rotation = hardpointrotation3;
      hP4.SetActive(true);
      hP4.GetComponent<Transform>().rotation = hardpointrotation4;
      isQuad = true;
      return;
    }
    if (isQuad)
    {
      return;
    }
  }
  void FormDown()
  {
    if (Time.time < nextHit) return;
  
    nextHit = Time.time + hitCoolDown;
    aus.Play();
    if (isLine)
    {
      Destroy(gameObject, 1.5f);
      return;
    }
    if (isTri)
    {
      isTri = false;
      Destroy(currentForm);
      GameObject obj = (GameObject)Instantiate(twoSideMesh, Vector3.zero, Quaternion.identity);
      obj.transform.SetParent(gameObject.transform, false);
      obj.GetComponent<MeshRenderer>().material = playerMat;
      currentForm = obj;
      gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(Vector3.zero);
      Quaternion hardpointrotation1 = Quaternion.Euler(0f, 0f, 0f);
      Quaternion hardpointrotation2 = Quaternion.Euler(0f, 0f, 180f);
      hP1.SetActive(true);
      hP1.GetComponent<Transform>().rotation = hardpointrotation1;
      hP2.SetActive(true);
      hP2.GetComponent<Transform>().rotation = hardpointrotation2;
      hP3.SetActive(false);
      hP4.SetActive(false);
      isLine = true;
      return;
    }
    if (isQuad)
    {
      isQuad = false;
      Destroy(currentForm);
      GameObject obj = (GameObject)Instantiate(threeSideMesh, Vector3.zero, Quaternion.identity);
      obj.transform.SetParent(gameObject.transform, false);
      obj.GetComponent<MeshRenderer>().material = playerMat;
      currentForm = obj;
      Quaternion hardpointrotation1 = Quaternion.Euler(0f, 0f, 0f);
      Quaternion hardpointrotation2 = Quaternion.Euler(0f, 0f, 120f);
      Quaternion hardpointrotation3 = Quaternion.Euler(0f, 0f, 240f);
      gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(Vector3.zero);
      hP1.SetActive(true);
      hP1.GetComponent<Transform>().rotation = hardpointrotation1;
      hP2.SetActive(true);
      hP2.GetComponent<Transform>().rotation = hardpointrotation2;
      hP3.SetActive(true);
      hP3.GetComponent<Transform>().rotation = hardpointrotation3;
      hP4.SetActive(false);
      isTri = true;
      return;
    }
  }
	// Update is called once per frame
	void Update () {
	 if (Input.GetKeyDown(KeyCode.T))
    {
      //form up
    }
	}
}
