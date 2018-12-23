using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour {

    public float moveSpeed;

    private Rigidbody2D myRigidbody;
    private Animator anim;

    private bool moving;

    public float timeBetweenMove;
    private float timeBetweenMoveCounter;
    public float timeToMove;
    private float timeToMoveCounter;
    private Vector3 moveDirection;
    private Vector3 lastMove = Vector3.zero;

	// Use this for initialization
	void Start () {

        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        timeBetweenMoveCounter = timeBetweenMove;
        timeToMoveCounter = timeToMove;
	}
	
	// Update is called once per frame
	void Update () {
		
        if (moving)
        {
            timeToMoveCounter -= Time.deltaTime;
            myRigidbody.velocity = moveDirection;

            if (timeToMoveCounter < 0f)
            {
                moving = false;
                timeBetweenMoveCounter = timeBetweenMove;
            }
        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;

            myRigidbody.velocity = Vector2.zero;

            if (timeBetweenMoveCounter < 0f)
            {
                moving = true;
                timeToMoveCounter = timeToMove;

                lastMove = moveDirection;
                moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
            }
        }
        anim.SetBool("moving", moving);

        if (lastMove.x + moveDirection.x > lastMove.x)
        {
            anim.SetFloat("movingRight", 1f);
        }
        else if (lastMove.x + moveDirection.x < lastMove.x)
        {
            anim.SetFloat("movingRight", 0f);
        }
    }
}
