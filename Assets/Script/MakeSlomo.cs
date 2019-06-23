using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MakeSlomo : MonoBehaviour
{
    // Start is called before the first frame update
    public float MaxSlomoTime;
    public bool EndGame;
    void Start()
    {
        GlobalSlomo.Manager.GlobalSetSlomo(true,this);
        BGMSource.BGM.DOFade(0.0f,0.01f);
    }
    private void OnDestroy() {
        if(GlobalSlomo.Manager.LastGlobalSetter == this){
            GlobalSlomo.Manager.GlobalSetSlomo(false,this);
            BGMSource.BGM.DOFade(1.0f,0.5f);
        }
        if(EndGame)
        {
            GameFlow.GF.EndGame();
        }
    }
    private void Update() {
        MaxSlomoTime-=Time.unscaledDeltaTime;
        if(MaxSlomoTime<=0) Destroy(this);
    }
    
}
