using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifeIcons : MonoBehaviour {
	//Life Icons passed in the inspector
	public Image lifeIcon1;
	public Image lifeIcon2;
	public Image lifeIcon3;
	public Image lifeIcon4;
	public Image lifeIcon5;

	public static bool addHealth;
	public static bool reduceHealth;

	private readonly byte maxVal = 255;		//store max RGB color val for easy access (type byte)
	private readonly byte minVal = 0;		//store min RGB color val for easy access (type byte)
	private readonly byte alphaVal = 255;	//store alphaVal
	
	// Update is called once per frame
	void Update () {
		//turn the corresponding health icon to black
		//new Color32(byte R, byte G, byte B, byte A) where A is alpha value (determines Opacity)

		if(reduceHealth == true){
			switch(PlayerController.health){
				case 4:
					lifeIcon1.color = new Color32(minVal, minVal, minVal, alphaVal);
					reduceHealth = false;
					break;
				case 3:
					lifeIcon2.color = new Color32(minVal, minVal, minVal, alphaVal);
					reduceHealth = false;
					break;
				case 2:
					lifeIcon3.color = new Color32(minVal, minVal, minVal, alphaVal);
					reduceHealth = false;
					break;
				case 1:
					lifeIcon4.color = new Color32(minVal, minVal, minVal, alphaVal);
					reduceHealth = false;		
					break;
				case 0:
					lifeIcon5.color = new Color32(minVal, minVal, minVal, alphaVal);
					reduceHealth = false;
					break;
			}
		}
		
		//bring corresponding icon back to normal color when a life point is gained
		if (addHealth == true) {
			switch (PlayerController.health) {
			case 2:
				lifeIcon4.color = new Color32 (maxVal, maxVal, maxVal, alphaVal);
				addHealth = false;
				break;
			case 3:
				lifeIcon3.color = new Color32 (maxVal, maxVal, maxVal, alphaVal);
				addHealth = false;
				break;
			case 4:
				lifeIcon2.color = new Color32 (maxVal, maxVal, maxVal, alphaVal);
				addHealth = false;
				break;
			case 5:
				lifeIcon1.color = new Color32 (maxVal, maxVal, maxVal, alphaVal);
				addHealth = false;
				break;
			}
		}
	}
}
