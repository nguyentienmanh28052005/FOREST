using Unity.VisualScripting;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    [SerializeField] private GameObject effectImpact;
    [SerializeField] private GameObject _skill;

    private bool isfacingRight;
    private bool _direction;
    void Start()
    {
        isfacingRight = _skill.GetComponent<SkillWatterBall>().GetDirection();
    }
    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Map")
        {
            Vector3 spon = transform.position;
            if (isfacingRight)
            {
                spon.x += 0.2f;
            }
            else
            {
                spon.x += 0.2f;
            }
            GameObject impact = Instantiate(effectImpact, spon, transform.rotation);
            if (!isfacingRight) Flip(impact);
            impact.gameObject.SetActive(true);
            Destroy(this.GameObject());
        }
    }  
    
    private void Flip(GameObject effect)
    {
        Vector3 kich_thuoc = effect.transform.localScale;
        kich_thuoc.x = -1 * kich_thuoc.x;
        effect.transform.localScale = kich_thuoc;
    }
}