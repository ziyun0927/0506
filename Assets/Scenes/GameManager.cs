using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject MonsterPrefab; //置放Prefab的變數
    float MonsterSpawnSpan = 5.0f; //預設時間長度
    float MonsterDelta = 0; //現在已經累積的時間
    public Image m_HPBar;  //玩家血條圖片
    public Image towerBar; //塔的血條圖片
    public TextMeshProUGUI timeUI; // UI文字元件
    private float timeCount = 60f; //定義初始顯示時間值為60秒



    // Start is called before the first frame update
    void Start()
    {
        timeUI = timeUI.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        MonsterDelta += Time.deltaTime; // 不斷累積時間
        timeCount -= Time.deltaTime; //倒數時間
        //在ui顯示目前倒數時間+顯示文字 #0為僅顯示整數
        timeUI.text= "Time: " + timeCount.ToString("#0") + " s";
        // 如果累積的時間大於預設的時間長度，就依據Prefab產生遊戲物件
        if (MonsterDelta > MonsterSpawnSpan)
        {
            MonsterDelta = 0; // 將累積時間歸零
            int px = Random.Range(5, 17); //設定隨機生成位置數值
            Instantiate(MonsterPrefab, new Vector3(px, 0, 0), Quaternion.identity);// 產生遊戲物件
        }

        //攻擊超過60秒失敗
        if (timeCount < 0)
        {
            timeUI.GetComponent<TextMeshProUGUI>().text = " Game Over";
            //  SceneManager.LoadScene("gameover");

        }



    }



}