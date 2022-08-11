using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shop : MonoBehaviour
{
    public GameObject[] Pages;
    public int pageIndex;
    public GameManager GM;
    public GameObject[] items;
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
    void Buy(int index)
    {
        int price = ItemPrice[index];
        if (GM.coin >= price)  //가진 돈이 충분할 경우
        {
            GM.coin -= price;
            GM.itemsCount[index]++;
        }
    }
}
