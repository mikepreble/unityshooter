using UnityEngine;
using System.Collections;

public class grenadeDamage : MonoBehaviour {

	public int damagePerThrow = 50;

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Enemy"){

			EnemyHealth enemyHealth = other.gameObject.GetComponent("EnemyHealth") as EnemyHealth;

			if(enemyHealth != null)
			{
				enemyHealth.TakeDamage (damagePerThrow, other.contacts[0].point);

			}
		}
		Destroy(gameObject);
	}
}
