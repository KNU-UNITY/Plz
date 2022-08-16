using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionNonreal : MonoBehaviour
{
    public GameManager manager;
    GameObject scanObject;
    public float speed;
    float h;
    float v;
    bool isHorizonMove;
    Vector3 dirVec;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    
   

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //anim = GetComponent<Animator>();
    }

    void Update()
    {
        //TopDown Move
        //Move Value
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        //Check Button Down & Up
        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");
        //Check Horizontal Move
        if(hDown || vUp)
        isHorizonMove = true;
        else if(vDown || hUp)
        isHorizonMove = false;

        //Direction
        if(vDown && v ==1)
            dirVec = Vector3.up;
        else if(vDown && v == -1)
            dirVec = Vector3.down;
        else if(hDown && h == -1)
            dirVec = Vector3.left;
            else if(hDown && h == 1)
            dirVec = Vector3.right;

        //Scan Object
        if(Input.GetButtonDown("Jump") && scanObject != null)
            manager.PortalMove(scanObject);


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
        //Move
        Vector2 moveVec = isHorizonMove ? new Vector2(h,0): new Vector2(0,v);
        rigid.velocity = moveVec*speed;

        //Ray
        Debug.DrawRay(rigid.position,dirVec*0.9f,new Color(0,1,0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position,dirVec,0.9f,LayerMask.GetMask("Object"));

        if(rayHit.collider != null ){
            scanObject = rayHit.collider.gameObject;
        }
        else
            scanObject = null;
    }
}
