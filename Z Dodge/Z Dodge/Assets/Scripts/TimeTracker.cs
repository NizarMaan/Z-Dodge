using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeTracker : MonoBehaviour {
	public Text timerText;				//text object reference obtained through Inspector
	public static int secondsElapsed;

	// Use this for initialization
	void Start () {
		//Invoker trackTime function every second
		InvokeRepeating ("trackTime", 0.0f, 1.0f);
	}

	public void trackTime() {
		//update secondsElapsed and display text to game screen
		if (PlayerController.gameOver == false) {
			//time since the main game screen was loaded
			secondsElapsed = (int) Time.timeSinceLevelLoad;
			timerText.text = "Time Elapsed: " + secondsElapsed.ToString ();
		}
	}
}
