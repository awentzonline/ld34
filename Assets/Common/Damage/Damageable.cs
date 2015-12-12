using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;

namespace FloppyA.Damage {

	public class DamageInfo {
		public float amount;
		public Vector3 point;
		public Vector3 normal;
		public Vector3 direction;
		public float forceMagnitude;

		public DamageInfo(float amount, Vector3 point, Vector3 normal, Vector3 direction, float forceMagnitude) {
			this.amount = amount;
			this.point = point;
			this.normal = normal;
			this.direction = direction;
			this.forceMagnitude = forceMagnitude;
		}
	}

	public class DamageEventData : BaseEventData {
		public DamageInfo damageInfo;
		public DamageEventData(EventSystem eventSystem, DamageInfo damageInfo) : base(eventSystem) {
			this.damageInfo = damageInfo;
		}
	}

	public interface IOnDamageHandler : IEventSystemHandler {
		void OnDamage (DamageInfo damageInfo);
	}

	public interface IOnDiedHandler : IEventSystemHandler {
		void OnDied (DamageInfo damageInfo);
	}


	public class DamageEvents {
		public static readonly ExecuteEvents.EventFunction<IOnDamageHandler> OnDamageHandler = ExecuteOnDamage;
		private static void ExecuteOnDamage(IOnDamageHandler handler, BaseEventData eventData)
		{
			handler.OnDamage (ExecuteEvents.ValidateEventData<DamageEventData> (eventData).damageInfo);
		}

		public static readonly ExecuteEvents.EventFunction<IOnDiedHandler> OnDiedHandler = ExecuteOnDied;
		private static void ExecuteOnDied(IOnDiedHandler handler, BaseEventData eventData)
		{
			handler.OnDied (ExecuteEvents.ValidateEventData<DamageEventData> (eventData).damageInfo);
		}

	}

	public class Damageable : MonoBehaviour {
		Health health;

		void Start() {
			health = GetComponent<Health> ();
		}

		public void Damage(DamageInfo damageInfo) {
			DamageEventData eventData = new DamageEventData(EventSystem.current, damageInfo);
			ExecuteEvents.Execute<IOnDamageHandler> (gameObject, eventData, DamageEvents.OnDamageHandler);
			if (health != null && health.IsAlive ()) {
				health.Damage (damageInfo.amount);
				if (health.IsDead()) {
					ExecuteEvents.Execute<IOnDiedHandler> (gameObject, eventData, DamageEvents.OnDiedHandler);
				}
			}
		}
	}

}
