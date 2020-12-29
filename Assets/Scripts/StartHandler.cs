using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartHandler : MonoBehaviour {
	public void OnMouseDown() {
		SceneManager.LoadScene("Main");
	}
}
