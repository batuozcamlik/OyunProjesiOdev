using UnityEngine;

public class DayNightIntensityCycle : MonoBehaviour
{
    public UnityEngine.Rendering.Universal.Light2D globalLight;
    public float dayDuration = 60f; 
    public float currentTime = 0f;

    public float minIntensity = 0.2f; 
    public float maxIntensity = 1f;  

    public bool isNight;
    public bool isLightOpen;

    public GameObject[] allLight;
    void Update()
    {
        if(globalLight.intensity>0.5f)
        {
            isNight = false;
            if(isLightOpen)
            {
                isLightOpen = false;
                lightChange(false);
            }
        }
        else
        {
            isNight=true;
            if(isLightOpen==false)
            {
                isLightOpen = true;
                lightChange(true);
            }
        }

        
        currentTime += Time.deltaTime;

        
        if (currentTime > dayDuration)
        {
            currentTime = 0f;
        }

       
        float timeProgress = currentTime / dayDuration;

        
        if (timeProgress <= 0.25f)
        {
           
            float t = timeProgress / 0.25f;
            globalLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, t);
        }
        else if (timeProgress <= 0.75f) 
        {
           
            float t = (timeProgress - 0.25f) / 0.5f;
            globalLight.intensity = Mathf.Lerp(maxIntensity, minIntensity, t);
        }
        else 
        {
           
            float t = (timeProgress - 0.75f) / 0.25f;
            globalLight.intensity = Mathf.Lerp(minIntensity, minIntensity, t);
        }
    }

    public void lightChange(bool a)
    {
        for (int i = 0; i < allLight.Length; i++)
        {
            allLight[i].SetActive(a);
        }
    }
}
