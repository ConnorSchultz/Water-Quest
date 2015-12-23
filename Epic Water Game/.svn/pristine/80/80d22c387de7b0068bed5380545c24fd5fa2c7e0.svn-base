#pragma strict



	public var gameManager : GameObject;
	var researchScript : researchScriptC;
	var scientistText : UnityEngine.UI.Text;
	var tutorialText2 : String;
	var tutorialText3 : String;
	var text2Check = false; // checks if text2 has been displayed
	var text3Check = false; // checks if text3 has been displayed
	
function Start () {
	researchScript = gameManager.GetComponent("researchScriptC");
	tutorialText2 = "Great! Now move your mouse to the edges of the screen to move around.";
	tutorialText3 = "Now you can place the desal plant, or you can continue finding research!";
}

function Update () {
	if(researchScript.numResearchCollected > 0 && !text2Check){
		scientistText.text = tutorialText2;
		text2Check = true;
	}
	if(researchScript.numResearchCollected >= 3 && !text3Check && text2Check){
		scientistText.text = tutorialText3;
		text3Check = true;
	}
}

