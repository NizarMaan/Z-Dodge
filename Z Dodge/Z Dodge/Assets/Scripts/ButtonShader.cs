using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonShader : MonoBehaviour {
	public static int currentSelection;
	
	//called when mouse enters button region, changes opacity and color of the button text
	public void ChangeShadeAndColor(GameObject thisObject){
		Text text = thisObject.GetComponent<Text> ();
		text.color = new Color32 (20, 50, 25, 50);
	}

	//called when mouse exits button region, changes opacity and color of the button text back to normal
	public void DefaultShadeAndColor(GameObject thisObject){
		Text text = thisObject.GetComponent<Text> ();
		text.color = new Color32 (0, 0, 0, 255);
	}

	//change opacity for a button's image
	public void  ChangeOpacity(Button someButton){
		Image image = someButton.GetComponent<Image> ();
		image.color = new Color32 (20, 50, 25, 50);
	}

	//change a button's image opacity back to normal
	public void DefaultOpacity(Button someButton){
		Image image = someButton.GetComponent<Image> ();
		image.color = new Color32 (0, 0, 0, 255);
	}
}
