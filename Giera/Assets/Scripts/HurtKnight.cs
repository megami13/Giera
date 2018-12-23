using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtKnight : MonoBehaviour {

    public int damageToGive;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Knight")
        {
            collision.gameObject.GetComponent<KnightHealthManager>().HurtKnight(damageToGive);
        }
    }
}
