using UnityEngine;
using System.Collections;

public class MoveGhosts : MonoBehaviour {
	private Animator animator;					//reference to the animator component
	private bool move;							//boolean to tell whether to start moving
	private float moveSpeed;
	private int direction;						//direction either -1 or 1, i.e. turn left or right
	public GameObject turnRightObject;			//object reference passed in the inspector
	public GameObject turnLeftObject;			//object reference passed in the inspector
	private float turnRightPoint;				//the point at which to change direction
	private float turnLeftPoint;				//the point at which to change direction
	private float yScale;						//store yscale
	private bool beginRoaming;

	// Use this for initialization
	void Start () {
		beginRoaming = false;
		moveSpeed = -0.02f;
		direction = -1;
		animator = gameObject.GetComponent<Animator> ();
		turnRightPoint = turnRightObject.transform.position.x;
		turnLeftPoint = turnLeftObject.transform.position.x;
		yScale = transform.localScale.y;
	}
	
	// Update is called once per frame
	void Update () {
		//destroy the ghost if not all ghost have been created yet
		//make ghosts start roaming once the 5 created are destroyed
		//the ghosts that are roaming are the different objects from the ones being "created" by Gotenks
		if (transform.position.x <= turnRightPoint && GhostCreationHandler.destroyCount != 5) {
			GhostCreationHandler.destroyCount += 1;
			Destroy(gameObject);
		}

		//turn right when point reached
		if (transform.position.x <= turnRightPoint && GhostCreationHandler.destroyCount == 5) {
			//keep yscale the same and change direction of movement
			transform.localScale = new Vector2 (direction*transform.localScale.x, yScale);
			transform.position = new Vector2(transform.position.x, transform.position.y + 0.25f);
			moveSpeed = 0.02f;
		}
		//turn left when point reached
		if (transform.position.x >= turnLeftPoint && GhostCreationHandler.destroyCount == 5) {
			//keep yscale the same and change direction of movement
			transform.localScale = new Vector2 (direction*transform.localScale.x, yScale);
			transform.position = new Vector2(transform.position.x, transform.position.y - 0.25f);
			moveSpeed = -0.02f;
		}

		//move the ghosts
		if (move == true) {
			transform.position = new Vector2 (transform.position.x + moveSpeed, transform.position.y);
		}

		//ghosts begin roaming
		if (GhostCreationHandler.destroyCount == 5) {
			if(beginRoaming == false){
				moveSpeed = 0.02f;
			}
			beginRoaming = true;
			transform.position = new Vector2 (transform.position.x + moveSpeed, transform.position.y);
		}
	}

	//this function is called as an Animation Event
	public void StartMoving(){
		move = true;
		animator.enabled = false;
	}
}
