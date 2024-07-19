using UnityEngine;

public class VanishState2 : StateMachineBehaviour
{
    public float speed = 5f;
    public float attackRange = 3f;

    private int cnt;

    Transform player;
    Rigidbody2D rb; 
    Vanish _vanish;
    private float rangeXR;
    private float rangeXL;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        _vanish= animator.GetComponent<Vanish>();
        rangeXL = animator.GetComponent<Vanish>().GetrangeXL();
        rangeXR = animator.GetComponent<Vanish>().GetrangeXR();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _vanish.LookAtPlayer();
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
        if(Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            //animator.SetTrigger("Attack");
        }
        if (player.position.x < rangeXL || player.position.x > rangeXR)
        {
            //Debug.Log("hi");
            animator.SetBool("Angry", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
