using UnityEngine;
using System.Collections;

public class BadgeScript : MonoBehaviour {

	public GameObject scoreKeeper;
	public UnityEngine.Sprite happinessHeroImage;
	public UnityEngine.Sprite environmentHeroImage;
	public UnityEngine.Sprite capacityHeroImage;
	public UnityEngine.Sprite balanceHeroImage;
	private string balanceText = "You are a Balance Hero! That means you made all of your stats  balanced, without letting anything be too low!";
	private string happinessText = "You are a Happiness Hero! That means your water capacity and environmental impact " +
		"aren't as high, but you made everyone super happy!";
	private string environmentText = "You are an Envionmental Hero! That means not everyone is happy and there is " +
		"less water, but your plant is very good for the environment!";
	private string capacityText = "You are a Water Hero! This means not everyone is happy and your plant isn't great " +
		"for the environment, but your plant makes a lot of water!";

	public GameObject badgeIcon;
	public UnityEngine.UI.Text scientistText;

	// Use this for initialization
	void Start () {
		scoreKeeper = GameObject.Find("ScoreKeeper");


		if (scoreKeeper.GetComponent<ScoreScript> ().environmentScore == 10) {
			badgeIcon.GetComponent<UnityEngine.UI.Image> ().sprite = environmentHeroImage;
			scientistText.text = environmentText;
		}
		else if (scoreKeeper.GetComponent<ScoreScript> ().capacityScore == 10) {
			badgeIcon.GetComponent<UnityEngine.UI.Image> ().sprite = capacityHeroImage;
			scientistText.text = capacityText;
		}
		else if (scoreKeeper.GetComponent<ScoreScript> ().happinessScore == 10) {
			badgeIcon.GetComponent<UnityEngine.UI.Image> ().sprite = happinessHeroImage;
			scientistText.text = happinessText;
		}

		else if (scoreKeeper.GetComponent<ScoreScript> ().happinessScore >=4 && 
		    scoreKeeper.GetComponent<ScoreScript> ().environmentScore >=4 &&
		    scoreKeeper.GetComponent<ScoreScript> ().capacityScore >=4) {
			badgeIcon.GetComponent<UnityEngine.UI.Image> ().sprite = balanceHeroImage;
			scientistText.text = balanceText;
		}
		else
			Destroy (this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
