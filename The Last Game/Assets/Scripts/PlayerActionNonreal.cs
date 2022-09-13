 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerActionNonreal : MonoBehaviour
{
    public GameManager manager;
    public StageClearCheck SCC;
    GameObject scanObject;
    public float speed;
    float h;
    float v;
    bool isHorizonMove;
    Vector3 dirVec;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
   

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
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
        if (vDown && v == 1)
        {
            dirVec = Vector3.up;
            anim.SetBool("isBack", true);
            anim.SetBool("isSide", false);

        }
        else if (vDown && v == -1)
        {
            dirVec = Vector3.down;
            anim.SetBool("isBack", false);
            anim.SetBool("isSide", false);
        }
        else if (hDown && h == -1)
        {
            dirVec = Vector3.left;
            anim.SetBool("isSide", true);
            anim.SetBool("isBack", false);
        }
        else if (hDown && h == 1)
        {
            dirVec = Vector3.right;
            anim.SetBool("isSide", true);
            anim.SetBool("isBack", false);
        }

        //Scan Object
        if(Input.GetButtonDown("Jump")&& scanObject != null && !scanObject.CompareTag("desk"))
            PortalMove(scanObject);
        
        
        else if(Input.GetButtonDown("Jump")&& scanObject != null && scanObject.CompareTag("desk"))
            manager.Action(scanObject);

        //flip character
        if (hDown)
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        else if(vDown)
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == 1;
    }
    void FixedUpdate()
    {
        //Move
        Vector2 moveVec = isHorizonMove ? new Vector2(h,0): new Vector2(0,v);
        rigid.velocity = moveVec*speed;

        //Ray
        Debug.DrawRay(rigid.position,dirVec*0.9f,new Color(0,1,0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position,dirVec,0.9f,LayerMask.GetMask("Object","Shop"));

        if(rayHit.collider != null ){
            scanObject = rayHit.collider.gameObject;
        }
        else
            scanObject = null;
    }


    //Scene Move Method
    public void PortalMove(GameObject scanObj)
    {
        scanObject = scanObj;
        Debug.Log("PortalMove");
        if(scanObject.CompareTag("Portal")==true)
            SCC.PortalEnter(scanObject);
        
        
        else if(scanObject.CompareTag("Shop")==true){
            Debug.Log("Shop");
            if(scanObject.name == "Bukmun Shop")
                SceneManager.LoadScene("NorthShop");
            else if(scanObject.name == "Seomun Shop")
                SceneManager.LoadScene("WestShop");
            else if(scanObject.name == "Dongmun Shop")
                SceneManager.LoadScene("EastShop");
            else if(scanObject.name == "Jeongmun Shop")
                SceneManager.LoadScene("MainShop");
        }

        else if(scanObject.CompareTag("2nd Portal")==true){
            if(scanObject.name == "Buk 2nd Portal")
                SceneManager.LoadScene("Buk Stage Decision");
            else if(scanObject.name == "Seo 2nd Portal")
                SceneManager.LoadScene("Seo Stage Decision");
            else if(scanObject.name == "Dong 2nd Portal")
                SceneManager.LoadScene("Dong Stage Decision");
            else if(scanObject.name == "Jeong 2nd Portal")
                SceneManager.LoadScene("Jeong Stage Decision");
        }

        else if(scanObject.CompareTag("return")==true){
            SceneManager.LoadScene("Main Map");
        }
    }

    void OnTriggerStay2D(Collider2D collision){
        if(collision.gameObject.tag == "enter" && Input.GetKey(KeyCode.Return)){
            Debug.Log("Enter");
            WhatClick(collision.gameObject);
               
        }
    }

    void WhatClick(GameObject obj){
        Debug.Log("button");
        SCC.StageEnter(SceneManager.GetActiveScene().name,obj);
    }
        
}

