using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] SeatSlots;
    public GameObject[] DrinkMenu;

    [Header( "Passenger Settings" )]
    public float passengerMoveSpeed = 0.5f;
    public float passengerMaxWaitTime = 20.0f;
    public float passengerTimeToAnger = 20.0f;
    public float passengerTimeToRage = 20.0f;
    public float passengerDrinkTime = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
