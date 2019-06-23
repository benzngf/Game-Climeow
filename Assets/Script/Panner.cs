using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Panner : MonoBehaviour
{
    RawImage Img;
    float offset = 0f;
    Rect r;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Img = GetComponent<RawImage>();
        r = new Rect(offset,0,1,1);
    }

    // Update is called once per frame
    void Update()
    {
        offset = (offset+Time.deltaTime*speed)%1.0f;
        r.x = offset;
        Img.uvRect = r;
        //Debug.Log(""+offset);
    }
}
