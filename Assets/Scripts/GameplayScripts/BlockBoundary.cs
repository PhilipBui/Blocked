using UnityEngine;
using System.Collections;

public class BlockBoundary : MonoBehaviour {

	 void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "Player") {
			col.gameObject.GetComponent<PlayerBlockv2>().falling();
        }
     }
}
