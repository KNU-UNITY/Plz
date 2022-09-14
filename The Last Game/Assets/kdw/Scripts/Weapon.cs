using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    PlayerHP playerhp;
    [SerializeField]
    private GameObject projectilePrefab;//공격할 때 생성되는 발사체 프리펩
    [SerializeField]
    private GameObject powerupprojectilePrefab;//파워업
    [SerializeField]
    private GameObject projectilePrefabtmp;
    [SerializeField]
    private float attackRate = 0.1f;//공격속도
    [SerializeField]
    private int maxAttackLevel = 4;
    private int attackLevel = 1;
    private AudioSource audioSource;
    [SerializeField]
    private GameObject boomPrefab;
    [SerializeField]
    private GameObject projectileLv1;
    [SerializeField]
    private GameObject projectileLv2;
    [SerializeField]
    private GameObject projectileLv3;
    [SerializeField]
    private GameObject projectileLv4;
    [SerializeField]
    private GameObject projectileLv0;
    private int boomCount = PlayerPrefs.GetInt("itemsCount" + 2);
    public int BoomCount
    {
        set => boomCount = Mathf.Max(0, value);
        get => boomCount;
    }

    public int AttackLevel
    {
        set => attackLevel = Mathf.Clamp(value, 1, maxAttackLevel);
        get => attackLevel;
    }
    //public int BoomCount => boomCount;
    private void Awake()
    {
        boomCount = PlayerPrefs.GetInt("itemsCount" + 2);
        audioSource = GetComponent<AudioSource>();
        if(PlayerPrefs.GetInt("upgradeCount") == 1)
        {
            projectilePrefab = projectileLv1;
        }
        else if (PlayerPrefs.GetInt("upgradeCount") == 2)
        {
            projectilePrefab = projectileLv2;
        }
        else if (PlayerPrefs.GetInt("upgradeCount") == 3)
        {
            projectilePrefab = projectileLv3;
        }
        else if (PlayerPrefs.GetInt("upgradeCount") == 4)
        {
            projectilePrefab = projectileLv4;
        }
        else 
        {
            projectilePrefab = projectileLv0;
        }
    }
    // Start is called before the first frame update
    public void StartFiring()
    {
        StartCoroutine("TryAttack");
    }

    public void StopFiring()
    {
        StopCoroutine("TryAttack");
    }

    private IEnumerator TryAttack()
    {
        while(true)
        {
            //발사체 오브젝트 생성;
            //Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            AttackByLevel();
            audioSource.Play();
            //attackRate 시간만큼 대기
            yield return new WaitForSeconds(attackRate);
        }
    }
    private void AttackByLevel()
    {
        GameObject cloneProjectile = null;

        switch(attackLevel)
        {
            case 1:
                Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(projectilePrefab, transform.position+Vector3.left*0.2f, Quaternion.identity);
                Instantiate(projectilePrefab, transform.position + Vector3.right * 0.2f, Quaternion.identity);
                break;
            case 3:
                Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                cloneProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                cloneProjectile.GetComponent<Movement2D>().MoveTo(new Vector3(-0.2f, 1, 0));
                cloneProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                cloneProjectile.GetComponent<Movement2D>().MoveTo(new Vector3(0.2f, 1, 0));
                break;
            case 4:
                Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                cloneProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                cloneProjectile.GetComponent<Movement2D>().MoveTo(new Vector3(-0.2f, 1, 0));
                cloneProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                cloneProjectile.GetComponent<Movement2D>().MoveTo(new Vector3(0.2f, 1, 0));
                Instantiate(projectilePrefab, transform.position + Vector3.left * 0.2f, Quaternion.identity);
                Instantiate(projectilePrefab, transform.position + Vector3.right * 0.2f, Quaternion.identity);
                break;
        }
    }
    public void Attackchange()
    {
        if (PlayerPrefs.GetInt("itemsCount" + 1) > 0)
        {
            PlayerPrefs.SetInt("itemsCount" + 1, PlayerPrefs.GetInt("itemsCount" + 1) - 1);
            projectilePrefabtmp = projectilePrefab;
            projectilePrefab = powerupprojectilePrefab;
            powerupprojectilePrefab = projectilePrefabtmp;
            Invoke("changeoriginal", 2);

        }
    }
    public void changeoriginal()
    {
        projectilePrefabtmp = projectilePrefab;
        projectilePrefab = powerupprojectilePrefab;
        powerupprojectilePrefab = projectilePrefabtmp;
    }

    public void StartBoom()
    {
        if(boomCount>0)
        {
           
            boomCount--;
            PlayerPrefs.SetInt("itemsCount" + 2,boomCount);
            Instantiate(boomPrefab, transform.position, Quaternion.identity);

        }
    }
    public void StartHeal()
    {
        if (PlayerPrefs.GetInt("itemsCount" + 0)> 0)
        {
            PlayerPrefs.SetInt("itemsCount" + 0, PlayerPrefs.GetInt("itemsCount" + 0) - 1);
            playerhp.CurrentHP = playerhp.CurrentHP + 2;
        }
    }
   

}
