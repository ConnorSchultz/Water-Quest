using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScriptBoard2 : MonoBehaviour
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
	public GameObject desal;
	public Sprite desalHappiness;
	public Sprite desalEnvironment;
	public Sprite desalCapacity;
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
    public GameObject signBeach;
    public GameObject signRiver;
    public GameObject signLagoon;
	public GameObject tree2;
	public GameObject crossRoad;
	public GameObject lagoon1;
	public GameObject lagoon2;
	public GameObject lagoon3;
	public GameObject lagoon4;
	public UnityEngine.UI.Text scientistText;
	public Sprite pollution;
	public GameObject desalButton;
	public GameObject upgradeButtons;
	public GameObject scores;
	public GameObject happinessBar;
	public GameObject environmentBar;
	public GameObject capacityBar;
	public GameObject scoreKeeper;
	public GameObject gameManager;
	public GameObject moneyParticle;
	public GameObject desalParticle;
	public GameObject roadCornerUL;
	public GameObject roadCornerRT;
	public GameObject roadInterLRD;
	public GameObject desalPlacerIcon;
	public GameObject beachSign;

	public UnityEngine.UI.Text desalButtonText;
	public UnityEngine.Sprite grayBarImage;
	public UnityEngine.Sprite happinessBarImage;
	public UnityEngine.Sprite environmentBarImage;
	public UnityEngine.Sprite capacityBarImage;
	public UnityEngine.UI.Text happinessScoreText;
	public UnityEngine.UI.Text environmentScoreText;
	public UnityEngine.UI.Text capacityScoreText;

	public GameObject happinessScoreIcon;
	public UnityEngine.Sprite happinessImageBW;
	public UnityEngine.Sprite happinessImage;
	public GameObject environmentScoreIcon;
	public UnityEngine.Sprite environmentImageBW;
	public UnityEngine.Sprite evironmentImage;
	public GameObject capacityScoreIcon;
	public UnityEngine.Sprite capacityImageBW;
	public UnityEngine.Sprite capacityImage;
	public UnityEngine.UI.Button placeDesalButton;

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
	private const int placing2ID = 33;
	private const int cornerULID = 34;
	private const int cornerRTID = 35;
	private const int roadInterLRDID = 36;
    private const int signBeachID = 37;
    private const int signRiverID = 38;
    private const int signLagoonID = 39;
	private const int tileNum = 40;
	bool moveCheck = false;

	bool textCheck = false; // checks if "find research text" been displayed
	private int[] board;
	private int[] boardT;
	private int[] boardD;
	private int[] boardL;
	private int[] boardR;
	private GameObject[] boardfabs;

	
	// private float flashtime = 0.0f;
	// private List<GameObject> placelist = new List<GameObject>();
	private List<GameObject> placeIcons = new List<GameObject> (); // holds the buttons to select desal location
	
	private Vector3 dragOrigin;
	private GameObject placeDesal;
	private bool locationSelected = false;
	private bool isClick = false;
	private bool isMove = true;
	private bool canPlaceDesal = false;
	private bool moneySpawned;
	private float zoomLevel = 2;
	private int[] researchC = new int[9];
	private int[] researchR = new int[9];
	public GameObject MoneyCoin;
	private int spawningMoney = 0;
	private List<GameObject> moneyCoinList = new List<GameObject> ();
	private List<int> moneyCoinTime = new List<int> ();
	int numCoins = 0;
	private bool tutorialcomplete = false;
	public UnityEngine.UI.Text timeText;
	public UnityEngine.UI.Text bestStatText;
	public UnityEngine.UI.Text coinText;
	private bool countDown = false;
	private string timerString;
	private bool upgradeBought = false;
	float currentTime = 90;//time in seconds
	string minutes;
	string seconds;
	private string findResearchText = "Now find more research!";
	private string placeDesalText = "You can now place the desalination plant, or continue to find more research!";
	private string moveText = "Great! Now move your mouse to the edges of the screen to move around.";
	private string moneyGameText = "Collect atleast 10 coins to buy an upgrade. You only have 90 seconds!";
	private string buyUpgradeText = "Time is up! You have enough coins to buy an upgrade!";
	private string noUpgradeText = "Time is up! Sorry, you don't have enough coins to buy an upgrade. Click anywhere to continue.";
	private string upgradeBoughtText = "Your desal plant is complete! Click anywhere to continue";

	private string defaultStatText = "Find more research to discover a special fact!";
	private string bestHappinessText = "This location has the highest Happiness!";
	private string bestEnvironmentText = "This location has the highest Environent!";
	private string bestCapacityText = "This location has the highest Capacity!";




	private int gxGlobal;
	private int gyGlobal;
	
	public void desalButtonClicked ()
	{
		if (locationSelected)
			return;
		

		
		if (canPlaceDesal) {
			zoomNorm ();
			canPlaceDesal = false;
			desalButtonText.text = "Place Desalination Plant";

		} else {
			zoomOutFull ();
			canPlaceDesal = true;
			desalButtonText.text = "Find More Research";
		}
	}
	
	private void zooming ()
	{
		Camera.main.orthographicSize = (Screen.height * (0.25f * zoomLevel));
	}
	
	public void spawnMoney ()
	{
		spawningMoney += 1800;
		spawnOneMoneyCoin ();
		scientistText.text = moneyGameText;
		countDown = true;	
		placeDesalButton.gameObject.SetActive (false);
	}

	public void spawnOneMoneyCoin ()
	{
		int c = Random.Range (3, columns);
		int r = Random.Range (0, rows);
		float x = (c - r) * halfWidth + Screen.width / 2;
		float y = (c + r) * halfHeight;
		GameObject coin = Instantiate (MoneyCoin, new Vector3 (x + halfWidth, y + halfHeight, 0), Quaternion.identity) as GameObject;
		SpriteRenderer rend = coin.GetComponent<SpriteRenderer> ();
		float scale = (float)(width * 0.4) / (float)rend.bounds.size.x;
		coin.transform.localScale = new Vector3 (scale, scale, 1.0f);
		rend.sortingOrder = columns + rows * columns;
		rend.color = new Color (1, 1, 1, 0);
		moneyCoinList.Add (coin);
		moneyCoinTime.Add (1800);
	}
	
	public void zoomIn ()
	{
		if (zoomLevel > 1)
			zoomLevel--;
		zooming ();
	}
	
	public void zoomOut ()
	{
		if (zoomLevel < 5)
			zoomLevel++;
		zooming ();
	}

	public void zoomOutFull ()
	{
		zoomLevel = 3.8f;
		zooming ();
		float zx = Screen.width / 2 + (gxGlobal - gyGlobal) * halfWidth;
		float zy = (gxGlobal+ gyGlobal) * halfHeight ;
		Camera.main.transform.position = new Vector3 (zx, zy, -10.0f);
	}
	
	public void zoomNorm ()
	{
		zoomLevel = 2;
		zooming ();
	}
	
	public void completeTutorial ()
	{
		tutorialcomplete = true;
	}
	
	private void screenBounds ()
	{
		float pxx = Camera.main.transform.position.x;
		float pyy = Camera.main.transform.position.y;
		
		float aspect = (float)Screen.width / (float)Screen.height;
		float verti = Camera.main.orthographicSize;
		float horiz = verti * aspect;
		
		float mapX = columns * halfWidth;
		float mapY = rows * halfHeight;
		
		float left = horiz - mapX + Screen.width / 2 + halfWidth;
		float right = mapX - horiz + Screen.width / 2 + halfWidth;
		float top = mapY * 2 - verti;
		float bot = verti;
		
		if (pxx < left)
			pxx = left;
		else if (pxx > right)
			pxx = right;
		
		if (pyy < bot)
			pyy = bot;
		else if (pyy > top)
			pyy = top;
		
		Camera.main.transform.position = new Vector3 (pxx, pyy, Camera.main.transform.position.z);
	}
	
	void Start ()
	{
		tiles = new GameObject[tileNum];
		tiles [grassID] = grass;
		tiles [beachID] = beach;
		tiles [oceanID] = ocean;
		tiles [researchRID] = researchPlantR;
		tiles [roadID] = road;
		tiles [road2ID] = road2;
		tiles [farmID] = farm;
		tiles [cropsID] = crops;
		tiles [house1ID] = house1;
		tiles [house2ID] = house2;
		tiles [house3ID] = house3;
		tiles [tree1ID] = tree1;
		tiles [roadCornerID] = roadCorner;
		tiles [roadInterLUDID] = roadInterLUD;
		tiles [roadInterRUDID] = roadInterRUD;
		tiles [roadInterLRUID] = roadInterLRU;
		tiles [researchGID] = researchPlantG;
		tiles [researchBID] = researchPlantB;
		tiles [crossRoadID] = crossRoad;
		tiles [cornerULID] = roadCornerUL;
		tiles [cornerRTID] = roadCornerRT;
		tiles [roadInterLRDID] = roadInterLRD;
        tiles [signBeachID] = signBeach;
        tiles [signRiverID] = signRiver;
        tiles [signLagoonID] = signLagoon;

		width = 100; // 62, 60
		height = 50; // 31, 30
		halfWidth = width / 2.0f - 3.0f;
		halfHeight = height / 2.0f - 1.5f;
		
		columns = 50;
		rows = 50;
		board = new int[columns * rows];
		boardfabs = new GameObject[columns * rows];
		
		boardT = new int[columns * rows];
		boardD = new int[columns * rows];
		boardL = new int[columns * rows];
		boardR = new int[columns * rows];
		
		CustomMap1 ();
		
		{
			placeDesal = Instantiate (desal, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
			SpriteRenderer rend = placeDesal.GetComponent<SpriteRenderer> ();
			float scale = (float)(width * 1.5) / (float)rend.bounds.size.x;
			// rend.color = new Color (1.0f, 1.0f, 1.0f, 0.66f);
			placeDesal.transform.localScale = new Vector3 (scale, scale, 1.0f);
			rend.enabled = false;
		}
		
		zooming ();
		{
			float x = Screen.width / 2 + (researchC [0] - researchR [0]) * halfWidth + halfWidth;
			float y = (researchC [0] + researchR [0]) * halfHeight + halfHeight;
			Camera.main.transform.position = new Vector3 (x, y, -10.0f);
		}
		
		// down
		for (int r = 0; r < rows; r++) {
			for (int c = -columns; c < 0; c++) {
				float x = (c - r) * halfWidth + Screen.width / 2;
				float y = (c + r) * halfHeight;
				
				GameObject tile = Instantiate (tiles [boardD [c + columns + r * columns]], new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
				Renderer renderer = tile.GetComponent<Renderer> ();
				float widthR = renderer.bounds.size.x;
				float heightR = renderer.bounds.size.y;
				float scaleX = width / widthR;
				float scaleY = height / heightR;
				tile.transform.localScale = new Vector3 (scaleX, scaleY, 1.0f);
				tile.transform.position = new Vector3 (x, y, 0);
			}
		}
		// right
		for (int r = -rows; r < 0; r++) {
			for (int c = 0; c < columns; c++) {
				float x = (c - r) * halfWidth + Screen.width / 2;
				float y = (c + r) * halfHeight;
				
				switch (boardR [c + (r + rows) * columns]) {
				case tree1ID:
					{
						boardR [c + (r + rows) * columns] = grassID;
						int use = Random.Range (0, 3);
						GameObject ent;
						float scale;
						if (use == 0) {
							ent = Instantiate (tree2, new Vector3 (x + halfWidth, y + halfHeight / 2, 0), Quaternion.identity) as GameObject;
							scale = (float)(height * 1.4) / (float)ent.GetComponent<Renderer> ().bounds.size.y;
						} else {
							ent = Instantiate (tree1, new Vector3 (x + halfWidth, y + halfHeight / 2, 0), Quaternion.identity) as GameObject;
							scale = (float)(height * 2) / (float)ent.GetComponent<Renderer> ().bounds.size.y;
						}
						ent.transform.localScale = new Vector3 (scale, scale, 1.0f);
						break;
					}
				}
				
				GameObject tile = Instantiate (tiles [boardR [c + (r + rows) * columns]], new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
				Renderer renderer = tile.GetComponent<Renderer> ();
				float widthR = renderer.bounds.size.x;
				float heightR = renderer.bounds.size.y;
				float scaleX = width / widthR;
				float scaleY = height / heightR;
				tile.transform.localScale = new Vector3 (scaleX, scaleY, 1.0f);
				tile.transform.position = new Vector3 (x, y, 0);
			}
		}
		// board
		for (int r = 0; r < rows; r++) {
			for (int c = 0; c < columns; c++) {
				float x = (c - r) * halfWidth + Screen.width / 2;
				float y = (c + r) * halfHeight;
				int special = -1;
				
				switch (board [c + r * columns]) {
				case -1:
					//continue;
					board [c + r * columns] = grassID;
					break;
				case placingID:
				case placing2ID:
					special = board [c + r * columns];
					board [c + r * columns] = grassID;
					break;
				//continue;
				case tree1ID:
					{
						board [c + r * columns] = grassID;
						int use = Random.Range (0, 3);
						GameObject ent;
						float scale;
						if (use == 0) {
							ent = Instantiate (tree2, new Vector3 (x + halfWidth, y + halfHeight / 2, 0), Quaternion.identity) as GameObject;
							scale = (float)(height * 1.4) / (float)ent.GetComponent<Renderer> ().bounds.size.y;
						} else {
							ent = Instantiate (tree1, new Vector3 (x + halfWidth, y + halfHeight / 2, 0), Quaternion.identity) as GameObject;
							scale = (float)(height * 2) / (float)ent.GetComponent<Renderer> ().bounds.size.y;
						}
						ent.GetComponent<Renderer> ().sortingOrder = (columns - c) + (rows - r) * columns;
						ent.transform.localScale = new Vector3 (scale, scale, 1.0f);
						break;
					}
				case researchRID:
				case researchGID:
				case researchBID:
					{
						GameObject ent;
						SpriteRenderer rend;
					
						if (board [c + r * columns] == researchRID) {
							ent = Instantiate (researchPlantR, new Vector3 (x + halfWidth, y + halfHeight / 2, 0), Quaternion.identity) as GameObject;
							rend = ent.GetComponent<SpriteRenderer> ();
							//rend.color = new Color(1.0f, 0.8f, 0.8f, 1.0f);
						} else if (board [c + r * columns] == researchGID) {
							ent = Instantiate (researchPlantG, new Vector3 (x + halfWidth, y + halfHeight / 2, 0), Quaternion.identity) as GameObject;
							rend = ent.GetComponent<SpriteRenderer> ();
							//rend.color = new Color(0.8f, 1.0f, 0.8f, 1.0f);
						} else {
							ent = Instantiate (researchPlantB, new Vector3 (x + halfWidth, y + halfHeight / 2, 0), Quaternion.identity) as GameObject;
							rend = ent.GetComponent<SpriteRenderer> ();
							//rend.color = new Color(0.8f, 0.8f, 1.0f, 1.0f);
						}
					
						float scale = (float)(width * 0.75) / (float)rend.bounds.size.x;
						ent.transform.localScale = new Vector3 (scale, scale, 1.0f);
						ent.GetComponent<Renderer> ().sortingOrder = (columns - c) + (rows - r) * columns;
					
						board [c + r * columns] = grassID;
						break;
					}
				case farmID:
					{
						board [c + r * columns] = cropsID;
						GameObject ent = Instantiate (farm, new Vector3 (x + halfWidth, y + halfHeight / 2, 0), Quaternion.identity) as GameObject;
						float scale = (float)(width * 0.9) / (float)ent.GetComponent<Renderer> ().bounds.size.x;
						ent.transform.localScale = new Vector3 (scale, scale, 1.0f);
						break;
					}
				case house1ID:
					{
						board [c + r * columns] = grassID;
						GameObject ent = Instantiate (house1, new Vector3 (x + halfWidth, y + halfHeight / 2, 0), Quaternion.identity) as GameObject;
						float scale = (float)(width * 0.5) / (float)ent.GetComponent<Renderer> ().bounds.size.x;
						ent.transform.localScale = new Vector3 (scale, scale, 1.0f);
						ent.GetComponent<Renderer> ().sortingOrder = (columns - c) + (rows - r) * columns;
						break;
					}
				case house2ID:
					{
						board [c + r * columns] = grassID;
						GameObject ent = Instantiate (house2, new Vector3 (x + halfWidth, y + halfHeight / 2, 0), Quaternion.identity) as GameObject;
						float scale = (float)(width * 0.5) / (float)ent.GetComponent<Renderer> ().bounds.size.x;
						ent.transform.localScale = new Vector3 (scale, scale, 1.0f);
						ent.GetComponent<Renderer> ().sortingOrder = (columns - c) + (rows - r) * columns;
						break;
					}
				case house3ID:
					{
						board [c + r * columns] = grassID;
						GameObject ent = Instantiate (house3, new Vector3 (x + halfWidth, y + halfHeight / 2, 0), Quaternion.identity) as GameObject;
						float scale = (float)(width * 0.5) / (float)ent.GetComponent<Renderer> ().bounds.size.x;
						ent.transform.localScale = new Vector3 (scale, scale, 1.0f);
						ent.GetComponent<Renderer> ().sortingOrder = (columns - c) + (rows - r) * columns;
						break;
					}
				case cropsID:
					{
						if (Random.Range (0, 6) == 0)
							break;
					
						GameObject ent = Instantiate (corn, new Vector3 (x + halfWidth - 4 + Random.Range (0, 9), y + halfHeight / 2 - 4 + Random.Range (0, 9), 0), Quaternion.identity) as GameObject;
						float scale = (float)(height * 0.8) / (float)ent.GetComponent<Renderer> ().bounds.size.y;
						ent.transform.localScale = new Vector3 (scale, scale, 1.0f);
						break;
					}
                case signBeachID:
                    {
                        board [c + r * columns] = grassID;
                        GameObject ent = Instantiate (signBeach, new Vector3 (x + halfWidth, y + halfHeight / 2, 0), Quaternion.identity) as GameObject;
						float scale = (float)(height * 1.0) / (float)ent.GetComponent<Renderer> ().bounds.size.y;
						ent.transform.localScale = new Vector3 (scale, scale, 1.0f);
						break; 
                    }
                case signLagoonID:
                    {
                        board [c + r * columns] = grassID;
                        GameObject ent = Instantiate (signLagoon, new Vector3 (x + halfWidth, y + halfHeight / 2, 0), Quaternion.identity) as GameObject;
						float scale = (float)(height * 1.0) / (float)ent.GetComponent<Renderer> ().bounds.size.y;
						ent.transform.localScale = new Vector3 (scale, scale, 1.0f);
						break; 
                    }
                case signRiverID:
                    {
                        board [c + r * columns] = grassID;
                        GameObject ent = Instantiate (signRiver, new Vector3 (x + halfWidth, y + halfHeight / 2, 0), Quaternion.identity) as GameObject;
						float scale = (float)(height * 1.0) / (float)ent.GetComponent<Renderer> ().bounds.size.y;
						ent.transform.localScale = new Vector3 (scale, scale, 1.0f);
						break; 
                    }
				case lagoon1ID:
					{
						GameObject ent = Instantiate (lagoon1, new Vector3 (x + halfWidth, y + halfHeight / 2, 0), Quaternion.identity) as GameObject;
						float scale = (float)(height * 4.0) / (float)ent.GetComponent<Renderer> ().bounds.size.y;
						ent.transform.localScale = new Vector3 (scale, scale, 1.0f);
						board [c + r * columns] = grassID;
						break;
					}
				case lagoon2ID:
					{
						GameObject ent = Instantiate (lagoon2, new Vector3 (x + halfWidth, y + halfHeight / 2, 0), Quaternion.identity) as GameObject;
						float scale = (float)(height * 4.0) / (float)ent.GetComponent<Renderer> ().bounds.size.y;
						ent.transform.localScale = new Vector3 (scale, scale, 1.0f);
						board [c + r * columns] = grassID;
						break;
					}
				case lagoon3ID:
					{
						GameObject ent = Instantiate (lagoon3, new Vector3 (x + halfWidth, y + halfHeight / 2, 0), Quaternion.identity) as GameObject;
						float scale = (float)(height * 4.0) / (float)ent.GetComponent<Renderer> ().bounds.size.y;
						ent.transform.localScale = new Vector3 (scale, scale, 1.0f);
						board [c + r * columns] = grassID;
						break;
					}
				case lagoon4ID:
					{
						GameObject ent = Instantiate (lagoon4, new Vector3 (x + halfWidth, y + halfHeight / 2, 0), Quaternion.identity) as GameObject;
						float scale = (float)(height * 4.0) / (float)ent.GetComponent<Renderer> ().bounds.size.y;
						ent.transform.localScale = new Vector3 (scale, scale, 1.0f);
						board [c + r * columns] = grassID;
						break;
					}
				}
				
				GameObject tile = Instantiate (tiles [board [c + r * columns]], new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
				
				if (special != -1) {
					board [c + r * columns] = special;
					// placelist.Add(tile);
				}
				
				if (board [c + r * columns] == beachID) {
					// placelist.Add(tile);
				}
				
				SpriteRenderer renderer = tile.GetComponent<SpriteRenderer> ();
				
				float widthR = renderer.bounds.size.x;
				float heightR = renderer.bounds.size.y;
				
				float scaleX = width / widthR;
				float scaleY = height / heightR;
				
				tile.transform.localScale = new Vector3 (scaleX, scaleY, 1.0f);
				tile.transform.position = new Vector3 (x, y, 0);
				
				boardfabs [c + r * columns] = tile;
			}
		}
		// left
		for (int r = rows; r < rows * 2; r++) {
			for (int c = 0; c < columns; c++) {
				float x = (c - r) * halfWidth + Screen.width / 2;
				float y = (c + r) * halfHeight;
				
				switch (boardL [c + (r - rows) * columns]) {
				case tree1ID:
					{
						boardL [c + (r - rows) * columns] = grassID;
						int use = Random.Range (0, 3);
						GameObject ent;
						float scale;
						if (use == 0) {
							ent = Instantiate (tree2, new Vector3 (x + halfWidth, y + halfHeight / 2, 0), Quaternion.identity) as GameObject;
							scale = (float)(height * 1.4) / (float)ent.GetComponent<Renderer> ().bounds.size.y;
						} else {
							ent = Instantiate (tree1, new Vector3 (x + halfWidth, y + halfHeight / 2, 0), Quaternion.identity) as GameObject;
							scale = (float)(height * 2) / (float)ent.GetComponent<Renderer> ().bounds.size.y;
						}
						ent.transform.localScale = new Vector3 (scale, scale, 1.0f);
						break;
					}
				}
				
				GameObject tile = Instantiate (tiles [boardL [c + (r - rows) * columns]], new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
				Renderer renderer = tile.GetComponent<Renderer> ();
				float widthR = renderer.bounds.size.x;
				float heightR = renderer.bounds.size.y;
				float scaleX = width / widthR;
				float scaleY = height / heightR;
				tile.transform.localScale = new Vector3 (scaleX, scaleY, 1.0f);
				tile.transform.position = new Vector3 (x, y, 0);
			}
		}
		// top
		for (int r = 0; r < rows; r++) {
			for (int c = columns; c < columns * 2; c++) {
				float x = (c - r) * halfWidth + Screen.width / 2;
				float y = (c + r) * halfHeight;
				
				switch (boardT [c - columns + r * columns]) {
				case tree1ID:
					{
						boardT [c - columns + r * columns] = grassID;
						int use = Random.Range (0, 3);
						GameObject ent;
						float scale;
						if (use == 0) {
							ent = Instantiate (tree2, new Vector3 (x + halfWidth, y + halfHeight / 2, 0), Quaternion.identity) as GameObject;
							scale = (float)(height * 1.4) / (float)ent.GetComponent<Renderer> ().bounds.size.y;
						} else {
							ent = Instantiate (tree1, new Vector3 (x + halfWidth, y + halfHeight / 2, 0), Quaternion.identity) as GameObject;
							scale = (float)(height * 2) / (float)ent.GetComponent<Renderer> ().bounds.size.y;
						}
						ent.transform.localScale = new Vector3 (scale, scale, 1.0f);
						break;
					}
				}
				
				GameObject tile = Instantiate (tiles [boardT [c - columns + r * columns]], new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
				Renderer renderer = tile.GetComponent<Renderer> ();
				float widthR = renderer.bounds.size.x;
				float heightR = renderer.bounds.size.y;
				float scaleX = width / widthR;
				float scaleY = height / heightR;
				tile.transform.localScale = new Vector3 (scaleX, scaleY, 1.0f);
				tile.transform.position = new Vector3 (x, y, 0);
			}
		}
	}
	
	void Update ()
	{
		if (upgradeBought && Input.GetMouseButtonDown (0)) {
			Application.LoadLevel ("ScoreScreen");
		}
		if (countDown) {
			if (currentTime > 0) {
				currentTime -= Time.deltaTime;
				minutes = Mathf.Floor (currentTime / 60).ToString ("0");
				seconds = Mathf.Floor (currentTime % 60).ToString ("00");
				timerString = (minutes + ":" + seconds);
				timeText.text = timerString;
			}
			if (currentTime <= 0) {
				timeText.text = "0:00";
				countDown = false;
				if(numCoins<10){
					moneyCoinList.Clear ();
					moneyCoinTime.Clear ();
					scientistText.text = noUpgradeText;
					buyUpgrade();
				}
			}
			
			if (numCoins >= 10) {
				scientistText.text = buyUpgradeText;
				timeText.text = "";
				currentTime = 0;
				moneyCoinList.Clear ();
				moneyCoinTime.Clear ();
				
			}

		}
		if (spawningMoney > 0) {
			spawningMoney--;
			if (spawningMoney % 60 == 0)
				spawnOneMoneyCoin ();
		}
		
		if (numCoins >= 10 && !upgradeBought) {
			moneyCoinList.Clear ();
			moneyCoinTime.Clear ();
			upgradeButtons.SetActive (true);
		}
		
		if (moneyCoinTime.Count > 0) {
			for (int i = 0; i < moneyCoinTime.Count; i++) {
				moneyCoinTime [i] = moneyCoinTime [i] - 1;
				Vector3 p = moneyCoinList [i].transform.position;
				moneyCoinList [i].transform.position = new Vector3 (p.x, p.y + Mathf.Sin (moneyCoinTime [i] * 0.1f) * 2f, p.z);
				if (moneyCoinTime [i] >= 1800 - 30) {
					SpriteRenderer rend = moneyCoinList [i].GetComponent<SpriteRenderer> ();
					rend.color = new Color (1, 1, 1, rend.color.a + 1f / 30f);
				} else if (moneyCoinTime [i] < 30) {
					SpriteRenderer rend = moneyCoinList [i].GetComponent<SpriteRenderer> ();
					rend.color = new Color (1, 1, 1, rend.color.a - 1f / 30f);
				} else if (moneyCoinTime [i] == 0) {
					GameObject.Destroy (moneyCoinList [i]);
					moneyCoinList.RemoveAt (i);
					moneyCoinTime.RemoveAt (i);
					i--;
				}
			}
			//if time runs out
			
			if (Input.GetMouseButtonDown (0)) {
				Collider2D coinHit = Physics2D.OverlapPoint (Camera.main.ScreenToWorldPoint (Input.mousePosition));
				if (coinHit && coinHit.tag == "coin") {
					numCoins++;
					coinText.text = numCoins.ToString ();
					int mid = moneyCoinList.IndexOf (coinHit.gameObject);
					moneyCoinTime.RemoveAt (mid);
					moneyCoinList.RemoveAt (mid);
					Instantiate (moneyParticle, coinHit.transform.position, Quaternion.identity);
					GameObject.Destroy (coinHit.gameObject);
				}
			}
		}






		if (canPlaceDesal && !locationSelected) {
			Collider2D hit = Physics2D.OverlapPoint (Camera.main.ScreenToWorldPoint (Input.mousePosition));
			if (hit && hit.tag == "desal coin") {
				int id = placeIcons.IndexOf (hit.gameObject);
				if (isClick) {
					int gx = 0;
					int gy = 0;
					if (id == 0) { // beach
						gx = 2;
						gy = Mathf.RoundToInt (rows / 2);
					} else if (id == 1) { // right lagoon
						gx = 9;
						gy = Mathf.RoundToInt (rows * 0.15f) + 5;
					} else if (id == 2) { // left lagoon
						gx = 5;
						gy = Mathf.RoundToInt (rows * 0.85f) + 3;
					}

					gxGlobal = gx;
					gyGlobal = gy;
					// zoom to plant
					zoomNorm();

					float zx = Screen.width / 2 + (gx - gy) * halfWidth + halfWidth;
					float zy = (gx + gy) * halfHeight + halfHeight;
					Camera.main.transform.position = new Vector3 (zx, zy, -10.0f);

					for (int i = 0; i < placeIcons.Count; i++)
						GameObject.Destroy (placeIcons[i]);
					placeIcons.Clear();

					float x = (gx - gy) * halfWidth + Screen.width / 2;
					float y = (gx + gy) * halfHeight;

					placeDesal.transform.position = new Vector3 (x + halfWidth * 2, y + halfHeight, 0);
					SpriteRenderer rend = placeDesal.GetComponent<SpriteRenderer> ();

					scores.SetActive (false);
					rend.enabled = true;
					rend.sortingOrder = (columns - gx) + (rows - gy) * columns;
					locationSelected = true;
					canPlaceDesal = false;
					Instantiate (desalParticle, placeDesal.transform.position, Quaternion.identity);

					// pollution around plant
					for (int pc = gx - 5; pc < gx + 5; pc++) {
						for (int pr = gy - 5; pr < gy + 5; pr++) {
							if (pc < 0 || pr < 0 || pc >= columns || pr >= rows)
								continue;
							if (pc == gx - 5 && pr == gy - 5)
								continue;
							if (pc == gx + 4 && pr == gy + 4)
								continue;
							if (pc == gx - 5 && pr == gy + 4)
								continue;
							if (pc == gx + 4 && pr == gy - 5)
								continue;
								
							int g = pc + pr * columns;
							if (board [g] == grassID || board [g] == placingID || board [g] == placing2ID) {
								SpriteRenderer prend = boardfabs [g].GetComponent<SpriteRenderer> ();
								prend.sprite = pollution;
							}
						}
							
					}
					if (!moneySpawned) {
						spawnMoney ();
						moneySpawned = true;
					}
					desalButton.SetActive (false);
				}
				//hovering over buttons
				//Collider2D hit = Physics2D.OverlapPoint (Camera.main.ScreenToWorldPoint (Input.mousePosition));

				if (hit && hit.tag == "desal coin" && !locationSelected){


					if (id == 0) {
						happinessScoreText.text = "Happiness " + 
							gameManager.GetComponent<ResearchScript>().currentResearchScore[0];
						environmentScoreText.text = "Environment " +  
							gameManager.GetComponent<ResearchScript>().currentResearchScore[3];
						capacityScoreText.text = "Water Capacity " + 
							gameManager.GetComponent<ResearchScript>().currentResearchScore[6];


						happinessBar.GetComponent<Progress_Bar> ().value = 
							gameManager.GetComponent<ResearchScript>().currentResearchScoreInt[0];
						if(gameManager.GetComponent<ResearchScript>().currentResearchScoreInt[0] == 0){
							happinessScoreIcon.GetComponent<UnityEngine.UI.Image> ().sprite = happinessImageBW;
							happinessBar.GetComponent<UnityEngine.UI.Image>().sprite = grayBarImage;
							bestStatText.text = defaultStatText;
							
						}
						else{
							happinessScoreIcon.GetComponent<UnityEngine.UI.Image> ().sprite = happinessImage;
							happinessBar.GetComponent<UnityEngine.UI.Image>().sprite = happinessBarImage;
							bestStatText.text = bestHappinessText;
						}
						scoreKeeper.GetComponent<ScoreScript> ().happinessScore = 4;
						environmentBar.GetComponent<Progress_Bar> ().value = 
							gameManager.GetComponent<ResearchScript>().currentResearchScoreInt[3];
						if(gameManager.GetComponent<ResearchScript>().currentResearchScoreInt[3] == 0){
							environmentScoreIcon.GetComponent<UnityEngine.UI.Image> ().sprite = environmentImageBW;
							environmentBar.GetComponent<UnityEngine.UI.Image>().sprite = grayBarImage;

						}
						else{
							environmentScoreIcon.GetComponent<UnityEngine.UI.Image> ().sprite = evironmentImage;
							environmentBar.GetComponent<UnityEngine.UI.Image>().sprite = environmentBarImage;
						}
						scoreKeeper.GetComponent<ScoreScript> ().environmentScore = 4;
						capacityBar.GetComponent<Progress_Bar> ().value = 
							gameManager.GetComponent<ResearchScript>().currentResearchScoreInt[6];
						if(gameManager.GetComponent<ResearchScript>().currentResearchScoreInt[6] == 0){
							capacityScoreIcon.GetComponent<UnityEngine.UI.Image> ().sprite = capacityImageBW;
							capacityBar.GetComponent<UnityEngine.UI.Image>().sprite = grayBarImage;
						}
						else{
							capacityScoreIcon.GetComponent<UnityEngine.UI.Image> ().sprite = capacityImage;
							capacityBar.GetComponent<UnityEngine.UI.Image>().sprite = capacityBarImage;
							
						}
						scoreKeeper.GetComponent<ScoreScript> ().capacityScore = 6;
					} else if (id == 1) {
						happinessScoreText.text = "Happiness " + 
								gameManager.GetComponent<ResearchScript>().currentResearchScore[1];
						environmentScoreText.text = "Environment " +  
							gameManager.GetComponent<ResearchScript>().currentResearchScore[4];
						capacityScoreText.text = "Water Capacity " + 
							gameManager.GetComponent<ResearchScript>().currentResearchScore[7];

						happinessBar.GetComponent<Progress_Bar> ().value = 
							gameManager.GetComponent<ResearchScript>().currentResearchScoreInt[1];
						if(gameManager.GetComponent<ResearchScript>().currentResearchScoreInt[1] == 0){
							happinessScoreIcon.GetComponent<UnityEngine.UI.Image> ().sprite = happinessImageBW;
							happinessBar.GetComponent<UnityEngine.UI.Image>().sprite = grayBarImage;
						}
						else{
							happinessScoreIcon.GetComponent<UnityEngine.UI.Image> ().sprite = happinessImage;
							happinessBar.GetComponent<UnityEngine.UI.Image>().sprite = happinessBarImage;
						}
						scoreKeeper.GetComponent<ScoreScript> ().happinessScore = 6;
						environmentBar.GetComponent<Progress_Bar> ().value = 
							gameManager.GetComponent<ResearchScript>().currentResearchScoreInt[4];
						if(gameManager.GetComponent<ResearchScript>().currentResearchScoreInt[4] == 0){
							environmentScoreIcon.GetComponent<UnityEngine.UI.Image> ().sprite = environmentImageBW;
							environmentBar.GetComponent<UnityEngine.UI.Image>().sprite = grayBarImage;
							bestStatText.text = defaultStatText;
						}
						else{
							environmentScoreIcon.GetComponent<UnityEngine.UI.Image> ().sprite = evironmentImage;
							environmentBar.GetComponent<UnityEngine.UI.Image>().sprite = environmentBarImage;
							bestStatText.text = bestEnvironmentText;
						}
						scoreKeeper.GetComponent<ScoreScript> ().environmentScore = 2;
						capacityBar.GetComponent<Progress_Bar> ().value = 
							gameManager.GetComponent<ResearchScript>().currentResearchScoreInt[7];
						if(gameManager.GetComponent<ResearchScript>().currentResearchScoreInt[7] == 0){
							capacityScoreIcon.GetComponent<UnityEngine.UI.Image> ().sprite = capacityImageBW;
							capacityBar.GetComponent<UnityEngine.UI.Image>().sprite = grayBarImage;
						}
						else{
							capacityScoreIcon.GetComponent<UnityEngine.UI.Image> ().sprite = capacityImage;
							capacityBar.GetComponent<UnityEngine.UI.Image>().sprite = capacityBarImage;
						}
						scoreKeeper.GetComponent<ScoreScript> ().capacityScore = 4;
					} else if (id == 2) {
						happinessScoreText.text = "Happiness " + 
							gameManager.GetComponent<ResearchScript>().currentResearchScore[2];
						environmentScoreText.text = "Environment " +  
							gameManager.GetComponent<ResearchScript>().currentResearchScore[5];
						capacityScoreText.text = "Water Capacity " + 
							gameManager.GetComponent<ResearchScript>().currentResearchScore[8];
						happinessBar.GetComponent<Progress_Bar> ().value = 
							gameManager.GetComponent<ResearchScript>().currentResearchScoreInt[2];
						if(gameManager.GetComponent<ResearchScript>().currentResearchScoreInt[2] == 0){
							happinessScoreIcon.GetComponent<UnityEngine.UI.Image> ().sprite = happinessImageBW;
							happinessBar.GetComponent<UnityEngine.UI.Image>().sprite = grayBarImage;
						}
						else{
							happinessScoreIcon.GetComponent<UnityEngine.UI.Image> ().sprite = happinessImage;
							happinessBar.GetComponent<UnityEngine.UI.Image>().sprite = happinessBarImage;
						}
						scoreKeeper.GetComponent<ScoreScript> ().happinessScore = 2;
						environmentBar.GetComponent<Progress_Bar> ().value = 
							gameManager.GetComponent<ResearchScript>().currentResearchScoreInt[5];
						if(gameManager.GetComponent<ResearchScript>().currentResearchScoreInt[5] == 0){
							environmentScoreIcon.GetComponent<UnityEngine.UI.Image> ().sprite = environmentImageBW;
							environmentBar.GetComponent<UnityEngine.UI.Image>().sprite = grayBarImage;
						}
						else{
							environmentScoreIcon.GetComponent<UnityEngine.UI.Image> ().sprite = evironmentImage;
							environmentBar.GetComponent<UnityEngine.UI.Image>().sprite = environmentBarImage;
						}
						scoreKeeper.GetComponent<ScoreScript> ().environmentScore = 6;
						capacityBar.GetComponent<Progress_Bar> ().value = 
							gameManager.GetComponent<ResearchScript>().currentResearchScoreInt[8];
						if(gameManager.GetComponent<ResearchScript>().currentResearchScoreInt[8] == 0){
							capacityScoreIcon.GetComponent<UnityEngine.UI.Image> ().sprite = capacityImageBW;
							capacityBar.GetComponent<UnityEngine.UI.Image>().sprite = grayBarImage;
							bestStatText.text = defaultStatText;
						}
						else{
							capacityScoreIcon.GetComponent<UnityEngine.UI.Image> ().sprite = capacityImage;
							capacityBar.GetComponent<UnityEngine.UI.Image>().sprite = capacityBarImage;
							bestStatText.text = bestCapacityText;
						}
						scoreKeeper.GetComponent<ScoreScript> ().capacityScore = 2;
					}
					//setting bars to correct color

					scores.SetActive (true);
				}
			}
			else {
				scores.SetActive (false);
			}

		}
		if (scientistText.text == moveText) {
			completeTutorial ();
		}
		//
		
		float dx = 0.0f;
		float dy = 0.0f;
		
		isClick = false;
		if (!Input.GetMouseButton (0)) {
			if (dragOrigin != new Vector3 (-9999, -9999, -9999)) {
				dragOrigin = new Vector3 (-9999, -9999, -9999);
				
				if (!isMove)
					isClick = true;
				isMove = false;
			}
			
			if (tutorialcomplete) {
				int Boundary = 4; // Mathf.CeilToInt(Screen.height * 0.05f);
				float speed = Mathf.CeilToInt (Screen.width * 0.5f);
				
				dx = 0.0f;
				dy = 0.0f;
				
				
				if (Input.mousePosition.x > Screen.width - Boundary)
					dx = speed * Time.deltaTime;
				else if (Input.mousePosition.x < 0 + Boundary)
					dx = -speed * Time.deltaTime;
				
				if (Input.mousePosition.y > Screen.height - Boundary)
					dy = speed * Time.deltaTime;
				else if (Input.mousePosition.y < 0 + Boundary)
					dy = -speed * Time.deltaTime;
				
				Camera.main.transform.position = new Vector3 (Camera.main.transform.position.x + dx, Camera.main.transform.position.y + dy, Camera.main.transform.position.z);
				
				//checking if player moved in tutorial
				if (dx != 0 || dy!=0)
					moveCheck = true;

				
				//tutorial over
				if (moveCheck  && !textCheck && scientistText.text!= placeDesalText) {
					scientistText.text = findResearchText;
					textCheck = true;
				}
				
			}
		} else {
			if (dragOrigin == new Vector3 (-9999, -9999, -9999))
				dragOrigin = Input.mousePosition;
			
			Vector3 mpos = Input.mousePosition - dragOrigin;
			
			if (mpos.x != 0 || mpos.y != 0) {
				isMove = true;
			}
			
            if (tutorialcomplete && isMove) // dragging with mouse
            {
                Vector3 sw = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                sw -= Camera.main.ScreenToWorldPoint(dragOrigin);

                float px = Camera.main.transform.position.x - sw.x;
                float py = Camera.main.transform.position.y - sw.y;

                Camera.main.transform.position = new Vector3 (px, py, Camera.main.transform.position.z);
            }

            dragOrigin = Input.mousePosition;
        }
		
		screenBounds ();
	}
	
	void CustomMap1 ()
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
		for (int r = 0; r < rows; r++) {
			board [0 + r * columns] = oceanID;
			boardL [0 + r * columns] = oceanID;
			boardR [0 + r * columns] = oceanID;
			
			board [1 + r * columns] = oceanID;
			boardL [1 + r * columns] = oceanID;
			boardR [1 + r * columns] = oceanID;
			
			board [2 + r * columns] = beachID;
			boardL [2 + r * columns] = beachID;
			boardR [2 + r * columns] = beachID;
			
			// board[5 + r * columns] = roadID;
			// boardL[5 + r * columns] = roadID;
			// boardR[5 + r * columns] = roadID;

			board [Mathf.RoundToInt (columns / 4) + r * columns] = roadID;
			boardL [Mathf.RoundToInt (columns / 4) + r * columns] = roadID;
			boardR [Mathf.RoundToInt (columns / 4) + r * columns] = roadID;

			boardL [(columns / 4) + r * columns] = roadID;
			boardR [(columns / 2) + r * columns] = roadID;
		}

		{ // placement button
			int c = 2;
			int r = Mathf.RoundToInt (rows / 2);
			float x = (c - r) * halfWidth + Screen.width / 2;
			float y = (c + r) * halfHeight;
			GameObject placer = Instantiate (desalPlacerIcon, new Vector3 (x + halfWidth, y + halfHeight, 0), Quaternion.identity) as GameObject;
			SpriteRenderer rend = placer.GetComponent<SpriteRenderer> ();
			float scale = (float)(width * 0.4) / (float)rend.bounds.size.x;
			placer.transform.localScale = new Vector3 (scale, scale, 1.0f);
			placeIcons.Add (placer); // index 0
		}
		
		for (int c = 0; c < columns; c++)
			boardT [c + (rows / 3) * columns] = road2ID;
		
		int c0;
		int c1;
		int r0;
		int r1;
		
		// lagoon right
		c0 = 4; // Mathf.RoundToInt (columns * 0.30f);
		c1 = c0 + 6;
		r0 = Mathf.RoundToInt (rows * 0.15f);
		r1 = r0 + 8;
		for (int c = c0; c < c1; c++)
			for (int r = r0; r < r1; r++)
				board [c + r * columns] = -1;
		board [(c0 + 5) + (r0 + 3) * columns] = lagoon1ID;
		board [(c0 + 3) + (r0 + 4) * columns] = lagoon2ID;
		/*for (int c = c0 - 1; c < c1; c++) {
			for (int r = r0; r < r1; r++) {
				if (c == c0 - 1 || r == r0 || c == c1 - 1 || r == r1 - 1)
					board [c + r * columns] = placingID;
			}
		}*/
		{ // placement button
			int c = c0 + 4;
			int r = r0 + 3;
			float x = (c - r) * halfWidth + Screen.width / 2;
			float y = (c + r) * halfHeight;
			GameObject placer = Instantiate (desalPlacerIcon, new Vector3 (x + halfWidth, y + halfHeight, 0), Quaternion.identity) as GameObject;
			SpriteRenderer rend = placer.GetComponent<SpriteRenderer> ();
			float scale = (float)(width * 0.4) / (float)rend.bounds.size.x;
			placer.transform.localScale = new Vector3 (scale, scale, 1.0f);
			placeIcons.Add (placer); // index 1
		}
		
		// lagoon left
		c0 = 3; // Mathf.RoundToInt (columns * 0.40f);
		c1 = c0 + 6;
		r0 = Mathf.RoundToInt (rows * 0.85f); 
		r1 = r0 + 6;
		for (int c = c0; c < c1; c++)
			for (int r = r0; r < r1; r++)
				board [c + r * columns] = -1;
		board [(c0 + 3) + (r0 + 2) * columns] = lagoon4ID;
		board [(c0 + 3) + (r0 + 4) * columns] = lagoon3ID;
		// add some houses around the lagoon
		board [c1 - 1 + (r0 + 2) * columns] = Random.Range (house1ID, house3ID + 1);
		board [c1 - 1 + (r0 + 4) * columns] = Random.Range (house1ID, house3ID + 1);
		board [c0 + 3 + (r1 - 1) * columns] = Random.Range (house1ID, house3ID + 1);
		/*for (int c = c0 - 1; c < c1; c++) {
			for (int r = r0; r < r1; r++) {
				if (c == c0 - 1 || r == r0 || c == c1 - 1 || r == r1 - 1)
					board [c + r * columns] = placing2ID;
			}
		}*/
		{ // placement button
			int c = c0 + 3;
			int r = r0 + 3;
			float x = (c - r) * halfWidth + Screen.width / 2;
			float y = (c + r) * halfHeight;
			GameObject placer = Instantiate (desalPlacerIcon, new Vector3 (x + halfWidth, y + halfHeight, 0), Quaternion.identity) as GameObject;
			SpriteRenderer rend = placer.GetComponent<SpriteRenderer> ();
			float scale = (float)(width * 0.4) / (float)rend.bounds.size.x;
			placer.transform.localScale = new Vector3 (scale, scale, 1.0f);
			placeIcons.Add (placer); // index 2
		}

        { // wood signs
            int c, r;
            c = 3; r = Mathf.RoundToInt (rows / 2)     + 3; board[c + r * columns] = signBeachID;
            c = 9; r = Mathf.RoundToInt (rows * 0.15f) + 6; board[c + r * columns] = signRiverID;
            c = 4; r = Mathf.RoundToInt (rows * 0.85f) + 1; board[c + r * columns] = signLagoonID;
        }
		
		// roads horizontal
		for (int c = 5; c < columns; c++)
			board [c + (rows / 3) * columns] = road2ID;
		
		for (int c = 5; c < Mathf.RoundToInt(columns / 1.25f); c++)
			board [c + Mathf.RoundToInt (rows / 1.75f) * columns] = road2ID;

		for (int c = 5; c < Mathf.RoundToInt(columns / 4); c++)
			board [c + Mathf.RoundToInt (rows * 0.80f) * columns] = road2ID;
		
		// roads vertical
		for (int r = Mathf.RoundToInt(rows / 1.75f) - 1; r > (rows / 3); r--)
			board [Mathf.RoundToInt (columns / 1.25f - 1) + r * columns] = roadID;
		
		for (int r = Mathf.RoundToInt(rows / 1.75f) - 1; r >= 0; r--)
			board [Mathf.RoundToInt (columns / 2) + r * columns] = roadID;

		for (int r = Mathf.RoundToInt(rows / 3); r < Mathf.RoundToInt(rows * 0.80f); r++)
			board [5 + r * columns] = roadID;
		
		// road corner
		board [Mathf.RoundToInt (columns / 1.25f - 1) + Mathf.RoundToInt (rows / 1.75f) * columns] = roadCornerID;
		board [5 + Mathf.RoundToInt (rows / 1.25f) * columns] = cornerRTID;
		board [5 + Mathf.RoundToInt (rows / 3) * columns] = cornerULID;

		// road 3 intersection
		board [Mathf.RoundToInt (columns / 1.25f - 1) + (rows / 3) * columns] = roadInterLUDID;
		board [Mathf.RoundToInt (columns / 4) + (rows / 3) * columns] = roadInterLUDID;
		board [5 + Mathf.RoundToInt (rows / 1.75f) * columns] = roadInterLRUID;
		board [Mathf.RoundToInt (columns / 2) + Mathf.RoundToInt (rows / 1.75f) * columns] = roadInterRUDID;
		board [Mathf.RoundToInt (columns / 4) + Mathf.RoundToInt (rows / 1.25f) * columns] = roadInterLRDID;

		// cross roads
		board [Mathf.RoundToInt (columns / 2) + Mathf.RoundToInt (rows / 3) * columns] = crossRoadID;
		board [Mathf.RoundToInt (columns / 4) + Mathf.RoundToInt (rows / 1.75f) * columns] = crossRoadID;
		board [Mathf.RoundToInt (columns / 4) + Mathf.RoundToInt (rows / 3) * columns] = crossRoadID;

		// houses
		for (int r = Mathf.RoundToInt(rows / 1.75f) + 1; r < rows; r++)
			board [Mathf.RoundToInt (columns / 4 + 1) + r * columns] = Random.Range (house1ID, house3ID + 1);
		
		for (int r = Mathf.RoundToInt(rows / 3) + 1; r < Mathf.RoundToInt(rows / 1.75f); r++)
			board [Mathf.RoundToInt (columns / 2 + 1) + r * columns] = Random.Range (house1ID, house3ID + 1);
		
		for (int r = Mathf.RoundToInt(rows / 3 + 1); r < Mathf.RoundToInt(rows / 1.75f + 1); r++)
			board [Mathf.RoundToInt (columns / 1.25f) + r * columns] = Random.Range (house1ID, house3ID + 1);
		
		for (int c = Mathf.RoundToInt(columns / 2) + 1; c < Mathf.RoundToInt(columns / 1.25f + 1); c++)
			board [c + (Mathf.RoundToInt (rows / 1.75f) + 1) * columns] = Random.Range (house1ID, house3ID + 1);
		
		for (int c = Mathf.RoundToInt(columns / 2) + 2; c < Mathf.RoundToInt(columns / 1.25f - 1); c++)
			board [c + (Mathf.RoundToInt (rows / 3) + 1) * columns] = Random.Range (house1ID, house3ID + 1);

		for (int c = 5; c < Mathf.RoundToInt(columns / 4); c++)
			board [c + (Mathf.RoundToInt (rows * 0.80f) + 1) * columns] = Random.Range (house1ID, house3ID + 1);

		// left farm
		c0 = Mathf.RoundToInt (columns * 0.50f);
		c1 = c0 + 8;
		r0 = Mathf.RoundToInt (rows * 0.80f);
		r1 = r0 + 8;
		for (int c = c0; c < c1; c++)
			for (int r = r0; r < r1; r++)
				board [c + r * columns] = cropsID;
		board [(c1 - 2) + (r1 - 2) * columns] = farmID;

		// right farm
		c0 = Mathf.RoundToInt (columns * 0.65f);
		c1 = c0 + 10;
		r0 = Mathf.RoundToInt (rows * 0.10f);
		r1 = r0 + 8;
		for (int c = c0; c < c1; c++)
			for (int r = r0; r < r1; r++)
				board [c + r * columns] = cropsID;
		board [(c0 + 1) + (r0 + 1) * columns] = farmID;
		
		// 9 research plants
		researchC [0] = Mathf.FloorToInt ((columns / 4.00f + columns / 2.00f) / 2.00f);
		researchR [0] = Mathf.FloorToInt ((rows / 3.00f + rows / 1.75f) / 2.00f);
		
		researchC [1] = Mathf.FloorToInt ((columns / 1.25f + columns / 2.00f) / 2.00f);
		researchR [1] = Mathf.FloorToInt ((rows / 3.00f + rows / 1.75f) / 2.00f) + (3 - Random.Range (0, 7));

		researchC [2] = Mathf.FloorToInt ((columns / 4.00f + 6) / 2.00f);
		researchR [2] = Mathf.FloorToInt ((rows / 3.00f + rows / 1.75f) / 2.00f) + (3 - Random.Range (0, 7));

		researchC [3] = Mathf.FloorToInt ((columns / 1.25f + columns) / 2.00f);
		researchR [3] = Mathf.FloorToInt ((rows / 3.00f + rows / 1.75f) / 2.00f) + (3 - Random.Range (0, 7));

		researchC [4] = Mathf.FloorToInt (columns * 0.20f) - 1;
		researchR [4] = Mathf.FloorToInt (rows - 1); // next to left lagoon

		researchC [5] = Mathf.FloorToInt ((columns / 4.00f + columns / 2.00f) / 2.00f);
		researchR [5] = Mathf.FloorToInt ((rows / 6.00f + 0) / 2.00f) + (3 - Random.Range (0, 7));

		researchC [6] = Mathf.FloorToInt (columns * 0.40f);
		researchR [6] = Mathf.FloorToInt ((rows / 1.75f + rows) / 2.00f) + (3 - Random.Range (0, 7));

		researchC [7] = Mathf.FloorToInt ((columns / 1.25f + columns) / 2.00f);
		researchR [7] = Mathf.FloorToInt (rows / 8.0f) + (3 - Random.Range (0, 7));
		
		researchC [8] = columns - 10;
		researchR [8] = rows - 5;

		/*for (int i = 1; i < 8; i++) {
			researchC [i] += 1 - Random.Range (0, 3);
			researchR [i] += 1 - Random.Range (0, 3);
		}*/
		
		for (int i = 0; i < 9; i++) {
			switch (i) {
			case 0:
			case 3:
			case 6:
				board [researchC [i] + researchR [i] * columns] = researchRID;
				break;
			case 1:
			case 4:
			case 7:
				board [researchC [i] + researchR [i] * columns] = researchGID;
				break;
			case 2:
			case 5:
			case 8:
				board [researchC [i] + researchR [i] * columns] = researchBID;
				break;
			}
		}
		
		// trees
		for (int i = 0; i < 150; i++) { // board
			int c = Random.Range (6, columns);
			int r = Random.Range (0, rows);
			
			if (board [c + r * columns] == grassID && board [c - 1 + r * columns] == grassID)
				board [c + r * columns] = tree1ID;
			else
				i--;
		}
		for (int i = 0; i < 225; i++) { // left
			int c = Random.Range (6, columns);
			int r = Random.Range (0, rows);
			
			if (boardL [c + r * columns] == grassID)
				boardL [c + r * columns] = tree1ID;
			else
				i--;
		}
		for (int i = 0; i < 225; i++) { // right
			int c = Random.Range (6, columns);
			int r = Random.Range (0, rows);
			
			if (boardR [c + r * columns] == grassID)
				boardR [c + r * columns] = tree1ID;
			else
				i--;
		}
		for (int i = 0; i < 225; i++) { // top
			int c = Random.Range (6, columns);
			int r = Random.Range (0, rows);
			
			if (boardT [c + r * columns] == grassID)
				boardT [c + r * columns] = tree1ID;
			else
				i--;
		}
	}
	
	public void capacityUpgrade ()
	{
		placeDesal.GetComponent<SpriteRenderer> ().sprite = desalCapacity;
		scientistText.text = upgradeBoughtText;
		upgradeButtons.SetActive (false);
		scoreKeeper.GetComponent<ScoreScript> ().capacityScore += 4;
		zoomNorm();
		float zx = Screen.width / 2 + (gxGlobal - gyGlobal) * halfWidth + halfWidth;
		float zy = (gxGlobal + gyGlobal) * halfHeight + halfHeight;
		Camera.main.transform.position = new Vector3 (zx, zy, -10.0f);

	}
	
	public void environmentUpgrade ()
	{
		placeDesal.GetComponent<SpriteRenderer> ().sprite = desalEnvironment;
		scientistText.text = upgradeBoughtText;
		upgradeButtons.SetActive (false);
		scoreKeeper.GetComponent<ScoreScript> ().environmentScore += 4;
		float zx = Screen.width / 2 + (gxGlobal - gyGlobal) * halfWidth + halfWidth;
		float zy = (gxGlobal + gyGlobal) * halfHeight + halfHeight;
		Camera.main.transform.position = new Vector3 (zx, zy, -10.0f);
	}
	
	public void happinessUpgrade ()
	{
		placeDesal.GetComponent<SpriteRenderer> ().sprite = desalHappiness;
		scientistText.text = upgradeBoughtText;
		upgradeButtons.SetActive (false);
		scoreKeeper.GetComponent<ScoreScript> ().happinessScore += 4;
		float zx = Screen.width / 2 + (gxGlobal - gyGlobal) * halfWidth + halfWidth;
		float zy = (gxGlobal + gyGlobal) * halfHeight + halfHeight;
		Camera.main.transform.position = new Vector3 (zx, zy, -10.0f);
	}

	public void buyUpgrade ()
	{
		upgradeBought = true;

	}


}
