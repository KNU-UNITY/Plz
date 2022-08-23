using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;//공격할 때 생성되는 발사체 프리펩
    [SerializeField]
    private float attackRate = 0.1f;//공격속도
    [SerializeField]
    private int maxAttackLevel = 4;
    private int attackLevel = 1;
    private AudioSource audioSource;
    [SerializeField]
    private GameObject boomPrefab;
    private int boomCount = 3;

    public int AttackLevel
    {
        set => attackLevel = Mathf.Clamp(value, 1, maxAttackLevel);
        get => attackLevel;
    }
    public int BoomCount
    {
        set => boomCount = Mathf.Max(0, value);
        get => boomCount;
    }
    //public int BoomCount => boomCount;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
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

    public void StartBoom()
    {
        if(boomCount>0)
        {
            boomCount--;
            Instantiate(boomPrefab, transform.position, Quaternion.identity);

        }
    }
}
