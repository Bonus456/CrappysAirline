using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerStateManager : MonoBehaviour
{
	public PassengerBaseState currentState;
	public PassengerAskForDrinkState AskForDrinkState = new PassengerAskForDrinkState();
	public PassengerFindSeatState FindSeatState = new PassengerFindSeatState();
	public PassengerFollowPlayerState FollowPlayerState = new PassengerFollowPlayerState();
	public PassengerSitInSeatState SitInSeatState = new PassengerSitInSeatState();
	public PassengerUseToiletState UseToiletState = new PassengerUseToiletState();
	public PassengerWalkToDestinationState WalkToDestinationState = new PassengerWalkToDestinationState();
	public PassengerWalkToSeatState WalkToSeatState = new PassengerWalkToSeatState();
	public PassengerWanderAroundState WanderAroundState = new PassengerWanderAroundState();
	public PassengerDrinkingState DrinkingState = new PassengerDrinkingState();
	
	[HideInInspector] public GameManager GameManager;
	[HideInInspector] public GameObject Seat;
	[HideInInspector] public GameObject Bubble;
	[HideInInspector] public GameObject Desire;
	[HideInInspector] public PlayerController Player;
	[HideInInspector] public PlaneSegmentSeat seatScript;
	[HideInInspector] public Animator anim;
	[HideInInspector] public Animator BubbleAnim;
	[HideInInspector] public Animator DesireAnim;

	public bool playerInRange;
	public float bubbleSitMoveY;
	public bool sitting;

	private Vector3 BubbleOrgPos;

	[Header("Game Manager Settings")]
	public float moveSpeed;
	public float maxWait;
	public float timeToAnger;
	public float timeToRage;
	public float drinkTime;

	void Awake( ) {
		Player = GameObject.FindGameObjectWithTag( "Player" ).GetComponent<PlayerController>();
		Bubble = this.transform.Find( "Bubble" ).gameObject;
		BubbleAnim = Bubble.GetComponent<Animator>();
		Desire = this.transform.Find( "Bubble/Desire" ).gameObject;
		DesireAnim = Desire.GetComponent<Animator>();
		GameManager = GameObject.Find( "Game Manager" ).GetComponent<GameManager>();
		anim = gameObject.GetComponent<Animator>();
		BubbleOrgPos = Bubble.transform.position;
		
		//copy Game Manager Settings
		moveSpeed = GameManager.passengerMoveSpeed;
		maxWait = GameManager.passengerMaxWaitTime;
		timeToAnger = GameManager.passengerTimeToAnger;
		timeToRage = GameManager.passengerTimeToRage;
		drinkTime = GameManager.passengerDrinkTime;
	}
	void Start( ) {
		currentState = FindSeatState;
		currentState.EnterState(this);
	}
	void Update( ) {
		currentState.UpdateState( this);
		playerInRange = seatScript.playerInRange;
	}


	void OnTriggerStay2D(Collider2D collision) {
		currentState.OnTriggerStay2D( this, collision );
	}
	void OnTriggerExit2D(Collider2D collision) {
		currentState.OnTriggerExit2D( this, collision );
	}

	public void SwitchState(PassengerBaseState state) {
		currentState = state;
		state.EnterState( this );
		Debug.Log( currentState );
	}
}
