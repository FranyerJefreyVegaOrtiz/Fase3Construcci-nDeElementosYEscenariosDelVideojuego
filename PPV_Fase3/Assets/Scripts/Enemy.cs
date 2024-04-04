using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float rotationSpeed = 150f; // Velocidad de rotación del cañón
    public float minInterval = 1f; // Intervalo mínimo entre disparos
    public float maxInterval = 5f; // Intervalo máximo entre disparos

    private bool rotating = true; // Indica si el cañón está rotando o no

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
            // Rotar el cañón continuamente
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
        // Aquí puedes poner el código para disparar el proyectil
        GameObject newBullet;

        newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

        newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce);

        shotRateTime = Time.time + shotRate;

        Destroy(newBullet, 3);

        // Detener la rotación y reanudar después de un segundo
        rotating = false;
        Invoke("ResumeRotation", 1f);
    }

    void ResumeRotation()
    {
        rotating = true;
    }
}
