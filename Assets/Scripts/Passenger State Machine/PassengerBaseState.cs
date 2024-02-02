using UnityEngine;

public abstract class PassengerBaseState
{
	public abstract void EnterState(PassengerStateManager passenger);
	public abstract void UpdateState(PassengerStateManager passenger);
	public abstract void OnCollisionEnter2D(PassengerStateManager passenger, Collision collision);
	public abstract void OnTriggerEnter2D(PassengerStateManager passenger, Collider2D trigger);
	public abstract void OnTriggerStay2D(PassengerStateManager passenger, Collider2D trigger);
	public abstract void OnTriggerExit2D(PassengerStateManager passenger, Collider2D trigger);
}
