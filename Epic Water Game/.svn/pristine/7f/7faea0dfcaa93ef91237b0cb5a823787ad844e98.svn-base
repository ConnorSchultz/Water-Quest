#pragma strict

//data storage main Texts and other important stuff
var happinessText : UnityEngine.UI.Text;
var capacityText : UnityEngine.UI.Text;
var environmentText : UnityEngine.UI.Text;
var desalButton : GameObject;
var desalButtonBW : GameObject;
var researchCollected :boolean[];
var researchText :String[];
var currentDisplay :int; //which research piece is being displayed
var bulletChar :char;
var coinNumText : Transform;//GetComponent<text>(); 
var numCoins = 0;
var numResearchCollected = 0;
var researchPositions :Vector2[];  //start, first, second, and last.
var moveRatesTime :float[];  //1st,2nd,3rd
var targetPos :Vector2;
var vel :Vector2;

//font stuff
var fontSize :Vector2;
var fontVel :float;

//Scales
var endScale :Vector2;
var scaleVel :Vector2;

//GUI Rects
var currentResearchRect :Rect;
var folderRect :Rect;
var addToResearchButton :Rect;

var guiTypeStyle :GUIStyle; //Styles


var theImage :Texture;
var bubbleSpace :float;

var yieldTime :float;
var defaultTime :float;
private var defaultTimer :float;

//Add to research button variables
var buttonNotYield :boolean;
var buttonOn :boolean;

var addToResearchTexts :String[];


var nextStageTimer :float;
var whenToNext :float;

///All Research Related Vars
var guiBusy :boolean; //Tracks if research is already being displayed
var displayAllReasearch :boolean;

var allResearchEndScales :Vector2;

var generalResearchText :String;
//
var textOriginal :String;
var theText :String;


var currentChars :int;

var timerVals :Vector2;
var timer :float;
var theTimer :float;
var displayEmptyText :boolean;
//



var index = 0;
var count = 0;
var numResearch = 3;
final var ENVIRONMENT = 0;
final var WATER = 1;
final var HAPPINESS = 2;

//new Vars
var researchSwitchDir :int; //(-1 = View research 1 to the left), (1 = view research to the right), (0 = nothing)
var leftRightSwitchPos :Vector2[];
var switchTime :float;

var rateOfScale :float;


function Start () {
	
	
	
}

function Update () {

	if(currentDisplay != -1)
	{
		researchUpdate1();
	}
	if(numResearchCollected >= 3){
		desalButtonBW.SetActive(false);
		desalButton.SetActive(true);

	}
}


//this is method start
function startValsForResearchDisplay()
{
	
	//setting default Timer
	defaultTimer = defaultTime;
	
	//default = no display
	currentDisplay = -1;
	
	//scaling
	currentResearchRect.width = Screen.height-bubbleSpace*2;
	currentResearchRect.height = currentResearchRect.width/5*3;
	
	folderRect.x = Screen.width - folderRect.width - bubbleSpace;
	folderRect.y = bubbleSpace;
	
	addToResearchButton.x = Screen.width/2 - addToResearchButton.width/2;
	//addToResearchButton.y = currentResearchRect.height+currentResearchRect.y - bubbleSpace - addToResearchButton.height;
	addToResearchButton.y = currentResearchRect.height+currentResearchRect.y - currentResearchRect.height/rateOfScale/2;
	addToResearchButton.height = currentResearchRect.height/rateOfScale;
	
	guiTypeStyle.normal.background = theImage;
	
	//Setting target positions
	researchPositions[0].x = Screen.width/2 - currentResearchRect.width/2;
	researchPositions[1].x = Screen.width/2 - currentResearchRect.width/2;
	researchPositions[2].x = folderRect.x;
	researchPositions[3].x = folderRect.x + folderRect.width/2;
	
	researchPositions[0].y = Screen.height + bubbleSpace;
	researchPositions[1].y = bubbleSpace;
	researchPositions[2].y = folderRect.y;
	researchPositions[3].y = folderRect.y + folderRect.height/2;//
	
	//switchVars
	leftRightSwitchPos[1].x = -currentResearchRect.width-bubbleSpace;
	leftRightSwitchPos[0].x = Screen.width+bubbleSpace;
	leftRightSwitchPos[1].y = bubbleSpace;
	leftRightSwitchPos[0].y = bubbleSpace;
	
	guiTypeStyle.padding.top = currentResearchRect.height/rateOfScale/1.5;

	
	
	guiTypeStyle.padding.top = currentResearchRect.height/rateOfScale/1.5;
   

        guiTypeStyle.padding.left = currentResearchRect.height/rateOfScale/1.5;

        guiTypeStyle.padding.right = currentResearchRect.height/rateOfScale/1.5;

}

//this method adds characters sequentially onto the current displayed text for research
function addNextCharToText()
{
	displayEmptyText = false;
	
	if(!displayAllReasearch)
	theText = textOriginal.Substring(0,currentChars);
	
	theTimer += Time.deltaTime;
	if(theTimer >= timer)
	{
		if(currentChars+1 <= textOriginal.length)
		{
			currentChars++;
		}
		theTimer -= timer;
		timer = Random.Range(timerVals.x,timerVals.y);
	}
}

