using UnityEngine;
using System.Collections;

public class ParticleScript : MonoBehaviour {

	float count = 0;
	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().sortingLayerName = "Particle";
	}
	
	// Update is called once per frame
	void Update () {
		count += Time.deltaTime;
		if (count >= 1) {
			Destroy(this);
		}
	}


}
