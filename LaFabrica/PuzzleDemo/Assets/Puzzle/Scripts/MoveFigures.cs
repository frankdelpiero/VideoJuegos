using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFigures : MonoBehaviour
{
    public GameObject shadowFigures;
    private bool ismove, isPlaced;
    private float positionX;
    private float positionY;
    const float MINIMUM = 1.2f;
    private float XPosition, YPosition, ZPosition;
    private float initialPosX;
    private float initialPosY;
    private float initialPosZ;
    // Start is called before the first frame update
    void Start()
    {
        this.InitialPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (ismove && isPlaced == false)
        {
            Vector3 position;
            position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            XPosition = position.x - positionX;
            YPosition = position.y - positionY;
            ZPosition = this.gameObject.transform.localPosition.z;
            this.gameObject.transform.localPosition = new Vector3(XPosition, YPosition, ZPosition);

        }


    }
    /*
     Funcion que reacciona cuando el usuario hace click
     */
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 position;
            position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            positionX = position.x - this.transform.localPosition.x;
            positionY = position.y - this.transform.localPosition.y;
            ismove = true;
        }
    }

    private void OnMouseUp()
    {
        ismove = false;
        float shadowXPosition = shadowFigures.transform.localPosition.x;
        float shadowYPosition = shadowFigures.transform.localPosition.y;
        float shadowZPosition = shadowFigures.transform.localPosition.z;
        XPosition = this.transform.localPosition.x - shadowXPosition;
        YPosition = this.transform.localPosition.y - shadowYPosition;
        if (Mathf.Abs(XPosition) <= MINIMUM && Mathf.Abs(YPosition) <= MINIMUM)
        {
            this.transform.localPosition = new Vector3(shadowXPosition, shadowYPosition, shadowZPosition);
           GameObject.Find("Canvas").GetComponent<Finished>().isFinished();
            isPlaced = true;
        }
        else
        {
            this.transform.localPosition = new Vector3(initialPosX, initialPosY, initialPosZ);
        }
    }

    private void InitialPosition()
    {
        initialPosX = this.transform.localPosition.x;
        initialPosY = this.transform.localPosition.y;
        initialPosZ = this.transform.localPosition.z;
    }


}


