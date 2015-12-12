using UnityEngine;
using System.Collections;

public class ChangeLevel : MonoBehaviour {
	public string levelName;

	public void GotoLevel() {
		Application.LoadLevel (levelName);
	}
}
