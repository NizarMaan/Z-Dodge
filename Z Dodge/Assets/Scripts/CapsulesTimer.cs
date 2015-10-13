using UnityEngine;
using System.Collections;

//this class will eliminate capsules when they exceed their "lifespan"
public class CapsulesTimer : MonoBehaviour {
	public static float secondsElapsed;
	private float timeAtInit;
	private float healthCapDecayTime;
	SpriteRenderer thisCapsule;
	Renderer capsuleRenderer;

	// Use this for initialization
	void Start () {
		thisCapsule = gameObject.GetComponent<SpriteRenderer> ();
		capsuleRenderer = gameObject.GetComponent<Renderer> ();
		timeAtInit = Time.time;
		healthCapDecayTime = 8.0f;				//a health capsules lifespan is 8 seconds
		InvokeRepeating("FlashCapsule", 0.0f, 0.75f);
	}
	
	//flash the capsule to indicate that it will soon disappear
	void FlashCapsule(){
		if (PlayerController.gameOver == false) {
			secondsElapsed = Time.time - timeAtInit;
			
			//if seconds passed is greater or equal to 75% of the decay time
			if (gameObject.transform.tag == "HealthCapsule" && secondsElapsed >= (0.60 * healthCapDecayTime)) {
				Invoke("Invisible", 0.0f);
				Invoke("Visible", 0.25f);
			}
			if (gameObject.transform.tag == "HealthCapsule" && secondsElapsed >= healthCapDecayTime) {
				Destroy (gameObject);
			}
		}
	}

	void Invisible(){
		capsuleRenderer.enabled = false;
	}

	void Visible(){
		capsuleRenderer.enabled = true;
	}
}
