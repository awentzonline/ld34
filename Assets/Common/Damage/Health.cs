using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

namespace FloppyA.Damage {

	public class Health : MonoBehaviour {
		public float maxHealth = 100.0f;
		float health = 0.0f;
		bool hasDied = false;
		
		public void Damage(float amount) {
			if (!hasDied) {
				health -= amount;
				health = Mathf.Max (0, health);
				if (health == 0) {
					hasDied = true;
				}
			}
		}

		public void Heal(float amount) {
			if (!hasDied) {
				health += amount;
				health = Mathf.Min (maxHealth, health);
			}
		}

		public float GetHealth() {
			return health;
		}

		public bool IsAlive() {
			return !hasDied;
		}

		public bool IsDead() {
			return hasDied;
		}

	}

}
