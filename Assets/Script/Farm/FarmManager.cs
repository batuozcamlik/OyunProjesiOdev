using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum farmType
{
    bugday,
    havuc
}
public class FarmManager : MonoBehaviour
{
    public farmType currentFarmType;
    public float currentFarmDuration;
    public float farmDuration;

    public bool canCollected;
    public bool isPlanted = false;
    public SpriteRenderer plantSprite;

    public Sprite[] farmSprite;
    public GameMng mng;

    public GameObject gosterme;
    public GameObject toplanbilirGorsel;
    void Start()
    {
        mng=FindAnyObjectByType<GameMng>();
        
    }

    
    void Update()
    {
        if(!isPlanted)
        {
            toplanbilirGorsel.SetActive(false);
            return;
        }
        if(currentFarmDuration > 0)
        {
            toplanbilirGorsel.SetActive(false);
            currentFarmDuration -= Time.deltaTime;

            if(farmDuration/2 >currentFarmDuration)
            {
                plantSprite.sprite = farmSprite[1];
            }
        }
        else
        {
            canCollected = true;
            toplanbilirGorsel.SetActive(true);
            plantSprite.sprite = farmSprite[2];
        }
        
    }

    public void etkilesim()
    {
        if(isPlanted==true && canCollected==false)
        {
            return;
        }

        if(canCollected==false)
        {
         
            plantSprite.sprite = farmSprite[0];
            isPlanted = true;
            currentFarmDuration = farmDuration;
        }
        else
        {
            Debug.Log("Topla");

            if(currentFarmType==farmType.bugday)
            {
                mng.bugday++;
                mng.updateText();
            }
            else if(currentFarmType ==farmType.havuc)
            {
                mng.havuc++;
                mng.updateText();
            }

            canCollected = false;
            plantSprite.sprite = null;
            isPlanted = false;
           

        }
        
        
    }
}
