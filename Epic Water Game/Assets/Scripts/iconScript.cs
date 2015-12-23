using UnityEngine;
using System.Collections;

public class iconScript : MonoBehaviour {

	float movementVector; //amount and direction to move in Y direction
	float moveTime = 2;
	double timer = 0;
	
	
	
	void Start () {
		movementVector = gameObject.GetComponent<BoxCollider2D>().size.x * 2;
		
		
	}
	
	void Update () {
		transform.Translate(0,movementVector*Time.deltaTime,0);
		timer+=Time.deltaTime;
		if(timer >= moveTime ){
			movementVector*=-1; //switch direction
			timer = 0;
		}
	}
	
	void OnMouseDown(){
		transform.parent.GetComponent<ResearchCenterScript>().showResearch();
	}
}
