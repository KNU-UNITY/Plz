using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    //퀘스트 쓸거면 아래 주석 해제하면 됨.
    //public QuestManager questManager;
    public GameObject scanObject;
    public GameObject player;
    public GameObject menuSet;
    public GameObject talkPanel;
    public TalkManager talkManager;
    public int talkPanelAnim;
    public TextMeshProUGUI talkText;
    
    //Shop
    public int Coin;
    public int[] itemsCount = new int[3];  //[포션 전체 개수, 쉴드, 파워업, 폭탄]
    public int[] ItemPrice;
    public int upgradeCount; //무기 업그레이드 횟수
    public Button btn; //업그레이드 버튼
    //UI
    public TextMeshProUGUI coin;
    public TextMeshProUGUI[] count;
     void Start()
     {
         talkPanel.SetActive(false);
         GameLoad();
         //questText.text = questManager.CheckQuest();
     }

//포탈 앞 안내데스크 구현 함수
     public void Action(GameObject scanObj)
     {
         scanObject = scanObj;
         talkPanel.SetActive(true);
         switch(scanObject.name){
             case "Dong Desk": talkText.text = "동문으로 가는 포탈이라고 적혀 있다.\n포탈 앞에서 스페이스 버튼을 눌러보자."; break;
             case "Seo Desk": talkText.text = "서문으로 가는 포탈이라고 적혀 있다.\n포탈 앞에서 스페이스 버튼을 눌러보자."; break;
             case "Jeong Desk": talkText.text = "정문으로 가는 포탈이라고 적혀 있다.\n포탈 앞에서 스페이스 버튼을 눌러보자."; break;
             case "Buk Desk": talkText.text = "북문으로 가는 포탈이라고 적혀 있다.\n포탈 앞에서 스페이스 버튼을 눌러보자."; break;
         }

         Invoke("SetUnactive",1.5f);
     }

     //잠겨 있는 스테이지 및 맵에 들어가려고 할 때 안내 구현 함수
        public void UnlockInfo(string info)
        {
            Debug.Log("UnlockInfo");
            talkPanel.SetActive(true);
            if(info == "stage")
                talkText.text = "이전 스테이지를 클리어해야 열리는 스테이지입니다.";
            else if(info == "map")
                talkText.text = "이전 맵의 스테이지들을 모두 클리어해야 열리는 맵입니다.\n맵의 순서는 동문, 서문, 정문, 북문입니다.";
            Invoke("SetUnactive",2.5f);
        }

     public void SetUnactive(){
         talkPanel.SetActive(false);
     }

    public void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (menuSet.activeSelf)
            {
                menuSet.SetActive(false);
                Time.timeScale = 1;
            }

            else
            {
                menuSet.SetActive(true);
                Time.timeScale = 0;
            }
        }

        Coin = PlayerPrefs.GetInt("Coin");
        coin.text = Coin.ToString();
        for (int i = 0; i < 3; i++)
        {
            itemsCount[i] = PlayerPrefs.GetInt("itemsCount" + i);
        }
        count[0].text = "X " + itemsCount[0].ToString();
        count[1].text = "X " + itemsCount[1].ToString();
        count[2].text = "X " + itemsCount[2].ToString();
        //for (int i = 0; i < 4; i++)
        //{
        //    potionCount[i] = PlayerPrefs.GetInt("potionCount" + i);
        //}
    }
    public void GameSave()
     {
         PlayerPrefs.SetFloat("PlayerX",player.transform.position.x);
         PlayerPrefs.SetFloat("PlayerY",player.transform.position.y);
         PlayerPrefs.SetInt("Coin", Coin);
        for(int i = 0; i < 3; i++)
        {
            PlayerPrefs.SetInt("itemsCount" + i, itemsCount[i]);
        }


        //  PlayerPrefs.SetInt("QustId",questManager.questId);
        //  PlayerPrefs.SetInt("QustActionIndex",questManager.questActionIndex);
        PlayerPrefs.Save();
         menuSet.SetActive(false);
         Time.timeScale = 1;
     }

     public void GameLoad()
     {
         if(!PlayerPrefs.HasKey("PlayerX")) return;
         float x = PlayerPrefs.GetFloat("PlayerX");
         float y = PlayerPrefs.GetFloat("PlayerY");
         
         //int questId = PlayerPrefs.GetInt("QustId");
         //int questActionIndex = PlayerPrefs.GetInt("QustActionIndex");
         player.transform.position = new Vector3(x,y,0);
        //  questManager.questId = questId;
        //  questManager.questActionIndex = questActionIndex;
        //  questManager.ControlObject();
     }

     public void GameExit()
     {
         Application.Quit();
     }

     public void GameReset()
     {
        PlayerPrefs.DeleteAll();
         float x = 0;
         float y = 0;
        //int questId = 0;
        
         //int questActionIndex = 0;
         player.transform.position = new Vector3(x,y,0);
        //  questManager.questId = questId;
        //  questManager.questActionIndex = questActionIndex;
        //  questManager.ControlObject();
         Time.timeScale = 1;
     }

    public void Buy(int index)
    {
        int price = ItemPrice[index];
        if (Coin >= price)  //가진 돈이 충분할 경우
        {
            PlayerPrefs.SetInt("Coin", Coin - price);
            itemsCount[index]++;
            PlayerPrefs.SetInt("itemsCount" + index, itemsCount[index]);
            coin.text = Coin.ToString();
            count[index].text = "X " + itemsCount[index].ToString();
        }
    }

    public void UpgradeClicked()
    {
        int price = ItemPrice[1];
        if(Coin >= price)
        {
            PlayerPrefs.SetInt("upgradeCount",PlayerPrefs.GetInt("upgradeCount")+1);
            PlayerPrefs.SetInt("Coin",Coin - price);
            coin.text = Coin.ToString();
            btn.interactable = false;
        }
    }
}
