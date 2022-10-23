using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHit : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D body;
    private int health;
    private Vector2 forceApplied;
    public bool inHitStun;
    [SerializeField]
    private Animator enemyAnimator;
    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
        enemyAnimator = transform.gameObject.GetComponent<Animator>();
    }
    public void onHit(Vector3 difference)
    {
        if (inHitStun)
        {
            return;
        }
        enemyAnimator.SetTrigger("onHit");
        float xForce = difference.x;
        float yForce = difference.y;
        forceApplied = new Vector2(xForce, yForce);
        forceApplied.Normalize();
        forceApplied = new Vector2(forceApplied.x * 1050f, forceApplied.y * 1050f);
        body.AddForce(forceApplied);
        inHitStun = true;
        StartCoroutine(hitStunAnim());

    }
    public IEnumerator hitStunTimer(Health enemyHealth, float attack)
    {
        yield return new WaitForSeconds(.2f);
        enemyHealth.TakeDamage(attack);
    }
    IEnumerator hitStunAnim()
    {
        yield return new WaitForSeconds(0.01f);
        body.AddForce(-(forceApplied / 8));
        yield return new WaitForSeconds(.03f);
        body.AddForce(-(forceApplied / 8));
        yield return new WaitForSeconds(.02f);
        body.AddForce(-(forceApplied / 4));
        yield return new WaitForSeconds(.04f);
        body.AddForce(-(forceApplied / 2));
        yield return new WaitForSeconds(.3f);
        inHitStun = false;

    }
}
