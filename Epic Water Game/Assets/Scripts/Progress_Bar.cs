﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class Progress_Bar : MonoBehaviour {

	public Sprite not_full_sprite;
	public Sprite full_sprite;
	public GameObject progress_end;
	public GameObject scoreKeeper;
	public int[] scores;


	public int value = 1;

	// Use this for initialization
	void Start () {
		scoreKeeper = GameObject.Find("ScoreKeeper");
		if (this.tag == "happinessValue") {
			value = scoreKeeper.GetComponent<ScoreScript>().happinessScore;

		}

		else if (this.tag == "environmentValue") {
			value = scoreKeeper.GetComponent<ScoreScript>().environmentScore;
		}

		else if (this.tag == "capacityValue") {
			value = scoreKeeper.GetComponent<ScoreScript>().capacityScore;
		}

	}

	void Update() {
	
		RectTransform rt = GetComponent<RectTransform> ();

		if (value < 1) {
			value = 1;
		} else if (value > 10) {
			value = 10;
		}

		if (value < 10) {
			progress_end.GetComponent<Image> ().sprite = not_full_sprite;
		} else {
			progress_end.GetComponent<Image> ().sprite = full_sprite;
		}

		if (value == 1) {
			rt.sizeDelta = new Vector2 (20, 30);
			rt.transform.localPosition = new Vector2 (-90, rt.transform.localPosition.y);
		} else if (value == 2) {
			rt.sizeDelta = new Vector2 (40, 30);
			rt.transform.localPosition = new Vector2 (-80, rt.transform.localPosition.y);
		} else if (value == 3) {
			rt.sizeDelta = new Vector2 (60, 30);
			rt.transform.localPosition = new Vector2 (-70, rt.transform.localPosition.y);
		} else if (value == 4) {
			rt.sizeDelta = new Vector2 (80, 30);
			rt.transform.localPosition = new Vector2 (-60, rt.transform.localPosition.y);
		} else if (value == 5) {
			rt.sizeDelta = new Vector2 (100, 30);
			rt.transform.localPosition = new Vector2 (-50, rt.transform.localPosition.y);
		} else if (value == 6) {
			rt.sizeDelta = new Vector2 (120, 30);
			rt.transform.localPosition = new Vector2 (-40, rt.transform.localPosition.y);
		} else if (value == 7) {
			rt.sizeDelta = new Vector2 (140, 30);
			rt.transform.localPosition = new Vector2 (-30, rt.transform.localPosition.y);
		} else if (value == 8) {
			rt.sizeDelta = new Vector2 (160, 30);
			rt.transform.localPosition = new Vector2 (-20, rt.transform.localPosition.y);
		} else if(value == 9) {
			rt.sizeDelta = new Vector2(180,30);
			rt.transform.localPosition = new Vector2(-10, rt.transform.localPosition.y);
		} else{
			rt.sizeDelta = new Vector2(200,30);
			rt.transform.localPosition = new Vector2(0, rt.transform.localPosition.y);
		}
	}

}
