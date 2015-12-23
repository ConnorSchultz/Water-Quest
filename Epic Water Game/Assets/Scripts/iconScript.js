#pragma strict


var movementVector :float; //amount and direction to move in Y direction
var moveTime =2;
var currpos;
var timer : double = 0;



function Start () {
	movementVector = gameObject.GetComponent(BoxCollider2D).size.x * 2;


}

function Update () {
	transform.position.y+=movementVector*Time.deltaTime;
	timer+=Time.deltaTime;
	if(timer >= moveTime ){
		movementVector*=-1; //switch direction
		timer = 0;
	}
}

function OnMouseDown(){
		transform.parent.GetComponent(ResearchCenterScript).showResearch();
}
