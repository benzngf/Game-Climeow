using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSlomo : MonoBehaviour
{
    public float UserControlledSlomoVal;
    public float GlobalSlomoVal;

    public bool UserSlomoing = false;
    public bool GlobalSlomoing = false;
    private float savedFixedDeltaTime;
    public static GlobalSlomo Manager;
    public Component LastGlobalSetter;
    // Start is called before the first frame update
    void Start()
    {
        Manager = this;
        savedFixedDeltaTime = Time.fixedDeltaTime;
    }

    public void UserSetSlomo(bool IsSlomo){
        UserSlomoing = IsSlomo;
        if(UserSlomoing){
            if(GlobalSlomoing)
            {
                SetSlomo(Mathf.Min(UserControlledSlomoVal,GlobalSlomoVal));
            }else
            {
                SetSlomo(UserControlledSlomoVal);
            }
        }else{
            if(GlobalSlomoing)
            {
                SetSlomo(GlobalSlomoVal);
            }else
            {
                SetSlomo(1.0f);
            }
        }
    }
    public void GlobalSetSlomo(bool IsSlomo, Component Setter){
        GlobalSlomoing = IsSlomo;
        if(IsSlomo) LastGlobalSetter = Setter;
        
        if(GlobalSlomoing){
            if(UserSlomoing)
            {
                SetSlomo(Mathf.Min(UserControlledSlomoVal,GlobalSlomoVal));
            }else
            {
                SetSlomo(GlobalSlomoVal);
            }
        }else{
            if(UserSlomoing)
            {
                SetSlomo(UserControlledSlomoVal);
            }else
            {
                SetSlomo(1.0f);
            }
        }
    }
    void SetSlomo(float SlomoDilation){
        Time.timeScale = SlomoDilation;
        Time.fixedDeltaTime = savedFixedDeltaTime*SlomoDilation;
    }
}
