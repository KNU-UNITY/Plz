using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    //������ [����,����,�Ŀ� ��,Ʈ����]
    public GameManager gameManager;
    public GameObject[] Pages;
    public int pageIndex;
    

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
