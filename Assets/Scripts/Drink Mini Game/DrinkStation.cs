using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkStation : MonoBehaviour
{

    public GameObject DrinkUI;
    private GameObject Player;
    private PlayerController PlayerController;
    private Collider2D Collide;
    public bool ScreenIsOpen;
    private bool PlayerInRange;
    public DrinkMiniGame DrinkMiniScript;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player" );
		PlayerController = Player.GetComponent<PlayerController>();
        DrinkMiniScript = DrinkUI.GetComponent<DrinkMiniGame>();
	}

	// Update is called once per frame
	void Update()
    {
        if(Input.GetKeyDown( KeyCode.E )) {
            if(ScreenIsOpen == false && PlayerInRange == true) {
                DrinkUI.gameObject.SetActive( true );
                ScreenIsOpen = true;
                PlayerController.CanMove = false;
            } else if(ScreenIsOpen == true) {
                
			}
        }    
        
        if(ScreenIsOpen == true && Input.GetKeyDown( KeyCode.Q )) {
            DrinkUI.gameObject.SetActive( false );
            ScreenIsOpen = false;
            PlayerController.CanMove = true;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Player") {
            PlayerInRange = true;
        }
	}

	private void OnTriggerExit2D(Collider2D col) {
        if(col.gameObject.tag == "Player") {
            PlayerInRange = false;
        }
    }
}
