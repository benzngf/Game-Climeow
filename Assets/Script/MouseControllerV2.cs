using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControllerV2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Head;
    public GameObject Pipi;
    public float speed;
    public float rotSpeed;
    private Vector2 ShootingVelHead;
    private Vector2 ShootingVelPipi;
    private bool bIsSlomo;
    public float SlomoDilation = 0.1f;
    private bool bPendingHead, bPendingPipi;
    private float savedFixedDeltaTime;
    public Vector3 HeadPivot;
    public Vector3 PipiPivot;
    public SpringJoint2D Joint;
    public float JointAffectMinDist;
    private float Dist;
    void Start()
    {
        ShootingVelHead = new Vector2(0,0);
        ShootingVelPipi = new Vector2(0,0);
        savedFixedDeltaTime = Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            //Head
            if(!bPendingHead)
            {
                bPendingHead = true;
                Head.GetComponent<Rigidbody2D>().angularVelocity = 0f;
            }
            else
            {
                Head.transform.RotateAround(Head.transform.TransformPoint(HeadPivot),Vector3.forward,Time.deltaTime*rotSpeed/SlomoDilation);
            }
        }else if(bPendingHead)
        {
            //shoot head
            bPendingHead = false;
            Head.GetComponent<Rigidbody2D>().angularVelocity = 0f;
            ShootingVelHead.x = -Head.transform.right.x;
            ShootingVelHead.y = -Head.transform.right.y;
            Head.GetComponent<Rigidbody2D>().AddForce(ShootingVelHead*speed,ForceMode2D.Impulse);
        }
        if(Input.GetKey(KeyCode.Mouse1))
        {
            //Pipi
            if(!bPendingPipi)
            {
                bPendingPipi = true;
                Pipi.GetComponent<Rigidbody2D>().angularVelocity = 0f;
            }
            else
            {
                Pipi.transform.RotateAround(Pipi.transform.TransformPoint(PipiPivot),Vector3.forward,Time.deltaTime*rotSpeed/SlomoDilation);
            }
        }else if(bPendingPipi)
        {
            //shoot pipi
            bPendingPipi = false;
            Pipi.GetComponent<Rigidbody2D>().angularVelocity = 0f;
            ShootingVelPipi.x = Pipi.transform.right.x;
            ShootingVelPipi.y = Pipi.transform.right.y;
            Pipi.GetComponent<Rigidbody2D>().AddForce(ShootingVelPipi*speed,ForceMode2D.Impulse);
        }

        //Slomo
        if((bPendingPipi||bPendingHead)&&!bIsSlomo){
            bIsSlomo = true;
            Time.timeScale = SlomoDilation;
            Time.fixedDeltaTime = savedFixedDeltaTime*SlomoDilation;
        }else if(!(bPendingPipi||bPendingHead)&&bIsSlomo){
            bIsSlomo = false;
            Time.timeScale = 1.0f;
            Time.fixedDeltaTime = savedFixedDeltaTime;
        }
        Dist = (Head.transform.TransformPoint(HeadPivot)-Pipi.transform.TransformPoint(PipiPivot)).magnitude;
        if(Dist<JointAffectMinDist && Joint.enabled == true)
        {
            Joint.enabled = false;
        }
        else if(Dist>=JointAffectMinDist && Joint.enabled == false)
        {
            Joint.enabled = true;
        }
    }
 
}

