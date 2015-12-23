using UnityEngine;
using System.Collections;

public class EndScreenMapScroll : MonoBehaviour {
		
	public float count = 0;
	public float moveAmount = .2f;
	// Update is called once per frame
	void Update () {

		Transform rt = GetComponent<Transform> ();

		if (count < 30) {
			rt.transform.Translate (moveAmount, -moveAmount, 0);
		} 
		else {
			Application.LoadLevel ("StartScreen");
			

		}
		count+=Time.deltaTime;
	
	}
}
