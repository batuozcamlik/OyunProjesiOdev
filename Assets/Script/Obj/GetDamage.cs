using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetDamage : MonoBehaviour
{
    public int healt;
    public GameObject infoPrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getDamage(int dmg)
    {
        healt -= dmg;
        spawnDamageInfo(dmg);
        if (healt < 0)
        {
            Debug.Log("Kirildi");
        }
    }

    public void spawnDamageInfo(int damage)
    {
        GameObject a = Instantiate(infoPrefab, transform.localPosition + new Vector3(0,0.5f,0), Quaternion.identity);
        a.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = damage.ToString();
        a.transform.SetParent(transform);
        a.transform.DOMoveY((transform.localPosition.y + 0.5f),1f).OnComplete(()=>Destroy(a));
    }
}
