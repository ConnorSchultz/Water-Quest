using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EndScriptBG : MonoBehaviour
{
	private float width;
	private float height;
	private float halfWidth;
	private float halfHeight;
	
	private int columns;
	private int rows;
	
	public GameObject grass;
	public GameObject beach;
	public GameObject ocean;
	public GameObject road;
	public GameObject road2;
	public GameObject farm;
	public GameObject crops;
	public GameObject house1;
	public GameObject house2;
	public GameObject house3;
	public GameObject tree1;
	public GameObject roadCorner;
	public GameObject roadInterLUD;
	public GameObject roadInterRUD;
	public GameObject roadInterLRU;
	public GameObject researchPlantR;
	public GameObject researchPlantG;
	public GameObject researchPlantB;
	public GameObject corn;
	public GameObject tree2;
	public GameObject crossRoad;
	public GameObject lagoon1;
	public GameObject lagoon2;
	public GameObject lagoon3;
	public GameObject lagoon4;
	public UnityEngine.UI.Text scientistText;
	public Sprite pollution;
	
	private GameObject[] tiles;
	private const int grassID = 0;
	private const int beachID = 1;
	private const int oceanID = 2;
	private const int researchRID = 3;
	private const int roadID = 4;
	private const int road2ID = 5;
	private const int farmID = 6;
	private const int cropsID = 7;
	private const int house1ID = 8;
	private const int house2ID = 9;
	private const int house3ID = 10;
	private const int tree1ID = 11;
	private const int roadCornerID = 12;
	private const int roadInterLUDID = 13;
	private const int roadInterRUDID = 14;
	private const int roadInterLRUID = 15;
	private const int researchGID = 16;
	private const int researchBID = 17;
	private const int crossRoadID = 26;
	private const int lagoon1ID = 27;
	private const int lagoon2ID = 28;
	private const int lagoon3ID = 29;
	private const int lagoon4ID = 30;
	private const int placingID = 31;
	private const int tileNum = 32;
	
	private int[] board;
	
	private int[] boardT;
	private int[] boardD;
	private int[] boardL;
	private int[] boardR;
	
	private GameObject[] boardfabs;
	
	private float flashtime = 0.0f;
	private List<GameObject> placelist = new List<GameObject>();
	
	private Vector3 dragOrigin;
	private GameObject placeDesal = null;
	private bool locationSelected = false;
	private bool isClick = false;
	private bool isMove = true;
	private bool canPlaceDesal = false;
	
	private int zoomLevel = 2;
	
	private int[] researchC = new int[9];
	private int[] researchR = new int[9];
	
	private bool tutorialcomplete = false;
	
	public void desalButtonClicked()
	{
		if (locationSelected)
			return;
		
		SpriteRenderer rend = placeDesal.GetComponent<SpriteRenderer> ();
		
		if (canPlaceDesal) {
			canPlaceDesal = false;
			rend.enabled = false;
			for (int i = 0; i < placelist.Count; i++) {
				GameObject p = placelist [i];
				SpriteRenderer pr = p.GetComponent<SpriteRenderer>();
				pr.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
			}
		} else {
			canPlaceDesal = true;
			rend.enabled = true;
			flashtime = 0.0f;
		}
	}
	
	public void completeTutorial()
	{
		tutorialcomplete = true;
	}

	
	void Start()
	{
		tiles = new GameObject[tileNum];
		tiles[grassID] = grass;
		tiles[beachID] = beach;
		tiles[oceanID] = ocean;
		tiles[researchRID] = researchPlantR;
		tiles[roadID] = road;
		tiles[road2ID] = road2;
		tiles[farmID] = farm;
		tiles[cropsID] = crops;
		tiles[house1ID] = house1;
		tiles[house2ID] = house2;
		tiles[house3ID] = house3;
		tiles[tree1ID] = tree1;
		tiles[roadCornerID] = roadCorner;
		tiles[roadInterLUDID] = roadInterLUD;
		tiles[roadInterRUDID] = roadInterRUD;
		tiles[roadInterLRUID] = roadInterLRU;
		tiles[researchGID] = researchPlantG;
		tiles[researchBID] = researchPlantB;
		tiles[crossRoadID] = crossRoad;
		
		width = 100; // 62, 60
		height = 50; // 31, 30
		halfWidth  = width  / 2.0f - 3.0f;
		halfHeight = height / 2.0f - 1.5f;
		
		columns = 50;
		rows = 50;
		board = new int[columns * rows];
		boardfabs = new GameObject[columns * rows];
		
		boardT = new int[columns * rows];
		boardD = new int[columns * rows];
		boardL = new int[columns * rows];
		boardR = new int[columns * rows];
		
		CustomMap1();
		
		{
			//placeDesal = Instantiate (desal, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
			//SpriteRenderer rend = placeDesal.GetComponent<SpriteRenderer>();
			//float scale = (float)(width * 1.5) / (float)rend.bounds.size.x;
			//rend.color = new Color(1.0f, 1.0f, 1.0f, 0.66f);
			//placeDesal.transform.localScale = new Vector3 (scale, scale, 1.0f);
			//rend.enabled = false;
		}
		
		// down
		for (int r = 0; r < rows; r++) {
			for (int c = -columns; c < 0; c++) {
				float x = (c - r) * halfWidth + Screen.width / 2;
				float y = (c + r) * halfHeight;
				
				GameObject tile = Instantiate(tiles[boardD[c + columns+ r * columns]], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
				Renderer renderer = tile.GetComponent<Renderer>();
				float widthR = renderer.bounds.size.x;
				float heightR = renderer.bounds.size.y;
				float scaleX = width / widthR;
				float scaleY = height / heightR;
				tile.transform.localScale = new Vector3(scaleX, scaleY, 1.0f);
				tile.transform.position = new Vector3(x, y, 0);
			}
		}
		// right
		for (int r = -rows; r < 0; r++) {
			for (int c = 0; c < columns; c++) {
				float x = (c - r) * halfWidth + Screen.width / 2;
				float y = (c + r) * halfHeight;
				
				switch (boardR[c + (r + rows) * columns])
				{
				case tree1ID:
				{
					boardR[c + (r + rows) * columns] = grassID;
					int use = Random.Range(0, 3);
					GameObject ent;
					float scale;
					if (use == 0)
					{
						ent = Instantiate(tree2, new Vector3(x + halfWidth, y + halfHeight / 2, 0), Quaternion.identity) as GameObject;
						scale = (float)(height * 1.4) / (float)ent.GetComponent<Renderer>().bounds.size.y;
					}
					else
					{
						ent = Instantiate(tree1, new Vector3(x + halfWidth, y + halfHeight / 2, 0), Quaternion.identity) as GameObject;
						scale = (float)(height * 2) / (float)ent.GetComponent<Renderer>().bounds.size.y;
					}
					ent.transform.localScale = new Vector3(scale, scale, 1.0f);
					break;
				}
				}
				
				GameObject tile = Instantiate(tiles[boardR[c + (r + rows) * columns]], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
				Renderer renderer = tile.GetComponent<Renderer>();
				float widthR = renderer.bounds.size.x;
				float heightR = renderer.bounds.size.y;
				float scaleX = width / widthR;
				float scaleY = height / heightR;
				tile.transform.localScale = new Vector3(scaleX, scaleY, 1.0f);
				tile.transform.position = new Vector3(x, y, 0);
			}
		}
		// board
		for (int r = 0; r < rows; r++)
		{
			for (int c = 0; c < columns; c++)
			{
				float x = (c - r) * halfWidth + Screen.width / 2;
				float y = (c + r) * halfHeight;
				bool special = false;
				
				switch (board[c + r * columns])
				{
				case -1:
					//continue;
					board[c + r * columns] = grassID;
					break;
				case placingID:
					board[c + r * columns] = grassID;
					special = true;
					break;
					//continue;
				case tree1ID:
				{
					board[c + r * columns] = grassID;
					int use = Random.Range(0, 3);
					GameObject ent;
					float scale;
					if (use == 0)
					{
						ent = Instantiate(tree2, new Vector3(x + halfWidth, y + halfHeight / 2, 0), Quaternion.identity) as GameObject;
						scale = (float)(height * 1.4) / (float)ent.GetComponent<Renderer>().bounds.size.y;
					}
					else
					{
						ent = Instantiate(tree1, new Vector3(x + halfWidth, y + halfHeight / 2, 0), Quaternion.identity) as GameObject;
						scale = (float)(height * 2) / (float)ent.GetComponent<Renderer>().bounds.size.y;
					}
					ent.GetComponent<Renderer>().sortingOrder = (columns - c) + (rows - r) * columns;
					ent.transform.localScale = new Vector3(scale, scale, 1.0f);
					break;
				}
				case researchRID:
				case researchGID:
				case researchBID:
				{
					GameObject ent;
					SpriteRenderer rend;
					
					if (board[c + r * columns] == researchRID)
					{
						ent = Instantiate(researchPlantR, new Vector3(x + halfWidth, y + halfHeight / 2, 0), Quaternion.identity) as GameObject;
						rend  = ent.GetComponent<SpriteRenderer>();
						rend.color = new Color(1.0f, 0.8f, 0.8f, 1.0f);
					}
					else if (board[c + r * columns] == researchGID)
					{
						ent = Instantiate(researchPlantG, new Vector3(x + halfWidth, y + halfHeight / 2, 0), Quaternion.identity) as GameObject;
						rend  = ent.GetComponent<SpriteRenderer>();
						rend.color = new Color(0.8f, 1.0f, 0.8f, 1.0f);
					}
					else
					{
						ent = Instantiate(researchPlantB, new Vector3(x + halfWidth, y + halfHeight / 2, 0), Quaternion.identity) as GameObject;
						rend  = ent.GetComponent<SpriteRenderer>();
						rend.color = new Color(0.8f, 0.8f, 1.0f, 1.0f);
					}
					
					float scale = (float)(width * 0.75) / (float)rend.bounds.size.x;
					ent.transform.localScale = new Vector3(scale, scale, 1.0f);
					ent.GetComponent<Renderer>().sortingOrder = (columns - c) + (rows - r) * columns;
					
					board[c + r * columns] = grassID;
					break;
				}
				case farmID:
				{
					board[c + r * columns] = cropsID;
					GameObject ent = Instantiate(farm, new Vector3(x + halfWidth, y + halfHeight / 2, 0), Quaternion.identity) as GameObject;
					float scale = (float)(width * 0.9) / (float)ent.GetComponent<Renderer>().bounds.size.x;
					ent.transform.localScale = new Vector3(scale, scale, 1.0f);
					break;
				}
				case house1ID:
				{
					board[c + r * columns] = grassID;
					GameObject ent = Instantiate(house1, new Vector3(x + halfWidth, y + halfHeight / 2, 0), Quaternion.identity) as GameObject;
					float scale = (float)(width * 0.5) / (float)ent.GetComponent<Renderer>().bounds.size.x;
					ent.transform.localScale = new Vector3(scale, scale, 1.0f);
					ent.GetComponent<Renderer>().sortingOrder = (columns - c) + (rows - r) * columns;
					break;
				}
				case house2ID:
				{
					board[c + r * columns] = grassID;
					GameObject ent = Instantiate(house2, new Vector3(x + halfWidth, y + halfHeight / 2, 0), Quaternion.identity) as GameObject;
					float scale = (float)(width * 0.5) / (float)ent.GetComponent<Renderer>().bounds.size.x;
					ent.transform.localScale = new Vector3(scale, scale, 1.0f);
					ent.GetComponent<Renderer>().sortingOrder = (columns - c) + (rows - r) * columns;
					break;
				}
				case house3ID:
				{
					board[c + r * columns] = grassID;
					GameObject ent = Instantiate(house3, new Vector3(x + halfWidth, y + halfHeight / 2, 0), Quaternion.identity) as GameObject;
					float scale = (float)(width * 0.5) / (float)ent.GetComponent<Renderer>().bounds.size.x;
					ent.transform.localScale = new Vector3(scale, scale, 1.0f);
					ent.GetComponent<Renderer>().sortingOrder = (columns - c) + (rows - r) * columns;
					break;
				}
				case cropsID:
				{
					if (Random.Range(0, 6) == 0) break;
					
					GameObject ent = Instantiate(corn, new Vector3(x + halfWidth - 4 + Random.Range(0, 9), y + halfHeight / 2 - 4 + Random.Range(0, 9), 0), Quaternion.identity) as GameObject;
					float scale = (float)(height * 0.8) / (float)ent.GetComponent<Renderer>().bounds.size.y;
					ent.transform.localScale = new Vector3(scale, scale, 1.0f);
					break;
				}
				case lagoon1ID:
				{
					GameObject ent = Instantiate(lagoon1, new Vector3(x + halfWidth, y + halfHeight / 2, 0), Quaternion.identity) as GameObject;
					float scale = (float)(height * 4.0) / (float)ent.GetComponent<Renderer>().bounds.size.y;
					ent.transform.localScale = new Vector3(scale, scale, 1.0f);
					board[c + r * columns] = grassID;
					break;
				}
				case lagoon2ID:
				{
					GameObject ent = Instantiate(lagoon2, new Vector3(x + halfWidth, y + halfHeight / 2, 0), Quaternion.identity) as GameObject;
					float scale = (float)(height * 4.0) / (float)ent.GetComponent<Renderer>().bounds.size.y;
					ent.transform.localScale = new Vector3(scale, scale, 1.0f);
					board[c + r * columns] = grassID;
					break;
				}
				case lagoon3ID:
				{
					GameObject ent = Instantiate(lagoon3, new Vector3(x + halfWidth, y + halfHeight / 2, 0), Quaternion.identity) as GameObject;
					float scale = (float)(height * 4.0) / (float)ent.GetComponent<Renderer>().bounds.size.y;
					ent.transform.localScale = new Vector3(scale, scale, 1.0f);
					board[c + r * columns] = grassID;
					break;
				}
				case lagoon4ID:
				{
					GameObject ent = Instantiate(lagoon4, new Vector3(x + halfWidth, y + halfHeight / 2, 0), Quaternion.identity) as GameObject;
					float scale = (float)(height * 4.0) / (float)ent.GetComponent<Renderer>().bounds.size.y;
					ent.transform.localScale = new Vector3(scale, scale, 1.0f);
					board[c + r * columns] = grassID;
					break;
				}
				}
				
				GameObject tile = Instantiate(tiles[board[c + r * columns]], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
				
				if (special)
				{
					board[c + r * columns] = placingID;
					placelist.Add(tile);
				}
				
				if (board[c + r * columns] == beachID)
				{
					placelist.Add(tile);
				}
				
				SpriteRenderer renderer = tile.GetComponent<SpriteRenderer>();
				
				float widthR = renderer.bounds.size.x;
				float heightR = renderer.bounds.size.y;
				
				float scaleX = width / widthR;
				float scaleY = height / heightR;
				
				tile.transform.localScale = new Vector3(scaleX, scaleY, 1.0f);
				tile.transform.position = new Vector3(x, y, 0);
				
				boardfabs[c + r * columns] = tile;
			}
		}
		// left
		for (int r = rows; r < rows * 2; r++) {
			for (int c = 0; c < columns; c++) {
				float x = (c - r) * halfWidth + Screen.width / 2;
				float y = (c + r) * halfHeight;
				
				switch (boardL[c + (r - rows) * columns])
				{
				case tree1ID:
				{
					boardL[c + (r - rows) * columns] = grassID;
					int use = Random.Range(0, 3);
					GameObject ent;
					float scale;
					if (use == 0)
					{
						ent = Instantiate(tree2, new Vector3(x + halfWidth, y + halfHeight / 2, 0), Quaternion.identity) as GameObject;
						scale = (float)(height * 1.4) / (float)ent.GetComponent<Renderer>().bounds.size.y;
					}
					else
					{
						ent = Instantiate(tree1, new Vector3(x + halfWidth, y + halfHeight / 2, 0), Quaternion.identity) as GameObject;
						scale = (float)(height * 2) / (float)ent.GetComponent<Renderer>().bounds.size.y;
					}
					ent.transform.localScale = new Vector3(scale, scale, 1.0f);
					break;
				}
				}
				
				GameObject tile = Instantiate(tiles[boardL[c + (r - rows) * columns]], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
				Renderer renderer = tile.GetComponent<Renderer>();
				float widthR = renderer.bounds.size.x;
				float heightR = renderer.bounds.size.y;
				float scaleX = width / widthR;
				float scaleY = height / heightR;
				tile.transform.localScale = new Vector3(scaleX, scaleY, 1.0f);
				tile.transform.position = new Vector3(x, y, 0);
			}
		}
		// top
		for (int r = 0; r < rows; r++) {
			for (int c = columns; c < columns * 2; c++) {
				float x = (c - r) * halfWidth + Screen.width / 2;
				float y = (c + r) * halfHeight;
				
				switch (boardT[c - columns + r * columns])
				{
				case tree1ID:
				{
					boardT[c - columns + r * columns] = grassID;
					int use = Random.Range(0, 3);
					GameObject ent;
					float scale;
					if (use == 0)
					{
						ent = Instantiate(tree2, new Vector3(x + halfWidth, y + halfHeight / 2, 0), Quaternion.identity) as GameObject;
						scale = (float)(height * 1.4) / (float)ent.GetComponent<Renderer>().bounds.size.y;
					}
					else
					{
						ent = Instantiate(tree1, new Vector3(x + halfWidth, y + halfHeight / 2, 0), Quaternion.identity) as GameObject;
						scale = (float)(height * 2) / (float)ent.GetComponent<Renderer>().bounds.size.y;
					}
					ent.transform.localScale = new Vector3(scale, scale, 1.0f);
					break;
				}
				}
				
				GameObject tile = Instantiate(tiles[boardT[c - columns+ r * columns]], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
				Renderer renderer = tile.GetComponent<Renderer>();
				float widthR = renderer.bounds.size.x;
				float heightR = renderer.bounds.size.y;
				float scaleX = width / widthR;
				float scaleY = height / heightR;
				tile.transform.localScale = new Vector3(scaleX, scaleY, 1.0f);
				tile.transform.position = new Vector3(x, y, 0);
			}
		}
	}
	
	void Update()
	{
		if (canPlaceDesal && !locationSelected) {
			
			flashtime += 0.05f;
			for (int i = 0; i < placelist.Count; i++) {
				GameObject p = placelist [i];
				SpriteRenderer pr = p.GetComponent<SpriteRenderer>();
				pr.color = new Color(1.0f + Mathf.Cos(flashtime) * 0.5f, 1.0f + Mathf.Cos(flashtime) * 0.5f, 1.0f + Mathf.Cos(flashtime) * 0.5f, 1.0f);
			}
			
			Vector3 pos = Camera.main.transform.position;
			Vector3 mouse = Input.mousePosition;
			
			// float aspect = (float)Screen.width / (float)Screen.height;
			// float verti  = Camera.main.orthographicSize;
			// float horiz  = verti * aspect;
			
			pos.x += Mathf.Round(mouse.x - Screen.width - halfWidth);
			pos.y += Mathf.Round(mouse.y - Screen.height / 2);
			
			float ww = halfWidth  * 2;
			float hh = halfHeight * 2;
			
			int gx = (int)Mathf.Floor(pos.x / ww + pos.y / hh);
			int gy = (int)Mathf.Floor(pos.y / hh - pos.x / ww);
			
			if (gx < 0)
				gx = 0;
			if (gy < 0)
				gy = 0;
			if (gx >= columns)
				gx = columns - 1;
			if (gy >= rows)
				gy = rows - 1;
			
			float x = (gx - gy) * halfWidth + Screen.width / 2;
			float y = (gx + gy) * halfHeight;
			
			placeDesal.transform.position = new Vector3 (x + halfWidth * 2, y + halfHeight, 0);
			
			SpriteRenderer rend = placeDesal.GetComponent<SpriteRenderer> ();
			
			if (board [gx + gy * columns] == beachID || board [gx + gy * columns] == placingID) {
				if (isClick) {
					rend.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
					rend.sortingOrder = (columns - gx) + (rows - gy) * columns;
					locationSelected = true;
					canPlaceDesal = false;
					
					for (int i = 0; i < placelist.Count; i++) {
						GameObject p = placelist [i];
						SpriteRenderer pr = p.GetComponent<SpriteRenderer>();
						pr.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
					}
					
					// pollution around plant
					for (int pc = gx - 5; pc < gx + 5; pc++) {
						for (int pr = gy - 5; pr < gy + 5; pr++) {
							if (pc < 0 || pr < 0 || pc >= columns || pr >= rows) continue;
							if (pc == gx - 5 && pr == gy - 5) continue;
							if (pc == gx + 4 && pr == gy + 4) continue;
							if (pc == gx - 5 && pr == gy + 4) continue;
							if (pc == gx + 4 && pr == gy - 5) continue;
							
							int g = pc + pr * columns;
							if (board[g] == grassID || board[g] == placingID) {
								SpriteRenderer prend = boardfabs[g].GetComponent<SpriteRenderer> ();
								prend.sprite = pollution;
							}
						}
					}
				}
				else {
					rend.color = new Color(1.0f, 1.0f, 1.0f, 0.66f);
				}
			} else {
				rend.color = new Color(1.0f, 0.5f, 0.5f, 0.66f);
			}
		}

	}
	
	void CustomMap1()
	{
		// base grass
		for (int c = 0; c < columns; c++) {
			for (int r = 0; r < rows; r++) {
				board [c + r * columns] = grassID;
				boardT [c + r * columns] = grassID;
				boardD [c + r * columns] = oceanID;
				boardL [c + r * columns] = grassID;
				boardR [c + r * columns] = grassID;
			}
		}
		
		// ocean + beach + road
		for (int r = 0; r < rows; r++)
		{
			board[0 + r * columns] = oceanID;
			boardL[0 + r * columns] = oceanID;
			boardR[0 + r * columns] = oceanID;
			
			board[1 + r * columns] = oceanID;
			boardL[1 + r * columns] = oceanID;
			boardR[1 + r * columns] = oceanID;
			
			board[2 + r * columns] = beachID;
			boardL[2 + r * columns] = beachID;
			boardR[2 + r * columns] = beachID;
			
			board[5 + r * columns] = roadID;
			boardL[5 + r * columns] = roadID;
			boardR[5 + r * columns] = roadID;
			
			boardL[(columns / 4) + r * columns] = roadID;
			boardR[(columns / 2) + r * columns] = roadID;
		}
		
		for (int c = 0; c < columns; c++)
			boardT[c + (rows / 3) * columns] = road2ID;
		
		int c0;
		int c1;
		int r0;
		int r1;
		
		// lakes + lagoons
		c0 = Mathf.RoundToInt (columns * 0.30f);
		c1 = c0 + 6;
		r0 = Mathf.RoundToInt (rows * 0.15f);
		r1 = r0 + 6;
		for (int c = c0; c < c1; c++)
			for (int r = r0; r < r1; r++)
				board [c + r * columns] = -1;
		board [(c0+3) + (r0+2) * columns] = lagoon1ID;
		board [(c0+3) + (r0+4) * columns] = lagoon2ID;
		for (int c = c0 - 1; c < c1; c++) {
			for (int r = r0; r < r1; r++) {
				if (c == c0 - 1 || r == r0 || c == c1 - 1 || r == r1 - 1)
					board [c + r * columns] = placingID;
			}
		}
		
		c0 = Mathf.RoundToInt (columns * 0.80f);
		c1 = c0 + 6;
		r0 = Mathf.RoundToInt (rows * 0.80f);
		r1 = r0 + 6;
		for (int c = c0; c < c1; c++)
			for (int r = r0; r < r1; r++)
				board [c + r * columns] = -1;
		board [(c0+3) + (r0+2) * columns] = lagoon4ID;
		board [(c0+3) + (r0+4) * columns] = lagoon3ID;
		for (int c = c0 - 1; c < c1; c++) {
			for (int r = r0; r < r1; r++) {
				if (c == c0 - 1 || r == r0 || c == c1 - 1 || r == r1 - 1)
					board [c + r * columns] = placingID;
			}
		}
		
		// roads horizontal
		for (int c = 5; c < columns; c++)
			board[c + (rows / 3) * columns] = road2ID;
		
		for (int c = 5; c < Mathf.RoundToInt(columns / 1.25f); c++)
			board[c + Mathf.RoundToInt(rows / 1.75f) * columns] = road2ID;
		
		// roads vertical
		for (int r = Mathf.RoundToInt(rows / 1.75f) - 1; r > (rows / 3); r--)
			board[Mathf.RoundToInt(columns / 1.25f - 1) + r * columns] = roadID;
		
		for (int r = Mathf.RoundToInt(rows / 1.75f) - 1; r >= 0; r--)
			board[Mathf.RoundToInt(columns / 2) + r * columns] = roadID;
		
		for (int r = (rows / 3); r < rows; r++)
			board[Mathf.RoundToInt(columns / 4) + r * columns] = roadID;
		
		// road corner
		board[Mathf.RoundToInt(columns / 1.25f - 1) + Mathf.RoundToInt(rows / 1.75f) * columns] = roadCornerID;
		
		// road 3 intersection
		board[Mathf.RoundToInt(columns / 1.25f - 1) + (rows / 3) * columns] = roadInterLUDID;
		board[Mathf.RoundToInt(columns / 4) + (rows / 3) * columns] = roadInterLUDID;
		
		board[5 + (rows / 3) * columns] = roadInterLRUID;
		board[5 + Mathf.RoundToInt(rows / 1.75f) * columns] = roadInterLRUID;
		
		board[Mathf.RoundToInt(columns / 2) + Mathf.RoundToInt(rows / 1.75f) * columns] = roadInterRUDID;
		
		// cross roads
		board[Mathf.RoundToInt(columns / 2) + Mathf.RoundToInt(rows / 3) * columns] = crossRoadID;
		board[Mathf.RoundToInt(columns / 4) + Mathf.RoundToInt(rows / 1.75f) * columns] = crossRoadID;
		
		// houses
		for (int r = Mathf.RoundToInt(rows / 1.75f) + 1; r < rows; r++)
			board[Mathf.RoundToInt(columns / 4 + 1) + r * columns] = Random.Range(house1ID, house3ID + 1);
		
		for (int r = Mathf.RoundToInt(rows / 3) + 1; r < Mathf.RoundToInt(rows / 1.75f); r++)
			board[Mathf.RoundToInt(columns / 2 + 1) + r * columns] = Random.Range(house1ID, house3ID + 1);
		
		for (int r = Mathf.RoundToInt(rows / 3 + 1); r < Mathf.RoundToInt(rows / 1.75f + 1); r++)
			board[Mathf.RoundToInt(columns / 1.25f) + r * columns] = Random.Range(house1ID, house3ID + 1);
		
		for (int c = Mathf.RoundToInt(columns / 2) + 1; c < Mathf.RoundToInt(columns / 1.25f + 1); c++)
			board[c + (Mathf.RoundToInt(rows / 1.75f) + 1) * columns] = Random.Range(house1ID, house3ID + 1);
		
		for (int c = Mathf.RoundToInt(columns / 2) + 2; c < Mathf.RoundToInt(columns / 1.25f - 1); c++)
			board[c + (Mathf.RoundToInt(rows / 3) + 1) * columns] = Random.Range(house1ID, house3ID + 1);
		
		// farm + crops
		c0 = Mathf.RoundToInt (columns * 0.40f);
		c1 = c0 + 8;
		r0 = Mathf.RoundToInt (rows * 0.80f);
		r1 = r0 + 8;
		for (int c = c0; c < c1; c++)
			for (int r = r0; r < r1; r++)
				board[c + r * columns] = cropsID;
		board[(c1 - 2) + (r1 - 2) * columns] = farmID;
		
		c0 = Mathf.RoundToInt (columns * 0.65f);
		c1 = c0 + 10;
		r0 = Mathf.RoundToInt (rows * 0.10f);
		r1 = r0 + 8;
		for (int c = c0; c < c1; c++)
			for (int r = r0; r < r1; r++)
				board[c + r * columns] = cropsID;
		board[(c0 + 1) + (r0 + 1) * columns] = farmID;

		// trees
		for (int i = 0; i < 150; i++) // board
		{
			int c = Random.Range(6, columns);
			int r = Random.Range(0, rows);
			
			if (board[c + r * columns] == grassID && board[c - 1 + r * columns] == grassID)
				board[c + r * columns] = tree1ID;
			else i--;
		}
		for (int i = 0; i < 225; i++) // left
		{
			int c = Random.Range(6, columns);
			int r = Random.Range(0, rows);
			
			if (boardL[c + r * columns] == grassID)
				boardL[c + r * columns] = tree1ID;
			else i--;
		}
		for (int i = 0; i < 225; i++) // right
		{
			int c = Random.Range(6, columns);
			int r = Random.Range(0, rows);
			
			if (boardR[c + r * columns] == grassID)
				boardR[c + r * columns] = tree1ID;
			else i--;
		}
		for (int i = 0; i < 225; i++) // top
		{
			int c = Random.Range(6, columns);
			int r = Random.Range(0, rows);
			
			if (boardT[c + r * columns] == grassID)
				boardT[c + r * columns] = tree1ID;
			else i--;
		}
	}
	
	public void capacityUpgrade(){
		//placeDesal.GetComponent<SpriteRenderer> ().sprite = desalCapacity;
	}
	
	public void environmentUpgrade(){
		//placeDesal.GetComponent<SpriteRenderer> ().sprite = desalEnvironment;
	}
	
	public void happinessUpgrade(){
		//placeDesal.GetComponent<SpriteRenderer> ().sprite = desalHappiness;
	}
}