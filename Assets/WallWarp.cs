using UnityEngine;
using System.Collections;

public class WallWarp : MonoBehaviour {


  public bool isTop;
  public bool isBottom;
  public bool isRight;
  public bool isLeft;

  void OnTriggerEnter(Collider other)
  {
    Transform tran = other.GetComponentInParent<Transform>();
    Vector3 pos = tran.position;
    if (other.tag == "Bullet" || other.tag == "PlayerBullet")
    {
      Destroy(other.gameObject);
    }
   if (isTop)
    {
      pos.y = -4f;
      tran.position = pos;
    }
    if (isBottom)
    {
      pos.y = 4f;
      tran.position = pos;
    }
    if (isLeft)
    {
      pos.x = 7f;
      tran.position = pos;
    }
    if (isRight)
    {
      pos.x = -7f;
      tran.position = pos;
    }
  }
  // Use this for initialization
  void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
