using UnityEngine;
using System.Collections;
using Gamelogic.Grids;

static class WorldGenerator {

	static private PointyHexGrid<int> tileMap; // Grid's "Hexagonal Array" containing an int corresponding to each type cell. Could be done with a simple 2D array for a square map.
	
	// Generate an Hexagonal map with Mathf.Perlin
	static public PointyHexGrid<int> GenerateHex(int width)
	{
		Debug.Log ("Time GenerationStart = " + Time.realtimeSinceStartup);
		
		tileMap = PointyHexGrid<int>.Hexagon(width); // Define tileMap from the inputted width of the hexagon

		float zoom = Random.Range (0.015f,0.17f);								   // Zoom in for "big smooth" peaks. Zoom out for "small noisy" peaks. Not the best description but gives an idea.
		Vector2 shift = new Vector2(Random.Range (-10,10), Random.Range (-10,10)); // play with this to move on the perlin map. Allow for infinite coherent map divided in chunks.

		// Step on each cell, calculate a noise value with Mathf.Perlin and define a type of cell according to hardcoded cell types
		 for(int x = 0; x < (width*2) - 1; x++) // The for loops aren't stepping precisely on the hexagon shape but it works. Could be improved.
		{
			for(int y = 0; y < (width*2) - 1; y++)
			{
				Vector2 pos = zoom * (new Vector2(x,y)) + shift;       						 // Position on the current cell on the perlin map, using value of shift/zoom
				float noise = 1.0f - Mathf.PerlinNoise(pos.x, pos.y);						 // Noise value at evaluated position on perlin map
				PointyHexPoint point = new PointyHexPoint(x - (width - 1), y - (width - 1)); // Calculate the grid's point that correspond to the current cell
				
				int _curTile = 0; // Default value

				// Define cell type according to noise value
				if (noise>0.90f) 	  _curTile = (int)TileName.Mountain; 
				else if (noise>0.80f) _curTile = (int)TileName.Hills;
				else if (noise>0.60f) _curTile = (int)TileName.BorealForest;
				else if (noise>0.50f) _curTile = (int)TileName.GrassLand; 
				else if (noise>0.45f) _curTile = (int)TileName.Desert; 
				else if (noise>0.30f) _curTile = (int)TileName.shallowWater;
				else 				  _curTile = (int)TileName.deepWater; 
				
				tileMap[point] = _curTile; // Set the current tile int on the tilemap
			}
		}
		Debug.Log ("Time GenerationFinish = " + Time.realtimeSinceStartup);
		return tileMap;
	}



}
