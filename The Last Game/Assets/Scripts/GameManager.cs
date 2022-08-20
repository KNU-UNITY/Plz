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


    void Start()
     {
         GameLoad();
        //questText.text = questManager.CheckQuest();

        if (SceneManager.GetActiveScene().name == "Buk Mun")
        {
            float x = 0;
            float y = -6.5f;
            player.transform.position = new Vector3(x, y, 0);

        }
        else if (SceneManager.GetActiveScene().name == "Jeong Mun")
        {
            float x = 0;
            float y = 7f;
            player.transform.position = new Vector3(x, y, 0);

        }
        else if (SceneManager.GetActiveScene().name == "Seo Mun")
        {
            float x = 9.5f;
            float y = 0f;
            player.transform.position = new Vector3(x, y, 0);

        }
        else if (SceneManager.GetActiveScene().name == "Dong Mun")
        {
            float x = -10f;
            float y = 0f;
            player.transform.position = new Vector3(x, y, 0);

        }


    }

    private void Update()
    {
        //Sub Menu
        if (Input.GetButtonDown("Cancel"))
        {
            if (menuSet.activeSelf)
                menuSet.SetActive(false);
            else
                menuSet.SetActive(true);
        }

    }



    public void GameSave()
     {
         PlayerPrefs.SetFloat("PlayerX",player.transform.position.x);
         PlayerPrefs.SetFloat("PlayerY",player.transform.position.y);
         PlayerPrefs.SetInt("Coin",Coin);
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
        if (SceneManager.GetActiveScene().name == "Buk Mun")
        {
            SceneManager.LoadScene("Main Map");
        }
        if (SceneManager.GetActiveScene().name == "Jeong Mun")
        {
            SceneManager.LoadScene("Main Map");
        }
        if (SceneManager.GetActiveScene().name == "Dong Mun")
        {
            SceneManager.LoadScene("Main Map");
        }
        if (SceneManager.GetActiveScene().name == "Seo Mun")
        {
            SceneManager.LoadScene("Main Map");
        }
         float x = 0;
         float y = -3.0f;
         //int questId = 0;
         int coin = 0;
         //int questActionIndex = 0;
         player.transform.position = new Vector3(x,y,0);
        
        //  questManager.questId = questId;
        //  questManager.questActionIndex = questActionIndex;
        //  questManager.ControlObject();
        Time.timeScale = 1;
     }

}

