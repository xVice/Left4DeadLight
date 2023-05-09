using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    public float rotationSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        float xRot = Random.Range(-1f, 1f) * rotationSpeed * Time.deltaTime;
        float yRot = Random.Range(-1f, 1f) * rotationSpeed * Time.deltaTime;
        float zRot = Random.Range(-1f, 1f) * rotationSpeed * Time.deltaTime;

        Quaternion randomRotation = Quaternion.Euler(xRot, yRot, zRot);
        transform.rotation *= randomRotation;
    }

}
