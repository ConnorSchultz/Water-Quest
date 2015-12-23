using UnityEngine;
using System.Collections;

public class StartGameScript : MonoBehaviour {

	public GameObject mapImage;
	public GameObject HUD;
	GameObject map;
	float changeAmount = 4f; // number of seconds for image to fade out
	Color currentColor;
	// Use this for initialization
	void Start () {
		if(changeAmount != 0)
			changeAmount = 1 / changeAmount;
		changeAmount *= Time.deltaTime; //to keep same speed at any graphics settings


	}
	
	// Update is called once per frame
	void Update () {
	
		if (mapImage) {
			currentColor = mapImage.GetComponent<UnityEngine.UI.Image>().color;
			currentColor.a-=changeAmount;
			mapImage.GetComponent<UnityEngine.UI.Image>().color = currentColor;
			if(currentColor.a<=.05)
				Destroy(mapImage);
		}
	}
}
