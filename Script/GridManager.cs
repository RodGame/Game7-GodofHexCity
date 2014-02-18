using UnityEngine;
using System.Collections;
using Gamelogic.Grids;

public class GridManager : GLMonoBehaviour {

	private readonly Vector2 HexDimensions = new Vector2(0.09f, 0.09f); // Dimension of one Hex Cel

	public Cell cellPrefab;
	private GameObject root;
	private GameObject UIPanel;

	public PointyHexGrid<Cell> grid;
	private PointyHexGrid<int>  tileMap;
	private IMap3D<PointyHexPoint> map;
	public City[] CityList;

	private int cellsPerIteration = 100;
	private int cellCount;
	private bool isGridBuilt = false;


	// World datas
	const int width = 75;
	private int nbrPlayer = 6;


	public void Start()
	{	
		UIPanel = GameObject.FindGameObjectWithTag("UIPanel");
		root = GameObject.FindGameObjectWithTag ("Root");
		
		// Generate the map with a coroutine. Draw tile by tile each frame. Give feedback to the player instead of a couple seconds of waiting
		StartCoroutine(BuildGrid());
		
		CityList = new City[nbrPlayer + 1];
		
	}

	// Instantiate all cell of the grid
	private IEnumerator BuildGrid()
	{
		//cellsPerIteration = (width*width)/(width/2);
		//const int height = 5;
		
		grid    = PointyHexGrid<Cell>.Hexagon(width);
		tileMap = PointyHexGrid<int>.Hexagon(width);

		// Generate an hexagonal map defining each cell type
		tileMap = WorldGenerator.GenerateHex (width);

		// Map setup
		map = new PointyHexMap(HexDimensions)
			.AnchorCellMiddleCenter()
			.WithWindow(ExampleUtils.ScreenRect)
			.AlignMiddleCenter(grid)
			.To3DXY();		

		// Instantiate each cell over many frames
		foreach(PointyHexPoint point in grid)
		{
			CreateCell(point);
			cellCount++;

			if(cellCount >= cellsPerIteration)
			{

				cellCount = 0;
				//Debug.Log ("Time BuildGridFrame = " + Time.realtimeSinceStartup);

				yield return null;
			}
		}

		// After grid generation
		Debug.Log ("Time BuildGridFinished = " + Time.realtimeSinceStartup);
		CreateCities(); // Put cities on the map
		TimeSystem.SetSpeed(2);
		isGridBuilt = true;

	}

	// Create cities on the map
	private void CreateCities()
	{
		int populationMin = 10;
		int populationMax = 20;

		Debug.Log ("Create Cities");
		// Pass after all cell has been instantiated
		for(int curPlayer = 1; curPlayer <= nbrPlayer; curPlayer++)
		{
			CityList[curPlayer] = new City();

			Cell _cell = GetRandomCell();
			
			while(_cell.tile.isSolid == true || _cell.tile.isWater == true)
			{
				_cell = GetRandomCell();
				
			}

			CityList[curPlayer].Ini(curPlayer, 1, Random.Range (populationMin,populationMax), _cell.point);
			_cell.SetTile ((int)TileName.City, curPlayer); // Put a city with a new player
		}
	}

	// Get a random cell that is contained by the grid
	private Cell GetRandomCell()
	{
		Cell _cell;
		int x = Random.Range (-(width-1),width-1);
		int y = Random.Range (-(width-1),width-1);
		PointyHexPoint point = new PointyHexPoint(x,y);

		// Make sure the random cell is not outside of the hexagonal grid
		while(!grid.Contains(point))
		{
			x = Random.Range (-(width-1),width-1);
			y = Random.Range (-(width-1),width-1);
			point = new PointyHexPoint(x,y);
		}

		return grid[point];
	}


	//Instantiate the cell and initialize its values
	private void CreateCell(PointyHexPoint point)
	{

		//Instantiate the cell
		Cell cell = Instantiate(cellPrefab);
		Vector3 worldPoint = map[point];

		cell.transform.parent = root.transform;
		cell.transform.localScale = Vector3.one;
		cell.transform.localPosition = worldPoint;
		cell.transform.name = "hexCell(" + point.X + "," + point.Y + ")";

		// Set cell's value
		cell.SetTile(tileMap[point]);
		cell.point = point;
		grid[point] = cell;
	}

	// Frame update. Wait for mouse input.
	public void Update()
	{
		Vector3 worldPosition = ExampleUtils.ScreenToWorld_NGUI(root, Input.mousePosition);
		PointyHexPoint point = map[worldPosition];


		if (grid.Contains(point) && grid[point] != null)
		{
			CellOnHover(grid[point]);
			
			if (Input.GetMouseButtonDown(0))
			{
				{
					CellOnClick(grid[point]);
				}
			}
		}
		else
		{
			UIPanel.transform.FindChild ("CityHoverGUI").gameObject.SetActive (false);
		}
	}

	// On mouse hovering a cell
	private void CellOnHover(Cell _cell)
	{
		if(_cell.tile.id == (TileType.List[(int)TileName.City]).id)
		{
			UIPanel.transform.FindChild ("CityHoverGUI").gameObject.SetActive (true);
			UIPanel.transform.FindChild ("CityHoverGUI").transform.position = Camera.main.ScreenToWorldPoint (Input.mousePosition) + new Vector3(0.0f, 0.0f, 0.0f);
			UIPanel.transform.FindChild ("CityHoverGUI/Size/Label").GetComponent<UILabel>().text = CityList[_cell.owner].size.ToString ();
			UIPanel.transform.FindChild ("CityHoverGUI/Population/Label").GetComponent<UILabel>().text = CityList[_cell.owner].population.ToString ();
			UIPanel.transform.FindChild ("CityHoverGUI/Label - Name").GetComponent<UILabel>().text = CityList[_cell.owner].name;
		}
		else
		{
			UIPanel.transform.FindChild ("CityHoverGUI").gameObject.SetActive (false);
		}

		Debug.Log (_cell.name);
	}

	// On mouse clicking a cell
	private void CellOnClick(Cell _cell)
	{



	}

}
