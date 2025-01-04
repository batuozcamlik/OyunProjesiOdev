using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GetDamage : MonoBehaviour
{
    public int healt;
    public GameObject infoPrefab;

    public Sprite destroyImage;
    public string addMngName;
    public GameMng mng;
    void Start()
    {
        mng = FindAnyObjectByType<GameMng>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getDamage(int dmg)
    {
        healt -= dmg;
        spawnDamageInfo(dmg);
        if (healt <= 0)
        {
            Debug.Log("Kirildi");
            destObj();
        }
    }

    public void destObj()
    {
        if(destroyImage!=null)
        {
            GetComponent<SpriteRenderer>().sprite = destroyImage;
            GetComponent<BoxCollider2D>().enabled = false;
            gameObject.layer = 0;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void spawnDamageInfo(int damage)
    {
        GameObject a = Instantiate(infoPrefab, transform.position + new Vector3(0,0.5f,0), Quaternion.identity);
        float scale = Random.Range(0.5f, 1f);
        a.transform.DOScale(scale, 0);
        a.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = damage.ToString();
        a.transform.SetParent(transform);
       
        a.transform.DOMoveY((transform.position.y + 1f),1f).OnComplete(()=>Destroy(a));
    }
}
