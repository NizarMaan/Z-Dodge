using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//have to document...
public class MenuSelection : MonoBehaviour {
	public Button playButton;
	public Button instrucButton;
	public Button credButton;
	public Image selectionHighlight;
	private int currentSelection;
	private int rotationMod;
	private SceneLoader loader;
	private Button[] buttons;

	// Use this for initialization
	void Start () {
		buttons = new Button[]{null, playButton, instrucButton, credButton};
		currentSelection = 1;
		rotationMod = 1;
		loader = new SceneLoader ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			moveHighlightDown ();
		}

		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			moveHighlightUp();
		}

		if (Input.GetKeyDown (KeyCode.KeypadEnter) || Input.GetKeyDown (KeyCode.Return) ) {
			loader.LoadScene (currentSelection);
			/*switch(currentSelection){
				case 1:
					SceneLoader.LoadScene(currentSelection);
					break;
				case 2:
					SceneLoader.LoadScene(currentSelection);
					break;
				case 3:
					SceneLoader.LoadScene(currentSelection);
					break;

			}*/
		}
	}

	public void mouseSelection(Button choice){
		selectionHighlight.transform.position = new Vector2 (selectionHighlight.transform.position.x, choice.transform.position.y);
		rotateHighlight ();
	}

	void moveHighlightDown(){
		if(currentSelection == 3){
			currentSelection = 1;
			selectionHighlight.transform.position = new Vector2(selectionHighlight.transform.position.x, buttons[currentSelection].transform.position.y);
		}
		else{
			currentSelection++;
			selectionHighlight.transform.position = new Vector2(selectionHighlight.transform.position.x, buttons[currentSelection].transform.position.y);
		}
		rotateHighlight ();
	}

	void moveHighlightUp(){
		if(currentSelection == 1){
			currentSelection = 3;
			selectionHighlight.transform.position = new Vector2(selectionHighlight.transform.position.x, buttons[currentSelection].transform.position.y);
		}
		else{
			currentSelection--;
			selectionHighlight.transform.position = new Vector2(selectionHighlight.transform.position.x, buttons[currentSelection].transform.position.y);
		}
		rotateHighlight ();
	}

	void rotateHighlight(){
		if(currentSelection == 1){
			selectionHighlight.transform.localEulerAngles = new Vector3(0, 0, rotationMod * 183);
		}
		else if(currentSelection == 2){
			selectionHighlight.transform.localEulerAngles = new Vector3(0, 0, rotationMod * 183);
		}
		else{
			selectionHighlight.transform.localEulerAngles = new Vector3(0, 0, rotationMod * 183);
		}

		rotationMod *= -1;
	}
}
