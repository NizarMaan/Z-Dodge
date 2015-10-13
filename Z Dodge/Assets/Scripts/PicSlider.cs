using UnityEngine;
using System.Collections;

public class PicSlider : MonoBehaviour {
	private float finalXPosition;
	private float moveSpeed;
	public AudioClip _introSound1;
	public AudioClip _introSound2;
	private bool isPlaying;

	// Use this for initialization
	void Start () {
		isPlaying = false;
		moveSpeed = 2.0f;
		finalXPosition = -6.4f;
	}
	void Update(){
		if (gameObject.transform.position.x < finalXPosition) {
			transform.Translate (Vector2.right * moveSpeed * Time.deltaTime);
		}
		if (gameObject.transform.position.x >= finalXPosition && isPlaying == false) {
			PlaySound ();
		}
	}

	void PlaySound(){
		int decider = Random.Range (1, 100);
		isPlaying = true;
		if (decider > 50) {
			GetComponent<AudioSource> ().PlayOneShot (_introSound1, 0.3f);
		} 
		else {
			GetComponent<AudioSource> ().PlayOneShot (_introSound2, 0.3f);
		}
	}
	
}
