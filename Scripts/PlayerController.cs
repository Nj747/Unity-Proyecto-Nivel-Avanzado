using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public CharacterController2D controller;

    public GameObject uiTip;

    public float runSpeed = 40f;
    public bool isDead;

    float horizontalMove;
    bool jump = false;
    bool crouch = false;

    Animator animator;
    Rigidbody2D rb;
    AudioSource sndFailure;

    private void Awake()
    {
        uiTip.SetActive(false);
        isDead = false;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sndFailure = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!isDead)
        {
            horizontalMove = Input.GetAxis("Horizontal") * runSpeed;

            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                animator.SetBool("isJumping", true);
            }

            if (Input.GetButtonDown("Crouch"))
            {
                crouch = true;
                Agachado(crouch);
            }

            else if (Input.GetButtonUp("Crouch"))
            {
                crouch = false;
                Agachado(crouch);
            }
        }
        else
        {
            controller.enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            enabled = false;
        }
    }

    // eventos del character controller 2D
    public void Aterrizando()
    {
        animator.SetBool("isJumping", false);
    }

    public void Agachado(bool isCrouching)
    {
        animator.SetBool("isCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.deltaTime, crouch, jump);
        jump = false;
    }

    public void Herido()
    {
        animator.SetBool("Dead", true);
        animator.SetBool("isJumping", false);
        rb.AddForce(new Vector2(0, 100));
        isDead = true;
        sndFailure.Play();
        uiTip.SetActive(true);
    }

    public void PlayDeadAnimation()
    {
        animator.SetBool("Dead", true);
        isDead = true;
    }
}
