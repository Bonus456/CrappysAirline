using UnityEngine;

public class PassengerSitInSeatState : PassengerBaseState
{
	public Transform ArmrestUp;
	public Transform ArmrestDown;
	public float moveSpeed;
	public Transform seatTrans;
	public float randWait;
	public float bubbleSitMoveY;
	public override void EnterState(PassengerStateManager passenger) {
		//Checks to see if the passenger is already sitting down
		if(passenger.sitting) {
			randWait = Random.Range( 0, passenger.maxWait );

		} else {
			SitDown(passenger);
		}

		if(passenger.bladder >= passenger.GameManager.passengerMaxAttribute) {
			passenger.SwitchState( passenger.WalkToBathroomState );
		}
	}
	public override void UpdateState(PassengerStateManager passenger) {
		if(!passenger.sitting) {
			Vector3 oldPosition = passenger.transform.position;
			Vector3 seatPosition = seatTrans.transform.position;
			if(oldPosition != seatPosition) {
				oldPosition.z = Mathf.MoveTowards( oldPosition.z, seatTrans.position.z, Time.deltaTime * passenger.moveSpeed );
				oldPosition.y = Mathf.MoveTowards( oldPosition.y, seatTrans.position.y, Time.deltaTime * passenger.moveSpeed );
				oldPosition.x = Mathf.MoveTowards( oldPosition.x, seatTrans.position.x, Time.deltaTime * passenger.moveSpeed );
				passenger.transform.position = oldPosition;
			} else if(oldPosition == seatPosition) {
				passenger.ArmRestUp.gameObject.SetActive( false );
				passenger.ArmRestDown.gameObject.SetActive( true );
			}
		}

		randWait -= Time.deltaTime;
		if(randWait <= 0) { 
			passenger.SwitchState( passenger.AskForDrinkState );
			passenger.sitting = true;
		}
	}
	public void SitDown( PassengerStateManager passenger) {
		//Change position of bubble for sitting
		passenger.BubbleOrgPos = passenger.Bubble.transform.position;
		bubbleSitMoveY = passenger.bubbleSitMoveY;
		passenger.Bubble.transform.localPosition = new Vector3( 0.0f,
		bubbleSitMoveY, passenger.Bubble.transform.position.z );

		passenger.seatScript.AssignPassenger( passenger.gameObject );
		moveSpeed = passenger.SitInSeatState.moveSpeed;
		passenger.anim.SetBool( "walking", false );
		passenger.anim.SetTrigger( "SitDown" );
		passenger.ArmRestUp = passenger.Seat.transform.Find( "Chair/Armrest Up" );
		passenger.ArmRestDown = passenger.Seat.transform.Find( "Chair/Armrest Down" );
		seatTrans = passenger.Seat.transform.Find( "Passenger" );
		randWait = Random.Range( 0, passenger.maxWait );
		passenger.StandingPos = passenger.transform.position;
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
