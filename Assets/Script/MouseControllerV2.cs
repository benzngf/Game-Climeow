using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControllerV2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Head;
    public ParticleSystem HeadPendingP;
    public GameObject Pipi;
    public ParticleSystem PipiPendingP;
    public float speed;
    public float rotSpeed;
    private Vector2 ShootingVelHead;
    private Vector2 ShootingVelPipi;
    private bool bPendingHead, bPendingPipi;
    public Vector3 HeadPivot;
    public Vector3 PipiPivot;
    public SpringJoint2D Joint;
    public float JointAffectMinDist;
    private float Dist;

    public AudioSource ShootSound;
    public AudioSource SpinSound;
    void Start()
    {
        ShootingVelHead = new Vector2(0,0);
        ShootingVelPipi = new Vector2(0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if(TouchScreenInputLayer.TouchingHead)
        {
            //Head
            if(!bPendingHead)
            {
                bPendingHead = true;
                Head.GetComponent<Rigidbody2D>().angularVelocity = 0f;
                HeadPendingP.Play();
            }
            else
            {
                Head.transform.RotateAround(Head.transform.TransformPoint(HeadPivot),Vector3.forward,Time.deltaTime*rotSpeed/GlobalSlomo.Manager.UserControlledSlomoVal);
            }
        }else if(bPendingHead)
        {
            //shoot head
            bPendingHead = false;
            Head.GetComponent<Rigidbody2D>().angularVelocity = 0f;
            ShootingVelHead.x = -Head.transform.right.x;
            ShootingVelHead.y = -Head.transform.right.y;
            Head.GetComponent<Rigidbody2D>().AddForce(ShootingVelHead*speed,ForceMode2D.Impulse);
            ShootSound.Play();
            HeadPendingP.Stop();
        }
        if(TouchScreenInputLayer.TouchingPipi)
        {
            //Pipi
            if(!bPendingPipi)
            {
                bPendingPipi = true;
                Pipi.GetComponent<Rigidbody2D>().angularVelocity = 0f;
                PipiPendingP.Play();
            }
            else
            {
                Pipi.transform.RotateAround(Pipi.transform.TransformPoint(PipiPivot),Vector3.forward,Time.deltaTime*rotSpeed/GlobalSlomo.Manager.UserControlledSlomoVal);
            }
        }else if(bPendingPipi)
        {
            //shoot pipi
            bPendingPipi = false;
            Pipi.GetComponent<Rigidbody2D>().angularVelocity = 0f;
            ShootingVelPipi.x = Pipi.transform.right.x;
            ShootingVelPipi.y = Pipi.transform.right.y;
            Pipi.GetComponent<Rigidbody2D>().AddForce(ShootingVelPipi*speed,ForceMode2D.Impulse);
            ShootSound.Play();
            PipiPendingP.Stop();
        }

        //Slomo
        if((bPendingPipi||bPendingHead)&&!GlobalSlomo.Manager.UserSlomoing){
            GlobalSlomo.Manager.UserSetSlomo(true);
            SpinSound.Play();
        }else if(!(bPendingPipi||bPendingHead)&&GlobalSlomo.Manager.UserSlomoing){
            GlobalSlomo.Manager.UserSetSlomo(false);
            SpinSound.Stop();
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

