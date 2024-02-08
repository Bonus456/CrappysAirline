using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerWaitForBathroomState : PassengerBaseState
{
	public override void EnterState(PassengerStateManager passenger) {
		passenger.anim.SetBool( "Walking", false );
	}
	public override void UpdateState(PassengerStateManager passenger) {

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
