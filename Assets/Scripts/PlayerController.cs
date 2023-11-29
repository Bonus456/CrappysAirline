using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public bool CanMove = true;
    // Use this for initialization
    void Start() {
        CanMove = true;
    }

    // Update is called once per frame
    void Update(){
        if(CanMove == true) {
            //Animation Handling
            animator.SetFloat( "Horizontal", Input.GetAxis( "Horizontal" ) );
            if(Input.GetAxis( "Horizontal" ) > 0) {
                animator.SetBool( "FacingRight", true );
            } else if(Input.GetAxis( "Horizontal" ) < 0) {
                animator.SetBool( "FacingRight", false );
            }
            //Movement
            Vector3 horizontal = new Vector3( Input.GetAxis( "Horizontal" ), 0.0f, 0.0f );
            transform.position = transform.position + horizontal * Time.deltaTime;
        }
    }
}
