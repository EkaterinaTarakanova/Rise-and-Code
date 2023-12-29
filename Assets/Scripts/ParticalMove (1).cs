using UnityEngine;

public class ParticleMove : MonoBehaviour
{
    public float temperature;
    public float boundaryRadius;
    public float repulsionRadius;
    public LayerMask boundaryLayer;
    public LayerMask sphereLayer;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        MoveSphere();
    }
    private float GetlVelocity()
    {
        const float BoltzmannConstant = 1.380649e-23f; // Постоянная Больцмана 
        const float particleMass = 1f; // Масса частицы 
        const long multiplier = 10000000000;
        float temperatureInKelvin = temperature + 273.15f; // Конвертация температуры в Кельвины 

        // Расчет скорости частицы по формуле МБТ (распределение Максвелла-Больцмана) 
        float averageSpeed = Mathf.Sqrt((3 * BoltzmannConstant * temperatureInKelvin) / particleMass) * multiplier;

        return averageSpeed;
    }
    private void MoveSphere()
    {
        float velocity = GetlVelocity(); // Задаем скорость частицы
        // Перемещение сферы
        Vector3 movement = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
        rb.AddForce(movement * velocity);

        // Отталкивание от краев области
        Collider[] boundaryColliders = Physics.OverlapSphere(transform.position, boundaryRadius, boundaryLayer);
        foreach (var boundaryCollider in boundaryColliders)
        {
            Vector3 repulsionDirection = (transform.position - boundaryCollider.ClosestPoint(transform.position)).normalized;
            rb.AddForce(repulsionDirection * velocity);
        }

        // Отталкивание от других сфер
        Collider[] sphereColliders = Physics.OverlapSphere(transform.position, repulsionRadius, sphereLayer);
        foreach (var sphereCollider in sphereColliders)
        {
            Vector3 repulsionDirection = (transform.position - sphereCollider.ClosestPoint(transform.position)).normalized;
            rb.AddForce(repulsionDirection * velocity);
        }
    }
}