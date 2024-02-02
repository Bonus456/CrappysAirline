using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSegmentSeat : MonoBehaviour
{
    public GameObject Passenger;
    public GameManager GameManager;
    public bool playerInRange;

    private PlayerController Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag( "Player" ).GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }
    public void AssignPassenger(GameObject _passenger) {
        Passenger = _passenger;
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
