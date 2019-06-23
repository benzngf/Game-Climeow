using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevertCat : MonoBehaviour
{
    public GameObject Head;
    public GameObject Pipi;
    Vector3 HeadLoc;
    Vector3 PipiLoc;
    private void Start() {
        HeadLoc = Head.transform.position;
        PipiLoc = Pipi.transform.position;
    }
   public void ResetCat(){
       Head.GetComponent<Collider2D>().enabled = false;
       Pipi.GetComponent<Collider2D>().enabled = false;
       Head.transform.position = HeadLoc;
       Pipi.transform.position = PipiLoc;
       Head.GetComponent<Collider2D>().enabled = true;
       Pipi.GetComponent<Collider2D>().enabled = true;
   }
}
