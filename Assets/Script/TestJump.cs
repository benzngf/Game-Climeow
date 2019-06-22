using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestJump : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D Head;
    public Rigidbody2D Pipi;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Pipi.AddForce(new Vector2(Random.Range(-2,2),10),ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.Slash))
        {
            Head.AddForce(new Vector2(Random.Range(-2,2),10),ForceMode2D.Impulse);
        }
    }
}
