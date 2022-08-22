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
    
    //Shop
    public int Coin;
    public int[] itemsCount;
    public int[] ItemPrice;
    //UI
    public TextMeshProUGUI coin;
    public TextMeshProUGUI[] count;
     void Start()
     {
         GameLoad();
         //questText.text = questManager.CheckQuest();
     }

    public void Update()
    {
        coin.text = Coin.ToString();
        count[0].text = "X " + itemsCount[0].ToString();
        count[1].text = "X " + itemsCount[1].ToString();
        count[2].text = "X " + itemsCount[2].ToString();
        count[3].text = "X " + itemsCount[3].ToString();
    }
    public void GameSave()
     {
         PlayerPrefs.SetFloat("PlayerX",player.transform.position.x);
         PlayerPrefs.SetFloat("PlayerY",player.transform.position.y);
         PlayerPrefs.SetInt("Coin", Coin);
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
         int coin = PlayerPrefs.GetInt("Coin");
         //int questId = PlayerPrefs.GetInt("QustId");
         //int questActionIndex = PlayerPrefs.GetInt("QustActionIndex");
         Coin = coin;
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
         float x = 0;
         float y = 0;
         //int questId = 0;
         int coin = 0;
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
            Coin -= price;
            itemsCount[index]++;
            coin.text = Coin.ToString();
            count[index].text = "X " + itemsCount[index].ToString();
        }
        
    }
}
