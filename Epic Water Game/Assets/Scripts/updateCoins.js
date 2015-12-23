#pragma strict


	var scoreText : UnityEngine.UI.Text;
	private var currentScore = 0;
	
	// Use this for initialization
function Start () {
	
}
	
	// Update is called once per frame
function Update () {
		scoreText.text= "" + currentScore;

}

function incrementScore() {
		currentScore++;
}

public function subtractCoins(num : int){
	var number : int;
	number = num;
	if(currentScore>=number)
		currentScore-=number;

}