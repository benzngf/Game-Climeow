using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScreenInputLayer : MonoBehaviour
{
    Rect headZone;
    Rect pipiZone;
    public static bool TouchingHead;
    public static bool TouchingPipi;
    bool TouchControl;
    // Start is called before the first frame update
    void Start()
    {
        headZone = new Rect(0, 0, Screen.width*0.5f, Screen.height);
        pipiZone = new Rect(Screen.width*0.5f, 0, Screen.width*0.5f, Screen.height);
        if(Application.platform == RuntimePlatform.Android)
        {
            TouchControl = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        TouchingHead = false;
        TouchingPipi = false;
        if(TouchControl)
        {
            foreach (Touch t in Input.touches)
            {
                if(headZone.Contains(t.position))
                {
                TouchingHead = true;
                }
                if(pipiZone.Contains(t.position))
                {
                    TouchingPipi = true;
                }
            }
        }else{
            TouchingHead = Input.GetKey(KeyCode.Mouse0);
            TouchingPipi = Input.GetKey(KeyCode.Mouse1);
        }
    }
}
