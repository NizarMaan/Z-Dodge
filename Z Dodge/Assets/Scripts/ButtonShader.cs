using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonShader : MonoBehaviour {

	//called when mouse enters button region, changes opacity and color of the button
	public void ChangeShadeAndColor(GameObject thisObject){
		Image image = thisObject.GetComponent<Image> ();
		image.color = new Color32 (255, 50, 25, 50);
	}

	//called when mouse exits button region, changes opacity and color of the button back to normal
	public void DefaultShadeAndColor(GameObject thisObject){
		Image image = thisObject.GetComponent<Image> ();
		image.color = new Color32 (219, 139, 18, 255);
	}
}
