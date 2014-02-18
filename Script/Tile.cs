using UnityEngine;
using System.Collections;

public class Tile {

	public int    id;
	public string name = "NoName";
	public Sprite sprite;
	public bool   isSolid = false;
	public bool   isWater = false;
	public bool   isBuilding = false;
	public int    orderLayer = 0;

}

enum TileName {
	deepWater,
	shallowWater,
	BorealForest,
	TempForest,
	RainForest,
	Desert,
	GrassLand,
	Marsh,
	WetLand,
	Snow,
	Tundra,
	Hills,
	Mountain,
	Plains,
	Settlement,
	Town,
	City
	/*plowedField_dark,
	plowedFiled_light,
	Seeds,
	Grass1,
	Grass2,
	wetSeed,
	Veggie,
	Wheat*/
}