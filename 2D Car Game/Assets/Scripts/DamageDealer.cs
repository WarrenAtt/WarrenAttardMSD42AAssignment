﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] public int damage = 1;

    //returns the amount of damage
    public int GetDamage()
    {
        return damage;
    }

    //destroys the gameObject
    public void Hit()
    {
        //Destroy(gameObject);
    }
}
