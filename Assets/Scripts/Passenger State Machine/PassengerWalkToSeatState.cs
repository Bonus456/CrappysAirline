using UnityEngine;

public class PassengerWalkToSeatState : PassengerBaseState
{
	public GameObject passSeat;
	public float direction;

	public override void EnterState(PassengerStateManager passenger) {
		passSeat = passenger.Seat;
		passenger.anim = passenger.GetComponent<Animator>();
	}
	public override void UpdateState(PassengerStateManager passenger) {
		if(passenger.transform.position.x > passSeat.transform.position.x) {
			passenger.anim.SetBool( "facingRight", false );
			passenger.anim.SetBool( "walking", true );
		}
		else if(passenger.transform.position.x < passSeat.transform.position.x) {
			passenger.anim.SetBool( "facingRight", true );
			passenger.anim.SetBool( "walking", true );

		}
		Vector3 oldPosition = passenger.transform.position;
		oldPosition.x = Mathf.MoveTowards( oldPosition.x, passSeat.transform.position.x, Time.deltaTime * passenger.moveSpeed );
		passenger.transform.position = oldPosition;
		
		if(passenger.gameObject.transform.position.x == passSeat.gameObject.transform.position.x) {
			passenger.gameObject.transform.position.Equals( passSeat.gameObject.transform.position.x );
			passenger.SwitchState( passenger.SitInSeatState );
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
