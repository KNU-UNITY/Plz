using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum BossState { MoveToAppearPoint = 0,Phase01,Phase02,Phase03}
public class Boss : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private float bossAppearPoint = 2.5f;
    [SerializeField]
    private GameObject explosionPrefab;
    [SerializeField]
    private PlayerController playerController;
  
    [SerializeField]
    private string nextSceneName;

    private BossState bossState = BossState.MoveToAppearPoint;
    private Movement2D movement2D;
    private BossWeapon bossWeapon;
    private BossHP bossHP;
    public StageClearCheck SCC;
    private void Awake()
    {
        movement2D = GetComponent<Movement2D>();
        bossWeapon = GetComponent<BossWeapon>();
        bossHP = GetComponent<BossHP>();
    }
    public void ChangeState(BossState newState)
    {
        StopCoroutine(bossState.ToString());
        bossState = newState;
        StartCoroutine(bossState.ToString());
        
    }
    private IEnumerator MoveToAppearPoint()
    {
        movement2D.MoveTo(Vector3.down);
        while(true)
        {
            if(transform.position.y <= bossAppearPoint)
            {
                movement2D.MoveTo(Vector3.zero);
                ChangeState(BossState.Phase01);
            }
            
            yield return null;
        }
    }
    private IEnumerator Phase01()
    {
        if(SceneManager.GetActiveScene().name == "Stage01"|| (SceneManager.GetActiveScene().name == "Stage06"))
        {
            bossWeapon.StartFiring(AttackType.SingleFireToCenterPosition);
            while(true)
            {
                if(bossHP.CurrentHP<=bossHP.MaxHP*0.7f)
                {
                    bossWeapon.StopFiring(AttackType.SingleFireToCenterPosition);
                    ChangeState(BossState.Phase02);
                }
                yield return null; 
            }
        }
        else if (SceneManager.GetActiveScene().name == "Stage02")
        {
            bossWeapon.StartFiring(AttackType.CircleFire);
            while (true)
            {
                if (bossHP.CurrentHP <= bossHP.MaxHP * 0.7f)
                {
                    bossWeapon.StopFiring(AttackType.CircleFire);
                    ChangeState(BossState.Phase02);
                }
                yield return null;
            }
        }
    }
    private IEnumerator Phase02()
    {
        if (SceneManager.GetActiveScene().name == "Stage01")
        {
            bossWeapon.StartFiring(AttackType.TripleFireToCenterPosition);
            while (true)
            {
                if (bossHP.CurrentHP <= bossHP.MaxHP * 0.3f)
                {
                    bossWeapon.StopFiring(AttackType.TripleFireToCenterPosition);
                    ChangeState(BossState.Phase03);
                }
                yield return null;
            }
        }
        else if (SceneManager.GetActiveScene().name == "Stage02")
        {
            bossWeapon.StartFiring(AttackType.SingleFireToCenterPosition);
            Vector3 direction = Vector3.right;
            movement2D.MoveTo(direction);

            while (true)
            {
                if (transform.position.x <= stageData.LimitMin.x ||
                    transform.position.x >= stageData.LimitMax.x)
                {
                    direction *= -1;
                    movement2D.MoveTo(direction);
                }

                if (bossHP.CurrentHP <= bossHP.MaxHP * 0.3f)
                {
                    bossWeapon.StopFiring(AttackType.SingleFireToCenterPosition);
                    ChangeState(BossState.Phase03);
                }
                yield return null;
            }
        }
    }
    private IEnumerator Phase03()
    {
        if (SceneManager.GetActiveScene().name == "Stage01")
        {
            bossWeapon.StartFiring(AttackType.PentaFireToCenterPosition);
          
            
            while (true)
            {
                
                yield return null;
            }
        }
        else if (SceneManager.GetActiveScene().name == "Stage02")
        {
            bossWeapon.StartFiring(AttackType.CircleFire);
            bossWeapon.StartFiring(AttackType.SingleFireToCenterPosition);
            Vector3 direction = Vector3.right;
            movement2D.MoveTo(direction);
            while (true)
            {
                if (transform.position.x <= stageData.LimitMin.x ||
                    transform.position.x >= stageData.LimitMax.x)
                {
                    direction *= -1;
                    movement2D.MoveTo(direction);
                }
                yield return null;
            }
        }
    }
    public void OnDie()
    {
        GameObject clone = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
        //???????????? ??????????????? 2?????? ????????? 1??????
        SCC.StageCheck(SceneManager.GetActiveScene().name);

        //?????? ????????? ?????? ??? ??? ????????? ?????????
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
