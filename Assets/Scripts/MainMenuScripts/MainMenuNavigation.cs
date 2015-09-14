using UnityEngine;
using System.Collections;

public class MainMenuNavigation : MonoBehaviour {
	public GameObject mainMenuUI;
	public GameObject selectLevel;
	public GameObject selectLevel01;
	public GameObject selectLevel02;
	public GameObject forwardButton;
	public GameObject backButton;
	// public GameObject selectLevels02;
	// Use this for initialization
	void Start () {
		mainMenuUI = GameObject.Find("MainMenuUI");
		selectLevel = GameObject.Find("SelectLevel");
		selectLevel01 = GameObject.Find("SelectLevel01");
		selectLevel02 = GameObject.Find("SelectLevel02");
		forwardButton = GameObject.Find("ForwardButton");
		backButton = GameObject.Find("BackButton");
		mainMenuUI.SetActive(true);
		selectLevel.SetActive(false);
	}
	
	public void loadLevel(string level) {
		Application.LoadLevel(level);
	}
	
	public void navigateMainMenuUI() {
		mainMenuUI.SetActive(true);
		selectLevel.SetActive(false);
	}
	
	public void navigateSelectLevel() {
		mainMenuUI.SetActive(false);
		selectLevel.SetActive(true);
		selectLevel01.SetActive(true);
		selectLevel02.SetActive(false);
		backButton.SetActive(false);
		forwardButton.SetActive(true);
	}
	
	public void navigateBeforeLevels() {
		if (selectLevel01.activeSelf) {
			// Do nothing
		}
		else if (selectLevel02.activeSelf) {
			selectLevel01.SetActive(true);
			selectLevel02.SetActive(false);
			forwardButton.SetActive(true);
			backButton.SetActive(false);
		}
	}
	public void navigateNextLevels() {
		if (selectLevel01.activeSelf) {
			selectLevel01.SetActive(false);
			selectLevel02.SetActive(true);
			forwardButton.SetActive(false);
			backButton.SetActive(true);
		}
		else if (selectLevel02.activeSelf) {
			// Do nothing
		}
	}
	
	
}
