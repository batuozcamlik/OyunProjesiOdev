using UnityEngine;

public class DayNightIntensityCycle : MonoBehaviour
{
    public UnityEngine.Rendering.Universal.Light2D globalLight; // 2D Global Light referansý
    public float dayDuration = 60f; // Bir tam döngü (sabah-gece) süresi (saniye)
    public float currentTime = 0f;

    public float minIntensity = 0.2f; // En karanlýk (gece) ýþýk seviyesi
    public float maxIntensity = 1f;  // En aydýnlýk (öðlen) ýþýk seviyesi

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

        // Zamaný ilerlet
        currentTime += Time.deltaTime;

        // Döngüyü sýfýrla (tekrarlý döngü)
        if (currentTime > dayDuration)
        {
            currentTime = 0f;
        }

        // Günün hangi aþamasýnda olduðumuzu belirle
        float timeProgress = currentTime / dayDuration;

        // Sabah -> Öðlen -> Akþam -> Gece geçiþleri
        if (timeProgress <= 0.25f) // Gece -> Sabah
        {
           
            float t = timeProgress / 0.25f;
            globalLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, t);
        }
        else if (timeProgress <= 0.75f) // Sabah -> Öðlen -> Akþam
        {
           
            float t = (timeProgress - 0.25f) / 0.5f;
            globalLight.intensity = Mathf.Lerp(maxIntensity, minIntensity, t);
        }
        else // Akþam -> Gece
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
