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
    public int[] itemsCount = new int[4];  //[포션 전체 개수, 쉴드, 파워업, 폭탄]
    public int[] ItemPrice;
    public int upgradeCount; //무기 업그레이드 횟수
    public int[] potionCount = new int[4]; //문 별 회복포션 개수

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
             case "Dong Desk": talkText.text = "동문으로 가는 포탈이라고 적혀 있다."; break;
             case "Seo Desk": talkText.text = "서문으로 가는 포탈이라고 적혀 있다."; break;
             case "Jeong Desk": talkText.text = "정문으로 가는 포탈이라고 적혀 있다."; break;
             case "Buk Desk": talkText.text = "북문으로 가는 포탈이라고 적혀 있다."; break;
         }

         Invoke("SetUnactive",1.5f);
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
        for (int i = 0; i < 4; i++)
        {
            itemsCount[i] = PlayerPrefs.GetInt("itemsCount" + i);
        }
        count[0].text = "X " + itemsCount[0].ToString();
        count[1].text = "X " + itemsCount[1].ToString();
        count[2].text = "X " + itemsCount[2].ToString();
        count[3].text = "X " + itemsCount[3].ToString();
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
        for(int i = 0; i < 4; i++)
        {
            PlayerPrefs.SetInt("itemsCount" + i, itemsCount[i]);
        }
        for (int i = 0; i < 4; i++)
        {
            PlayerPrefs.SetInt("potionCount" + i, potionCount[i]);
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
    
    //포션 구매
    public void BuyPotion(int index)
    {
        int price = ItemPrice[0];
        if(Coin >= price)
        {
            PlayerPrefs.SetInt("Coin",Coin - price);
            potionCount[index]++;
            coin.text = Coin.ToString();
            count[index].text = "X " + itemsCount[index].ToString();
        }
    }
}
