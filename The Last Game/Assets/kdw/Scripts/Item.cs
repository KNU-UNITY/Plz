using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemType { PowerUp =0,Boom,HP,Coin}

public class Item : MonoBehaviour
{
    [SerializeField]
    private ItemType itemType;
    private Movement2D movement2D;
    private PlayerController playerController;
    private void Awake()
    {
        movement2D = GetComponent<Movement2D>();
        float x = Random.Range(-1.0f, 1.0f);
        float y = Random.Range(-1.0f, 1.0f);

        movement2D.MoveTo(new Vector3(x, y, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Use(collision.gameObject);
            Destroy(gameObject);
        }
    }
    private void Use(GameObject player)
    {
        switch(itemType)
        {
            case ItemType.PowerUp:
                player.GetComponent<Weapon>().AttackLevel++;
                break;
            case ItemType.Boom:
                player.GetComponent<Weapon>().BoomCount++;
                PlayerPrefs.SetInt("itemsCount" + 3, PlayerPrefs.GetInt("itemsCount" + 3)+1);
                break;
            case ItemType.HP:
                player.GetComponent<PlayerHP>().CurrentHP+=2;
                break;
            case ItemType.Coin:
                player.GetComponent<PlayerController>().Coin += 100;
                break;
        }
    }
}
