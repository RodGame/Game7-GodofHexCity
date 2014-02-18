using UnityEngine;
using System.Collections;

public class SpeedButtonManager : MonoBehaviour {

	public GameObject ButtonPause;
	public GameObject ButtonSpeed1;
	public GameObject ButtonSpeed2;
	public GameObject ButtonSpeed3;

	/*
	private GameObject _ButtonPause;
	private GameObject _ButtonSpeed1;
	private GameObject _ButtonSpeed2;
	private GameObject _ButtonSpeed3;
	*/

	private SpeedButtonManager _SpeedButtonManager;

	// Use this for initialization
	void Start () {

		_SpeedButtonManager = GameObject.FindGameObjectWithTag ("ButtonSpeed").GetComponent<SpeedButtonManager>();
		/*_ButtonPause = _SpeedButtonManager.ButtonPause;
		_ButtonSpeed1 = _SpeedButtonManager.ButtonSpeed1;
		_ButtonSpeed2 = _SpeedButtonManager.ButtonSpeed2;
		_ButtonSpeed3 = _SpeedButtonManager.ButtonSpeed3;*/

	}

	void OnClick()
	{
		switch(transform.name)
		{
		case "Button - Pause":
			TimeSystem.SetSpeed(0);
			break;
		case "Button - Speed1x":
			TimeSystem.SetSpeed(1);
			break;
		case "Button - Speed2x":
			TimeSystem.SetSpeed(2);
			break;
		case "Button - Speed3x":
			TimeSystem.SetSpeed(3);
			break;
		}
		// Debug.Log ("ButtonClicked");
	}

	public void ActivateSpeedButton(int _buttonNumber)
	{

		switch(_buttonNumber)
		{
		case 0:
			ButtonPause.GetComponent<SpeedButtonManager>().Activate ();
			ButtonSpeed1.GetComponent<SpeedButtonManager>().Deactivate ();
			ButtonSpeed2.GetComponent<SpeedButtonManager>().Deactivate ();
			ButtonSpeed3.GetComponent<SpeedButtonManager>().Deactivate ();
			break;
		case 1:
			ButtonPause.GetComponent<SpeedButtonManager>().Deactivate (); 
			ButtonSpeed1.GetComponent<SpeedButtonManager>().Activate ();
			ButtonSpeed2.GetComponent<SpeedButtonManager>().Deactivate ();
			ButtonSpeed3.GetComponent<SpeedButtonManager>().Deactivate ();
			break;
		case 2:
			ButtonPause.GetComponent<SpeedButtonManager>().Deactivate (); 
			ButtonSpeed1.GetComponent<SpeedButtonManager>().Deactivate ();
			ButtonSpeed2.GetComponent<SpeedButtonManager>().Activate ();
			ButtonSpeed3.GetComponent<SpeedButtonManager>().Deactivate ();
			break;
		case 3:
			ButtonPause.GetComponent<SpeedButtonManager>().Deactivate (); 
			ButtonSpeed1.GetComponent<SpeedButtonManager>().Deactivate ();
			ButtonSpeed2.GetComponent<SpeedButtonManager>().Deactivate ();
			ButtonSpeed3.GetComponent<SpeedButtonManager>().Activate ();
			break;
		}


		// Set sprite
	}

	public void Activate()
	{
		transform.FindChild ("OverlayOn").gameObject.SetActive(true);
		transform.FindChild ("OverlayOff").gameObject.SetActive(false);
	}

	public void Deactivate()
	{
		transform.FindChild ("OverlayOn").gameObject.SetActive(false);
		transform.FindChild ("OverlayOff").gameObject.SetActive(true);
	}

}
