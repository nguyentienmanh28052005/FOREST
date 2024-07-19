using Unity.VisualScripting;
using UnityEngine;

public class SlimeState1 : StateMachineBehaviour
{
    private Rigidbody2D _rb;
    private Transform _posiPlayer;
    private float _speed = 1.5f;
    private int _horizontal;
    private Slime _slime;
    private float rangeXR;
    private float rangeXL;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _rb = animator.GetComponent<Rigidbody2D>();
        _posiPlayer = GameObject.FindGameObjectWithTag("Player").transform;
       // _slime = animator.GetComponent<Slime>();
       rangeXL = animator.GetComponent<Slime>().GetrangeXL();
       rangeXR = animator.GetComponent<Slime>().GetrangeXR();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _horizontal = animator.GetComponent<Slime>().GetHorizontal();
        //Debug.Log(_horizontal);
        _rb.velocity = new Vector2(_horizontal, _rb.velocity.y);
        animator.transform.Translate(_rb.velocity * Time.deltaTime * _speed);
        if (_posiPlayer.position.x > rangeXL && _posiPlayer.position.x < rangeXR)
        {
            //Debug.Log("hi");
            animator.SetBool("Angry", true);
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
