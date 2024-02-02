using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrinkMiniGame : MonoBehaviour {

    public GameObject[] CupSlots;
    public Sprite[] FullCups;
    public Sprite[] NormSprites;
    public Sprite[] PushSprites;
    public GameObject[] InventoryDrinks;
    public Sprite DefaultCupSprite;
    private GameObject CurrentSlot;
    private int CurrentSlotNumber;
    public GameObject DrinkStation;
    private PlayerController PC;
    private bool ScreenisOpen;
    private Slider CurrSlider;
    public float CurrSliderValue ;
    private bool SpaceDown;
    // Start is called before the first frame update
    void Start( ) {
        ScreenisOpen = DrinkStation.GetComponent<DrinkStation>().ScreenIsOpen;
        CurrentSlot = CupSlots[0];
        CurrentSlotNumber = 0;
        SpaceDown = false;
        PC = GameObject.FindGameObjectWithTag( "Player" ).GetComponent<PlayerController>();
    }


    // Update is called once per frame
    void Update( ) {
        Slider CurrSlider = CurrentSlot.GetComponentInChildren<Slider>();
        Image CupImage = CupSlots[CurrentSlotNumber].GetComponent<Image>();
        //Enables only the current cup
        if(ScreenisOpen == true) {
            foreach(GameObject Cupslot in CupSlots) {
                if(Cupslot == CurrentSlot) {
                    Cupslot.SetActive( true );
                } else {
                    Cupslot.SetActive( false );
                }
            }
        }

        //Check if right key is clicked
        if(Input.GetKeyDown( KeyCode.D ) && SpaceDown == false) {
            //Corrects Dispenser Push Animation
            Dispenser ParentSource = CurrentSlot.transform.parent.GetComponentInParent<Dispenser>();
            ParentSource.PushDown = false;
            CupImage.sprite = DefaultCupSprite;
            //Checks if adding 1 would go over the limit of spaces
            if(CurrentSlotNumber + 1 <= CupSlots.Length - 1) {
                CurrentSlot = CupSlots[CurrentSlotNumber + 1];
                CurrentSlotNumber++;
            } else {
                CurrentSlot = CupSlots[0];
                CurrentSlotNumber = 0;
            }
            CurrSliderValue = 0;
        }

        //Checks if left key is clicked
        else if(Input.GetKeyDown( KeyCode.A ) && SpaceDown == false) {
            //Corrects Dispenser Push Animation
            Dispenser ParentSource = CurrentSlot.transform.parent.GetComponentInParent<Dispenser>();
            ParentSource.PushDown = false;
            CupImage.sprite = DefaultCupSprite;

            //Checks if subtracting 1 would go over the limit of spaces
            if(CurrentSlotNumber - 1 >= 0) {
                CurrentSlot = CupSlots[CurrentSlotNumber - 1];
                CurrentSlotNumber--;
            } else {
                CurrentSlot = CupSlots[CupSlots.Length-1];
                CurrentSlotNumber = CupSlots.Length - 1;
			}
            CurrSliderValue = 0;
        }

        //If Space is down, Enable filling or disable if up
        if(Input.GetKeyDown( KeyCode.Space )) {
            EnableFill( CurrentSlot );
            CupImage.sprite = FullCups[CurrentSlotNumber];
        } else if(Input.GetKeyUp( KeyCode.Space ) ) {
            DisableFill( CurrentSlot );
            SpaceDown = false;

		}else if(Input.GetKey( KeyCode.Space )) {
            CurrSliderValue += Time.deltaTime;
            SpaceDown = true;
        }
        CurrSlider.value = CurrSliderValue;

        //When the cup is filled
        if(CurrSlider.value == CurrSlider.maxValue) {
           ParticleSystem CurrentPart =  CurrentSlot.GetComponentInChildren<ParticleSystem>();
			for(int i = 0; i < PC.InventorySlots.Length; i++) {
                //Add drink to inventory system
                if(PC.isFull[i] == false) {
                    PC.isFull[i] = true;
                    var clone = Instantiate( InventoryDrinks[CurrentSlotNumber],PC.InventorySlots[i].transform, false );
                    clone.name = InventoryDrinks[CurrentSlotNumber].name;
                    CurrSliderValue = CurrSlider.minValue;
                    break;
                }
            }

        }

    }
    public void EnableFill( GameObject FillSlot) {
        Dispenser ParentSource = FillSlot.transform.parent.GetComponentInParent<Dispenser>();
        ParticleSystem FillSlotPart =  FillSlot.GetComponentInChildren<ParticleSystem>();
        ParentSource.PushDown = true;
        FillSlotPart.Play();

    }

    public void DisableFill(GameObject FillSlot) {
        Dispenser ParentSource = FillSlot.transform.parent.GetComponentInParent<Dispenser>();
        ParticleSystem FillSlotPart = FillSlot.GetComponentInChildren<ParticleSystem>();
        ParentSource.PushDown = false;
        FillSlotPart.Stop();
    }
}
