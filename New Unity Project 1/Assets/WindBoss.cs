using UnityEngine;
using System.Collections;

public class WindBoss : MonoBehaviour {

    private float health = 50f;
    Camera mainCam;
    float attackTime;
    float stunTime;
    bool isStunned;
    float angle = -50f;
    Rigidbody2D rgbd;
    Vector2 Dir;
    float speed = 1000;
    float speedModifier = 1f;
    float damage = 2.5f;
    public float damageModifier = 1f;
    public float armourModifier = 1f;
    public bool Play = false;
    bool setup = false;
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Play)
        {
            if (!setup)
            {
                mainCam = FindObjectOfType<Camera>();
                //transform.position = mainCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0)) - GetComponent<SpriteRenderer>().bounds.extents;
                rgbd = GetComponent<Rigidbody2D>();
                setup = true;
            }
            Debug.Log(stunTime + "," + attackTime);
            if (!isStunned)
            {
                //if(angle < 0)
                //{
                angle = Random.Range(0, 360);
                stunTime = 3f;
                //}
                //else
                //{
                Dir = new Vector2(Mathf.Sin(Mathf.Deg2Rad * angle), Mathf.Cos(Mathf.Deg2Rad * angle));
                //}
                rgbd.AddForce(Dir * speed * speedModifier * Time.deltaTime);
                transform.Rotate(new Vector3(0, 0, 30f));
                attackTime -= Time.deltaTime;
            }
            else
            {
                attackTime = 3f;
                stunTime -= Time.deltaTime;
                rgbd.velocity = Vector2.zero;
                transform.rotation = Quaternion.identity;
            }
            if (attackTime <= 0)
            {
                rgbd.velocity = Vector2.zero;
                isStunned = true;
                stunTime = 1.5f;
            }
            if (stunTime <= 0)
                isStunned = false;
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isStunned)
        {
            other.GetComponent<PlayerScript>().TakeDamage(damage * damageModifier);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage * armourModifier;
    }
}
