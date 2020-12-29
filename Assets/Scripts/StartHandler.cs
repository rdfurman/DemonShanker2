using UnityEngine;
using System.Collections;

public class StartHandler : MonoBehaviour {

	public Sprite normalButton;
	public Sprite hoverButton;

	void OnMouseEnter() {
		GetComponent<GUITexture>().texture = hoverButton.texture;
	}

	void OnMouseExit() {
		GetComponent<GUITexture>().texture = normalButton.texture;
	}

	void OnMouseDown() {
		Application.LoadLevel ("Main");
	}
	
}
