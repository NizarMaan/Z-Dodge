using UnityEngine;
using System.Collections;

//have to document...
public class CapsuleSlider : MonoBehaviour {
	void Start(){
		InvokeRepeating("rotateCapsule", 0, 1.0f);
	}

	// Update is called once per frame
	void Update(){
		if(gameObject.transform.position.x <= 107.0f){
			gameObject.transform.position = new Vector2(transform.position.x + 3.0f, transform.position.y); 
		}
		else{
			ShowToolTip.inPosition = true;
		}
	}

	void rotateCapsule(){
		if (transform.eulerAngles.z <= 90) {
			transform.Rotate(Vector3.forward * 90);
		}
		else{
			transform.Rotate(Vector3.forward * -90);
		}
	}
}
