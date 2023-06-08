using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class test_player_move : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    public float speed = 5;
    [HideInInspector]
    private Vector2 move_value = Vector2.zero;
    private int direction = 2;
    public Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void OnMove(InputValue value){
        Vector2 val = value.Get<Vector2>();
    
        move_value = (val);
        if(animator != null){
            if(move_value == Vector2.zero) return;
            RaycastHit2D hit= Physics2D.Raycast(transform.position, move_value, .1f,LayerMask.GetMask("Player"));
            Debug.DrawRay(transform.position, 
                hit.point - new Vector2(transform.position.x, transform.position.y), 
                Color.red);
            animator.SetBool("Moving", true);
            
            if(val.y > 0){   //N
                if(val.y > Mathf.Abs(val.x)){ // N >>>
                    direction = 0;
                }else{      // W OR E BETTER
                    direction = (val.x > 0) ? 1 : 3;
                }


            }else{          //S
                if(-val.y > Mathf.Abs(val.x)){ // S >>>
                    direction = 2;
                }else{ // W OR E BETTER
                    direction = (val.x > 0) ? 1 : 3;
                }
            }
            
        }
    }
    public void OnTouch(InputValue value){
        Debug.Log("touch");
    }
    public void OnTest(InputValue value){
        Debug.Log("test");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(animator.GetBool("Moving"));
        //Debug.Log(animator.GetInteger("Direction"));
        
        if(animator != null && move_value == Vector2.zero )animator.SetBool("Moving", false); 
        animator.SetInteger("Direction", direction);
        
        rb.velocity = (move_value * speed);
        if(Input.GetKey(KeyCode.LeftShift)) rb.velocity = rb.velocity * 1.2f;
    }
}
