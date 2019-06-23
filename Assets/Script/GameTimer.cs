using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameTimer : MonoBehaviour
{
    int levelTime;
    float CurTime;
    int CurTimeINT;
    bool Counting;
    Text TimeDisplay;
    // Start is called before the first frame update
    void Start()
    {
        TimeDisplay = GetComponent<Text>();
    }

    public void StartCount(int newLevelTime){
        levelTime = newLevelTime;
        CurTime = newLevelTime;
        Counting = true;
    }
    // Update is called once per frame
    void Update()
    {
        if(Counting)
        {
            CurTime-=Time.unscaledDeltaTime;
            if(CurTime<=0f)
            {
                Counting = false;
                if(GameFlow.GF.inGame)
                    GameFlow.GF.EndGame();
            }else{
                if(Mathf.FloorToInt(CurTime)!=CurTimeINT)
                {
                    CurTimeINT = Mathf.FloorToInt(CurTime);
                    TimeDisplay.text = ""+(CurTimeINT/60).ToString("00")+":"+(CurTimeINT%60).ToString("00");
                }
                
            }
        }
    }
}
