using UnityEngine;

public class PassengerAskForDrinkState : PassengerBaseState
{
	public float timeToAnger;
	public GameObject order;
	public int orderNumber;
	public float bubbleSitMoveY;
	public override void EnterState(PassengerStateManager passenger) {
		timeToAnger = passenger.timeToAnger;
		orderNumber = Random.Range( 0, passenger.GameManager.DrinkMenu.Length);
		order = passenger.GameManager.DrinkMenu[orderNumber];

		//Changes animation for the bubble and the desire game object
		passenger.anim.SetTrigger( "Ordering" );
		passenger.BubbleAnim.SetTrigger( "Ordering" );
		passenger.DesireAnim.SetInteger( "orderNumber", orderNumber );
		Debug.Log( order );
	}
	public override void UpdateState(PassengerStateManager passenger) {
		timeToAnger -= Time.deltaTime;
		if(timeToAnger <= 0) {
			passenger.BubbleAnim.SetBool( "angry", true );
			passenger.anim.SetBool( "angry", true );
		}

		if(passenger.playerInRange == true && Input.GetKeyDown( KeyCode.E )) {
			for(int i = 0; i<passenger.Player.InventorySlots.Length; i++) {
				//checks every inventory slot to see if any match the drink passenger's drink order
				if(passenger.Player.InventorySlots[i].transform.Find(order.name)) {
					GameObject.Destroy( passenger.Player.InventorySlots[i].transform.Find(order.name).gameObject );
					passenger.Player.isFull[i] = false;
					passenger.anim.SetBool( "angry", false );
					passenger.anim.SetTrigger( "HasDrink" );
					passenger.BubbleAnim.SetTrigger( "SpeechOver" );
					passenger.BubbleAnim.SetBool( "angry", false );
					passenger.DesireAnim.SetTrigger( "HasDesire" );
					passenger.DesireAnim.SetInteger( "orderNumber", -1 );
					passenger.SwitchState( passenger.DrinkingState );
					break;
				}
			}
		}
	}
	public override void OnCollisionEnter2D(PassengerStateManager passenger, Collision collision) {

	}
	public override void OnTriggerEnter2D(PassengerStateManager passenger, Collider2D trigger) {
	}
	public override void OnTriggerStay2D(PassengerStateManager passenger, Collider2D trigger) {

	}
	public override void OnTriggerExit2D(PassengerStateManager passenger, Collider2D trigger) {

	}
}
