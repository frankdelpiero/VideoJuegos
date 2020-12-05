using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finished : MonoBehaviour
{
    private int numberOfFigures;
    private int placedFigures;
    public GameObject figures;
    private bool finished = false;
    // Start is called before the first frame update
    void Start()
    {
        numberOfFigures = figures.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (finished == true)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }

    }
    public void isFinished()
    {
        placedFigures++;

        if (placedFigures >= numberOfFigures)
        {
            finished = true;
            Debug.Log(finished);
        }

    }

}
