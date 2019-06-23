using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticleOnCollide : MonoBehaviour
{
    public ParticleSystem PS;
    // Start is called before the first frame update
    void Start()
    {
        if(!PS){
            PS = GetComponentInChildren<ParticleSystem>();
        }
        if(PS){
            PS.gameObject.transform.parent = null;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(PS){
            PS.gameObject.transform.position = other.GetContact(0).point;
            PS.Play();
        }
    }
}
