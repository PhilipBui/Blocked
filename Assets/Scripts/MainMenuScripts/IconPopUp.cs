using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class IconPopUp : MonoBehaviour {

	public List<Transform> icons = new List<Transform>();
	private float iconTimeAppear = 2f;
	private float delayBetweenIcons = 0.05f;
	// Use this for initialization
	void Start () {
		foreach (Transform child in transform)
			icons.Add(child);
		hideIcons();
		StartCoroutine(popUpIcons());
	}
	
	void OnEnable() {
		StartCoroutine(popUpIcons());
	}
	void OnDisable() {
		hideIcons();
	}
	private IEnumerator popUpIcons() {
		for (int i = 0; i < icons.Count; i++) {
			StartCoroutine(scaleUpIcon(icons[i].transform));
			yield return new WaitForSeconds(delayBetweenIcons);
		}
	}
	private IEnumerator scaleUpIcon(Transform icon) {
		float t = 0f;
		Vector3 one = new Vector3(1f, 1f, 1f);
		while (t < 1f) {
			t+= Time.deltaTime / iconTimeAppear;
			icon.localScale = Vector3.Lerp(icon.localScale, one, t);
			yield return 0;
		}
	}
	private void hideIcons() {
		for (int i = 0; i < icons.Count; i++) {
			icons[i].transform.localScale = Vector3.zero;
		}
	}
}
