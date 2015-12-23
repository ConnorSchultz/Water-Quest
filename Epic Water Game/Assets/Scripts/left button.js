#pragma strict

var researchPanel : GameObject;
function Start () {
	GetComponent(RectTransform).anchorMax = researchPanel.GetComponent(RectTransform).anchorMax;
	GetComponent(RectTransform).anchorMin = researchPanel.GetComponent(RectTransform).anchorMin;
	//setting buttons to correct size
	GetComponent(RectTransform).localScale.x /= 3.1;
	GetComponent(RectTransform).localScale.y /= 9.5;
	//GetComponent(RectTransform).anchoredPosition.x -= GetComponent(RectTransform).rect.width/4;
	//adding half of containers height
	GetComponent(RectTransform).anchoredPosition.y += GetComponent(RectTransform).rect.height/2;
	//subtracting half of containers width
	GetComponent(RectTransform).anchoredPosition.x -= GetComponent(RectTransform).rect.width/2;
	
	//offsetting according to buttons height
	GetComponent(RectTransform).anchoredPosition.y -= (GetComponent(RectTransform).rect.height/9)/2;
	
	GetComponent(RectTransform).anchoredPosition.x += (GetComponent(RectTransform).rect.width/3)/2;


	
	
	
	
}

function Update () {

}