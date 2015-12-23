#pragma strict

var timeText : UnityEngine.UI.Text;
var startTime = 300;//time in seconds
var currentTime : float;
var minutes : String;
var seconds : String;

var timerString : String;
function Start () {
	currentTime = startTime;
}

function Update () {
	if(currentTime >=0){
		currentTime-=Time.deltaTime;
		minutes = Mathf.Floor(currentTime/60).ToString("0");
		seconds = Mathf.Floor(currentTime % 60).ToString("00");
		timerString = (minutes + ":" + seconds);
		timeText.text = timerString;
	}
	if(currentTime<=30){
		timeText.color = Color.red;
	}
	
}