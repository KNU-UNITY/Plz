using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;//공격할 때 생성되는 발사체 프리펩
    [SerializeField]
    private float attackRate = 0.1f;//공격속도
  
    public void StartFiring()
    {
        Debug.Log("발사!");
        StartCoroutine("TryAttack");

    }

    public void StopFiring()
    {
        StopCoroutine("TryAttack");
    }

    private IEnumerator TryAttack()
    {
        while (true)
        {
            //발사체 오브젝트 생성;
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
           
            yield return new WaitForSeconds(attackRate);
        }
    }
   
}
