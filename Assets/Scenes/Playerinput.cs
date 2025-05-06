using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Playerinput : MonoBehaviour
{
    //�]�w�Ѽ�
    private Rigidbody2D pl;
    public float mymove;
    private float moveInput;
    private Animator animator;
    public int mylife = 100; //�w�q���a�ͩR��
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

        // ��V�]�u�n�����ʤ~��^
        if (moveInput > 0)
        {
            // ���V�k
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput < 0)
        {
            // ���V��
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // �]�w�ʵe�Ѽ�
        animator.SetBool("walk", Mathf.Abs(moveInput) > 0.01f);
        // �����ʴNwalk=true�A�S����walk=false
    }

    //�z�L���}�禡�]�wAction,�W�٬�On+�ʧ@�W��
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
            animator.SetTrigger("attack"); //��������ʵe

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �I��Ǫ��ɼ�����˰ʵe
        if (collision.gameObject.tag == "monster")
        {
            Debug.Log("hurt");
            animator.SetTrigger("hurt");
            //mylife -= 10; //�ͩR�Ȧ�10
           // gameManager.m_HPBar.fillAmount -= 0.1f;// �����R���״�u0.1����
        }


    }


}


