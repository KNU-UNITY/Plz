using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossExplosion : MonoBehaviour
{
    private PlayerController playerController;
    private string sceneName;
    public StageClearCheck SCC;

    public void Setup(PlayerController playerController,string sceneName)
    {
        this.playerController = playerController;
        this.sceneName = sceneName;
    }

    private void OnDestroy()
    {
        playerController.Score += 10000;
        PlayerPrefs.SetInt("Score", playerController.Score);
        playerController.Coin += 1000;
        PlayerPrefs.SetInt("Coin", playerController.Coin);

        //스테이지 클리어하면 2차월 배열에 1입력
        //SCC.StageCheck(SceneManager.GetActiveScene().name);

        //게임 클리어 하면 각 문 맵으로 돌아감
        switch(SceneManager.GetActiveScene().name)
        {
            case "Stage01":
            case "Stage02":
            case "Stage03":
                SceneManager.LoadScene("Dong Mun");
                break;
            case "Stage04":
            case "Stage05":
            case  "Stage06":
                SceneManager.LoadScene("Seo Mun");
                break;
            case "Stage07":
            case "Stage08":
            case "Stage09":
                SceneManager.LoadScene("Jeong Mun");
                break;
            case "Stage10":
            case "Stage11":
            case "Stage12":
                SceneManager.LoadScene("Buk Mun");
                    break;
        }
        
    }

}
