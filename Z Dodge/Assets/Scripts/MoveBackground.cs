using UnityEngine;
using System.Collections;

public class MoveBackground : MonoBehaviour {
	public GameObject leftLimit;
	public GameObject rightLimit;
	public float moveSpeed;
	public bool moveRight;
	
	// Use this for initialization
	void Start () {
		moveSpeed = 0.0125f;
		moveRight = false;
	}

	//move the Instructions Menu backgrounds left to right
	void Update(){
		if(gameObject.transform.position.x >= leftLimit.transform.position.x && moveRight == false ){
			transform.position = new Vector2 (transform.position.x - moveSpeed, transform.position.y);
		}
		else{
			moveRight = true;
			transform.position = new Vector2 (transform.position.x + moveSpeed, transform.position.y);
		}
		if (gameObject.transform.position.x >= rightLimit.transform.position.x) {
			moveRight = false;
		}
	}
}

