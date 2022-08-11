using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private int scorePoint = 100;
    [SerializeField]
    private GameObject explosionPrefab;
    [SerializeField]
    private GameObject[] itemPrefabs;
    [SerializeField]
    private float shootDelay=1.0f;
    private float shootTimer = 0;
    private EnemyWeapon enemyWeapon;
    private PlayerController playerController;

    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        enemyWeapon = GetComponent<EnemyWeapon>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHP>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
    public void OnDie()
    {
        playerController.Score += scorePoint;

        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        SpawnItem();
        Destroy(gameObject);
    }
    private void SpawnItem()
    {
        int spawnItem = Random.Range(0, 100);
        if(spawnItem<7)
        {
            Instantiate(itemPrefabs[0], transform.position, Quaternion.identity);
        }
        else if(spawnItem<10)
        {
            Instantiate(itemPrefabs[1], transform.position, Quaternion.identity);
        }
        else if(spawnItem<12)
        {
            Instantiate(itemPrefabs[2], transform.position, Quaternion.identity);
        }
    }
    private void Update()
    {
        if (shootTimer > shootDelay)
        {
            enemyWeapon.StartFiring();
            shootTimer = 0;
        }
        shootTimer += Time.deltaTime;

    }
}
