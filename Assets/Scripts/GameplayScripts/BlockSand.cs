using UnityEngine;
using System.Collections;

public class BlockSand : MonoBehaviour {

	void OnTriggerEnter(Collider col) {
		if (col.CompareTag("Player")) {
			GameObject go = col.gameObject;
			PlayerBlockv2 playerBlockScript = go.GetComponent<PlayerBlockv2>();
			if (playerBlockScript.isStanding()) {
				playerBlockScript.falling();
			}
		}
	}
}
