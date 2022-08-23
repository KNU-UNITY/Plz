using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int,Sprite> portraitData;

    public Sprite[] portraitArr;

    // Start is called before the first frame update
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData(); 
    }

    void GenerateData()
    {
        //Talk Data
        //ObjIId ->Dong: 100, Seo : 200, Jeong : 300, Buk 400
        talkData.Add(100, new string[]{"동문으로 가는 포탈이라고 적혀 있다."});
        talkData.Add(200, new string[]{"서문으로 가는 포탈이라고 적혀 있다."});
        talkData.Add(300, new string[]{"정문으로 가는 포탈이라고 적혀 있다."});
        talkData.Add(400, new string[]{"북문으로 가는 포탈이라고 적혀 있다."});

    }

    public string GetTalk(int id, int talkIndex)
    {
        if(!talkData.ContainsKey(id)){
            if(!talkData.ContainsKey(id-id%10))
                return GetTalk(id-id%100,talkIndex); //Get first Talk
            else
                return GetTalk(id-id%10,talkIndex) ; //Get First Quest Talk
        }
        if(talkIndex == talkData[id].Length)
            return null;
            else
            return talkData[id][talkIndex];
    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id+portraitIndex];
    }
}
