using UnityEngine;
using System.Collections;

using FloppyA.Damage;

public class LoseOnDied : MonoBehaviour, IOnDiedHandler {
	public void OnDied(DamageInfo damageInfo) {
		SocietyRules.current.Lose ();
	}
}
