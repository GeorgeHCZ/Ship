using System.Collections.Generic;
using UnityEngine;
[System.Serializable]//可序列化的属性

public class Boundary
{
    public float xmin, xmax, zmin, zmax;
}

public class PlayerController : MonoBehaviour
{

    public float speed = 10.0f;
    public Boundary boundary;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
	private float nextFire;

    void Update()
    {
        if(Input.GetButton("Fire1")&&Time.time>nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();//控制飞船射击音效
        }
    }

    void FixedUpdate()
    {
        //获取水平方向输入
        float moveHorizontal = Input.GetAxis("Horizontal");
        //获取垂直方向输入
        float moveVertical = Input.GetAxis("Vertical");
        //使用获取的水平、垂直方向输入创建Vector3类型对象
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        //使用Vector3类型变量作为飞船刚体的运动速度
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = movement * speed;
        rb.position = new Vector3(Mathf.Clamp(rb.position.x, boundary.xmin, boundary.xmax), 0, Mathf.Clamp(rb.position.z, boundary.zmin, boundary.zmax));

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
   
}