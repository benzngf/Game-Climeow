using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public MouseControllerV2 CatControl;
    public GameObject FinalScore;
    public GameObject Breakables;
    public int gameTime;
    public GameTimer gameTimer;
    public static GameFlow GF;
    public bool inGame;

    // Start is called before the first frame update
    void Start()
    {
        CatControl.enabled = false;
        inGame = false;
        GF = this;
    }
    public void StartGame(){
        gameObject.SetActive(false);
        CatControl.enabled = true;
        foreach(BreakpointBase bb in Breakables.GetComponentsInChildren<BreakpointBase>()){
            bb.SetNextSprite(true);
        }
        gameTimer.StartCount(gameTime);
        inGame = true;
        ScoreManager.Manager.ResetScore();
        CatControl.gameObject.GetComponent<RevertCat>().ResetCat();
    }
    public void EndGame(){
        gameObject.SetActive(true);
        CatControl.enabled = false;
        GlobalSlomo.Manager.UserSetSlomo(false);
        FinalScore.SetActive(true);
        FinalScore.GetComponentInChildren<ShowFinalScore>().enabled = true;
        inGame = false;
    }
}
