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
    public bool CanMoveDown;
    private float followingY;
    private float camY;
    private float movementDist;
    private float speed = 0f;

    public float maxHeight;
    public float minHeight;
    // Update is called once per frame
    void Update()
    {
        followingY = Mathf.Min(Head.transform.position.y,Pipi.transform.position.y);
        camY = transform.position.y;
        if(followingY > camY+followingHeight)
        {
            movementDist = followingY-(camY+followingHeight);
            speed = Mathf.Pow(movementDist,FollowSpeedPower)*FollowSpeedMult;
            if(transform.position.y+speed*Time.deltaTime < maxHeight)
                transform.Translate(0,speed*Time.deltaTime,0);
            else transform.Translate(0,maxHeight-transform.position.y,0);
        }
        else if(CanMoveDown)
        {
            followingY = Mathf.Max(Head.transform.position.y,Pipi.transform.position.y);
            if(followingY < camY-followingHeight)
            {
                movementDist = (camY-followingHeight)-followingY;
                speed = Mathf.Pow(movementDist,FollowSpeedPower)*FollowSpeedMult;
                if(transform.position.y-speed*Time.deltaTime > minHeight)
                    transform.Translate(0,-speed*Time.deltaTime,0);
                else transform.Translate(0,minHeight-transform.position.y,0);
            }
        }
    }
}
