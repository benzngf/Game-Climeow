using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SkinChanger : MonoBehaviour
{
    public Sprite Head, Head2, Pipi;
    public Texture2D Body;
    public SpriteRenderer HeadSprite,PipiSprite;
    public Material BodyMaterial;
    public void SetSkin(Sprite newHead,Sprite newHead2,Texture2D newBody,Sprite newPipi){
        Head = newHead;
        Head2 = newHead2;
        Body = newBody;
        Pipi = newPipi;
        RefreshSkin();
    }
    public void RefreshSkin(){
        if(Head&&Head2&&Body&&Pipi)
        {
            if(HeadSprite&&PipiSprite&&BodyMaterial)
            {
                HeadSprite.sprite = Head;
                PipiSprite.sprite = Pipi;
                BodyMaterial.mainTexture = Body;
            }
        }
    }
}

