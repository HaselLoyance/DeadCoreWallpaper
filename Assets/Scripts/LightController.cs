using UnityEngine;

public class LightController : MonoBehaviour
{
    public float intensityStrength = 0.05f;

	void Update ()
    {
        Light l = GetComponent<Light>();
        l.intensity = l.intensity + (Mathf.Sin(Time.time) * intensityStrength);
    }
}
