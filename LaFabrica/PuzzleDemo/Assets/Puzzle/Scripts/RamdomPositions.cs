using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamdomPositions : MonoBehaviour
{
    public GameObject figures;
    private List<float> xPosition;
    public System.Random ran;
    private int rnd;
    // Start is called before the first frame update
    void Start()
    {
        this.RandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void RandomPosition()
    {
        xPosition = new List<float> { -8.0f, -3f, 2.3f, 8.0f };
        int j = 4;
        int nPos;
        nPos = xPosition.Count;
        for (int i=0; i < nPos; i++)
        {
            ran = new System.Random();
            rnd = ran.Next(0, j);
            figures.transform.GetChild(i).Translate(xPosition[rnd], 0, 0);
            this.xPosition.Remove(xPosition[rnd]);
            j--;
        }

    }
}
