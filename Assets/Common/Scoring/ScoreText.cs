using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace FloppyA.Scoring {

	public class ScoreText : MonoBehaviour {
		public string scoreName = "Killed";
		ScoreKeeper scoreKeeper;
		float lastValue = 0f;
		Text text;

		void Start () {
			text = GetComponent<Text> ();
			// TODO: improve this
			scoreKeeper = GameObject.FindGameObjectWithTag ("GameRules").GetComponent<ScoreKeeper> ();
		}
		
		// Update is called once per frame
		void Update () {
			float currentValue = scoreKeeper.GetScore (scoreName);
			if (currentValue != lastValue) {
				text.text = currentValue.ToString();
				lastValue = currentValue;
			}
		}
	}

}
