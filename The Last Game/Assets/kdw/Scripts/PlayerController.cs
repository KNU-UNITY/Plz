using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField]
    private string nextSceneName;
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private KeyCode KeyCodeAttack = KeyCode.Space;
    [SerializeField]
    private KeyCode keyCodeBoom = KeyCode.Z;
    [SerializeField]
    private KeyCode keyCodeHeal = KeyCode.X;
    [SerializeField]
    private KeyCode keyCodePower = KeyCode.C;
    private bool isDie = false;
    private Movement2D movement2D;
    private Weapon weapon;
    private Animator animator;
    float timer;
    int waitingTime;
    bool inside;

    void Start()
    {
        timer = 0.0f;
        waitingTime = 2;
        inside = false;
    }

    
    private int score;
    public int Score
    {
        set => score = Mathf.Max(0, value);
        get => score;
    }
    private int coin;
    public int Coin 
    {
        set => coin = Mathf.Max(0, value);
        get => coin;
    }

    private void Awake()
    {
        movement2D = GetComponent<Movement2D>();
        weapon = GetComponent<Weapon>();
        animator = GetComponent<Animator>();
      
    }

    private void Update()

    {
        if (isDie == true) return;
        //방향 키를 눌러 이동 방향 설정
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movement2D.MoveTo(new Vector3(x, y, 0));
        //공격 키를 Down/Up으로 공격 시작/종료
        if(Input.GetKeyDown(KeyCodeAttack))
        {
            weapon.StartFiring();
        }
        else if(Input.GetKeyUp(KeyCodeAttack))
        {
            weapon.StopFiring();
        }
        if(Input.GetKeyDown(keyCodeBoom))
        {
            weapon.StartBoom();
        }
        if (Input.GetKeyDown(keyCodeHeal))
        {
            weapon.StartHeal();
        }
        if (Input.GetKeyDown(keyCodePower))
        {
            weapon.Attackchange();
        }
    }
    void InvokeTest()
    {
        Debug.Log("Invoke Start!");
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x),
            Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y));
    }

    public void OnDie()
    {
        movement2D.MoveTo(Vector3.zero);

        animator.SetTrigger("onDie");
        Destroy(GetComponent<CircleCollider2D>());
        isDie = true;
    }
    public void OnDieEvent()
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("Coin", coin+ PlayerPrefs.GetInt("Coin"));
        
        SceneManager.LoadScene(nextSceneName);
    }
}
