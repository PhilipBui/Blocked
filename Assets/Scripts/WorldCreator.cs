using UnityEngine;
using System.Collections;
/**

*/
public class WorldCreator : MonoBehaviour {
	public GameObject boundaryCube;
	public GameObject normalCube;
	public GameObject sandCube;
	public GameObject softSwitchCube;
	public GameObject hardSwitchCube;
	public GameObject victoryCube;
	public GameObject playerCube;
	public float worldHeight = 0.38f;
	int[,] worldBlocks = new int[,]{
		{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
	};
	private Quaternion quaternionZero;
	// Use this for initialization
	void Start () {
		quaternionZero = transform.rotation;
	}
	public void loadLevel (int[,] level) {
		this.worldBlocks = level;
	}
	public void loadLevel (GameObject level) {
		Instantiate(level, Vector3.zero, quaternionZero);
	}
	public void createLevel () {
		for (int i = 0; i < worldBlocks.GetLength(0); i++) {
			for (int j = 0; j < worldBlocks.GetLength(1); j++) {
				int blockType = worldBlocks[i,j];
				if (blockType == 0 ) {
					
				}
				else if (blockType == 1) {
					Instantiate(boundaryCube, new Vector3(i, worldHeight, j), quaternionZero);
				}
				else if (blockType == 2) {
					Instantiate(normalCube, new Vector3(i, worldHeight, j), quaternionZero);
				}
				else if (blockType == 8) {
					Instantiate(normalCube, new Vector3(i, worldHeight, j), quaternionZero);
					Instantiate(playerCube, new Vector3(i, 4, j), quaternionZero);
				}
				else if (blockType == 9) {
					Instantiate(victoryCube, new Vector3(i, worldHeight, j), quaternionZero);
				}
			}
		}
	}
}
