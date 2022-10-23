using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;
    public bool inHitStun;

    void Start()
    {

    }
    public void TakeDamage(float damageTaken)
    {
        if (inHitStun)
        {
            return;
        }

        health = health - damageTaken;
        if (health <= 0)
        {
            Despawn();
        }
        StartCoroutine(hitStun());


    }

    private void Despawn()
    {
        Destroy(this.gameObject);
    }
    private IEnumerator hitStun()
    {
        inHitStun = true;
        yield return new WaitForSeconds(.3f);
        inHitStun = false;
    }
}
