using UnityEngine;
using System.Collections;
using System;
public class PlayerBlock : MonoBehaviour {
	
	bool standing = true;
	bool isVertical = false; 
	float buttonPressed;
	
	private Transform playerTransform;
	private Transform cubeTransform;
	private Animator cubeAnimator;
	private Rigidbody cubeRigidbody;
	private bool animationStarted = false;
	// Use this for initialization
	void Start () {
		playerTransform = transform.parent.transform;
		cubeAnimator = playerTransform.GetComponent<Animator>();
		cubeTransform = transform;
		cubeRigidbody = transform.gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Horizontal") < 0 && !animationStarted) {
			animationStarted = true;
			moveLeft();
		}
		else if (Input.GetAxis("Horizontal") > 0 && !animationStarted) {
			animationStarted = true;
			moveRight();
		}
		else if (Input.GetAxis("Vertical") > 0 && !animationStarted) {
			animationStarted = true;
			moveUp();
		}
		else if (Input.GetAxis("Vertical") < 0 && !animationStarted) {
			animationStarted = true;
			moveDown();
		}
		else if (Time.time > buttonPressed + 120f) {
			
		}
	}
	void FixedUpdate () {
		
	}
	public void moveLeft() {
		if (standing) {
			cubeAnimator.Play("standingDropLeft");
			isVertical = false;
			standing = false;
		}
		else {
			// If horizontal, moving left would make it stand upright!
			if (!isVertical) {
				cubeAnimator.Play("droppedStandLeft");
				standing = true;
			}
			else {
				cubeAnimator.Play("droppedRollLeft");
			}
		}
	}
	
	public void moveRight() {
		if (standing) {
			cubeAnimator.Play("standingDropRight");
			isVertical = false;
			standing = false;
		}
		else {
			// If horizontal, moving left would make it stand upright!
			if (!isVertical) {
				cubeAnimator.Play("droppedStandRight");
				standing = true;
			}
			else {
				cubeAnimator.Play("droppedRollRight");
			}
		}
	}
	
	public void moveUp() {
		if (standing) {
			cubeAnimator.Play("standingDropUp");
			isVertical = true;
			standing = false;
		}
		else {
			// If horizontal, moving left would make it stand upright!
			if (isVertical) {
				cubeAnimator.Play("droppedStandUp");
				standing = true;
			}
			else {
				cubeAnimator.Play("droppedRollUp");
			}
		}
	}
	
	public void moveDown() {
		if (standing) {
			cubeAnimator.Play("standingDropDown");
			isVertical = true;
			standing = false;
		}
		else {
			// If horizontal, moving left would make it stand upright!
			if (isVertical) {
				cubeAnimator.Play("droppedStandDown");
				standing = true;
			}
			else {
				cubeAnimator.Play("droppedRollDown");
			}
		}
	}
	
	public void finishAnimation(String animation) {
		StartCoroutine("wait");
		cubeTransform.position = Vector3.zero;
		cubeTransform.localEulerAngles = Vector3.zero;
		if (animation == "standingDropLeft") {	
			playerTransform.position = new Vector3(playerTransform.position.x -1.5f, 1, playerTransform.position.z);
			playerTransform.localEulerAngles = new Vector3(0, 0, 90);
		}
		else if (animation == "standingDropRight") {
			playerTransform.position = new Vector3(playerTransform.position.x +1.5f, 1, playerTransform.position.z);
			playerTransform.localEulerAngles = new Vector3(0, 0, 90);
		}
		else if (animation == "standingDropUp") {
			playerTransform.position = new Vector3(playerTransform.position.x, 1, playerTransform.position.z + 1.5f);
			playerTransform.localEulerAngles = new Vector3(90, 0, 0);
		}
		else if (animation == "standingDropDown") {
			playerTransform.position = new Vector3(playerTransform.position.x, 1, playerTransform.position.z - 1.5f);
			playerTransform.localEulerAngles = new Vector3(90, 0, 0);
		}
		else if (animation == "droppedRollUp") {
			playerTransform.position = new Vector3(playerTransform.position.x, 1, playerTransform.position.z + 1f);
			playerTransform.localEulerAngles = new Vector3(0, 0, 90);
		}
		else if (animation == "droppedRollDown") {
			playerTransform.position = new Vector3(playerTransform.position.x, 1, playerTransform.position.z - 1f);
			playerTransform.localEulerAngles = new Vector3(0, 0, 90);
		}
		else if (animation == "droppedStandLeft") {
			playerTransform.position = new Vector3(playerTransform.position.x - 1.5f, 1.5f, playerTransform.position.z);
			playerTransform.localEulerAngles = new Vector3(0, 0, 0);
		}
		else if (animation == "droppedStandRight") {
			playerTransform.position = new Vector3(playerTransform.position.x + 1.5f, 1.5f, playerTransform.position.z);
			playerTransform.localEulerAngles = new Vector3(0, 0, 0);
		}
		else if (animation == "droppedRollLeft") {
			playerTransform.position = new Vector3(playerTransform.position.x -1f, 1, playerTransform.position.z);
			playerTransform.localEulerAngles = new Vector3(90, 0, 0);
		}
		else if (animation == "droppedRollRight") {
			playerTransform.position = new Vector3(playerTransform.position.x + 1f, 1, playerTransform.position.z);
			playerTransform.localEulerAngles = new Vector3(90, 0, 0);
		}
		else if (animation == "droppedStandUp") {
			playerTransform.position = new Vector3(playerTransform.position.x, 1.5f, playerTransform.position.z + 1.5f);
			playerTransform.localEulerAngles = new Vector3(0, 0, 0);
		}
		else if (animation == "droppedStandDown") {
			playerTransform.position = new Vector3(playerTransform.position.x, 1.5f, playerTransform.position.z - 1.5f);
			playerTransform.localEulerAngles = new Vector3(0, 0, 0);
		}
		animationStarted = false;
	}
	IEnumerator wait() {
		yield return 0;
	}
}

