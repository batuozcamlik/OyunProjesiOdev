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
    void Start()
    {
        
    }

    
    void Update()
    {
        if(!isPlanted)
        {
            return;
        }
        if(currentFarmDuration > 0)
        {
            currentFarmDuration -= Time.deltaTime;

            if(farmDuration/2 >currentFarmDuration)
            {
                plantSprite.sprite = farmSprite[1];
            }
        }
        else
        {
            canCollected = true;
            plantSprite.sprite = farmSprite[2];
        }
    }

    public void etkilesim()
    {
        if(canCollected==false)
        {
         
            plantSprite.sprite = farmSprite[0];
            isPlanted = true;
            currentFarmDuration = farmDuration;
        }
        else
        {
            Debug.Log("Topla");
            canCollected = false;
            plantSprite.sprite = null;
            isPlanted = false;
           

        }
        
        
    }
}