//this funciton moves and scales the displayed research by tracking velocity using smooth follow
function researchUpdate1()
{
	if(researchSwitchDir != 0)
	{
		researchUpdateSwitch();
	}
	else
	{
	if(targetPos == researchPositions[1]) //Moving to Display Research Position
	{

		if(displayAllReasearch)
		{
			currentResearchRect.width = 
			Mathf.SmoothDamp(currentResearchRect.width,allResearchEndScales.x,scaleVel.x,moveRatesTime[0]);
			currentResearchRect.height = 
			Mathf.SmoothDamp(currentResearchRect.height,allResearchEndScales.y,scaleVel.y,moveRatesTime[0]);
		}
		currentResearchRect.position = Vector2.SmoothDamp(currentResearchRect.position,researchPositions[1],vel,moveRatesTime[0]);
		
		if(Mathf.Abs(vel.x) <= whenToNext && Mathf.Abs(vel.y) <= whenToNext
		&& Mathf.Abs(scaleVel.x) <= whenToNext && Mathf.Abs(scaleVel.y) <= whenToNext)
		addNextCharToText();
		
		if(Mathf.Abs(vel.x) <= whenToNext && Mathf.Abs(vel.y) <= whenToNext && theText.Length == 
		(textOriginal.Length))
		{
			yield WaitForSeconds(yieldTime);
			{
				if(buttonNotYield)
				{
					buttonOn = true;
				}
				else
				{
					targetPos = researchPositions[2];
				}
				
				if(Input.GetMouseButtonDown(0) && !displayAllReasearch)
				{
					targetPos = researchPositions[2];
				}
			}
			defaultTimer -= Time.deltaTime;
			if(defaultTimer <= 0 && !displayAllReasearch)
			{
				targetPos = researchPositions[2];
			}
		}
	}
	else if(targetPos == researchPositions[2] || targetPos == researchPositions[3])
	{
		for(var zi:int = 2;zi<researchPositions.Length-1;zi++)
		{
	if(targetPos == researchPositions[zi])
	{
		currentResearchRect.position = Vector2.SmoothDamp(currentResearchRect.position,researchPositions[zi],vel,moveRatesTime[zi-1]);
		
		displayEmptyText = true;
		if(zi == 2)
		{
		currentResearchRect.width = Mathf.SmoothDamp(currentResearchRect.width,folderRect.width,scaleVel.x,moveRatesTime[zi-1]);
		currentResearchRect.height = Mathf.SmoothDamp(currentResearchRect.height,folderRect.height,scaleVel.y,moveRatesTime[zi-1]);
		}
		else
		{
		currentResearchRect.width = Mathf.SmoothDamp(currentResearchRect.width,endScale.x,scaleVel.x,moveRatesTime[zi-1]);
		currentResearchRect.height = Mathf.SmoothDamp(currentResearchRect.height,endScale.y,scaleVel.y,moveRatesTime[zi-1]);
		}
		if(Mathf.Abs(vel.x) <= whenToNext && Mathf.Abs(vel.y) <= whenToNext)
		{
			targetPos = researchPositions[zi+1];
		}
	}
		}//End of for loop
	}
	else if(targetPos == new Vector2(0,0)) //Finished Moving
	{
		currentDisplay = -1;
		guiBusy = false;
	}
	}
}

function researchUpdateSwitch()
{
	if(researchSwitchDir == 1)
	{
		currentResearchRect.position = Vector2.SmoothDamp(currentResearchRect.position,leftRightSwitchPos[1],vel,switchTime);
	}
	if(researchSwitchDir == -1)
	{
		currentResearchRect.position = Vector2.SmoothDamp(currentResearchRect.position,leftRightSwitchPos[0],vel,switchTime);
	}
	if(Mathf.Abs(vel.x) <= whenToNext && Mathf.Abs(vel.y) <= whenToNext)
	{
		if(researchSwitchDir == 1)
		{
			currentResearchRect.position.x = Screen.width+bubbleSpace;
			do{
			currentDisplay++;
			if(currentDisplay >= researchCollected.Length)
			currentDisplay = 0;
			}while(!researchCollected[currentDisplay]);
		}
		if(researchSwitchDir == -1)
		{
			currentResearchRect.position.x = -currentResearchRect.width-bubbleSpace;
			do{
			currentDisplay--;
			if(currentDisplay < 0)
			currentDisplay = researchCollected.Length-1;
			}while(!researchCollected[currentDisplay]);
		}
		theText = "\n\n     "+ bulletChar + researchText[currentDisplay];
		
		researchSwitchDir = 0;
	}
}

