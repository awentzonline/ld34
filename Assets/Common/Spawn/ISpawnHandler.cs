using UnityEngine;
using System.Collections;

namespace FloppyA.Spawn {

	public interface ISpawnHandler {
		void OnSpawn(GameObject gameObject);
	}

}
