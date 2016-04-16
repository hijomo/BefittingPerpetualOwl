using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

  private Rigidbody rig;
  public float playerMoveSpeed = 10f;
  public float playerTurningSpeed = 10f;
  private float moveInput;
  private float turnInput;
	// Use this for initialization
	void Start () {
    rig = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
    moveInput = Input.GetAxis("Vertical");
    turnInput = Input.GetAxis("Horizontal");
	}

  void FixedUpdate()
  {
    Vector3 forward = transform.TransformDirection(Vector3.up) * moveInput * playerMoveSpeed * Time.fixedDeltaTime;
    forward.z = 0f;
    rig.MovePosition(rig.position + forward);
    
    float turn = turnInput * playerTurningSpeed * Time.fixedDeltaTime;
    Quaternion turnRotation = Quaternion.Euler(0f, 0f, -turn);
    rig.MoveRotation(rig.rotation * turnRotation);

 
    
  }
}


