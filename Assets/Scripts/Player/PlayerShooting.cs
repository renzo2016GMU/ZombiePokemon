using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int shotDamage = 1;

    public Rigidbody projectile;
    public Transform shotPos;
    public AudioSource shootSound;          //Plays a sound whenever a new zombie pokemon is spawned
    public float shotForce = 1000f;
    private Ray shootRay;
    public float timeBetweenAttacks = 0.5f;
    float timer;

    //public Transform objToMove;
    // Use this for initialization
    void Start()
    {
        Cardboard.SDK.OnTrigger += On_Click;
        shootSound = GetComponent<AudioSource>();
    }
    void On_Click()
    {
        int shootableMask = LayerMask.GetMask("Shootable");
        shootRay = GetComponentInChildren<CardboardHead>().Gaze;
        //Debug.DrawRay(shootRay.origin, shootRay.direction, Color.blue, 1);
        //RaycastHit shootHit;
        //if (Physics.Raycast(shootRay, out shootHit, 250, shootableMask))
        //{
        //    Debug.Log("PIKA");
        //    PokemonHealth currentPokeHP = shootHit.collider.GetComponent<PokemonHealth>(); //get the HP of the pokemon that you just hit
        //    currentPokeHP.TakeDamage(shotDamage); //subtract the pokemon's HP from the damage of the shot
        //    Debug.Log("current pokemon's hp is " + currentPokeHP.currentHealth);
        //}
        if (timer >= timeBetweenAttacks)
        {
            Shoot();
        }
    }
    void Update()
    {
        Cardboard.SDK.UpdateState();
        Pose3D head = Cardboard.SDK.HeadPose;
        shootRay = GetComponentInChildren<CardboardHead>().Gaze;
        timer += Time.deltaTime;
    }

    void Shoot()
    {
        timer = 0f;
        Vector3 position = shootRay.direction + (Vector3.up * 2) + Vector3.forward;
        Rigidbody shot = Instantiate(projectile, position, shotPos.rotation) as Rigidbody;
        shot.AddForce(shootRay.direction * shotForce);
        //Physics.IgnoreCollision(shot.GetComponent<Collider>(), GetComponent<Collider>());
        shootSound.Play();
        Destroy(shot.gameObject, 6f);
    }
}
