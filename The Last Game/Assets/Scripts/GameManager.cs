using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
<<<<<<< HEAD
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
=======

public class GameManager : MonoBehaviour
{
    public QuestManager questManager;
    public Image portraitImg;
    public Animator portraitAnim;
    public Sprite prevPortrait;
    public TalkManager talkManager;
    public Animator talkPanel;
    public TypeEffect talk;
    public GameObject scanObject;
    public GameObject menuSet;
    public GameObject player;
    public bool isAction;
    public int talkIndex;
    public TextMeshProUGUI charNameText;
    public TextMeshProUGUI questText;
    public ObjData obj;

    private void Start()
    {
        if(!PlayerPrefs.HasKey("PlayerX"))
            return;
        GameLoad();
        questText.text = questManager.CheckQuest();
    }

    void Update()
    {
        //Submenu
        if(Input.GetButtonDown("Cancel"))
        {
            if(menuSet.activeSelf)
            menuSet.SetActive(false);
            else
            menuSet.SetActive(true);
        }
    }

    // Update is called once per frame
    public void Action(GameObject scanObj)
    {
        isAction = true;
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        Talk(objData.id,objData.isNpc);
        talkPanel.SetBool("isShow",isAction);
    }

    public void Talk(int id, bool isNpc)
    {
        int questTalkIndex=0;
        string talkData ="";
         //Set Talk Data
        if(talk.isAnimation){
            talk.SetMsg("");
            return;
        }
        else{
            questTalkIndex = questManager.GetQuestTalkIndex(id);
            talkData  = talkManager.GetTalk(id+questTalkIndex,talkIndex);
        }

        //End Talk
        if(talkData == null){
            isAction = false;
            talkIndex  =0;
            questText.text = questManager.CheckQuest(id);
            return;
        }

        if(isNpc){
            //Char Name Text
            if(id==1000)
                charNameText.text = "루도";
            else if(id==2000)
                charNameText.text = "루나";
            talk.SetMsg(talkData.Split(':')[0]);

            //Show Portrait
            portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1]));
            portraitImg.color = new Color(1,1,1,1);
            //Animation Potrait
            if(prevPortrait != portraitImg.sprite){
                portraitAnim.SetTrigger("doEffect");
                prevPortrait = portraitImg.sprite;
            }
        }
        else{
            charNameText.text = "루나";
            talk.SetMsg(talkData);
            portraitImg.color = new Color(1,1,1,0);
        }
        isAction = true;
        talkIndex++;
    }


    public void GameSave()
    {
        PlayerPrefs.SetFloat("PlayerX",player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY",player.transform.position.y);
        PlayerPrefs.SetInt("QustId",questManager.questId);
        PlayerPrefs.SetInt("QustActionIndex",questManager.questActionIndex);
        PlayerPrefs.Save();

        menuSet.SetActive(false);

    }

    public void GameLoad()
    {
        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");
        int questId = PlayerPrefs.GetInt("QustId");
        int questActionIndex = PlayerPrefs.GetInt("QustActionIndex");

        player.transform.position = new Vector3(x,y,0);
        questManager.questId = questId;
        questManager.questActionIndex = questActionIndex;
        questManager.ControlObject();
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void GameReset()
    {
        float x = 0;
        float y = 0;
        int questId = 0;
        int questActionIndex = 0;
        player.transform.position = new Vector3(x,y,0);
        questManager.questId = questId;
        questManager.questActionIndex = questActionIndex;
        questManager.ControlObject();
    }

>>>>>>> parent of b518b49 (scripts move)
}
