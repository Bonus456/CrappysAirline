using UnityEngine;

public class PassengerWalkToBathroomState : PassengerBaseState
{
	public GameObject BathroomSpot;
	public bool standing;
	public override void EnterState(PassengerStateManager passenger) {
		FindBathroom( passenger );
	}
	public void FindBathroom( PassengerStateManager passenger) {
		//Checks bathroom list for vacant bathroom
		for(int i = 0;i < passenger.GameManager.Bathrooms.Length;i++){
			if(passenger.GameManager.Bathrooms[i].tag == "Vacant") {
				BathroomSpot = passenger.GameManager.Bathrooms[i];
				passenger.GameManager.Bathrooms[i].tag = "Occupied";
				break;
			}
			//if all bathrooms are vacant than check if there is an open queue spot
			if(i == passenger.GameManager.Bathrooms.Length-1) {
				Debug.Log( "Checking queues" );
				for(int a = 0; a < passenger.GameManager.Bathrooms[a].GetComponent<Bathroom>().QueueSpots.Length; a++) {
					if(passenger.GameManager.Bathrooms[a].GetComponent<Bathroom>().QueueSpots[a].tag == "Vacant") {
						BathroomSpot = passenger.GameManager.Bathrooms[a].GetComponent<Bathroom>().QueueSpots[a];
						passenger.waitingForBathroom= true;
						passenger.GameManager.Bathrooms[a].GetComponent<Bathroom>().QueueSpots[a].tag = "Occupied";
						break;
						
					}
				}
			}
		}
		Debug.Log( BathroomSpot );
		if(BathroomSpot != null) {
			GetUp( passenger );
		}
	}

	public void GetUp(PassengerStateManager passenger ) {
		passenger.Bubble.transform.localPosition = new Vector2(passenger.BubbleOrgPos.y, passenger.BubbleOrgPos.z );
		passenger.anim.SetTrigger( "GetUp" );

	}
	public override void UpdateState(PassengerStateManager passenger) {
		//Makes the Passenger Stand Up
		if(BathroomSpot != null && !standing ) {
			Vector3 oldPosition = passenger.transform.position;
			Vector3 standPosition = passenger.StandingPos;
			if(oldPosition != standPosition) {
				oldPosition.z = Mathf.MoveTowards( oldPosition.z, standPosition.z, Time.deltaTime * passenger.moveSpeed );
				oldPosition.y = Mathf.MoveTowards( oldPosition.y, standPosition.y, Time.deltaTime * passenger.moveSpeed );
				oldPosition.x = Mathf.MoveTowards( oldPosition.x, standPosition.x, Time.deltaTime * passenger.moveSpeed );
				passenger.transform.position = oldPosition;
			} else if(oldPosition == standPosition) {
				passenger.ArmRestDown.gameObject.SetActive( false );
				passenger.ArmRestUp.gameObject.SetActive( true );
				standing = true;
			}
		}

		if(standing) {
			if(passenger.transform.position.x > BathroomSpot.transform.position.x) {
				passenger.anim.SetBool( "facingRight", false );
				passenger.anim.SetBool( "walking", true );
			} else if(passenger.transform.position.x < BathroomSpot.transform.position.x) {
				passenger.anim.SetBool( "facingRight", true );
				passenger.anim.SetBool( "walking", true );

			}
			Vector3 oldPosition = passenger.transform.position;
			oldPosition.x = Mathf.MoveTowards( oldPosition.x, BathroomSpot.transform.position.x, Time.deltaTime * passenger.moveSpeed );
			passenger.transform.position = oldPosition;

			if(passenger.gameObject.transform.position.x == BathroomSpot.gameObject.transform.position.x) {
				passenger.gameObject.transform.position.Equals( BathroomSpot.gameObject.transform.position.x );
				if(passenger.waitingForBathroom) {
					passenger.SwitchState( passenger.WaitForBathroomState );
				} else {
					passenger.SwitchState( passenger.UseToiletState );
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
