using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageClearCheck : MonoBehaviour
{
    public int [,] stageCheck = new int [4,3];
    
    public GameManager GM;

    //스테이지 클리어하면 1 입력하는 함수
    public void StageCheck(string strnum)
    {
        int stageNum = int.Parse(strnum.Substring(strnum.Length-2));
        int index2 = (stageNum%3)-1;

        Debug.Log(stageNum);

        if(stageNum<=3){
            Debug.Log("plz");
            PlayerPrefs.SetInt(("stageCheck"+index2)+0,1);
            //stageCheck[0,index2]=1;
        }
        else if(stageNum <=6)
            stageCheck[1,index2]=1;
        else if(stageNum <=9)
            stageCheck[2,index2]=1;
        else if(stageNum <=12)
            stageCheck[3,index2]=1;
    }

    public void PortalEnter(GameObject scanObject)
    {
            if(scanObject.name == "Dong Portal")
                SceneManager.LoadScene("Dong Mun");

            else if(scanObject.name == "Seo Portal"){
                if(stageCheck[0,2]==1)
                    SceneManager.LoadScene("Seo Mun");
                //else GM.UnlockInfo("map");
            }
            else if(scanObject.name == "Jeong Portal"){
                if(stageCheck[1,2]==1)
                    SceneManager.LoadScene("Jeong Mun");
                //else GM.UnlockInfo("map");
            }
            else if(scanObject.name == "Buk Portal"){
                Debug.Log("Buk Portal");
                if(stageCheck[2,2]==1)
                    SceneManager.LoadScene("Buk Mun");
                //else GM.UnlockInfo("map");
            }
    }

    public void StageEnter(string name,GameObject obj)
    {
        Debug.Log(name);
        switch (name)
        {
            case "Dong Stage Decision":
                if(obj.name == "return")
                    SceneManager.LoadScene("Dong Mun");
                else if(obj.name == "Dstage 1")
                    SceneManager.LoadScene("Stage01");
                else if(obj.name == "Dstage 2"){
                    if(PlayerPrefs.GetInt(("stageCheck"+0)+0)==1)
                        SceneManager.LoadScene("Stage02");
                    //else GM.UnlockInfo("stage");
                }
                else if(obj.name == "Dstage 3"){
                    if(stageCheck[0,1]==1)
                        SceneManager.LoadScene("Stage03");
                    //else GM.UnlockInfo("stage");
                }
                break;
            case "Seo Stage Decision":
                if(obj.name == "return")
                    SceneManager.LoadScene("Seo Mun");
                else if(obj.name == "Sstage 1")
                    SceneManager.LoadScene("Stage04");
                else if(obj.name == "Sstage 2"){
                    if(stageCheck[1,0]==1)
                        SceneManager.LoadScene("Stage05");
                    //else GM.UnlockInfo("stage");
                }
                else if(obj.name == "Sstage 3"){
                    if(stageCheck[1,1]==1)
                        SceneManager.LoadScene("Stage06");
                   // else GM.UnlockInfo("stage");
                }
                break;
            case "Jeong Stage Decision":
                if(obj.name == "return")
                    SceneManager.LoadScene("Jeong Mun");
                else if(obj.name == "Jstage 1")
                    SceneManager.LoadScene("Stage07");
                else if(obj.name == "Jstage 2"){
                    if(stageCheck[2,0]==1)
                        SceneManager.LoadScene("Stage08");
                   // else GM.UnlockInfo("stage");
                }
                else if(obj.name == "Jstage 3"){
                    if(stageCheck[2,1]==1)
                    SceneManager.LoadScene("Stage09");
                  //  else GM.UnlockInfo("stage");
                }
                break;
            case "Buk Stage Decision":
                if(obj.name == "return")
                    SceneManager.LoadScene("Buk Mun");
                else if(obj.name == "Bstage 1")
                    SceneManager.LoadScene("Stage10");
                else if(obj.name == "Bstage 2"){
                    if(stageCheck[3,0]==1)
                        SceneManager.LoadScene("Stage11");
                   // else GM.UnlockInfo("stage");
                }
                else if(obj.name == "Bstage 3"){
                    if(stageCheck[3,1]==1)
                        SceneManager.LoadScene("Stage12");
                   // else GM.UnlockInfo("stage");
                }
                break;           
            default: break;
        }
    }
}

