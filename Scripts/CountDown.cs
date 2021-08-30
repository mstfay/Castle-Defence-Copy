using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    float totalTime = 0;
    float passingTime = 0;

    bool work = false;
    bool start = false;

    /// <summary>
    /// Geri sayım sayacının toplam süresini ayarlar.
    /// </summary>
    public float TotalTime
    {
        set
        {
            if (!work)
            {
                totalTime = value;
            }
        }
    }

    /// <summary>
    /// Geri sayımın bitip bitmediğini söyler.
    /// </summary>
    public bool Over
    {
        get
        {
            return start && !work;
        }
    }

    /// <summary>
    /// Sayacı çalıştırır.
    /// </summary>
    public void RunIt()
    {
        if (totalTime > 0)
        {
            work = true;
            start = true;
            passingTime = 0;
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        if (work)
        {
            passingTime += Time.deltaTime;
            if (passingTime >= totalTime)
            {
                work = false;
            }
        }
    }
}
