using UnityEngine;

public class DayNightIntensityCycle : MonoBehaviour
{
    public UnityEngine.Rendering.Universal.Light2D globalLight; // 2D Global Light referans�
    public float dayDuration = 60f; // Bir tam d�ng� (sabah-gece) s�resi (saniye)
    public float currentTime = 0f;

    public float minIntensity = 0.2f; // En karanl�k (gece) ���k seviyesi
    public float maxIntensity = 1f;  // En ayd�nl�k (��len) ���k seviyesi

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

        // Zaman� ilerlet
        currentTime += Time.deltaTime;

        // D�ng�y� s�f�rla (tekrarl� d�ng�)
        if (currentTime > dayDuration)
        {
            currentTime = 0f;
        }

        // G�n�n hangi a�amas�nda oldu�umuzu belirle
        float timeProgress = currentTime / dayDuration;

        // Sabah -> ��len -> Ak�am -> Gece ge�i�leri
        if (timeProgress <= 0.25f) // Gece -> Sabah
        {
           
            float t = timeProgress / 0.25f;
            globalLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, t);
        }
        else if (timeProgress <= 0.75f) // Sabah -> ��len -> Ak�am
        {
           
            float t = (timeProgress - 0.25f) / 0.5f;
            globalLight.intensity = Mathf.Lerp(maxIntensity, minIntensity, t);
        }
        else // Ak�am -> Gece
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
