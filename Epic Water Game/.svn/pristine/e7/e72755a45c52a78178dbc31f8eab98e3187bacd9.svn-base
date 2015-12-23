using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuitGameScript : MonoBehaviour {
	
	public Canvas quitMenu;

	
	// Use this for initialization
	void Start () {
		quitMenu = quitMenu.GetComponent<Canvas> ();
		quitMenu.enabled = false;
		
	}
	
	public void ExitPress()
	{
		quitMenu.enabled = true;

		
	}
	
	public void NoPress()
	{
		quitMenu.enabled = false;

	}

	
	public void ExitGame()
	{
		Application.LoadLevel (0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
