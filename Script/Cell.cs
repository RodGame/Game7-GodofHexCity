//----------------------------------------------//
// Gamelogic Grids                              //
// http://www.gamelogic.co.za                   //
// Copyright (c) 2013 Gamelogic (Pty) Ltd       //
//----------------------------------------------//

using System.Linq;

using UnityEngine;
using Gamelogic.Grids;

[AddComponentMenu("Gamelogic/Cells/Cell")]
public class Cell : GLMonoBehaviour 
{	
	public PointyHexPoint point;
	private SpriteRenderer image;
	public Tile tile;
	public Tile tileBuiltOn = null;
	public int owner;

	public int _TileId;
	public string _TileName;

	private Color[] _colors = new Color[8] {Color.white, Color.red, Color.blue, Color.green, Color.yellow, Color.magenta, Color.cyan, Color.grey};

	public void Awake()
	{
		image = GetComponentInChildren<SpriteRenderer>();
	}

	public void SetTile(int _tileIndex, int _owner)
	{

		SetTile (_tileIndex);
		SetOwner(_owner);
	}

	public void SetOwner(int _newOwner)
	{
		float colorTransparency = 0.95f;

		owner = _newOwner;
		SetColor (new Color(_colors[owner].r, _colors[owner].g, _colors[owner].b, colorTransparency));
	}

	public void SetColor(Color _color)
	{
		image.color = _color;
	}

	public void SetTile(int _tileIndex)
	{
		Tile _newTile = TileType.List[_tileIndex];

		if(_newTile.isBuilding == true)
		{
			tileBuiltOn = tile;
		}

		tile = _newTile;
		SetImage(tile.sprite);
		_TileId = tile.id;
		_TileName = System.Enum.GetNames (typeof(TileName))[_TileId];

		if(tile.orderLayer != 0)
		{
			image.sortingOrder = tile.orderLayer;
		}
	}

	private void SetImage(Sprite _newSprite)
	{
		image.sprite = _newSprite;
	}


}
