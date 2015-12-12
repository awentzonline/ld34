using UnityEngine;
using System.Collections;
using FloppyA.Damage;

namespace FloppyA.Scoring {

	public class ScoreOnDied : MonoBehaviour, IOnDiedHandler {
		public float scoreAmount = 100f;
		public string scoreType = "Killed";
		ScoreKeeper scoreKeeper;

		void Start() {
			if (scoreKeeper == null) {
				// TODO: make this better
				GameObject scoreObj = GameObject.FindGameObjectWithTag("GameRules");  // HACK
				if (scoreObj) {
					scoreKeeper = scoreObj.GetComponent<ScoreKeeper> ();
				}
			}
		}

		public void OnDied(DamageInfo damageInfo) {
			scoreKeeper.IncrementScore(scoreType, scoreAmount);
		}
	}

}
