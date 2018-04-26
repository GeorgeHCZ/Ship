using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedByContact : MonoBehaviour {
	public GameObject explosion;//行星爆炸效果
	public GameObject playerExplosion;//飞船爆炸效果

    public int scoreValue;//击中一次的得分
    private GameController gameController;//用gameController来获取对脚本GameController.cs的访问
    
    //在层级视图中设定GameController对象的tag标签

	void OnTriggerEnter(Collider other)//进入触发器时响应
	{
		if (other.tag == "Boundary") 
		{
			return;
		}
		if (other.tag == "Bolt") 
		{
			Instantiate (explosion, transform.position, transform.rotation);
            gameController.AddScore(scoreValue);
		}
		if (other.tag == "Player") 
		{
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();//调用游戏结束函数
        }
		Destroy(other.gameObject);//销毁与行星碰撞的其他对象
		Destroy(gameObject);//销毁行星自身
		print(other.name);//测试other所表示的游戏对象
    }
	// Use this for initialization
	void Start () {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            //获取GameController游戏对象上的名称为GameController.cs的脚本文件
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Can not find 'GameController' script.");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
