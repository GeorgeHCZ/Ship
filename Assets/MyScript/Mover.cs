using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    public float speed=15;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
