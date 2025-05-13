using UnityEngine;

public class monster : MonoBehaviour
{

    // Start is called before the first frame update
    private Rigidbody2D mon; //�ŧi�ܼ�

    // Start is called before the first frame update
    void Start()
    {

        mon = GetComponent<Rigidbody2D>();
    }


    //攻擊範圍接觸到怪物時
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "atk")
        {
            Debug.Log("atk monster");
            Destroy(gameObject);
        }


    }



}
