using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float rotationSpeed = 150f; // Velocidad de rotación del cañón

    private bool rotating = true; // Indica si el cañón está rotando o no

    public Transform spawnPoint;

    public GameObject bullet;

    public float shotForce = 1500f;
    public float shotRate = 1f;

    private float shotRateTime = 0;

    void Update()
    {
        if (rotating)
        {
            // Rotar el cañón continuamente
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }

        // Detectar clic izquierdo del mouse
        if (Input.GetMouseButtonDown(0))
        {
            // Detener la rotación y disparar el proyectil
            StopRotation();
            Fire();
        }
    }

    void StopRotation()
    {
        rotating = false; // Detener la rotación
        Invoke("ResumeRotation", 1f); // Reanudar la rotación después de un segundo
    }

    void ResumeRotation()
    {
        rotating = true; // Reanudar la rotación
    }

    void Fire()
    {
        if (Time.time > shotRateTime)
        {
            GameObject newBullet;

            newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

            newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce);

            shotRateTime = Time.time + shotRate;

            Destroy(newBullet, 3);
        }
    }
}
