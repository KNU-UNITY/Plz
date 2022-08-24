using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    public static GameManager control;
    public int cnt = 0;
    //퀘스트 쓸거면 아래 주석 해제하면 됨.
    //public QuestManager questManager;
    public GameObject scanObject;
    public GameObject player;
    public GameObject menuSet; 

    //Shop
    public int Coin;
    public int[] itemsCount;
    

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if(control == null)
        {
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }

        
        Coin = PlayerPrefs.GetInt("Coin", 99999);
    }
    void Start()
     {
        GameLoad();
        //questText.text = questManager.CheckQuest();

        // 맵 들어올 때 초기 위치 설정
    }

    private void Update()
    {

        //Sub Menu
        if (Input.GetButtonDown("Cancel"))
        {
            if (menuSet.activeSelf)
            {
                menuSet.SetActive(false);
                Time.timeScale = 1;
            }

            else{
                menuSet.SetActive(true);
                Time.timeScale = 0;
                }        
            }

    }



    public void GameSave()
     {
        
         PlayerPrefs.SetFloat("PlayerX",player.transform.position.x);
         PlayerPrefs.SetFloat("PlayerY",player.transform.position.y);
         PlayerPrefs.SetInt("Coin",Coin);

        if (SceneManager.GetActiveScene().name == "EastShop")
        {
            for (int i = 0; i < 5; i++)
            {
                PlayerPrefs.SetInt("itemsCount" + i, itemsCount[i]);
            }

        }
        

            //  PlayerPrefs.SetInt("QustId",questManager.questId);
            //  PlayerPrefs.SetInt("QustActionIndex",questManager.questActionIndex);
            PlayerPrefs.Save();
         menuSet.SetActive(false);
         Time.timeScale = 1;

        if (SceneManager.GetActiveScene().name == "Buk Mun")
        {
            cnt = 1;
           
        }
        if (SceneManager.GetActiveScene().name == "Dong Mun")
        {
            cnt = 2;
        }
        if (SceneManager.GetActiveScene().name == "Seo Mun")
        {
            cnt = 3;
        }
        if (SceneManager.GetActiveScene().name == "Jeong Mun")
        {
            cnt = 4;
        }

    }

     public void GameLoad()
     {
        
        if(!PlayerPrefs.HasKey("PlayerX")) return;
       
         float x = PlayerPrefs.GetFloat("PlayerX");
         float y = PlayerPrefs.GetFloat("PlayerY");
         PlayerPrefs.GetInt("Coin");

        if (SceneManager.GetActiveScene().name == "EastShop")
        {
            for (int i = 0; i < 5; i++)
            {
                itemsCount[i] = PlayerPrefs.GetInt("itemsCount" + i);
            }
        }
         player.transform.position = new Vector3(x,y,0);
        //int questId = PlayerPrefs.GetInt("QustId");
        //int questActionIndex = PlayerPrefs.GetInt("QustActionIndex");

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
        cnt = 0; 
        if (SceneManager.GetActiveScene().name == "Buk Mun")
        {
            location();
        }
        if (SceneManager.GetActiveScene().name == "Jeong Mun")
        {
            location();
        }
        if (SceneManager.GetActiveScene().name == "Dong Mun")
        {
            location();
        }
        if (SceneManager.GetActiveScene().name == "Seo Mun")
        {
            location();
        }
        PlayerPrefs.DeleteKey("ItemsCount");
        
        if (SceneManager.GetActiveScene().name == "Main Map")
        {
            float x = 0;
            float y = -3.0f;
            player.transform.position = new Vector3(x, y, 0);
        }

        for (int i = 0; i < 5; i++)
        {
            itemsCount[i] = 0; 
        }
        PlayerPrefs.GetInt("itemsCount");

        Coin = 99999;
        PlayerPrefs.GetInt("Coin");

        //int questId = 0;

        //int questActionIndex = 0;
        
        
        //  questManager.questId = questId;
        //  questManager.questActionIndex = questActionIndex;
        //  questManager.ControlObject();
        Time.timeScale = 1;
     }








    public void SceneChange_Buk()
    {
        SceneManager.LoadScene("Buk Mun");
    }

    public void location()
    {
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
}

