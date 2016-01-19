using UnityEngine;
using System.Collections;

public class BallBehaviour : MonoBehaviour {
	private float horizontalMoveSpeed;			//variable to store ball's move speed
	private float vertMoveSpeed;
	private float[] validMoveSpeeds;			//a selection of possible movement speeds for balls
	private int[] validAngleChanges;			//a selection of angles to change direction by
	private Rigidbody2D thisBall;				//reference to ball's rigidbody component
	private int angle;							//angle to change direction by

	// Use this for initialization
	void Start () {
		//get ball's rigidbody component
		thisBall = GetComponent<Rigidbody2D>();
		//list of possible move speeds
		validAngleChanges = new int [] {-30, -45, -60, -75, -90};
		validMoveSpeeds =  new float [] {-3.0f, -2.5f, -2.0f, -1.5f, -1.0f, 1.0f, 1.5f, 2.0f, 2.5f, 3.0f};

		//moveSpeed in different directions is random value within specified range
		horizontalMoveSpeed = validMoveSpeeds[Random.Range (0, validMoveSpeeds.Length)];			
		vertMoveSpeed = validMoveSpeeds[Random.Range (0, validMoveSpeeds.Length)];
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerController.gameOver == false) {
			transform.Translate (Vector2.right * horizontalMoveSpeed * Time.deltaTime);
			transform.Translate (Vector2.up * vertMoveSpeed * Time.deltaTime);
		}
		//if game is over balls fall
		else {
			thisBall.gravityScale = 1;
		}
	}

	//check for coillision with game border colliders so ball can "bounce" (change direction)
	void OnCollisionStay2D(Collision2D col){
		//randomly choose angle
		angle = validAngleChanges [Random.Range (0, validAngleChanges.Length)];

		//apply direction change on collision with a border
		if (col.transform.tag == "GameBorderCollider") {
			transform.Rotate (Vector3.forward * angle);	
			transform.Translate (Vector2.right * horizontalMoveSpeed * Time.deltaTime);
			transform.Translate (Vector2.up * vertMoveSpeed * Time.deltaTime);
		}
		//disable physics once game is over and object collides with something
		if (PlayerController.gameOver == true) {
			thisBall.isKinematic = true;
		}
	}
}


