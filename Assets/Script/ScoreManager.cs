using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Manager;
    public int CurScore;
    private Text scoreText;
    public Text comboText;
    public float CurCombo;
    public float CurComboTimeout;

    public bool CountingCombo;
    // Start is called before the first frame update
    void Start()
    {
        Manager = this;
        scoreText = GetComponent<Text>();
        CurCombo = 1.0f;
        CurScore = 0;
    }

    public void ResetScore(){
        SetScore(0,false,false);
        SetCombo(1.0f,-1.0f,false);
    }
    public void SetScore(int Score, bool CountCombo = true, bool Additive = true){
        if(Additive) CurScore = CurScore + Mathf.FloorToInt(Score * ((CountCombo)? CurCombo:1.0f));
        else CurScore = Mathf.FloorToInt(Score * ((CountCombo)? CurCombo:1.0f));
        scoreText.DOText(""+CurScore,0.5f,false,ScrambleMode.Numerals);
        //scoreText.transform.DOPunchPosition(Vector3.up*10f,0.2f);
    }
    public void SetCombo(float Combo, float ComboTimeout, bool Additive = true){
        //comboText.transform.DOPunchPosition(Vector3.right*(-20f),0.2f);
        if(ComboTimeout>0f)
        {
            CountingCombo = true;
            CurComboTimeout = ComboTimeout;
        }else{
            CountingCombo = false;
        }
        if(Additive) CurCombo+=Combo;
        else CurCombo = Combo;
        comboText.text = "Combo x"+CurCombo.ToString("F1");
    }
    private void Update() {
        if(CountingCombo)
        {
            CurComboTimeout-=Time.unscaledDeltaTime;
            if(CurComboTimeout<=0f){
                SetCombo(1.0f,-1.0f,false);
            }
        }
    }
}
