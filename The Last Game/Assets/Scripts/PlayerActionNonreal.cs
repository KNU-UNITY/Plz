using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionNonreal : MonoBehaviour
{
    public float speed;
    float h;
    float v;
    bool isHorizonMove;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    //CapsuleCollider2D collider2D;
   

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //anim = GetComponent<Animator>();
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        //flip character
        if (Input.GetButtonDown("Horizontal"))
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        //jump
        if (Input.GetButtonDown("Jump"))
        {
            rigid.AddForce(Vector2.up * 20, ForceMode2D.Impulse);
        }
    }
    void FixedUpdate()
    {
        rigid.velocity = new Vector2(h,v)*speed;
        //Move
        // Vector2 moveVec = isHorizonMove ? new Vector2(h,0): new Vector2(0,v);
        //rigid.velocity = moveVec*Speed;

        // //Ray
        // Debug.DrawRay(rigid.position,dirVec*0.9f,new Color(0,1,0));
        // RaycastHit2D rayHit = Physics2D.Raycast(rigid.position,dirVec,0.9f,LayerMask.GetMask("Object"));

        // if(rayHit.collider != null ){
        //     scanObject = rayHit.collider.gameObject;
        // }
        // else
        //     scanObject = null;
    }
}