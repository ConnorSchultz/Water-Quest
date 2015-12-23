#pragma strict

var hover = false;
function Start () {

}

function Update () {

	if(Input.GetMouseButton(1) && hover){
		Application.Quit();
	}
}

public function toggleHover(status : boolean){
	hover = status;
}