using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Head;
    public GameObject Pipi;
    public float followingHeight;
    public float FollowSpeedMult;
    public float FollowSpeedPower;
    private float followingY;
    private float camY;
    private float movementDist;
    private float speed = 0f;
    // Update is called once per frame
    void Update()
    {
        followingY = Mathf.Min(Head.transform.position.y,Pipi.transform.position.y);
        camY = transform.position.y + followingHeight;
        if(followingY > camY)
        {
            movementDist = followingY-camY;
            speed = Mathf.Pow(movementDist,FollowSpeedPower)*FollowSpeedMult;
            transform.Translate(0,speed*Time.deltaTime,0);
        }
    }
}
