using UnityEngine;
using System.Collections;

public class HUDButtonManager : MonoBehaviour {

	GameManager _GameManager;

	// Use this for initialization
	void Start () {
		_GameManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager>();
	}
	
	void OnClick()
	{
		_GameManager.RestartLevel();
	}
}
