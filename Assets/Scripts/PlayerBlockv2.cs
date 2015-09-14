using UnityEngine;
using System.Collections;
public class PlayerBlockv2 : MonoBehaviour {
	private bool animating = false;
	private bool animationStarted = false;
	private bool standing = true;
	public bool isVertical = false;
	private bool isFalling = false;
	private Rigidbody rigidbody;
	private int positionCursor = 0;
	private Vector3[] positions;
	private Quaternion[] rotations;
	private Vector3 currentPosition;
	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (animating) {
			if (positionCursor < positions.Length) {
				if (!animationStarted)
					StartCoroutine(moveTo(positions[positionCursor], rotations[positionCursor], 0.25f));
			}
			else {
				if (standing)
					transform.localRotation = Quaternion.Euler(0, 0, 0);
				else if (isVertical)
					transform.localRotation = Quaternion.Euler(0, 90, 90);
				else if (!isVertical)
					transform.localRotation = Quaternion.Euler(0, 0, 90);
				animating = false;
			}
		}
		else if (!animating && !isFalling) {
			if (Input.GetAxis("Horizontal") < 0) {
				moveDown();
			}
			else if (Input.GetAxis("Horizontal") > 0) {
				moveUp();
			}
			else if (Input.GetAxis("Vertical") > 0) {
				moveLeft();
			}
			else if (Input.GetAxis("Vertical") < 0) {
				moveRight();
			}
			else {
				
			}
		}
	}
	public void moveLeft() { // Moving up
		currentPosition = transform.position;
		if (standing) {
			positions = new [] {new Vector3(currentPosition.x-0.85f, 1.5f, currentPosition.z), new Vector3(currentPosition.x -1.5f, 1f, currentPosition.z)};
			rotations = new [] {Quaternion.Euler(0, 0, 45), Quaternion.Euler(0, 0, 90)};
			positionCursor = 0;
			isVertical = false;
			standing = false;
			animating = true;
		}
		else {
			// If horizontal, moving left would make it stand upright!
			if (!isVertical) {
				positions = new [] {new Vector3(currentPosition.x-0.85f, 1.5f, currentPosition.z), new Vector3(currentPosition.x -1.5f, 1.5f, currentPosition.z)};
				rotations = new [] {Quaternion.Euler(0, 0, 135), Quaternion.Euler(0, 0, 180)};
				positionCursor = 0;
				standing = true;
				animating = true;
			}
			else {
				positions = new [] {new Vector3(currentPosition.x - 0.5f, 1.25f, currentPosition.z), new Vector3(currentPosition.x - 1f, 1, currentPosition.z)};
				rotations = new [] {Quaternion.Euler(-45, 90, 90), Quaternion.Euler(-90, 90, 90)};
				positionCursor = 0;
				animating = true;
			}
		}
	}
	
	public void moveRight() { // Moving down
		currentPosition = transform.position;
		if (standing) {
			positions = new [] {new Vector3(currentPosition.x+0.85f, 1.5f, currentPosition.z), new Vector3(currentPosition.x +1.5f, 1f, currentPosition.z)};
			rotations = new [] {Quaternion.Euler(0, 0, -45), Quaternion.Euler(0, 0, -90)};
			positionCursor = 0;
			isVertical = false;
			standing = false;
			animating = true;
		}
		else {
			// If horizontal, moving right would make it stand upright!
			if (!isVertical) {
				positions = new [] {new Vector3(currentPosition.x+0.85f, 1.5f, currentPosition.z), new Vector3(currentPosition.x +1.5f, 1.5f, currentPosition.z)};
				rotations = new [] {Quaternion.Euler(0, 0, 45), Quaternion.Euler(0, 0, 0)};
				positionCursor = 0;
				standing = true;
				animating = true;
			}
			else {
				positions = new [] {new Vector3(currentPosition.x + 0.5f, 1.25f, currentPosition.z ), new Vector3(currentPosition.x + 1f, 1, currentPosition.z)};
				rotations = new [] {Quaternion.Euler(45, 90, 90), Quaternion.Euler(90, 90, 90)};
				positionCursor = 0;
				animating = true;
			}
		}
	}
	
	public void moveUp() { // Moving right
		currentPosition = transform.position;
		if (standing) {
			positions = new [] {new Vector3(currentPosition.x, 1.5f, currentPosition.z + 0.85f), new Vector3(currentPosition.x, 1f, currentPosition.z + 1.5f)};
			rotations = new [] {Quaternion.Euler(45, 0, 0), Quaternion.Euler(90, 0, 0)};
			positionCursor = 0;
			isVertical = true;
			standing = false;
			animating = true;
			
		}
		else {
			// If vertical, moving up would make it stand upright!
			if (isVertical) {
				positions = new [] {new Vector3(currentPosition.x, 1.5f, currentPosition.z + 0.85f), new Vector3(currentPosition.x, 1.5f, currentPosition.z + 1.5f)};
				rotations = new [] {Quaternion.Euler(0, 90, 135), Quaternion.Euler(0, 90, 180)};
				positionCursor = 0;
				standing = true;
				animating = true;
				
			}
			else {
				positions = new [] {new Vector3(currentPosition.x, 1.25f, currentPosition.z + 0.5f), new Vector3(currentPosition.x, 1, currentPosition.z + 1f)};
				rotations = new [] {Quaternion.Euler(45, 0, 90), Quaternion.Euler(90, 0, 90)};
				positionCursor = 0;
				animating = true;
			}
		}
	}
	
	public void moveDown() {
		currentPosition = transform.position;
		if (standing) {
			positions = new [] {new Vector3(currentPosition.x, 1.5f, currentPosition.z - 0.85f), new Vector3(currentPosition.x, 1f, currentPosition.z - 1.5f)};
			rotations = new [] {Quaternion.Euler(-45, 0, 0), Quaternion.Euler(-90, 0, 0)};
			positionCursor = 0;
			isVertical = true;
			standing = false;
			animating = true;
		}
		else {
			// If vertical, moving down would make it stand upright!
			if (isVertical) {
				positions = new [] {new Vector3(currentPosition.x, 1.5f, currentPosition.z - 0.85f), new Vector3(currentPosition.x, 1.5f, currentPosition.z - 1.5f)};
				rotations = new [] {Quaternion.Euler(0, 90, 45), Quaternion.Euler(0, 90,0)};
				positionCursor = 0;
				standing = true;
				animating = true;
			}
			else {
				positions = new [] {new Vector3(currentPosition.x, 1.25f, currentPosition.z - 0.5f), new Vector3(currentPosition.x, 1, currentPosition.z - 1f)};
				rotations = new [] {Quaternion.Euler(-45, 0, 90), Quaternion.Euler(-90, 0, 90)};
				positionCursor = 0;
				animating = true;
			}
		}
	}
	
	private IEnumerator moveTo(Vector3 positionB, Quaternion rotationB, float time) {
		animationStarted = true;
		float t = 0f;
		while (t < 1.0f) {
			t += Time.deltaTime / time;
			transform.position = Vector3.Lerp(transform.position, positionB, t);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotationB, t);
			yield return 0;
		}
		positionCursor++;
		animationStarted = false;
	}
	
	private IEnumerator disappearTo(Vector3 positionB, float time) {
		float t = 0f;
		while (t < 1.0f) {
			t += Time.deltaTime / time;
			transform.position = Vector3.Lerp(transform.position, positionB, t);
			transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(0.95f, 0.01f, 0.95f), t);
			yield return 0;
		}
	}
	public void falling() {
		isFalling = true;
		rigidbody.constraints = RigidbodyConstraints.None;
	}
	public void victory() {
		
	}
	public bool isStanding() {
		if (standing)
			return true;
		return false;
	}
	IEnumerator wait() {		
		yield return new WaitForEndOfFrame();
	}
	IEnumerator wait(int duration) {
		yield return new WaitForSeconds(duration);
	}
}
