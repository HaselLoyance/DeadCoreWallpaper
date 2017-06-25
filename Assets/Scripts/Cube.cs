using UnityEngine;

public class Cube : MonoBehaviour
{
    float moveSpeed = 20.0f;
    float rotationSpeed = 1.0f;
    float newScale = 1.0f;
    float downscaleRate = 0.001f;

    void Start ()
    {
        transform.eulerAngles = new Vector3(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f));
        newScale = Random.Range(0.4f,0.5f);
        transform.localScale = new Vector3(newScale, newScale, newScale);
    }

    public void Begin (float _rotationSpeed)
    {
        rotationSpeed = _rotationSpeed * (Random.value >= 0.5 ? -1 : 1);
    }

    void Update ()
    {
        downscaleRate = (moveSpeed * Time.deltaTime) * newScale / 150.0f;
        GetComponent<Rigidbody>().velocity = new Vector3(0, moveSpeed * Time.deltaTime / 15.0f, moveSpeed / 50.0f);

        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        transform.localScale -= new Vector3(downscaleRate, downscaleRate, downscaleRate);

        if (transform.localScale.x < 0.03f)
            Destroy(gameObject);
    }
}
