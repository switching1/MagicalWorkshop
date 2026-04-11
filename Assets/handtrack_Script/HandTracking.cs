using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Mathematics.math;

public class HandTracking : MonoBehaviour
{
    // Start is called before the first frame update
    public UDPReceive udpReceive;
    public GameObject[] handPoints;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string data = udpReceive.data;

        data = data.Remove(0, 1);
        data = data.Remove(data.Length-1, 1);
        //print(data);
        string[] points = data.Split(',');
        //print(points[0]);

        //0        1*3      2*3


        for ( int i = 0; i<21; i++)
        {

            float x = 7-float.Parse(points[i * 3])/100;
            float y = float.Parse(points[i * 3 + 1]) / 100;
            float z = float.Parse(points[i * 3 + 2]) / 100;

            handPoints[i].transform.localPosition = new Vector3(x, y, z);
  
        }

        Vector3 difference = new Vector3(
            handPoints[8].transform.localPosition.x - handPoints[4].transform.localPosition.x,
            handPoints[8].transform.localPosition.x - handPoints[4].transform.localPosition.x,
            handPoints[8].transform.localPosition.x - handPoints[4].transform.localPosition.x);


        Vector3 difference_petitdoigt_poignet = new Vector3(
            handPoints[20].transform.localPosition.x - handPoints[0].transform.localPosition.x,
            handPoints[20].transform.localPosition.x - handPoints[0].transform.localPosition.x,
            handPoints[20].transform.localPosition.x - handPoints[0].transform.localPosition.x);

        Vector3 difference_annuaire_poignet = new Vector3(
            handPoints[16].transform.localPosition.x - handPoints[0].transform.localPosition.x,
            handPoints[16].transform.localPosition.x - handPoints[0].transform.localPosition.x,
            handPoints[16].transform.localPosition.x - handPoints[0].transform.localPosition.x);

                    Vector3 difference_majeur_poignet = new Vector3(
            handPoints[12].transform.localPosition.x - handPoints[0].transform.localPosition.x,
            handPoints[12].transform.localPosition.x - handPoints[0].transform.localPosition.x,
            handPoints[12].transform.localPosition.x - handPoints[0].transform.localPosition.x);

            print("diff maj poignet" + difference_majeur_poignet);
    }
}