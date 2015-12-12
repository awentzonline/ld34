using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using ScoreDict = System.Collections.Generic.Dictionary<string, float>;

namespace FloppyA.Scoring {

	public class ScoreKeeper : MonoBehaviour {
		static public ScoreKeeper current;
		ScoreDict scoreDict;

		void Awake() {
			current = this;
		}

		void Start () {
			scoreDict = new ScoreDict ();
		}
		
		public void IncrementScore(string scoreName, float amount) {
			float currentValue = 0f;
			if (!scoreDict.TryGetValue (scoreName, out currentValue)) {
				currentValue = 0f;
			}
			scoreDict[scoreName] = currentValue + amount;
		}

		public float GetScore(string scoreName) {
			float value;
			if (!scoreDict.TryGetValue (scoreName, out value)) {
				value = 0f;
			}
			return value;
		}

		public void SetScore(string scoreName, float amount) {
			scoreDict[scoreName] = amount;
		}

		public void ResetScores() {
			scoreDict.Clear ();
		}
	}

}
