#pragma strict

	var glow : boolean = false;
	var glowColor : Color = Color.white;
	var glowDirection = 1;
	var gameManager : GameObject;
function Start () {
gameManager =  GameObject.Find("Game Manager");
	glowColor.a = 1;
}

function Update () {
	
	if(glow){
	
		if(glowColor.r <=.5){
			glowDirection = 1;
		}
		
		else if(glowColor.r >=1){
			glowDirection = -1;
		}
		
		glowColor.r+= glowDirection * Time.deltaTime;
		glowColor.g+= glowDirection * Time.deltaTime;
		glowColor.b+= glowDirection * Time.deltaTime;
		GetComponent(SpriteRenderer).color = glowColor;
	}
	if(!glow && gameManager.GetComponent(researchScript).numResearchCollected>=3){
		glowOn();
	
	}
}

function glowOff(){
	glow = false;
}

function glowOn(){
	glow = true;
}