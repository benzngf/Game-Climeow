using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShowFinalScore : MonoBehaviour
{
    public GameObject ScorePanel;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        ScorePanel.SetActive(false);
        this.enabled = false;
    }
    private void OnEnable() {
        GetComponent<Text>().text = "0";
        if(ScoreManager.Manager)
            GetComponent<Text>().DOText(""+ScoreManager.Manager.CurScore,3.0f,false,ScrambleMode.Numerals);
        ScorePanel.transform.localScale = Vector3.zero;
        ScorePanel.transform.DOScale(1.0f,0.3f);
    }

    public void Confirm(){
        ScorePanel.transform.DOScale(0.0f,0.36f).OnComplete(()=>{
            ScorePanel.SetActive(false);
            this.enabled = false;
        });
    }
}
