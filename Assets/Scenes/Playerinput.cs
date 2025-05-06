using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Playerinput : MonoBehaviour
{
    //設定參數
    private Rigidbody2D pl;
    public float mymove;
    private float moveInput;
    private Animator animator;
    public int mylife = 100; //定義玩家生命值
   // public GameManager gameManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pl = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();



    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(moveInput, 0, 0) * mymove * Time.deltaTime;
        transform.Translate(move);

        // 轉向（只要有移動才轉）
        if (moveInput > 0)
        {
            // 面向右
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput < 0)
        {
            // 面向左
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // 設定動畫參數
        animator.SetBool("walk", Mathf.Abs(moveInput) > 0.01f);
        // 有移動就walk=true，沒移動walk=false
    }

    //透過公開函式設定Action,名稱為On+動作名稱
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<float>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {

            Debug.Log("jump");

            pl.AddForce(Vector2.up * 10, ForceMode2D.Impulse);

        }
    }



    public void OnAtack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {

            Debug.Log("attack");
            animator.SetTrigger("attack"); //播放攻擊動畫

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 碰到怪物時播放受傷動畫
        if (collision.gameObject.tag == "monster")
        {
            Debug.Log("hurt");
            animator.SetTrigger("hurt");
            //mylife -= 10; //生命值扣10
           // gameManager.m_HPBar.fillAmount -= 0.1f;// 血條填充長度減短0.1長度
        }


    }


}


