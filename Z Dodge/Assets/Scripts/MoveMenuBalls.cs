using UnityEngine;
using System.Collections;

//this script moves an object in a circular motion
//formula obtained from: http://answers.unity3d.com/questions/596671/circular-rotation-via-the-mathematical-circle-equa.html
//thanks to user ziv03: http://answers.unity3d.com/users/258007/ziv03.html

public class MoveMenuBalls : MonoBehaviour {
	float angle;
	float speed;
	float newX;
	float newY;
	float radius;
	public GameObject gameTitle;

	// Use this for initialization
	void Start () {
		//angle in the circle to start rotation at, relative to circle center
		angle = 180;
		//speed of the object
		speed = (2 * Mathf.PI) / 5; //2*PI in degress is 360, so you get 5 seconds to complete a circle
		//radius of the movement
		radius= 1.00f;
	}
	
	// Update is called once per frame
	void Update () {
		//moving the object around the circle relative to time
		angle += speed*Time.deltaTime; //if you want to switch direction, use -= instead of +=
		//calculate angles,  x= cos(angle)*R+a, y = sin(angle)*R+b where 'a' and 'b' are the center of the circle (a,b).
		newX = Mathf.Cos(angle)*radius + gameTitle.transform.position.x;
		newY = Mathf.Sin(angle)*radius + gameTitle.transform.position.y;
		//actually move the object
		gameObject.transform.position = new Vector3 (newX, newY, gameObject.transform.position.z);
	}
}
