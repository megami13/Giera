using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public float waitToReload;
    private bool reloading;
    private GameObject theKnight;

	// Use this for initialization
	void Start () {

        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        //timeBetweenMoveCounter = timeBetweenMove;
        //timeToMoveCounter = timeToMove;

        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
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
                //timeBetweenMoveCounter = timeBetweenMove;
                timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
            }
        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;

            myRigidbody.velocity = Vector2.zero;

            if (timeBetweenMoveCounter < 0f)
            {
                moving = true;
                //timeToMoveCounter = timeToMove;
                timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);

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

        if (reloading)
        {
            waitToReload -= Time.deltaTime;
            if (waitToReload < 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                theKnight.SetActive(true);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.name == "Knight")
        //{
        //    //Destroy(collision.gameObject);
        //    collision.gameObject.SetActive(false);
        //    reloading = true;
        //    theKnight = collision.gameObject;
        //}
    }
}
