using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMng : MonoBehaviour
{
    public int bugday;
    public int havuc;
    public int odun;
    public int tas;

    public int altin;
    void Start()
    {
        
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
    }
}
