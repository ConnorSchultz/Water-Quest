#pragma strict


var moveTime = 2;
var timer = 0;
var moveAmount : float;
var move : boolean;
function Start () {
	moveAmount = Screen.width/moveTime * Time.deltaTime;

}

function Update () {
	
	if(move){

		transform.Translate(-moveAmount,0,0);
	
	}

}
public function setMoveTrue(){
	move = true;
}