#pragma strict

var researchFolder : GameObject;
var scaleVal : float;
var boundary : float;
var happinessText : UnityEngine.UI.Text;
var environmentText : UnityEngine.UI.Text;
var capacityText : UnityEngine.UI.Text;
var happinessScore : UnityEngine.UI.Text;
var environmentScore : UnityEngine.UI.Text;
var capacityScore : UnityEngine.UI.Text;
var researchCheck : boolean[];
var researchText : String[]; //All research facts to be used
var researchScore : String[];
var scientistText : UnityEngine.UI.Text;
var tab1 : UnityEngine.UI.Image;
var tab2 : UnityEngine.UI.Image;
var tab3 : UnityEngine.UI.Image;
var desalButton : GameObject;
var desalButtonBW : GameObject;
var researchPanel0 : GameObject;
var researchPanel1 : GameObject;
var researchPanel2 : GameObject;
var researchButton : GameObject;

private var desalSet = false;
private var opening : boolean;
var closing : boolean;
var researchOpen : boolean = false;
public var currentResearchText : String[]; // the current text for each location 
private var currentResearchScore : String[]; // the current score for each location 
private var defaultText = "Collect more research to unlock this fact!";
private var placeDesalText = "You can now place the desal plant, or continue to find more research!";
private var defaultScore = "+ ?";
private var happinessOffset = 0;
private var environmentOffset = 3;
private var capacityOffset = 6;
private var numResearch = 0; //how much research you have collected
private var tutorialText2Check = false;
private var tutorialText3Check = false;
var numResearchCollected = 0;





function Start () {
	
		 currentResearchText = [ defaultText,
		                            defaultText,
		                            defaultText,
		                            defaultText,
		                            defaultText,
		                            defaultText,
		                            defaultText,
		                            defaultText,
		                            defaultText];
		                            
		currentResearchScore = [ defaultScore,
		                         defaultScore,
		                         defaultScore,
		                         defaultScore,
		                         defaultScore,
		                         defaultScore,
		                         defaultScore,
		                         defaultScore,
		                         defaultScore];
		                            
		
	
}

function Update () {

	if(closing){
		researchFolder.GetComponent(RectTransform).localScale *= (1 - scaleVal);
		
		if(researchFolder.GetComponent(RectTransform).localScale.x < boundary){
			closing = false;
			researchFolder.GetComponent(RectTransform).localScale = Vector3.zero;
		}	
	}
	
	if(opening){
		
		researchFolder.GetComponent(RectTransform).localScale *= (1 + scaleVal);
		if(researchFolder.GetComponent(RectTransform).localScale.x * (1 + scaleVal) > 1){
			opening = false;
			researchFolder.GetComponent(RectTransform).localScale = Vector3.one;
		}
			
	}
	
	if(numResearchCollected >= 3 && !desalSet){
		desalButton.SetActive(true);
		desalButtonBW.SetActive(false);
		desalSet = true;
	
	}
	if(numResearchCollected >= 3 && !tutorialText3Check){
		scientistText.text = placeDesalText;
		tutorialText3Check = true;
	}
}

function openResearch(){
	if(!closing && !opening && !researchOpen){
		opening = true;
		researchOpen = true;
		researchFolder.GetComponent(RectTransform).localScale = Vector3(boundary,boundary,boundary);
	}
	
}

function closeResearch(){
	if(!opening){
		closing = true;
		researchOpen = false;
	}
}

function switchText(location : int){
	if(location == 0)
		researchPanel0.GetComponent(RectTransform).SetAsLastSibling();
	if(location == 1)
		researchPanel1.GetComponent(RectTransform).SetAsLastSibling();
	if(location == 2)
		researchPanel2.GetComponent(RectTransform).SetAsLastSibling();
	//setting research text to show
	happinessText.text = currentResearchText[(location + happinessOffset)];
	environmentText.text = currentResearchText[(location + environmentOffset)];
	capacityText.text = currentResearchText[(location + capacityOffset)];
	//setting score to show
	happinessScore.text = currentResearchScore[(location + happinessOffset)];
	environmentScore.text = currentResearchScore[(location + environmentOffset)];
	capacityScore.text = currentResearchScore[(location + capacityOffset)];
	
	
	openResearch();
}

function findResearch(){

	var index : int; //which index to choose for research
	var allResearchFound = true; //determines if all research has been found
	//checking if any research is left
	for (var i = 0; i < researchText.Length ; i++){
		if(!researchCheck[i]){
			allResearchFound = false;
			break;
		}
	}
	if(!allResearchFound){
		//searching for new research
		do{
			index = Random.Range(0,researchText.Length);
		}
		while(researchCheck[index]);
		
		currentResearchText[index] = researchText[index];
		currentResearchScore[index] = "+ " + researchScore[index];
		researchCheck[index] = true;
		numResearchCollected++;
		if(!tutorialText2Check){
			scientistText.text = "Great! Now move your mouse to the edges of the screen to move around.";
			tutorialText2Check = true;
		}
		switchText((index )%3);

	}
}






function OnMouseDown() {
	
}





