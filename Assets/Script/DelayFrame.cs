using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 public class Trans
 {
 
     public Vector3 position;
     public Quaternion rotation;
     public Vector3 localScale;
     public Trans (Vector3 newPosition, Quaternion newRotation, Vector3 newLocalScale)
     {
         position = newPosition;
         rotation = newRotation;
         localScale = newLocalScale;
     }
 
     public Trans ()
     {
         position = Vector3.zero;
         rotation = Quaternion.identity;
         localScale = Vector3.one;
     }
 
     public Trans (Transform transform)
     {
         copyFrom (transform);
     }
 
     public void copyFrom (Transform transform)
     {
         position = transform.position;
         rotation = transform.rotation;
         localScale = transform.localScale;
     }
 
     public void copyTo (Transform transform)
     {
         transform.position = position;
         transform.rotation = rotation;
         transform.localScale = localScale;
     }
 
 }
[ExecuteAlways]
public class DelayFrame : MonoBehaviour
{
    public Transform FollowedTransform;
    private Trans CachedTransform;
    // Start is called before the first frame update
    void Start()
    {
        CachedTransform = new Trans();
        if(FollowedTransform){
            CachedTransform.copyFrom(FollowedTransform);
            CachedTransform.copyTo(gameObject.transform);
        }else{
            CachedTransform.copyFrom(gameObject.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(FollowedTransform){
            if (Application.IsPlaying(gameObject))
            {
                CachedTransform.copyTo(gameObject.transform);
                CachedTransform.copyFrom(FollowedTransform);
            }
            else
            {
                gameObject.transform.position = FollowedTransform.position;
                gameObject.transform.rotation = FollowedTransform.rotation;
                gameObject.transform.localScale = FollowedTransform.localScale;
            }
        }
    }
}
