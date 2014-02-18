using UnityEngine;
using System.Collections;
using Gamelogic.Grids;

static class Simulation {

	static GridManager _GridManager;

	static public void Ini()
	{
		_GridManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GridManager>();
	}

	static public void StepTick()
	{
		// Each step, loop over each city
		for(int i = 1; i < _GridManager.CityList.Length; i++)
		{


			City _City = _GridManager.CityList[i];
			if(Random.Range(0.0f,1.0f) < 0.05f)
			{
				PointyHexPoint _point = _City.pointCity;
				IEnumerable Neighbors = _GridManager.grid.GetNeighbors(_point);

				foreach(PointyHexPoint neighbor in Neighbors)
				{
					// If the cell is not owned by the current player
					if(_GridManager.grid[neighbor].owner != i)
					{
						Debug.Log ("In City");
						if(Random.Range (0.0f,1.0f) < 0.1f)
						{
							//Debug.Log ("In City");
							_GridManager.grid[neighbor].SetOwner (i);
							_City.size++;

						}
					}
				}
			}
		}


	}

	static public void FrameTick()
	{

	}
}
