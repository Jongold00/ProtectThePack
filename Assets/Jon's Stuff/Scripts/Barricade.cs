using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : MonoBehaviour
{

    #region Health

    [SerializeField]
    int health;

    [SerializeField]
    int maxHealth;

    #endregion Health

    public bool spiked;

    [SerializeField]
    int returnDamage;

    public void TakeDamage(int damage, GameObject source)
    {
        health -= damage;
        if (health <= 0)
        {
            DestroyMe();
        }
        if (spiked)
        {
            DealReturnDamage(source);
        }
    }

    private void DestroyMe()
    {
        Destroy(gameObject);
    }
    
    private void DealReturnDamage(GameObject source)
    {
        // source.TakeDamage(returnDamage);
    }

}
