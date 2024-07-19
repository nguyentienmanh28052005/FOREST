using UnityEngine;

public class Vanish : MonoBehaviour
{
    public Transform player;
    public bool isFlipped = false;
    private bool isfacingRight = true;
    private int _horizontal = 1;
    //private int scale;
    public float rangeXR;
    public float rangeXL;
    public float rangeY;
    private Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public float GetrangeXL()
    {
        return rangeXL;
    }

    public float GetrangeXR()
    {
        return rangeXR;
    }
    
    public float GetrangeY()
    {
        return rangeY;
    }
    
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bound")
        {
            _anim.SetBool("Angry", false);
            Flip();
        }
    }
    
    void Flip()
    {
        isFlipped = !isFlipped;
        _horizontal *= -1;
        Vector3 kich_thuoc = transform.localScale;
        kich_thuoc.x = -1 * kich_thuoc.x;
        transform.localScale = kich_thuoc;
    }

    public int GetHorizontal()
    {
        return _horizontal;
    }
    
    public bool GetDirection()
    {
        return isFlipped;
        
    }
}
