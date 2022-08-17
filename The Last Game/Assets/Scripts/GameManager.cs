using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public QuestManager questManager;
    public GameObject scanObject;

    //Shop
    public int Coin;
    public int[] itemsCount;

    // void Start()
    // {
    //     GameLoad();
    //     questText.text = questManager.CheckQuest();
    // }


    

    // public void GameSave()
    // {
    //     PlayerPrefs.SetFloat("PlayerX",player.transform.position.x);
    //     PlayerPrefs.SetFloat("PlayerY",player.transform.position.y);
    //     PlayerPrefs.SetInt("QustId",questManager.questId);
    //     PlayerPrefs.SetInt("QustActionIndex",questManager.questActionIndex);
    //     PlayerPrefs.Save();
    //     menuSet.SetActive(false);
    //     Time.timeScale = 1;
    // }

    // public void GameLoad()
    // {
    //     if(!PlayerPrefs.HasKey("PlayerX")) return;
    //     float x = PlayerPrefs.GetFloat("PlayerX");
    //     float y = PlayerPrefs.GetFloat("PlayerY");
    //     int questId = PlayerPrefs.GetInt("QustId");
    //     int questActionIndex = PlayerPrefs.GetInt("QustActionIndex");

    //     player.transform.position = new Vector3(x,y,0);
    //     questManager.questId = questId;
    //     questManager.questActionIndex = questActionIndex;
    //     questManager.ControlObject();
    // }

    // public void GameExit()
    // {
    //     Application.Quit();
    // }

    // public void GameReset()
    // {
    //     float x = 0;
    //     float y = 0;
    //     int questId = 0;
    //     int questActionIndex = 0;
    //     player.transform.position = new Vector3(x,y,0);
    //     questManager.questId = questId;
    //     questManager.questActionIndex = questActionIndex;
    //     questManager.ControlObject();
    //     Time.timeScale = 1;
    // }
}
