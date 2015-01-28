using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioClip deathClip;


    Animator anim;
    AudioSource enemyAudio;
    public ParticleSystem hitParticles;
	public ParticleSystem frozenEnemyParticle;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;
    
    public PlayerMagic regularGun;


    void Awake ()
    {
        anim = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();

        currentHealth = startingHealth;
        
    }


    void Update ()
    {
    
        if(isSinking)
        {
            transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
        }
        
    }


    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        if(isDead)
            return;

        enemyAudio.Play ();

        currentHealth -= amount;
     
//        if(PlayerMagic.regularGun)
//        {
//			hitParticles.transform.position = hitPoint;
//	        hitParticles.particleSystem.Play();
//	        Debug.Log("HIT PARTICLES");
//	        
//		}else{
//		
//			frozenEnemyParticle.transform.position = hitPoint;
//			frozenEnemyParticle.particleSystem.Play();
//			Debug.Log("ICE PARTICLES");
//			
//		}
		
        if(currentHealth <= 0)
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        anim.SetTrigger ("Dead");

        enemyAudio.clip = deathClip;
        enemyAudio.Play ();
    }


    public void StartSinking ()
    {
        GetComponent <NavMeshAgent> ().enabled = false;
        GetComponent <Rigidbody> ().isKinematic = true;
        isSinking = true;
        ScoreManager.score += scoreValue;
        Destroy (gameObject, 2f);
    }
}
