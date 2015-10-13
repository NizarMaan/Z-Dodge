using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowToolTip : MonoBehaviour {
	public GameObject referencePoint;
	private Vector2 spawnPoint;

	// Use this for initialization
	void Start () {
		spawnPoint = referencePoint.transform.position;
	}

	public void CreateToolTipText(GameObject text){
		Text toolTipText = text.GetComponent<Text> ();
		toolTipText.enabled = true;
	}
	//called as an event trigger when mouse hovers over the image
	public void CreateToolTipPanel(GameObject panel){
		Image panelImage = panel.GetComponent<Image> ();
		panelImage.enabled = true;
	}
	public void HideToolTipText(GameObject text){
		Text toolTipText = text.GetComponent<Text> ();
		toolTipText.enabled = false;
	}
	//called as an event trigger when mouse hovers over the image
	public void HideToolTipPanel(GameObject panel){
		Image panelImage = panel.GetComponent<Image> ();
		panelImage.enabled = false;
	}

	//called as an event trigger when mouse leaves image area
	public void  destroyToolTip(GameObject text, GameObject panel){
	
	}

}
