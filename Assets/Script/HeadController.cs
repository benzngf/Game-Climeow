using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadController : MonoBehaviour
{
    public SpriteRenderer HeadSprite;
    public Sprite NormalHead;
    public Sprite CollideHead;
    // Start is called before the first frame update
    public float CollidingHeadTime;
    private float CountTime;
    private bool usingColHead = false;
    private void OnCollisionEnter2D(Collision2D other) {
        CountTime = CollidingHeadTime;
        if(!usingColHead)
        {
            HeadSprite.sprite = CollideHead;
            usingColHead = true;
        }
    }
    void Update()
    {
        if(usingColHead){
            CountTime-=Time.deltaTime;
            if(CountTime<=0f)
            {
                HeadSprite.sprite = NormalHead;
                usingColHead = false;
            }
        }
    }
}
