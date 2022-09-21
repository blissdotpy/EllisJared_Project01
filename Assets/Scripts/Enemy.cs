using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;

    public int Health
    {
        get => health;
        set => health = value;
    }
}
