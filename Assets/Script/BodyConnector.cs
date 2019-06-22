using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SplineMesh;

[ExecuteAlways]
public class BodyConnector : MonoBehaviour
{
    public SplineMesh.Spline Body;
    public Transform Head;
    public Transform Pipi;
    public float offsetSize;
    private float len;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Body && Head && Pipi)
        {
            len = (Pipi.localPosition - Head.localPosition).magnitude;
            Body.nodes[0].Position = Pipi.localPosition-(Pipi.right*offsetSize);
            Body.nodes[0].Direction = Body.nodes[0].Position-(Pipi.right*len*0.3f);
            Body.nodes[1].Position = Head.localPosition+(Head.right*offsetSize);
            Body.nodes[1].Direction = Body.nodes[1].Position-(Head.right*len*0.3f);
        }
        if (!Application.IsPlaying(gameObject))
        {
            // Play logic
            if(Body)
                Body.ManualUpdateInEditor();
        }
    }
}
