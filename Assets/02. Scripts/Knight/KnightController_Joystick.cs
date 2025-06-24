using System;
 using UnityEngine;
 using UnityEngine.UI;
 
 public class KnightController_Joystick : MonoBehaviour
 {
     private Animator animator;
     private Rigidbody2D knightRb;
 
     [SerializeField] private Button jumpButton;
     [SerializeField] private Button atkButton;
 
     private Vector3 inputDir;
     [SerializeField] private float moveSpeed = 3f;
     [SerializeField] private float jumpPower = 13f;
 
     private bool isGround = false;
     private bool isAttack = false;
 
     void Start()
     {
         animator = GetComponent<Animator>();
         knightRb = GetComponent<Rigidbody2D>();
 
         jumpButton.onClick.AddListener(Jump);
         atkButton.onClick.AddListener(Attack);
     }
 
     void Update()
     {
         
     }
 
     void FixedUpdate()
     {
         Move();
     }
 
     void OnCollisionEnter2D(Collision2D other)
     {
         if (other.gameObject.CompareTag("Ground"))
         {
             animator.SetBool("isGround", true);
             isGround = true;
         }
     }
 
     void OnCollisionExit2D(Collision2D other)
     {
         if (other.gameObject.CompareTag("Ground"))
         {
             animator.SetBool("isGround", false);
             isGround = false;
         }
     }
 
     public void InputJoystick(float x, float y)
     {
         inputDir = new Vector3(x, y, 0).normalized;
         
         animator.SetFloat("JoystickX", inputDir.x);
         animator.SetFloat("JoystickY", inputDir.y);
     }
 
     void Move()
     {
         if (inputDir.x != 0)
         {
             var scaleX = inputDir.x > 0 ? 1 : -1;
             transform.localScale = new Vector3(scaleX, 1, 1);
             
             knightRb.linearVelocityX = inputDir.x * moveSpeed;
         }
     }
 
     void Jump()
     {
         if (isGround)
         {
             animator.SetTrigger("Jump");
             knightRb.AddForceY(jumpPower, ForceMode2D.Impulse);
         }
     }
 
     void Attack()
     {
         animator.SetBool("isCombo", false);
         
         if (!isAttack)
         {
             isAttack = true;
             animator.SetTrigger("Attack");
         }
         else
             animator.SetBool("isCombo", true);
     }
 
     // public void CheckCombo()
     // {
     //     if (!animator.GetBool("isCombo"))
     //         isAttack = false;
     // }
 
     public void EndAttackCombo()
     {
         isAttack = false;
     }
 }