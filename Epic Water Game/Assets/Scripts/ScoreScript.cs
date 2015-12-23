using UnityEngine;
using System.Collections;



public class ScoreScript : MonoBehaviour {
	public int environmentScore = 0;
	public int happinessScore = 0;
	public int capacityScore = 0;



	void Awake() {
		DontDestroyOnLoad(this);

	}
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
