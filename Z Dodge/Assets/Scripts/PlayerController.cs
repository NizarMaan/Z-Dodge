using UnityEngine;
using System.Collections;

/*
Created by Nizar Maan on Unity 5
*/

public class PlayerController : MonoBehaviour {
	public float moveSpeed;
	private float yScale;
	private Animator animator;
	private int direction;								//-1 or 1
	private Collider2D gotenks;							//this objects collider
	public AudioClip _onHitFX;							//public variable, audio file given in inspector
	public AudioClip _recoveryFX;						//public variable, audio file given in inspector
	public AudioClip _onHitTauntFX;						//public variable, audio file given in inspector
	public AudioClip _onHitTaunt2FX;					//public variable, audio file given in inspector
	public AudioClip _onHitTaunt3FX;					//public variable, audio file given in inspector
	public AudioClip _CapsulePickUp;					//soundeffect upon capsule pickup
	public AudioClip _healthPickUp;						//soundeffect upon capsule pickup
	public AudioSource _backGroundMusic;				//reference to the background music player
	public GameObject _healthUpAnim;					//reference to healh gain animation sprites
	public static int health;
	public static int maxHealth;
	private SpriteRenderer playerSprite;
	public static bool gameOver;

	// Use this for initialization
	//initializing variables
	void Start () {
		gameOver = false;

		//get player sprite's renderer component
		playerSprite = gameObject.GetComponent<SpriteRenderer> ();

		maxHealth = 5;
		health = maxHealth;

		//get player's collider component
		gotenks = gameObject.GetComponent<Collider2D>();

		direction = 1;   								//direction facing, 1 for facing right, -1 for facing left

		//get player's animator componenet
		animator = GetComponent<Animator>();

		moveSpeed = 2.0f;

		yScale = transform.localScale.y;				//store the yScale to keep size of sprite consistent when calculating direction
		animator.SetBool ("isMoving", false);
	}
	
	// Update is called once per frame
	void Update () {
		if (gameOver == false) {
			//use this line to reset player sprite Z rotations to zero to counteract unwanted Z axis rotations upon impact with a ball
			transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, 0);		

			//stopped moving
			if (Input.GetKeyUp (KeyCode.A) || Input.GetKeyUp (KeyCode.D) || Input.GetKeyUp (KeyCode.W) || Input.GetKeyUp (KeyCode.S)) {
				animator.SetBool ("isMoving", false);
			}
			//use "direction" variable to multiply the X cord with it and reverse the direction sprite is facing
			//player movement within game border limits
			//moving to the right
			if (Input.GetKey (KeyCode.D) && animator.GetBool ("gotHit") == false && gameObject.transform.position.x <= CreateBall.rightBorderLimit) {
				direction = 1;
				animator.SetBool ("isMoving", true);
				transform.localScale = new Vector2 (direction, yScale);
				transform.Translate (direction * Vector2.right * moveSpeed * Time.deltaTime);
			}

			//moving to the left
			if (Input.GetKey (KeyCode.A) && animator.GetBool ("gotHit") == false && gameObject.transform.position.x >= CreateBall.leftBorderLimit) {
				direction = -1;
				animator.SetBool ("isMoving", true);
				transform.localScale = new Vector2 (direction, yScale);
				transform.Translate (direction * Vector2.right * moveSpeed * Time.deltaTime);
			}

			//moving up
			if (Input.GetKey (KeyCode.W) && animator.GetBool ("gotHit") == false && gameObject.transform.position.y <= CreateBall.topBorderLimit) {
				animator.SetBool ("isMoving", true);
				transform.Translate (Vector2.up * moveSpeed * Time.deltaTime);
			}

			//moving down
			if (Input.GetKey (KeyCode.S) && animator.GetBool ("gotHit") == false && gameObject.transform.position.y >= CreateBall.bottomBorderLimit) {
				animator.SetBool ("isMoving", true);
				transform.Translate (-Vector2.up * moveSpeed * Time.deltaTime);
			}
		}
	}

	//check for collision with ball to set animation and reduce health
	//reduce health, trigger animation, destroy ball object
	void OnCollisionEnter2D (Collision2D coll){
		if (coll.transform.tag == "Ball") {
			GameObject ballObject = coll.gameObject;			//reference to the ball collided with
			gotenks.isTrigger = true;							//player becomes invulnerable
			animator.SetBool ("gotHit", true);
			animator.SetBool ("isRecovered", false);

			if (health > 0){
				health = health - 1;							//reduce health by 1 when hit
			}
			LifeIcons.reduceHealth = true;
			Destroy(ballObject);
		}

		if (coll.transform.tag == "HealthCapsule") {
			//invoke the healthanimation object as a child of the Player sprite
			GameObject healthAnim = (GameObject) Instantiate (_healthUpAnim, gameObject.transform.position, Quaternion.identity);
			healthAnim.transform.parent = gameObject.transform;
			//set the size of it
			healthAnim.transform.localScale = new Vector3(0.7f,0.8f,1);

			GameObject healthCapsule = coll.gameObject;			//reference to health capsule object
			GetComponent<AudioSource> ().PlayOneShot (_CapsulePickUp, 0.5f);
			GetComponent<AudioSource> ().PlayOneShot (_healthPickUp, 0.5f);
			if(health < 5){
				health = health + 1;							//increase health by 1
			}
			LifeIcons.addHealth = true;
			Destroy (healthCapsule);							//destory the capsule object
		}
	}


	//the following functions are called as an Animation Event, the player recovers after-
	//the "take damage" animation is finished, and appropriate soundFX are played
	//return type is IEnumerator, as required for using the Unity library function "WaitForSeconds"
	IEnumerator Recovery(){
		animator.SetBool ("gotHit", false);
		animator.SetBool ("isRecovered", true);

		playerSprite.color = new Color32(150, 150, 150, 150);	//modify sprite to darker color for visual queue of invulnerability, reduce opacity

		yield return new WaitForSeconds (1.0f);					//wait 1 seconds before becoming vulnerable
		gotenks.isTrigger = false;								//player becomes vulnerable again
		playerSprite.color = new Color32(255, 255, 255, 255);	//reset color
	}


	//play this upon end of the recovery animation as an animation event
	void RecoverySound(){
		GetComponent<AudioSource> ().PlayOneShot (_recoveryFX, 0.3f);
	}

	//this function is called as an Animation Event
	void IsDead(){
		if (health == 0) {
			gameOver = true;
			_backGroundMusic.Stop ();
			gotenks.isTrigger = true;
			animator.enabled = false;
		}
	}

	//this function is called as an Animation Event
	void GotHitSound(){
		//33% chance for one of these soundFX to play
		int decider = Random.Range (1, 100);
		if (decider > 66) {
			GetComponent<AudioSource> ().PlayOneShot (_onHitTauntFX, 0.3f);
		} 
		else if (decider > 33){
			GetComponent<AudioSource> ().PlayOneShot (_onHitTaunt3FX, 1.2f);
		}
		else 
		{
			GetComponent<AudioSource> ().PlayOneShot (_onHitTaunt2FX, 0.3f);
		}
		GetComponent<AudioSource> ().PlayOneShot (_onHitFX, 0.3f);
	}
}
