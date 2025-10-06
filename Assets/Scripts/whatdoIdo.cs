using UnityEngine;

public class whatdoIdo : MonoBehaviour
{
    public Light lightSource;
    public float minIntensity = 0.5f;  
    public float maxIntensity = 2f;  
    public float flickerSpeed = 0.1f;  

    private float targetIntensity;
    private float smoothFactor = 0.1f;  

    void Start()
    {
        if (lightSource == null)
        {
            lightSource = GetComponent<Light>();
        }
    }

    void Update()
    {
        FlickerLight();
    }

    void FlickerLight()
    {
        if (Random.value > 0.9)  
        {
            targetIntensity = Random.Range(minIntensity, maxIntensity);
        }

        
        lightSource.intensity = Mathf.Lerp(lightSource.intensity, targetIntensity, smoothFactor * flickerSpeed);
    }
}
