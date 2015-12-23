using UnityEngine;
using System.Collections;

public class resizeMapScript : MonoBehaviour {
	public GameObject mapImage;
	public GameObject HUD;
	// Use this for initialization
	void Start () {
		//make map size of screen
		mapImage.GetComponent<RectTransform>().sizeDelta = 
			new Vector2(HUD.GetComponent<RectTransform>().rect.width,
			            HUD.GetComponent<RectTransform>().rect.height);
		//put map in middle of screen
		mapImage.GetComponent<RectTransform>().anchoredPosition = HUD.GetComponent<RectTransform>().anchoredPosition;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
