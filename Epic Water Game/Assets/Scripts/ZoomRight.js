#pragma strict


var moveTime = 2;
var timer = 0;
var moveAmount : float;
var move : boolean;
var zoomLevel = 2; 
var loadingText : UnityEngine.UI.Text;
function Start () {
	var width = 100; // 62, 60
	var height = 50; // 31, 30
	var columns = 50;
	var rows = 50;
	var halfWidth  = width  / 2.0f - 3.0f;
	var halfHeight = height / 2.0f - 1.5f;
	var researchC = Mathf.FloorToInt((columns / 4 + columns / 2) / 2);
	var researchR = Mathf.FloorToInt((rows / 3 + rows / 1.75f) / 2);
		
	var x = Screen.width  / 2 + (researchC - researchR) * halfWidth + halfWidth;
	var y = (researchC + researchR) * halfHeight + halfHeight;
	Camera.main.transform.position = new Vector3 (x, y, -10.0f);
	
	moveAmount = Screen.width/moveTime * Time.deltaTime;
	Camera.main.orthographicSize = Mathf.Floor(Screen.height * (0.25f * zoomLevel));
}

function Update () {
	
	if(move){

		transform.Translate(moveAmount,0,0);
	
	}
	if(transform.position.x > Screen.width + GetComponent(RectTransform).rect.width/2){
		loadingText.gameObject.SetActive(true);
		Application.LoadLevel("Game Scene");
	}
}
public function setMoveTrue(){
	move = true;
}