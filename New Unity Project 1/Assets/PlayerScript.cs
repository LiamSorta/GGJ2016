using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    private float _damageModifier = 1;
    private float _speedModifier = 1;
    private float _armourModifier = 1;
    private float _hpRegenModifier = 1;

    public bool freezeControls; //For Liam, cos he's weird

    private float _health = 100;
    private float _damage = 5f;
    private float _speed = 25f;

    public float damageModifier { get { return _damageModifier; } set { _damageModifier = value; } }
    public float speedModifier { get { return _speedModifier; } set { _speedModifier = value; } }
    public float armourModifier { get { return _armourModifier; } set { _armourModifier = value; } }
    public float hpRegenModifier { get { return _hpRegenModifier; } set { _hpRegenModifier = value; } }

    public float health { get { return _health; } }

    Rigidbody2D rigidbody;
    Collider2D collider;


	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
	}
	
    void Update()
    {
        /*GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject e in allEnemies)
        {
            if (collider.IsTouching(e.GetComponent<Collider2D>())&&Input.GetButtonDown("Fire1"))
            {
                //e.GetComponent<AIScript>().TakeDamage(damageModifier * _damage);
            }
        }*/
    }

	// Update is called once per frame
	void FixedUpdate () {
        HpRegen();
        Movement();
	}

    public void TakeDamage(float damage)
    {
        _health -= damage * armourModifier;
    }

    private void HpRegen()
    {
        _health += hpRegenModifier * Time.deltaTime;
    }

    private void Movement()
    {
        rigidbody.velocity = Vector2.zero;
        Vector2 movement= new Vector2(Input.GetAxisRaw("Horizontal") * speedModifier * Time.deltaTime, Input.GetAxisRaw("Vertical") * speedModifier * Time.deltaTime);
        rigidbody.velocity = movement;
    }


}
