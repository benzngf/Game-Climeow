using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinChanger : MonoBehaviour
{
    [System.Serializable]
    public struct Meow{
        public Sprite Text,Thumbnail;
        public Sprite Head, Head2, Pipi;
        public Texture2D Body;
    }
    public List<Meow> MeowData;
    public Sprite Head, Head2, Pipi;
    public Texture2D Body;
    public SpriteRenderer HeadSprite,PipiSprite;
    public Material BodyMaterial;
    public Image MeowThumb;
    public Image MeowText;
    public int CurSkinIndex;
    HeadController HC;
    public void SetSkin(Sprite newHead,Sprite newHead2,Texture2D newBody,Sprite newPipi){
        Head = newHead;
        Head2 = newHead2;
        Body = newBody;
        Pipi = newPipi;
        RefreshSkin();
    }
    public void SetSkin(int index){
        if(index>=0 && index<MeowData.Count)
        {
            SetSkin(MeowData[index].Head,MeowData[index].Head2,MeowData[index].Body,MeowData[index].Pipi);
            if(MeowThumb)MeowThumb.sprite = MeowData[index].Thumbnail;
            if(MeowText)MeowText.sprite = MeowData[index].Text;
            CurSkinIndex = index;
        }
    }
    public void ToggleNextSkin()
    {
        SetSkin((CurSkinIndex+1)%MeowData.Count);
    }
    public void TogglePrevSkin()
    {
        SetSkin((CurSkinIndex-1+MeowData.Count)%MeowData.Count);
    }
    public void RefreshSkin(){
        if(Head&&Head2&&Body&&Pipi)
        {
            if(HeadSprite&&PipiSprite&&BodyMaterial)
            {
                HeadSprite.sprite = Head;
                PipiSprite.sprite = Pipi;
                BodyMaterial.mainTexture = Body;
                HC = GetComponentInChildren<HeadController>();
                HC.NormalHead = Head;
                HC.CollideHead = Head2;
            }
        }
    }
    private void Start() {
        SetSkin(CurSkinIndex);
    }
}

