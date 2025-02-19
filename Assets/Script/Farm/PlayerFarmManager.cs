using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFarmManager : MonoBehaviour
{
    public bool isInside;
    public FarmManager currentFarmMng;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isInside==true && Input.GetKeyDown(KeyCode.E))
        {
            currentFarmMng.etkilesim();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Farm" && isInside==false)
        {
            isInside = true;
            currentFarmMng= collision.gameObject.GetComponent<FarmManager>();
            currentFarmMng.gosterme.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Farm")
        {
            currentFarmMng.gosterme.SetActive(false);
            isInside = false;
            currentFarmMng = null;
        }
    }
}
