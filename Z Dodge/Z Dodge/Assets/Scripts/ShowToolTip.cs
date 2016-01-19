using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowToolTip : MonoBehaviour {
	public GameObject referencePoint;
	public static bool inPosition;

	// Use this for initialization
	void Start () {
		inPosition = false;
	}

	public void CreateToolTipText(GameObject text){
		if (inPosition == true) {
			Text toolTipText = text.GetComponent<Text> ();
			toolTipText.enabled = true;
		}
	}
	//called as an event trigger when mouse hovers over the image
	public void CreateToolTipPanel(GameObject panel){
		if (inPosition == true) {
			Image panelImage = panel.GetComponent<Image> ();
			panelImage.enabled = true;
		}
	}
	public void HideToolTipText(GameObject text){
		if (inPosition == true) {
			Text toolTipText = text.GetComponent<Text> ();
			toolTipText.enabled = false;
		}
	}
	//called as an event trigger when mouse exits image area
	public void HideToolTipPanel(GameObject panel){
		if (inPosition == true) {
			Image panelImage = panel.GetComponent<Image> ();
			panelImage.enabled = false;
		}
	}
}
