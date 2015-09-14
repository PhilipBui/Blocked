using UnityEngine;
using System.Collections;

public class PlayerPref : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Object.DontDestroyOnLoad(gameObject);
	}
	
	public void saveLevel(string level, int score) {
		if (PlayerPrefs.HasKey(level)) {
			int oldscore = PlayerPrefs.GetInt(level);
			if (oldscore > score)
				PlayerPrefs.SetInt(level, score);
		}
		else
			PlayerPrefs.SetInt(level, score);
	}
	public void saveProgress(int level) {
		if (PlayerPrefs.HasKey("progress")) {
			int oldLevel = PlayerPrefs.GetInt("progress");
			if (oldLevel < level)
				PlayerPrefs.SetInt("progress", level);
		}
		else
			PlayerPrefs.SetInt("progress", level);
	}
	public int getProgress() {
		if (PlayerPrefs.HasKey("progress"))
			return PlayerPrefs.GetInt("progress");
		else {
			PlayerPrefs.SetInt("progress", 0);
			return 0;
		}
	}
}
