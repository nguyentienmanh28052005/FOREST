using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : StateMachineBehaviour
{

    public float speed = 5f;
    public float attackRange = 3f;

    private int cnt;

    Transform player;
    Rigidbody2D rb; 
    Boss boss;
    

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
        int Numrd = 2;//Random.Range(1, 4);
        if(Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            if (Numrd == 3)
            {
                animator.SetTrigger("Ulti");
            }
            else if (Numrd == 1)
            {
                animator.SetTrigger("Attack");
            }
            else
            {
                animator.SetTrigger("Skill1");
            }    
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
        animator.ResetTrigger("Skill1");
        animator.ResetTrigger("Ulti");
    }
    
}