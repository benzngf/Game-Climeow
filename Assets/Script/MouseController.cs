using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Head;
    public GameObject Pipi;
    public float speed;
    private bool bControllingHead = true;
    private bool bCursorLocked;
    private Vector3 deltaMovement;
    void Start()
    {
        deltaMovement = new Vector3(0,0,0);
        SetCursorLockState(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            bControllingHead = !bControllingHead;
            /*if(bControllingHead){
                Head.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
                Pipi.GetComponent<Rigidbody2D>().gravityScale = 1f;
            }else{
                Pipi.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
                Head.GetComponent<Rigidbody2D>().gravityScale = 1f;
            }*/
        }
        deltaMovement.x = Input.GetAxis("Mouse X");
        deltaMovement.y = Input.GetAxis("Mouse Y");
        if(bControllingHead){
            Head.transform.position += deltaMovement*speed*Time.deltaTime;
        }else{
            Pipi.transform.position += deltaMovement*speed*Time.deltaTime;
        }
        //lock and hide cursor
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           SetCursorLockState(!bCursorLocked);
        }
    }
    void SetCursorLockState(bool Locked)
    {
        if(Locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        bCursorLocked = Locked;
    }
}
