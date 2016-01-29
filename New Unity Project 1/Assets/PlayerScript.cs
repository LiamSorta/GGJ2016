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


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        HpRegen();
	}

    private void HpRegen()
    {
        _health += hpRegenModifier * Time.deltaTime;
    }
}
