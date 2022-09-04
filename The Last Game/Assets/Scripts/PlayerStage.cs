using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStage : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    public GameObject scanObject;

    int maxSpeed = 5;
    int jumpPower = 12;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        //Move
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rigid.velocity.x > maxSpeed)  //Right Max Speed
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < maxSpeed * (-1))  //Left Max Speed
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);

        ////Draw Ray front
        //Vector2 frontVec = new Vector2(rigid.position.x + 0.5f, rigid.position.y + 1f);
        //Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
        //RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 0.9f, LayerMask.GetMask("board"));
        //if (rayHit.collider != null)
        //{
        //    scanObject = rayHit.collider.gameObject;
        //    Debug.Log(scanObject);
        //}
        //else
        //    scanObject = null;

        
        //Jump
        if (rigid.velocity.y < 0)
        {
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayhit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));
            if (rayhit.collider != null)
            {
                if (rayhit.distance < 0.6f)
                {
                    anim.SetBool("isJumping", false);
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        //Stop Speed
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        //Flip character
        if (Input.GetButton("Horizontal"))
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;

        //Jump
        if (Input.GetButtonDown("Jump") && !anim.GetBool("isJumping"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
        }
        //walk
        if (Mathf.Abs(rigid.velocity.x) > 0.3)  //속도가 0.3 이하이라면

            anim.SetBool("isWalking", true);
        else
            anim.SetBool("isWalking", false);

        ////Move to game
        //if(Input.GetKey(KeyCode.E) && scanObject != null)
        //{
        //    if (scanObject.name == "Stage1")
        //        SceneManager.LoadScene("Stage01");
        //    else if (scanObject.name == "Stage2")
        //        SceneManager.LoadScene("Stage02");
        //    else if (scanObject.name == "Stage3")
        //        SceneManager.LoadScene("Stage03");
        //}
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "board")
        {
            Debug.Log("인식");
            if (collision.gameObject.name == "Stage1")
                SceneManager.LoadScene("Stage01");
            else if (scanObject.name == "Stage2")
                SceneManager.LoadScene("Stage02");
            else if (scanObject.name == "Stage3")
                SceneManager.LoadScene("Stage03");
        }
    }
}
