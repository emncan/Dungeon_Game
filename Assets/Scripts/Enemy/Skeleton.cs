using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageble
{
    public int Health { get; set; }
    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public override void Movement()
    {
        base.Movement();

        float distance = Vector3.Distance(player.transform.localPosition, transform.localPosition);
        Debug.Log("Distance: " + distance);

        Vector3 direction = player.transform.localPosition - transform.localPosition;

        Debug.Log("side " + direction.x);

        if(direction.x > 0) { }
    }

    public void Damage()
    {
        Debug.Log("Damage()");
        Health--;
        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("InCombat", true);

        if(Health < 1)
        {
            Destroy(this.gameObject);
        }
    }
}
