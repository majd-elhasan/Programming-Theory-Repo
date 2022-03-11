using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SphereManager : MonoBehaviour
{
    float AngleChangeSpeed = 0.5f;
    float InvokingSpeed = 0.002f;

    Ball ballScript;
    GameObject PointPrefab;
    GameObject centerPoint;
    List<GameObject> circlingPoints = new List<GameObject>();
    int ballCount = 0;
    [SerializeField] int ball_list_count = 0;
    
    List<int[]> spawningList = new List<int[]>();
    Dictionary<int, bool> Switcher = new Dictionary<int, bool>();

    public bool OkayToSpawning = true;
    private void Start()
    {
        centerPoint = GameObject.Find("CenterPoint");
        centerPoint.transform.localScale = Vector3.one * 2;
        PointPrefab = (GameObject)Resources.Load("Point");

        ballScript = centerPoint.GetComponent<Ball>();
        //ballScript.Radius = 20;
        ball_spacing();
        StartCoroutine(AutoSwitch());
       
        InvokeRepeating("spawning_layouts", 0, InvokingSpeed); 
        
    }
    void ball_spacing()
    {
        for (int i =1; i < 12; i++)
        {
            if (i == 6) { ballCount = 18; }
            else if (i == 5 || i == 7) { ballCount = 15; }
            else if (i == 4 || i == 8) { ballCount = 12; }
            else if (i == 3 || i == 9) { ballCount = 9; }
            else if (i == 2 || i == 10) { ballCount = 6; }
            else if (i == 1 || i == 11) { ballCount = 4; }
            ball_list_count += ballCount;
            for (int j = 0; j < ballCount; j++)
            {
                addCirclingPoint();
            }
            spawningList.Add(new int[3] { i - 1, ballCount, ball_list_count });
            // dictionary
            Switcher.Add(i - 1, false);
        }
    }
    IEnumerator AutoSwitch()
    {
        for (int i = 0; i < spawningList.Count;i++)
        {
            Switcher[i] = !Switcher[i];
            yield return new WaitForSeconds(1);
        }
        StopCoroutine(AutoSwitch());
        
    }
    void spawning_layouts()
    {
        if (OkayToSpawning)
            for (int indexer = 0; indexer < spawningList.Count; indexer++)
                if (Switcher[indexer])
                    layout(spawningList[indexer][0], spawningList[indexer][1], spawningList[indexer][2]);
    }

    void addCirclingPoint()
    {
        GameObject newGameObject = Instantiate(PointPrefab, default, Quaternion.identity, this.transform);
        newGameObject.GetComponent<PointCicling>().V_angle_degree = 90;
        
        circlingPoints.Add(newGameObject);
        

    }
    void layout(int index, int ballCount , int ball_list_count)
    {
        int l = 0;
        for (int k = ball_list_count-ballCount; k < ball_list_count; k++)  // k starts with 0   ,  index starts with 0 ends with 10
        {
            if(index % 2 == 0)
                circlingPoints[k ].GetComponent<PointCicling>().Ballcolor = Color.red;
            circlingPoints[k].GetComponent<PointCicling>().H_angle_degree = 360/ballCount *l;

            //circlingPoints[k].gameObject.transform.localScale = Vector3.one * 3;
            circlingPoints[k].GetComponent<PointCicling>().Scale = Vector3.one * 3;
            circlingPoints[k].gameObject.SetActive(true);

            if (circlingPoints[k].GetComponent<PointCicling>().V_angle_degree < 18 * (15 - index))
                circlingPoints[k].GetComponent<PointCicling>().V_angle_degree += AngleChangeSpeed;
            else circlingPoints[k].GetComponent<PointCicling>().V_angle_degree = 18 * (15 - index);
            if (circlingPoints[circlingPoints.Count-1].gameObject.activeSelf)
                OkayToSpawning = false;
            l++;
        }
    }
    private void Update()
    {
        if(!OkayToSpawning)
        foreach(GameObject point in circlingPoints)
        {
            point.GetComponent<PointCicling>().H_angle_degree -=  AngleChangeSpeed ; // horizontal
            point.GetComponent<PointCicling>().V_angle_degree -=  AngleChangeSpeed ; // vertical
        }
    }

}                                                                              
                                                                               