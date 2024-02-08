using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations;
using UnityEngine;

public class Bathroom : MonoBehaviour
{
	[HideInInspector] public GameObject Passenger;
	[HideInInspector] public GameManager GameManager;
	[HideInInspector] public Animator anim;
	[HideInInspector] public bool playerInRange;


	public bool doorOpen;
	public bool signOpen;

	public GameObject[] QueueSpots;

	[Header( "Stain Objects" )]
	public GameObject PoopStain;
	public GameObject PeeStain;
	public GameObject GraffitiS;
	
	private PlayerController Player;

	void Start( ) {
		Player = GameObject.Find( "Player" ).GetComponent<PlayerController>();
		anim = gameObject.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update( ) {
		if(doorOpen) {
			anim.SetBool( "open", true );
		} else {
			anim.SetBool( "open", false );
		}
		if(signOpen) {
			anim.SetBool( "inUse", true );
		} else {
			anim.SetBool( "inUse", false );
		}
	}
	public void AssignPassenger(GameObject _passenger) {
		Passenger = _passenger;
	}

	public void ClearPassenger() {
		Passenger = null;
	}
	public void OnTriggerEnter2D(Collider2D col) {
		if(col.tag == "Player") {
			playerInRange = true;
		}
	}

	public void OnTriggerExit2D(Collider2D col) {
		if(col.tag == "Player") {
			playerInRange = false;
		}
	}
}
