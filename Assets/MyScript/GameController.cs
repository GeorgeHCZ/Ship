using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//引入命名空间

public class GameController : MonoBehaviour
{
    public float spawnWait;//行星之间的延迟间隔
    public float Wait;//等待时间间隔再批量生成
    public float startWait;//第一次批量生成的等待时间
    public int hazardCount;//批量生成行星的数量
    public GameObject hazard;//存储向量预制体
    public Vector3 spawnValues;//实例化行星的位置
    public Vector3 spawnPosition = Vector3.zero;//实例化行星的位置
    private Quaternion spawnRotation;//旋转

    public Text scoreText;//更新得分组件
    private int score;//保存当前的分数值

    public Text gameOverText;//更新Text组件的显示
    private bool gameOver;

    public Text restartText;//更新重启文件组件的显示
    private bool restart;//重启游戏的状态

    IEnumerator SpawnWaves()//协程函数返回类型特定IEnumerator
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
           if(gameOver)
            {
                restartText.text = "Press R for restart.";
                restart = true;
                break;
            }
            for (int i = 0; i < hazardCount; i++)
            {
                //生成一个小行星
                spawnPosition.x = Random.Range(-spawnValues.x, spawnValues.x);
                spawnPosition.z = spawnValues.z;
                spawnRotation = Quaternion.identity;//设置不旋转
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);//控制同一批次陨石延迟生成
            }
            yield return new WaitForSeconds(Wait);//控制不同批次的延迟
            
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();//更新窗口中的文本组件 自定义函数
    }

    void UpdateScore()
    {
        scoreText.text = "Score:" + score;
    }

    //Use this for initialization
    void Start()
    {
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
        gameOverText.text = "";
        gameOver = false;
        restartText.text = "";
        restart = false;
    }

    //游戏结束函数
    public void GameOver()
    {
        gameOver = true;
        gameOverText.text = "Game Over！";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);//重新加载场景
        }
    }
}
