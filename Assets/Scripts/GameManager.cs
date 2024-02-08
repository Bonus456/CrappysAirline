using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] SeatSlots;
    public GameObject[] DrinkMenu;
    public GameObject[] Bathrooms;

    [Header( "Passenger Settings" )]
    [Range(0,1f)]
    public float passengerMoveSpeed = 0.5f;
    [Range(0,30)]
    public int passengerMaxWaitTime = 20;
    [Range(0,120)]
    public int passengerTimeToAnger = 20;
    [Range(0,120)]
    public int passengerTimeToRage = 20;
    [Range(0,10)]
    public int passengerDrinkTime = 5;
    [Range(0,10)]
    public int passengerBathroomTime = 3;
    public int passengerMinAttribute = 0;
    [Range(0,100)]
    public int passengerMaxAttribute = 100;

    [Header( "Object Values" )]
    [Range(5,50)]
    public int drinkBladderAmount = 20;
    [Range( 50, 100 )]
    public int bathroomRelief = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
