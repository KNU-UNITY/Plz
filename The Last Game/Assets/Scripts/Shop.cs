using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    //아이템 [포션,쉴드,파워 업,트리플]
    public GameManager gameManager;
    public GameObject[] Pages;
    public int pageIndex;
    public int[] ItemPrice;

    //상점 페이지 앞으로 넘기기
    public void NextPage()
    {
        if (pageIndex == 0)
        {
            Pages[pageIndex].SetActive(false);
            pageIndex++;
            Pages[pageIndex].SetActive(true);
        }

    }
    //상점 페이지 뒤로 넘기기
    public void PrePage()
    {
        if (pageIndex == 1)
        {
            Pages[pageIndex].SetActive(false);
            pageIndex--;
            Pages[pageIndex].SetActive(true);
        }
    }
    //Buy Item
    public void Buy(int index)
    {
        int price = ItemPrice[index];
        if (gameManager.Coin >= price)  //가진 돈이 충분할 경우
        {
            gameManager.Coin -= price;
            gameManager.itemsCount[index]++;
        }
        //Debug.Log(price);
    }

    //Exit
    public void ExitMain()
    {
        SceneManager.LoadScene("Jeong Mun");
    }

    public void ExitEast()
    {
        SceneManager.LoadScene("Dong Mun");
    }

    public void ExitWest()
    {
        SceneManager.LoadScene("Seo Mun");
    }
    public void ExitNorth()
    {
        SceneManager.LoadScene("Buk Mun");
    }
}
