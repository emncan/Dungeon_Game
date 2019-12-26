using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageble
{
    public int Health { get; set; }
    public override void Init()
    {
        base.Init();
    }

    public void Damage()
    {

    }

}
