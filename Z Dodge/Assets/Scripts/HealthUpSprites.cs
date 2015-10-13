using UnityEngine;
using System.Collections;

public class HealthUpSprites : MonoBehaviour {
	//this function is called as an Animation Event
	public void RemoveHealthUpSprite(){
		Destroy (gameObject);
	}

}
