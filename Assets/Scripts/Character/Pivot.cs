using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{
    public GameObject player;
    public SpriteRenderer render;
    public ChrMovementController playerScript;
    public Transform circleOrigin;
    public float radius;
    [SerializeField]
    private bool hitboxEnabled = false;
    public Vector3 difference;


    void Start()
    {
        render = player.GetComponent<SpriteRenderer>();
        playerScript = player.GetComponent<ChrMovementController>();
    }
    void Update()
    {
        DetectColliders();

    }
    private void FixedUpdate()
    {
        if (playerScript.isAttacking)
        {
            return;
        }
        difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        if (rotationZ > 30 & rotationZ < 1500)
        {
            render.sortingOrder = 3;
        }
        else
        {
            render.sortingOrder = 1;
        }

        if (rotationZ < -90 || rotationZ > 90)
        {
            if (player.transform.eulerAngles.y == 0)
            {
                transform.localRotation = Quaternion.Euler(180, 0, -rotationZ);
            }
            else if (player.transform.eulerAngles.y == 180)
            {
                transform.localRotation = Quaternion.Euler(180, 180, -rotationZ);
            }
        }
    }

    public void UpdateHitboxStatus()
    {
        hitboxEnabled = !hitboxEnabled;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector3 position = circleOrigin.position;
        Gizmos.DrawWireSphere(position, radius);
    }
    public void DetectColliders()
    {
        if (hitboxEnabled == false)
        {
            return;
        }
        foreach (Collider2D collider in Physics2D.OverlapCircleAll(circleOrigin.position, radius))
        {
            Debug.Log(collider.tag);
            if (collider.tag == "Enemy")
            {
                enemyHit contact = collider.gameObject.GetComponent<enemyHit>();
                Health enemyHealth = collider.gameObject.GetComponent<Health>();
                contact.onHit(difference); // KnockBack
                StartCoroutine(contact.hitStunTimer(enemyHealth, ChrStats.attack));
                // Deal Damage


            }
            else
            {

            }
        }
    }

}
