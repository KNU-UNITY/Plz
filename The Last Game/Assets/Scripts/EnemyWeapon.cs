using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;//������ �� �����Ǵ� �߻�ü ������
    [SerializeField]
    private float attackRate = 0.1f;//���ݼӵ�
  
    public void StartFiring()
    {
        Debug.Log("�߻�!");
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
            //�߻�ü ������Ʈ ����;
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
           
            yield return new WaitForSeconds(attackRate);
        }
    }
   
}
