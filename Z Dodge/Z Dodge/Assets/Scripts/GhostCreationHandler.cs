using UnityEngine;
using System.Collections;

public class GhostCreationHandler : MonoBehaviour {
	public static int ghostCount;				//keep track of how many ghosts created
	private Animator animator;					//reference to animator
	public static int destroyCount;				//keep track of how many ghosts destroyed
	private float moveSpeed;
	private bool dashAway;						//variable to check whether to make gotenks dash off screen

	// Use this for initialization
	void Start () {
		dashAway = false;
		moveSpeed = 0.06f;
		destroyCount = 0;
		ghostCount = 0;
		animator = gameObject.GetComponent<Animator> ();
	}
	void Update(){
		if (dashAway == true && transform.position.x > -30) {
			transform.position = new Vector2 (transform.position.x - moveSpeed, transform.position.y);
		}
		if(transform.position.x < -30){
			Destroy (gameObject);
		}
	}

	//this function is called as an Animation Event
	public void GhostReady(GameObject ghost){
		if(ghostCount < 5){
			//create a ghost object slightly to the left
			Instantiate(ghost, new Vector3(transform.position.x -.25f, transform.position.y, transform.position.z), Quaternion.identity);
			ghostCount++;		//+1 to ghost count
		}
	}

	//this function is called as an Animation Event
	public void FinishedMakingGhosts(){
		//once finished making ghosts set animator value to change animation
		if (ghostCount > 4) {
			animator.SetBool ("finishedGhosts", true);
		}
	}

	//this function is called as an Animation Event
	//animate gotenks to dash away off the screen
	public void GotenksGoAway(){
		dashAway = true;
	}

	//this function is called as an Animation Event
	public void StopAnimating(){
		animator.enabled = false;
	}
}
