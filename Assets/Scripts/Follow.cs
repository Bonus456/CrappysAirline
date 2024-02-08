using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform objectToFollow;
    public Vector3 offset;
    public float damping;

    private Vector3 velocity = Vector3.zero;

    public float speed = 2.0f;

    void FixedUpdate()
    {
        Vector3 movePosition = objectToFollow.position + offset;
        transform.position = Vector3.SmoothDamp( transform.position, movePosition, ref velocity, damping );

        float interpolation = speed * Time.deltaTime;

        //Vector3 position = this.transform.position;
        //position.y = Mathf.Lerp(this.transform.position.y, objectToFollow.transform.position.y, interpolation);
        //position.x = Mathf.Lerp(this.transform.position.x, objectToFollow.transform.position.x, interpolation);

        //this.transform.position = position;
    }
}
