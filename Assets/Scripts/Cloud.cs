using UnityEngine;

public class Cloud : MonoBehaviour
{
    float moveSpeed = 10.0f;
    float rotationSpeed = 15.0f;
    float destroyAt = 1.0f;
    
    void Start()
    {
        transform.eulerAngles = new Vector3(0,0,Random.Range(0.0f, 360.0f));
        float newScale = Random.Range(2.0f, 3.0f);
        transform.localScale = new Vector3(newScale, newScale, 1);
    }

    public void Begin (float _moveSpeed, float _rotationSpeed, float _destroyAt)
    {
        moveSpeed = _moveSpeed;
        rotationSpeed = _rotationSpeed * (Random.value >= 0.5 ? -1 : 1);
        destroyAt = _destroyAt;
        GetComponent<Rigidbody>().velocity = new Vector3(moveSpeed, 0, 0);
    }
	
	void Update ()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

        if ((destroyAt < 0.0f && transform.position.x < destroyAt) ||
            (destroyAt > 0.0f && transform.position.x > destroyAt))
            Destroy(gameObject);
    }
}
