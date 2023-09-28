using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject player;
    private Transform playerPos;
    private Vector2 currentPos;
    public float distance;
    public float speedEnemy;
    private Animator enemyAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = player.GetComponent<Transform>();
        currentPos = GetComponent<Transform>().position;
        enemyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, playerPos.position) < distance) 
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speedEnemy * Time.deltaTime);
            enemyAnim.SetBool("isAttacking", true);
            //FlipSprite();
        }
        else
        {
            if(Vector2.Distance(transform.position, currentPos) <= 0)
            {
                enemyAnim.SetBool("isAttacking", false);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, currentPos, speedEnemy * Time.deltaTime);
                enemyAnim.SetBool("isAttacking", true);
               // FlipSprite();
            }
        }
    }

   /* void FlipSprite()
    {
        bool isAttacking;

        if (isAttacking)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
    } */
}
