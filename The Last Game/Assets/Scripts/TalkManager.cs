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
<<<<<<< HEAD
        //ObjIId ->Dong: 100, Seo : 200, Jeong : 300, Buk 400
        talkData.Add(100, new string[]{"동문으로 가는 포탈이라고 적혀 있다."});
        talkData.Add(200, new string[]{"서문으로 가는 포탈이라고 적혀 있다."});
        talkData.Add(300, new string[]{"정문으로 가는 포탈이라고 적혀 있다."});
        talkData.Add(400, new string[]{"북문으로 가는 포탈이라고 적혀 있다."});
=======
        //Ludo : 1000 , Luna : 2000
        //Box : 100, Desk : 200
        talkData.Add(1000, new string[]{"안녕?:0","이 곳에 처음 왔구나?:1"});
        talkData.Add(2000,new string[]{"여어.:2","저 책상에 적혀 있는 글씨를 봤니?:3"});
        talkData.Add(100, new string[]{"평범한 나무상자다."});
        talkData.Add(200, new string[]{"누군가 사용했던 흔적이 있는 책상이다."});


        //Quest Talk
         talkData.Add(10 + 1000, new string[]{"어서와.:0","이 마을에 놀라운 전설이 있다는데:1","오른쪽 호수 쪽에 루나가 알려줄거야.:2"});
         talkData.Add(11 + 2000, new string[]{"여어.:0","이 호수의 전설을 들으러 온거야?:1","그럼 일 좀 하나 해주면 좋을텐데...:2","내 집 근처에 떨어진 동전 좀 주워줬으면 해:2"});
         talkData.Add(20 + 1000, new string[]{"루나의 동전?:1",
                                                                        "돈을 흘리고 다니면 못쓰지!:3",
                                                                        "나중에 루나에게 한마디 해야겠어.:3"});
         talkData.Add(20 + 2000, new string[]{"아직 못찾은거야?"});             
         talkData.Add(20 + 5000, new string[]{"근처에서 동전을 찾았다."});
         talkData.Add(21 + 2000, new string[]{"엇, 찾아줘서 고마워.:2"});                                                      
        //Portrait Data
        //0: Normal, 1: Smile, 2: Talk, 3: Angry
        portraitData.Add(2000+0,portraitArr[0]);
        portraitData.Add(2000+1,portraitArr[1]);
        portraitData.Add(2000+2,portraitArr[2]);
        portraitData.Add(2000+3,portraitArr[3]);
        portraitData.Add(1000+0,portraitArr[4]);
        portraitData.Add(1000+1,portraitArr[5]);
        portraitData.Add(1000+2,portraitArr[6]);
        portraitData.Add(1000+3,portraitArr[7]);
>>>>>>> parent of b518b49 (scripts move)

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