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

    //���� ������ ������ �ѱ��
    public void NextPage()
    {
        if (pageIndex == 0)
        {
            Pages[pageIndex].SetActive(false);
            pageIndex++;
            Pages[pageIndex].SetActive(true);
        }

    }
    //���� ������ �ڷ� �ѱ��
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
        if (GM.coin >= price)  //���� ���� ����� ���
        {
            GM.coin -= price;
            GM.itemsCount[index]++;
        }
    }
}
