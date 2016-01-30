using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    private float _damageModifier;
    private float _speedModifier;
    private float _armourModifier;
    private float _hpRegenModifier;

    private float _health;

    public float damageModifier { get { return _damageModifier; } set { _damageModifier = value; } }
    public float speedModifier { get { return _speedModifier; } set { _speedModifier = value; } }
    public float armourModifier { get { return _armourModifier; } set { _armourModifier = value; } }
    public float hpRegenModifier { get { return _hpRegenModifier; } set { _hpRegenModifier = value; } }

    public float health { get { return _health; } }

    Rigidbody2D rigidbody2D;


	// Use this for initialization
	void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        HpRegen();
        Movement();
	}

    private void HpRegen()
    {
        _health += hpRegenModifier * Time.deltaTime;
    }

    private void Movement()
    {
        GetComponent<Rigidbody>().velocity = Vector2.zero;
        Vector2 movement= new Vector2(Input.GetAxisRaw("Horizontal") * speedModifier * Time.deltaTime, Input.GetAxisRaw("Vertical") * speedModifier * Time.deltaTime);
        GetComponent<Rigidbody>().velocity = movement;
    }


}
