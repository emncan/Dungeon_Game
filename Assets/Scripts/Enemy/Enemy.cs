﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int gems;
    [SerializeField]
    protected Transform pointA, pointB;

    protected Vector3 currentTarget;
    protected Animator anim;
    private SpriteRenderer _sprite;

    protected bool isHit = false;
    protected Player player;

    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && anim.GetBool("InCombat") == false) // check if current anim is Idle do nothing
        {
            return;
        }
        Movement();
    }

    public virtual void Movement()
    {
        if (currentTarget == pointA.position) // first idle and then move
        {
            _sprite.flipX = true;
        }
        else
        {
            _sprite.flipX = false;
        }

        if (transform.position == pointA.position)
        {
            
            currentTarget = pointB.position;
            anim.SetTrigger("Idle");
            _sprite.flipX = false;

        }
        else if (transform.position == pointB.position)
        {
            
            currentTarget = pointA.position;
            anim.SetTrigger("Idle");

        }
        if(isHit == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }

        float distance = Vector3.Distance(player.transform.localPosition,transform.localPosition);
      //  Debug.Log("Distance: " + distance + "for" + transform.name);
        if(distance > 2.0f)
        {
            isHit = false;
            anim.SetBool("InCombat", false);
        }
    }

    


}
