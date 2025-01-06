using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market : MonoBehaviour
{
    public GameObject markett;
    private bool isIn = false;
    void Start()
    {
        markett.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            markett.SetActive(true);
            markett.transform.DOScale(5, 1f).From(0).SetEase(Ease.OutBack);
            isIn = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isIn = false;
            
            markett.transform.DOScale(0, 0.5f).From(5).SetEase(Ease.InBack).OnComplete(()=>close());
        }
    }

    public void close()
    {
        if(isIn==false)
        {
            markett.SetActive(false);
        }
    }
}
