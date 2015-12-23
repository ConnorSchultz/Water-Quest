using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResearchScript : MonoBehaviour {


	
	public GameObject researchFolder;
	public float scaleVal;
	public float boundary;
	public UnityEngine.UI.Text happinessText;
	public UnityEngine.UI.Text environmentText;
	public UnityEngine.UI.Text capacityText;
	public UnityEngine.UI.Text happinessScore;
	public UnityEngine.UI.Text environmentScore;
	public UnityEngine.UI.Text capacityScore;
	public UnityEngine.UI.Text happinessScoreText;
	public UnityEngine.UI.Text environmentScoreText;
	public UnityEngine.UI.Text capacityScoreText;
	public UnityEngine.UI.Button placeDesalButton;
	public UnityEngine.UI.Button outsidePanelButton;
	public bool[] researchCheck;
	public string[] researchText; //All research facts to be used
	public int[] researchScore;
	public int[] currentResearchScoreInt;
	public UnityEngine.UI.Text scientistText;
	public UnityEngine.UI.Image tab1;
	public UnityEngine.UI.Image tab2;
	public UnityEngine.UI.Image tab3;
	public GameObject desalButton;
	public GameObject desalButtonBW;
	public GameObject panelBeach;
	public GameObject panelNorth;
	public GameObject panelSouth;
	public GameObject researchButton;
	public GameObject happinessIcon;
	public GameObject environmentIcon;
	public GameObject capacityIcon;
	public UnityEngine.Sprite happinessImageBW;
	public UnityEngine.Sprite happinessImage;
	public UnityEngine.Sprite environmentImageBW;
	public UnityEngine.Sprite environmentImage;
	public UnityEngine.Sprite capacityImageBW;
	public UnityEngine.Sprite capacityImage;
	public GameObject happinessScoreIcon;
	public GameObject environmentScoreIcon;
	public GameObject capacityScoreIcon;

	public bool closing;
	public bool researchOpen = false;
	public int numResearchCollected = 0;

	
	private bool desalSet = false;
	private bool opening;
	public string[] currentResearchText; // the current text for each location 
	public string[] currentResearchScore; // the current score for each location 

	private string defaultText = "Collect more research to unlock this fact!";
	private string placeDesalText = "You can now place the desalination plant, or continue to find more research!";
	private string defaultScore = "+ ?";
	private int happinessOffset = 0;
	private int environmentOffset = 3;
	private int capacityOffset = 6;
	private int numResearch = 0; //how much research you have collected
	private bool tutorialText2Check = false;
	private bool tutorialText3Check = false;
	private bool minResearchCollected;

	
	
	
	
	
	void Start () {
		
		currentResearchText = new string[9]{ defaultText,
		                       defaultText,
		                       defaultText,
		                       defaultText,
		                       defaultText,
		                       defaultText,
		                       defaultText,
		                       defaultText,
							   defaultText};
		
		currentResearchScore = new string[9]{ defaultScore,
		                        defaultScore,
		                        defaultScore,
		                        defaultScore,
		                        defaultScore,
		                        defaultScore,
		                        defaultScore,
		                        defaultScore,
								defaultScore};
		currentResearchScoreInt = new int[9]{0,0,0,0,0,0,0,0,0};
	
		
	}
	
	void Update () {

	

		if(closing){
			researchFolder.GetComponent<RectTransform>().localScale *= (1 - scaleVal);
			
			if(researchFolder.GetComponent<RectTransform>().localScale.x <= boundary){
				closing = false;
				researchFolder.GetComponent<RectTransform>().localScale = Vector3.zero;
			}	
		}
		
		if(opening){
			
			researchFolder.GetComponent<RectTransform>().localScale *= (1 + scaleVal);
			if(researchFolder.GetComponent<RectTransform>().localScale.x * (1 + scaleVal) >= 1){
				opening = false;
				researchFolder.GetComponent<RectTransform>().localScale = Vector3.one;
			}
			
		}
		
		if(numResearchCollected >= 3 && !desalSet && !minResearchCollected){
			minResearchCollected = true;
			//Camera.main.GetComponent<ScriptBoard2>().desalButtonClicked();
			placeDesalButton.gameObject.SetActive(true);
			desalSet = true;
			
		}
		if(numResearchCollected >= 3 && !tutorialText3Check){
			scientistText.text = placeDesalText;
			tutorialText3Check = true;
		}
	}
	
	public void openResearch(){
		if (!closing && !opening && !researchOpen) {
			opening = true;
			researchOpen = true;
			researchFolder.GetComponent<RectTransform> ().localScale = new Vector3 (boundary, boundary, boundary);
			outsidePanelButton.gameObject.SetActive(true);
		} 
		
	}
	
	public void closeResearch(){
		if(!opening){
			closing = true;
			researchOpen = false;
			outsidePanelButton.gameObject.SetActive(false);
		}
	}
	
	public void switchText(int location){
		if(location == 0)
			panelSouth.GetComponent<RectTransform>().SetAsLastSibling();
		if(location == 1)
			panelNorth.GetComponent<RectTransform>().SetAsLastSibling();
		if(location == 2)
			panelBeach.GetComponent<RectTransform>().SetAsLastSibling();
		//setting research text to show
		happinessText.text = currentResearchText[(location + happinessOffset)];
		environmentText.text = currentResearchText[(location + environmentOffset)];
		capacityText.text = currentResearchText[(location + capacityOffset)];
		if (happinessText.text == defaultText) {
			happinessIcon.GetComponent<UnityEngine.UI.Image> ().sprite = happinessImageBW;
			happinessScoreIcon.GetComponent<UnityEngine.UI.Image> ().sprite = happinessImageBW;
			happinessText.color = Color.gray;
		} else {
			happinessIcon.GetComponent<UnityEngine.UI.Image> ().sprite = happinessImage;
			happinessScoreIcon.GetComponent<UnityEngine.UI.Image> ().sprite = happinessImage;
			happinessText.color = Color.black;
		}

		if (environmentText.text == defaultText) {
			environmentIcon.GetComponent<UnityEngine.UI.Image> ().sprite = environmentImageBW;
			environmentScoreIcon.GetComponent<UnityEngine.UI.Image> ().sprite = environmentImageBW;
			environmentText.color = Color.gray;
		} else {
			environmentIcon.GetComponent<UnityEngine.UI.Image> ().sprite = environmentImage;
			environmentScoreIcon.GetComponent<UnityEngine.UI.Image> ().sprite = environmentImage;
			environmentText.color = Color.black;
		}

		if (capacityText.text == defaultText){
			capacityIcon.GetComponent<UnityEngine.UI.Image>().sprite = capacityImageBW;
			capacityScoreIcon.GetComponent<UnityEngine.UI.Image>().sprite = capacityImageBW;
			capacityText.color = Color.gray;
		}else{
			capacityIcon.GetComponent<UnityEngine.UI.Image>().sprite = capacityImage;
			capacityIcon.GetComponent<UnityEngine.UI.Image>().sprite = capacityImage;
			capacityText.color = Color.black;
		}

		//setting score to show
		happinessScore.text = currentResearchScore[(location + happinessOffset)];
		environmentScore.text = currentResearchScore[(location + environmentOffset)];
		capacityScore.text = currentResearchScore[(location + capacityOffset)];


		
		
		openResearch();
	}
	
	public void findResearch(){
		
		int index; //which index to choose for research
		bool allResearchFound = true; //determines if all research has been found
		//checking if any research is left
		for (int i = 0; i < researchText.Length ; i++){
			if(!researchCheck[i]){
				allResearchFound = false;
				break;
			}
		}
		if(!allResearchFound){
			//searching for new research
			do{
				index = Random.Range(0,researchText.Length);
			}
			while(researchCheck[index]);
			
			currentResearchText[index] = researchText[index];
			currentResearchScore[index] = "+ " + researchScore[index];
			currentResearchScoreInt[index] = researchScore[index];
			researchCheck[index] = true;
			numResearchCollected++;
			if(!tutorialText2Check){
				scientistText.text = "Great! Now move your mouse to the edges of the screen to move around.";
				tutorialText2Check = true;
			}
			switchText((index )%3);
			
		}


	}
	//opens panel if closed, closes panel if open
	public void invertResearchPanel(){
		if(researchOpen)
			closeResearch();
		
		else
			openResearch();
		
	}
	
	
	
	

	
	
	
	
	

}
