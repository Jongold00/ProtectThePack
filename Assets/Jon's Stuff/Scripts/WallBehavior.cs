using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehavior : MonoBehaviour
{
    public int health = 100;

    public void LoseHealth(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            DestroyMe();
        }
    }

    public void GainHealth(int heal)
    {
        health += heal;
    }

    void DestroyMe()
    {
        Destroy(gameObject);
    }
}
