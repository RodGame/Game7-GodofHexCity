using UnityEngine;
using System.Collections;

static class TimeSystem {

	static public int day;
	static public int minuteElapsed; //1440 minute in a day
	static private float elapsedTimeSinceLastTimeUpdate = 0.0f;
	static private float realSecPerGameMinute = 1.0f;
	static private float timeSpeed = 0;
	static private float timeSpeedLast = 0;

	static private GameObject UIPanel;

	public static void Ini()
	{
		UIPanel = GameObject.FindGameObjectWithTag("UIPanel");
		SetSpeed (0);
		SetTime (0);
	}

	public static void SetTime(int _day, int _minuteElapsed)
	{
		SetDay(_day);
		SetTime(_minuteElapsed);
	}

	static public void SetTime(int _minuteElapsed)
	{
		minuteElapsed = _minuteElapsed;
		UpdateTimeLabel();
	}

	static void SetDay(int _day)
	{
		day = _day;	
		UIPanel.transform.FindChild ("TimeGUI/Label - Day").GetComponent<UILabel>().text = "Day : " + day;
	}

	public static void Pause()
	{
		SetSpeed(0);
	}

	public static void SetSpeed(int _speed)
	{
		timeSpeedLast = timeSpeed;
		timeSpeed = _speed;

		GameObject.FindGameObjectWithTag ("ButtonSpeed").GetComponent<SpeedButtonManager>().ActivateSpeedButton (_speed);

		if(timeSpeed == 0)
		{
			realSecPerGameMinute = 0.0f;
		}
		else if(timeSpeed == 1)
		{
			realSecPerGameMinute = 0.1f;
		}
		else if(timeSpeed == 2)
		{
			realSecPerGameMinute = 0.01f;
		}
		else if(timeSpeed == 3)
		{
			realSecPerGameMinute = 0.003f;
		}
		elapsedTimeSinceLastTimeUpdate = 0.0f;
	}

	public static void Update(float _deltaTime)
	{
		// If game isn't paused
		//Debug.Log ("SecPerMInute = " + realSecPerGameMinute);
		if(timeSpeed != 0)
		{
			elapsedTimeSinceLastTimeUpdate += _deltaTime;
			//Debug.Log (elapsedTimeSinceLastTimeUpdate);
			if(elapsedTimeSinceLastTimeUpdate > realSecPerGameMinute)
			{

				int _minuteUpdate = (int)(elapsedTimeSinceLastTimeUpdate/realSecPerGameMinute); // Number of minute that happened in the 
				int _hour   = Mathf.FloorToInt(minuteElapsed/60.0f);
				int _minute = Mathf.FloorToInt(minuteElapsed - (_hour*60)); //10.50 - 10 = 50*60/100 = 30
				//minuteElapsed += minuteUpdate;
				//Debug.Log (minuteUpdate);
				//Debug.Log (elapsedTimeSinceLastTimeUpdate);
				for(int i = 1; i <= _minuteUpdate; i++)
				{
					minuteElapsed++;
					//UpdateTimeLabel();
					Simulation.StepTick (); //Evaluate(_hour, _minute);
					if(minuteElapsed == 1440)
					{
						NewDay ();
					}
				}
				
				Simulation.FrameTick ();
				UpdateTimeLabel();

				elapsedTimeSinceLastTimeUpdate -= Mathf.Floor(elapsedTimeSinceLastTimeUpdate/realSecPerGameMinute)*realSecPerGameMinute;
			}
		}
	}

	static void NewDay()
	{
		minuteElapsed= 0;
		elapsedTimeSinceLastTimeUpdate = 0.0f;
		SetDay(day + 1);
	}

	public static void UpdateTimeLabel()
	{
		int _hour   = Mathf.FloorToInt(minuteElapsed/60.0f);
		int _minute = Mathf.FloorToInt(minuteElapsed - (_hour*60)); //10.50 - 10 = 50*60/100 = 30

		string _timeToShow;
		
		if(_minute < 10)
		{
			_timeToShow = _hour + "h0" + _minute;
		}
		else
		{
			_timeToShow = _hour + "h" + _minute;
		}
		
		UIPanel.transform.FindChild ("TimeGUI/Label - Time").GetComponent<UILabel>().text = _timeToShow;

	}

}
