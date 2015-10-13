using UnityEngine;
using System.Collections;

public class SlideGhost : MonoBehaviour {
	private float finalXPosition;		
	private float finalZRotation;
	private float horizontalMoveSpeed;
	public AudioClip _introSound;
	private float rotationSpeed;
	private RectTransform rectTransform;
	private bool finalPosition;
	private float initialXpos;

	// Use this for initialization
	void Start () {
		finalPosition = false;
		rotationSpeed = 50.0f;
		horizontalMoveSpeed = 200.0f;
		finalXPosition = 820.0f;
		finalZRotation = 35.0f;
		rectTransform = gameObject.GetComponent<RectTransform> ();
		initialXpos = rectTransform.position.x;
	}

	//move the ghost picture in the Instructions menu back and forth
	void Update(){
		if (finalPosition == false) {
			if (rectTransform.position.x > finalXPosition) {
				transform.Translate (Vector2.right * -horizontalMoveSpeed * Time.deltaTime);
			}
			if (gameObject.transform.eulerAngles.z < finalZRotation) {
				transform.Rotate (Vector3.forward * rotationSpeed * Time.deltaTime);
			}
			if (gameObject.transform.eulerAngles.z >= finalZRotation && gameObject.transform.position.x <= finalXPosition) {
				finalPosition = true;
				PlaySound ();
			}
		} 
		//move back every 'x' seconds
		if(finalPosition == true && (((int) Time.time) % 10) == 0) {
			if (rectTransform.position.x < initialXpos) {
				transform.Translate (Vector2.right * horizontalMoveSpeed * Time.deltaTime);
			}

			if (gameObject.transform.position.x >= initialXpos) {
				finalPosition = false;
			}
		}
	}
	
	void PlaySound(){
		GetComponent<AudioSource> ().PlayOneShot (_introSound, 0.3f);	
	}
}