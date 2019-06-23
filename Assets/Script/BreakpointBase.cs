using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BreakpointBase : MonoBehaviour
{
    public List<Sprite> Sprites;
    public List<int> Scores;
    public GameObject DestroyParticle;
    private int CurSpriteInd = -1;
    private Sprite CurSprite;
    SpriteRenderer SRenderer;
    bool CountingBetweenHits = false;
    public AudioClip HitSound;
    public AudioClip BreakSound;

    public bool AddCombo;
    public bool ClearCombo;
    AudioSource AS;
    // Start is called before the first frame update
    void Start()
    {
        SRenderer = GetComponentInChildren<SpriteRenderer>();
        if(SRenderer)
        {
           SetNextSprite(true);
        }
        AS = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        if(GameFlow.GF.inGame)
            OnCollideOrTrigger();
    }
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if(GameFlow.GF.inGame)
            OnCollideOrTrigger();
    }
    private void OnCollideOrTrigger(){
        if(!CountingBetweenHits)
        {
            CountingBetweenHits = true;
            
            if(SRenderer)
            {
                if(SetNextSprite(false))
                {
                    SRenderer.gameObject.transform.DOShakePosition(0.2f,0.2f,10,90f,false,true);
                    if(AS){
                        AS.PlayOneShot(HitSound);
                    }
                    ScoreManager.Manager.SetScore(Scores[CurSpriteInd]);
                    StartCoroutine(HitableDelay(0.2f));
                }
                else
                {
                    //done
                    GetComponent<Collider2D>().enabled = false;
                    if(DestroyParticle) Instantiate(DestroyParticle,gameObject.transform.position,Quaternion.identity);
                    if(AS){
                        AS.PlayOneShot(BreakSound);
                    }
                    ScoreManager.Manager.SetScore(Scores[CurSpriteInd]);
                    if(AddCombo) ScoreManager.Manager.SetCombo(0.2f,5f);
                    if(ClearCombo) ScoreManager.Manager.SetCombo(1.0f,-1.0f,false);
                    CountingBetweenHits = false;
                }
            }
        }
    }
    Sprite GetNextSprite()
    {
        if(Sprites.Count > CurSpriteInd+1)
            return Sprites[CurSpriteInd+1];
        else return null;
    }

    public bool SetNextSprite(bool IsReset)
    {
        if(IsReset){
            CurSpriteInd = -1;
            GetComponent<Collider2D>().enabled = true;
        }
        CurSprite = GetNextSprite();
        if(CurSprite)
        {
            CurSpriteInd++;
            SRenderer.sprite = CurSprite;
            SRenderer.enabled = true;
            SRenderer = GetComponentInChildren<SpriteRenderer>();
            return true;
        }
        else
        {
            SRenderer.enabled = false;
            return false;
        }
    }
    IEnumerator HitableDelay(float time)
    {
        yield return new WaitForSeconds(time);
        // Code to execute after the delay
        CountingBetweenHits = false;
    }
}
