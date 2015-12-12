using UnityEngine;
using System.Collections;

namespace FloppyA.ParticleFX {

	public enum FXType {
		SmokePuff,
		BloodSplash
	}

	public class WorldParticleFX : MonoBehaviour {
		static public WorldParticleFX current;
		public ParticleSystem smokePuffParticleSystem;
		public ParticleSystem bloodParticleSystem;
		public float bloodAmountRatio = 1f;
		public float smokePuffAmountRatio = 1f;

		void Awake() {
			current = this;
		}

		public void MakeFX(FXType fxType, Vector3 position, Vector3 direction, float amount) {
			switch (fxType) {
				case FXType.SmokePuff:
					MakeSmokePuff(position, direction, amount);
					break;
				case FXType.BloodSplash:
					MakeBloodSplash(position, direction, amount);
					break;
			}	
		}

		public void MakeSmokePuff(Vector3 position, Vector3 direction, float amount) {
			smokePuffParticleSystem.transform.position = position;
			smokePuffParticleSystem.transform.rotation = Quaternion.LookRotation(direction);
			int numParticles = (int) (smokePuffAmountRatio * amount);
			smokePuffParticleSystem.Emit(numParticles);
		}

		public void MakeBloodSplash(Vector3 position, Vector3 direction, float amount) {
			bloodParticleSystem.transform.position = position;
			bloodParticleSystem.transform.rotation = Quaternion.LookRotation(direction);
			int numParticles = (int) (bloodAmountRatio * amount);
			bloodParticleSystem.Emit(numParticles);
		}

	}

}