//This method preps all necessary variables such as positions, scalings and texts so that research update will flow  properly
//Call this method sending the number variable of Research desired to display
//Also include whether you desire to display all collected research, or just one piece with a boolean as the second sent var
//Once calling this method, a boolean array stores which numbers of researches that have been called
function displayResearch(num :int,tempDisplayAllResearch :boolean)
{
	var shouldBreak :boolean;
	if(tempDisplayAllResearch)
	{
		currentDisplay = 0;
		do
		{
			currentDisplay++;
			if(currentDisplay >= researchCollected.Length)
			{
				shouldBreak = true;
				break;
			}
		}while(!researchCollected[currentDisplay]);
	}
	
	displayAllReasearch = tempDisplayAllResearch;
	
	guiBusy = true;
	
	defaultTimer = defaultTime;
	
	//currentResearchRect.position = researchPositions[0];
	currentDisplay = num;
	targetPos = researchPositions[1];
	buttonOn = false;
	//Text Writing
	theText = "";
	if(displayAllReasearch)
	{
		var oneIsTrue :boolean;
		for(var rr:int = 0;rr<researchCollected.Length;rr++)
		{
			if(researchCollected[rr])
			oneIsTrue = true;
		}
		currentResearchRect.position.x = Screen.width/2;
		currentResearchRect.position.y = Screen.height/2;
		if(oneIsTrue){//if you have atleast 1 research

			theText = "\n";
		}
		else{

			theText = "No Research Found Yet";
		}
		/*for(var zi:int = 0;zi<researchText.Length;zi++)
		{
			if(researchCollected[zi])
			theText += "\n     "+ bulletChar + researchText[zi];
		}*/
		if(oneIsTrue)
			theText = "\n\n     "+ bulletChar + researchText[num];
		displayEmptyText = true;
		textOriginal = theText;
		}
	else
	{
		researchCollected[num] = true;
		
		displayEmptyText = false;
		
		currentResearchRect.position = researchPositions[0];
		
		textOriginal = "\n\n     "+ bulletChar + researchText[currentDisplay];

	}
	currentChars = 0;
	//scaling
	currentResearchRect.width = Screen.height-bubbleSpace*2;
	currentResearchRect.height = currentResearchRect.width*3/5;
	
	//fonts
	//var rateOfScale :float = 9.34375;
	guiTypeStyle.fontSize = currentResearchRect.height/rateOfScale;//fontSize.x;

	
	allResearchEndScales.x = currentResearchRect.width;
	allResearchEndScales.y = currentResearchRect.height;
	if(displayAllReasearch)
	{
		currentResearchRect.width = 0;
		currentResearchRect.height = 0;
	}
	scaleVel.x = 0;
	scaleVel.y = 0;
	
}

function OnGUI()
{
	
	//Research Folder GUI
	/*
	
	if(GUI.Button(folderRect,"Research"))
	{
		if(!guiBusy)
		displayResearch(Random.Range(0,researchCollected.Length),true);
		else if(buttonOn && targetPos == researchPositions[1])
		{
			targetPos = researchPositions[2];
		}
	}
	*/
	//displaying research
	if(currentDisplay != -1)
	{
		if(displayEmptyText)
		GUI.Label(currentResearchRect,"",guiTypeStyle);
		else
		{
			GUI.Label(currentResearchRect,theText,guiTypeStyle);

		}
	}
	//Add To Research Button
	if(buttonOn && targetPos == researchPositions[1] && researchSwitchDir == 0)
	{
		var tempText :String;
		if(displayAllReasearch)
		{
			tempText = addToResearchTexts[0];
			var oneIsTrue :boolean;
	for(var rr:int = 0;rr<researchCollected.Length;rr++)
	{
		if(researchCollected[rr])
		oneIsTrue = true;
	}
	if(oneIsTrue){
			//GUI Left Right Buttons
			if(GUI.Button(Rect(addToResearchButton.x-50,addToResearchButton.y,40,addToResearchButton.height),"<"))
			{
				//print("L");
				researchSwitchDir = -1;
			}
			if(GUI.Button(Rect(addToResearchButton.x+10+addToResearchButton.width,addToResearchButton.y,
			40,addToResearchButton.height),">"))
			{
				//print("R");
				researchSwitchDir = 1;
			}
	}
		}
		else
		tempText = addToResearchTexts[1];
		
		if(GUI.Button(addToResearchButton,tempText))
		{
			targetPos = researchPositions[2];
			buttonOn = false;
		}
		
	}
	
	//side-image here (coming soon?)
	if(displayEmptyText)
	{
		GUI.Label(Rect(0,0,0,0),"");
	}
}


function findResearch(){

	var researchString = "";
	index = Random.Range(0,numResearch);
	for(var i = 0; i<numResearch;i++){ //checks if there are any unused messages(index = 0)
		if(researchCollected[i] == false){
			do {
				index = Random.Range(0,numResearch);

			}
			while(researchCollected[index]);//loop again if that message was already used
			researchCollected[index] = true;
			
			numResearchCollected++;
//			coinNumText.GetComponent(updateCoins).incrementScore;
			displayResearch(index,false);
			return("");
		}
	}

	
	return ("All Research Found!");
}