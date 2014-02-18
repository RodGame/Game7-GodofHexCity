using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	// Use this for initialization
	void Awake () {
		TileType.Ini();
		TimeSystem.Ini ();
		Simulation.Ini ();
	}
	
	// Update is called once per frame
	void Update () {
		TimeSystem.Update (Time.deltaTime);

		if(Input.GetKeyDown(KeyCode.R))
		{
			RestartLevel();
		}
	}

	public void RestartLevel()
	{
		Application.LoadLevel(Application.loadedLevelName);
	}
}
