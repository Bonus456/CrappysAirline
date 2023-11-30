using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkMiniGame : MonoBehaviour {
    public GameObject[] CupSlots;
    private GameObject CurrentSlot;
    private int CurrentSlotNumber;
    public GameObject DrinkStation;
    private bool ScreenisOpen;
    // Start is called before the first frame update
    void Start( ) {
        ScreenisOpen = DrinkStation.GetComponent<DrinkStation>().ScreenIsOpen;
        CurrentSlot = CupSlots[0];
        CurrentSlotNumber = 0;
    }


    // Update is called once per frame
    void Update( ) {
        Debug.Log( CurrentSlotNumber );
        if(ScreenisOpen == true) {

            //Enables only the current cup
            foreach(GameObject Cupslot in CupSlots) {
                if(Cupslot == CurrentSlot) {
                    Cupslot.SetActive( true );
                } else {
                    Cupslot.SetActive( false );
                }
            }
        }
        //Check if right key is clicked
		if(Input.GetKeyDown(KeyCode.D)){
            //Checks if adding 1 would go over the limit of spaces
            if(CurrentSlotNumber + 1 <= CupSlots.Length-1) {
                CurrentSlot = CupSlots[CurrentSlotNumber + 1];
                CurrentSlotNumber++;
            } else {
                CurrentSlot = CupSlots[0];
                CurrentSlotNumber = 0;
			}
		}
        //Checks if left key is clicked
        else if(Input.GetKeyDown( KeyCode.A )) {
            //Checks if subtracting 1 would go over the limit of spaces
            if(CurrentSlotNumber - 1 >= 0) {
                CurrentSlot = CupSlots[CurrentSlotNumber - 1];
                CurrentSlotNumber--;
            } else {
                CurrentSlot = CupSlots[CupSlots.Length-1];
                CurrentSlotNumber = CupSlots.Length - 1;
			}
        }
    }
}
