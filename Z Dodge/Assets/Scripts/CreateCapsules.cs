using UnityEngine;
using System.Collections;

public class CreateCapsules : MonoBehaviour {
	private Vector3 _spawnPoint;
	private float yCord;
	private float xCord;
	public GameObject _healthCapsule;				//healthCapsule object reference passed in the inspector
		
	void Start(){
		Invoke ("CapsuleMaker", 5.0f);				//start function to choose a capsule after 5 seconds
	}

	// Update is called once per frame
	void CapsuleMaker () {
		int capsuleTypeDecider = Random.Range (1, 100);

		if (capsuleTypeDecider >= 20) {				//i.e. 80% chance to choose a health Capsule
			GenerateHealthCapsule ();
		}

		if (PlayerController.gameOver == false) {
			Invoke ("CapsuleMaker", 4.0f);				//recursively call self every 5 seconds
		}
	}

	/*since there is an 80% chance for this function to be chosen and x% chance for a health capsule to actually be made,
	the actual chance of a health cap to appear is 0.8*x = actual chance
	x = 0.4, .5, .66, 1.0 and 1.0 respectively
	e.g.   |---5 health---4 health---3 health---2 health---1 health|
	%chance|      32%    |   40%	 |	52.8% |    80%  |     80%  |

	i.e. the lower your health the greater chance for a capsule to appear
	 */
	void GenerateHealthCapsule(){
		//40% chance at max health, 50% chance at 4 health, 66% chance at 3 health, 100% chance at 2 health, and 100% chance at 1 health
		int decider = Random.Range (1, PlayerController.health);
		if (decider == PlayerController.health || decider == PlayerController.health - 1) {						
			yCord = Random.Range (CreateBall.bottomBorderLimit, CreateBall.topBorderLimit);		
			xCord = Random.Range (CreateBall.leftBorderLimit, CreateBall.rightBorderLimit);
			_spawnPoint = new Vector3 (xCord, yCord, 0);
			Instantiate (_healthCapsule, _spawnPoint, Quaternion.identity);
		}
	}

	void GenerateSpeedCapsule(){
		
	}
	void GenerateExplosiveCapsule(){
		
	}
}
