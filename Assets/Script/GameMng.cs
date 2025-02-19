using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameMng : MonoBehaviour
{
    [Header("All Value")]
    public int bugday;
    public int havuc;
    public int odun;
    public int tas;

    public int altin;

    [Header("All Text")]
    public TextMeshProUGUI bugdayText;
    public TextMeshProUGUI havucText;
    public TextMeshProUGUI odunText;
    public TextMeshProUGUI tasText;
    public TextMeshProUGUI altinText;
    void Start()
    {
        updateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void add(string name)
    {
        if(name=="odun")
        {
            odun++;
        }
        if(name=="tas")
        {
            tas++;
        }
        updateText();
    }

    public void updateText()
    {
        bugdayText.text = "x"+bugday.ToString();
        havucText.text = "x" + havuc.ToString();
        odunText.text = "x" + odun.ToString();
        tasText.text = "x" + tas.ToString();
        altinText.text = "x" + altin.ToString();
    }

    public void havucSat(int para)
    {
        if(havuc>0)
        {
            havuc--;
            altin += para;
        }
        updateText();
    }

    public void bugdaySat(int para)
    {
        if (bugday > 0)
        {
            bugday--;
            altin += para;
        }
        updateText();
    }

    public void tasSat(int para)
    {
        if (tas > 0)
        {
            tas--;
            altin += para;
        }
        updateText();
    }

    public void odunSat(int para)
    {
        if (odun > 0)
        {
            odun--;
            altin += para;
        }
        updateText();
    }
}
