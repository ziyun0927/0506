using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject MonsterPrefab; //�m��Prefab���ܼ�
    float MonsterSpawnSpan = 5.0f; //�w�]�ɶ�����
    float MonsterDelta = 0; //�{�b�w�g�ֿn���ɶ�
    public Image m_HPBar;  //���a����Ϥ�
    public Image towerBar; //�𪺦���Ϥ�
    public TextMeshProUGUI timeUI; // UI��r����
    private float timeCount = 60f; //�w�q��l��ܮɶ��Ȭ�60��



    // Start is called before the first frame update
    void Start()
    {
        timeUI = timeUI.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        MonsterDelta += Time.deltaTime; // ���_�ֿn�ɶ�
        timeCount -= Time.deltaTime; //�˼Ʈɶ�
        //�bui��ܥثe�˼Ʈɶ�+��ܤ�r #0������ܾ��
        timeUI.text= "Time: " + timeCount.ToString("#0") + " s";
        // �p�G�ֿn���ɶ��j��w�]���ɶ����סA�N�̾�Prefab���͹C������
        if (MonsterDelta > MonsterSpawnSpan)
        {
            MonsterDelta = 0; // �N�ֿn�ɶ��k�s
            int px = Random.Range(5, 17); //�]�w�H���ͦ���m�ƭ�
            Instantiate(MonsterPrefab, new Vector3(px, 0, 0), Quaternion.identity);// ���͹C������
        }

        //�����W�L60����
        if (timeCount < 0)
        {
            timeUI.GetComponent<TextMeshProUGUI>().text = " Game Over";
            //  SceneManager.LoadScene("gameover");

        }



    }



}