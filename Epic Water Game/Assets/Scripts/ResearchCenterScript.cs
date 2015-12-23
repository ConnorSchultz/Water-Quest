using UnityEngine;
using System.Collections;

public class ResearchCenterScript : MonoBehaviour {

	
	bool researchFound = false;
	public GameObject gameManager;
	public GameObject icon;
	public GameObject cloneIcon;
	public AudioClip collectSound;
	Vector3 iconPos;
	int researchType;
	public GameObject thisParticle;

	void Start () {
		
		gameManager = GameObject.Find("Game Manager");
		iconPos = new Vector3(transform.position.x,
		                  transform.position.y + icon.GetComponent<BoxCollider2D>().size.y*6,0);
		cloneIcon = (GameObject)Instantiate(icon,iconPos,Quaternion.identity);
		
		cloneIcon.transform.SetParent(transform);
	}
	
	void Update () {
		
	}
	
	void OnMouseDown(){
		showResearch();
	}

	public void showResearch(){
		//if clicked for 1st time then print research fact
		if(!researchFound && !gameManager.GetComponent<ResearchScript>().researchOpen
		   && !gameManager.GetComponent<ResearchScript>().closing){
			gameManager.GetComponent<ResearchScript>().findResearch();
			researchFound = true;
//			this.GetComponent.<AudioSource>().PlayOneShot(collectSound);
			
			Instantiate(thisParticle,cloneIcon.transform.position,Quaternion.identity);
			Destroy(cloneIcon);
		}
		
		
		
	}

}
