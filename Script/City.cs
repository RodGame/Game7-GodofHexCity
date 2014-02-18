using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Gamelogic.Grids;

public class City {

	public PointyHexPoint pointCity;
	public List<PointyHexPoint> points = new List<PointyHexPoint>();
	public string name;
	public int owner;
	public int size;
	public int population;
	public float energy;
	public float energymax;
	public float research;


	public void Ini(int _owner, int _size, int _population, PointyHexPoint _pointCity)
	{
		owner = _owner;
		size = _size;
		population = _population;
		pointCity = _pointCity;
		points.Add(_pointCity);

		List<string> AllNames = new List<string>() {"Tristram", "Gerudo", "Kakariko", "Xel'naga", "Athkatla", "San Andreas", "Reach", "Pallet Town", "Rapture", "City17"  };

		name = AllNames[Random.Range (0,AllNames.Count)];
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
}
