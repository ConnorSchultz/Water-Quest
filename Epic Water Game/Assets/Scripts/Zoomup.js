#pragma strict
var moveAmount;
var moveTime = 2;
var move : boolean;
function Start () {
	moveAmount = Screen.width/moveTime * Time.deltaTime;

}

function Update () {
	
	if(move && transform.position.y<Screen.height/2){

		transform.Translate(0,moveAmount,0);
	
	}
	

}
public function setMoveTrue(){
	move = true;
}