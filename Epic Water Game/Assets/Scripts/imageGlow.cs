using UnityEngine;
using System.Collections;

public class imageGlow : MonoBehaviour {

	
	bool glow= false;
	Color glowColor  = Color.white;
	int glowDirection = 1;
	GameObject gameManager;

	void Start () {
		gameManager =  GameObject.Find("Game Manager");
		glowColor.a = 1;
	}
	
	void Update () {
		
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
			GetComponent<SpriteRenderer>().color = glowColor;
		}
		if(!glow && gameManager.GetComponent<ResearchScript>().numResearchCollected>=3){
			glowOn();
			
		}
	}
	
	void glowOff(){
		glow = false;
	}
	
	void glowOn(){
		glow = true;
	}
}
