using UnityEngine;

public class PassengerFindSeatState : PassengerBaseState
{
	public override void EnterState(PassengerStateManager passenger) {
		Debug.Log( "Looking For Seat" );
		SearchForSeat(passenger);
	}
	public override void UpdateState(PassengerStateManager passenger) {
		//Switches state to "Walk To Seat" when passenger has located seat
		if(passenger.Seat != null) {
			passenger.SwitchState( passenger.WalkToSeatState );
		}
	}
	public override void OnCollisionEnter2D(PassengerStateManager passenger, Collision collision) {

	}
	public override void OnTriggerEnter2D(PassengerStateManager passenger, Collider2D trigger) {

	}

	public void SearchForSeat(PassengerStateManager passenger) {
		for(int i = 0; i< passenger.GameManager.SeatSlots.Length; i++) {
			if(passenger.GameManager.SeatSlots[i].gameObject.tag == "Unclaimed") {
				passenger.Seat = passenger.GameManager.SeatSlots[i];
				passenger.seatScript = passenger.Seat.GetComponent<PlaneSegmentSeat>();
				passenger.Seat.tag = "Claimed";
				break;
			}
		}
	}
	public override void OnTriggerStay2D(PassengerStateManager passenger, Collider2D trigger) {

	}
	public override void OnTriggerExit2D(PassengerStateManager passenger, Collider2D trigger) {

	}
}
