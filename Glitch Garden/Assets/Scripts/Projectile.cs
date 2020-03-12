using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Range(0f,10f)] [SerializeField] float currentSpeed = 2f;
    [SerializeField] int damage = 100;
    [SerializeField] bool moveRight = true;

    // Update is called once per frame
    void Update()
    {
        if(moveRight)
        {
        transform.Translate(Vector2.right * currentSpeed * Time.deltaTime, Space.Self);
        } else transform.Translate(Vector2.left * currentSpeed * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var enemy = otherCollider.GetComponent<Enemy>();
        if(enemy && health)
        {
            health.DealDamage(damage); // reduce health of Game Object with Health class
            Destroy(gameObject);
        } 
    }
}
