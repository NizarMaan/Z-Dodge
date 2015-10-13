using UnityEngine;
using System.Collections;

public class CreateBall : MonoBehaviour {

	private PlayerController count;		//keep track of number of balls on the screen
	private float yCord;
	private float xCord;
	private Vector3 _spawnPoint;
	private float spawnTime;
	public GameObject _dragonBall;
	public static int ballCount;		//keeping track of number of balls on the screen

	//use dummy objects to get limit of the dragonballs' movement
	//declare as public static for easy access by BallBehaviour class
	public static float leftBorderLimit;
	public static float topBorderLimit;
	public static float bottomBorderLimit;
	public static float rightBorderLimit;

	public GameObject _topRightCorner;
	public GameObject _topLeftCorner;
	public GameObject _bottomLeftCorner;
	public GameObject _bottomRightCorner;

	void Start(){
		ballCount = 0;
		topBorderLimit = _topRightCorner.transform.position.y;
		bottomBorderLimit = _bottomLeftCorner.transform.position.y;
		rightBorderLimit = _bottomRightCorner.transform.position.x;
		leftBorderLimit = _bottomLeftCorner.transform.position.x;

		//create a ball every spawnTime seconds
		spawnTime = 0.5f * (ballCount/5) + 1;

		Invoke ("createBall", spawnTime);						//invoke createBall() method after "spawntime" seconds
	}
	
	void createBall () {
		//maximum amount of balls capped at 70
		if(ballCount < 50 && PlayerController.gameOver == false){
			//generate random x and y cords between appropriate ranges
			yCord = Random.Range (bottomBorderLimit, topBorderLimit);		
			xCord = Random.Range (leftBorderLimit, rightBorderLimit);
			_spawnPoint = new Vector3 (xCord, yCord, 0);
			Instantiate (_dragonBall, _spawnPoint, Quaternion.identity);
			ballCount += 1;										//keep track of number of balls created
			spawnTime = 0.5f * (ballCount/5 + 1);				//spawn time for dragonballs increases as the amount of balls increases
			Invoke("createBall", spawnTime);					//a recursive method, invokes itself after "spawntime" seconds
		}
	}
}
