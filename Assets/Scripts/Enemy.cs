using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float velocidad; 
    private Transform jugador;

    private float horizontalInput;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Vector2 _movement;
    public GameObject BulletPrefab;

    private int Health = 3;
    private float LastShoot;

    public GameObject shooter;
    // Start is called before the first frame update

    
private Transform _firePoint;
private Transform _shootingArea;

        void Update()
    {
        if (jugador == null) return;

        Vector3 direction = jugador.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        float distance = Mathf.Abs(jugador.position.x - transform.position.x);

        if (distance < 1.0f && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    private void Shoot()
    {
        Vector3 direction = new Vector3(transform.localScale.x, 0.0f, 0.0f);
        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetDirection(direction);
    }

    public void Hit()
    {
        Health -= 1;
        if (Health == 0) Destroy(gameObject);
    }


    // void Awake()
    // {
    //     _rigidbody = GetComponent<Rigidbody2D>();
    //     _animator = GetComponent<Animator>();
    //     _firePoint = transform.Find("FirePoint");
    //     _shootingArea = transform.Find("ShootingArea");
    // }

    // void Start()
    // {
    //     jugador = GameObject.FindGameObjectWithTag("Player").transform; // Asigna el jugador al inicio
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     if (jugador == null) return;
    //     transform.position = Vector2.MoveTowards(transform.position, jugador.position, velocidad * Time.deltaTime);
    //     RotaHaciaJugador();   
    //     _animator.SetBool("Run", Mathf.Abs(velocidad) > 0);      

    //     float distance = Mathf.Abs(jugador.position.x - transform.position.x);

    //     if (distance < 5.0f && Time.time > LastShoot + 1.25f)
    //     {
    //         Shoot();
    //         LastShoot = Time.time;
    //     }
    // }

    // void RotaHaciaJugador()
    // {
    //     Vector3 direccion = jugador.position - transform.position;
    //     // float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
        
    //     // Cambia la escala en el eje X para reflejar el sprite según la dirección
    //     if (direccion.x > 0)
    //         transform.localScale = new Vector3(1f, 1f, 1f); // Sin reflejo (normal)
    //     else if (direccion.x < 0)
    //         transform.localScale = new Vector3(-1f, 1f, 1f); // Reflejado horizontalmente


    // }

    // public void Hit()
    // {
    //     Health --;
    //     Debug.Log(Health);
    //     if (Health == 0) Destroy(gameObject);
    // }

    //     private void Shoot()
    // {

    //     // Vector3 direction;
    //     // // Vector3 direction = new Vector3(transform.localScale.x, 0.0f, 0.0f);

    //     // GameObject bullet = Instantiate(BulletPrefab, _firePoint.position, Quaternion.identity);

    //     // bullet.GetComponent<Bullet>().SetDirection(direction);

	// 		GameObject myBullet = Instantiate(BulletPrefab, _firePoint.position, Quaternion.identity) as GameObject;

	// 		Bullet bulletComponent = myBullet.GetComponent<Bullet>();

	// 		if (shooter.transform.localScale.x < 0f) {
	// 			// Left
	// 			bulletComponent.direction = Vector2.left; // new Vector2(-1f, 0f)
	// 		} else {
	// 			// Right
	// 			bulletComponent.direction = Vector2.right; // new Vector2(1f, 0f)
	// 		}

    // }
}
