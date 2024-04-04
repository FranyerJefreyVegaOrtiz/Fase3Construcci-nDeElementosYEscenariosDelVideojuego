using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float rotationSpeed = 150f; // Velocidad de rotaci�n del ca��n
    public float minInterval = 1f; // Intervalo m�nimo entre disparos
    public float maxInterval = 5f; // Intervalo m�ximo entre disparos

    private bool rotating = true; // Indica si el ca��n est� rotando o no

    public Transform spawnPoint;

    public GameObject bullet;

    public float shotForce = 1500f;
    public float shotRate = 1f;
    private float shotRateTime = 0;

    void Start()
    {
        // Comienza el ciclo de disparo aleatorio
        Invoke("RandomFire", Random.Range(minInterval, maxInterval));
    }

    void Update()
    {
        if (rotating)
        {
            // Rotar el ca��n continuamente
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }

    void RandomFire()
    {
        // Disparar y establecer un nuevo intervalo aleatorio
        Fire();
        Invoke("RandomFire", Random.Range(minInterval, maxInterval));
    }

    void Fire()
    {
        // Aqu� puedes poner el c�digo para disparar el proyectil
        GameObject newBullet;

        newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

        newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce);

        shotRateTime = Time.time + shotRate;

        Destroy(newBullet, 3);

        // Detener la rotaci�n y reanudar despu�s de un segundo
        rotating = false;
        Invoke("ResumeRotation", 1f);
    }

    void ResumeRotation()
    {
        rotating = true;
    }
}
