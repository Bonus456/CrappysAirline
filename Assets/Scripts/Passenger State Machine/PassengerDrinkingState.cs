using UnityEngine;

public class PassengerDrinkingState : PassengerBaseState {
	public float drinkTime;
	public override void EnterState(PassengerStateManager passenger) {
		drinkTime = passenger.drinkTime;
	}
	public override void UpdateState(PassengerStateManager passenger) {
		drinkTime -= Time.deltaTime;
		if(drinkTime <= 0) {
			passenger.SwitchState( passenger.SitInSeatState );
			passenger.anim.SetTrigger( "BackToSit" );
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
