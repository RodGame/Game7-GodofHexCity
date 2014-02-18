using UnityEngine;
using System.Collections;
using System;

public static class TileType {

	public static Tile[] List;
	private static SpriteManager _SpriteManager;

	public static void Ini()
	{
		List  = new Tile [Enum.GetValues(typeof(TileName) ).Length];	
		_SpriteManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<SpriteManager>();
		
		IniList ();
	}

	private static void IniList()
	{
		for(int i = 0; i < List.Length; i++)
		{
			
			Tile _Tile = new Tile();
			_Tile.name = ((TileName)i).ToString();
			_Tile.id = i;
			switch(_Tile.name)
			{
			case "deepWater":
				_Tile.sprite = _SpriteManager.tile_deepWater;
				_Tile.isWater = true;
				break;
			case "shallowWater":
				_Tile.sprite = _SpriteManager.tile_shallowWater;
				_Tile.isWater = true;
				break;
			case "BorealForest":
				_Tile.sprite = _SpriteManager.tile_BorealForest;
				break;
			case "TempForest":
				_Tile.sprite = _SpriteManager.tile_TempForest;
				break;
			case "RainForest":
				_Tile.sprite = _SpriteManager.tile_RainForest;
				break;
			case "Desert":
				_Tile.sprite = _SpriteManager.tile_Desert;
				break;
			case "GrassLand":
				_Tile.sprite = _SpriteManager.tile_GrassLand;
				break;
			case "Marsh":
				_Tile.sprite = _SpriteManager.tile_Marsh;
				break;
			case "WetLand":
				_Tile.sprite = _SpriteManager.tile_WetLand;
				break;
			case "Snow":
				_Tile.sprite = _SpriteManager.tile_Snow;
				break;
			case "Tundra":
				_Tile.sprite = _SpriteManager.tile_Tundra;
				break;
			case "Hills":
				_Tile.sprite = _SpriteManager.tile_Hills;
				break;
			case "Mountain":
				_Tile.sprite = _SpriteManager.tile_Mountain;
				_Tile.isSolid = true;
				_Tile.orderLayer = 1;
				break;
			case "Plains":
				_Tile.sprite = _SpriteManager.tile_Plains;
				break;
			case "Settlement":
				_Tile.sprite = _SpriteManager.tile_Settlement;
				_Tile.isBuilding = true;
				break;
			case "Town":
				_Tile.sprite = _SpriteManager.tile_Town;
				_Tile.isBuilding = true;
				break;
			case "City":
				_Tile.sprite = _SpriteManager.tile_City;
				_Tile.isBuilding = true;
				_Tile.orderLayer = 1;
				break;
			}
			List[i] = _Tile;
		}
	}
}

	/*
enum TileName {
	plowedField_dark,
	plowedFiled_light,
	Seeds,
	Grass1,
	Grass2,
	wetSeed,
	Veggie,
	Wheat
}


*/