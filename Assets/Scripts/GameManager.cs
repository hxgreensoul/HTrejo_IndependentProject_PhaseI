using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager : MonoBehaviour
{	
	// Place holders to allow connecting to other objects
	public Transform spawnPoint;
	public GameObject player;

	// Flags that control the state of the game
	//private float elapsedTime = 0;
	private bool isRunning = false;
	private bool isFinished = false;
    public int count;
  
    // So that we can access the player's controller from this script
    private FirstPersonController fpsController;

	// Use this for initialization
	void Start ()
	{
		// Finds the First Person Controller script on the Player
		fpsController = player.GetComponent<FirstPersonController> ();
	
		// Disables controls at the start.
		fpsController.enabled = false;
	}


	//This resets to game back to the way it started
	private void StartGame()
	{
		//elapsedTime = 0;
		isRunning = true;
		isFinished = false;
         
        // Move the player to the spawn point, and allow it to move.
        PositionPlayer();
		fpsController.enabled = true;
	}


	// Update is called once per frame
	void Update ()
	{
        
	}

	//Runs when the player needs to be positioned back at the spawn point
	public void PositionPlayer()
	{
		player.transform.position = spawnPoint.position;
		player.transform.rotation = spawnPoint.rotation;
	}

	// Runs when the player enters the finish zone
	public void FinishedGame()
	{
		isRunning = false;
		isFinished = true;
        fpsController.enabled = false;
    }


    //This section creates the Graphical User Interface (GUI)
    void OnGUI() {

		if(!isRunning)
		{
			string message;

            if (isFinished)
			{
				message = "Click or Press Enter to Play Again";
			}
			else
			{
				message = "Click or Press Enter to Play";
            }

			//Define a new rectangle for the UI on the screen
			Rect startButton = new Rect(Screen.width/2 - 120, Screen.height/2, 240, 30);

			if (GUI.Button(startButton, message) || Input.GetKeyDown(KeyCode.Return))
			{
				//start the game if the user clicks to play
				StartGame ();
			} 
        }	
		
    }
}
