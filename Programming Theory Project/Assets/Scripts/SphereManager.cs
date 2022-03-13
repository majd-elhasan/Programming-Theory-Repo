using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SphereManager : MonoBehaviour
{
    float AngleChangeSpeed = 0.5f;
    float InvokingSpeed = 0.002f;

    Ball ballScript = new Ball();
    GameObject PointPrefab;
    GameObject centerPoint;
    List<GameObject> circlingPoints = new List<GameObject>();
    int ballCount = 0;
    [SerializeField] int ball_list_count = 0;
    
    List<int[]> spawningList = new List<int[]>();
    Dictionary<int, bool> Switcher = new Dictionary<int, bool>();

    public bool OkayToPlay = false;
    private void Start()
    {

        centerPoint = GameObject.Find("CenterPoint");
        PointPrefab = (GameObject)Resources.Load("Point");

        ball_spacing();
        StartCoroutine(AutoSwitch());
       
        InvokeRepeating("spawning_layouts", 0, InvokingSpeed); 
        
    }
    IEnumerator oneSec()
    {
        yield return new WaitForSeconds(1);
        OkayToPlay = true;

    }
    void ball_spacing()
    {
        for (int i =1; i < 12; i++)   // we have 11 levels of ball rings
        {
            if (i == 6) { ballCount = 18; }   // the middle (6'th) ring will have 18 balls in it
            else if (i == 5 || i == 7) { ballCount = 15; } // the 5'th and the 7'th rings will have 15 balls in them and so on... 
            else if (i == 4 || i == 8) { ballCount = 12; }
            else if (i == 3 || i == 9) { ballCount = 9; }
            else if (i == 2 || i == 10) { ballCount = 6; }
            else if (i == 1 || i == 11) { ballCount = 4; }
            ball_list_count += ballCount;  // save the ball count to a variable to use it later to instantiate them alternatly 
            for (int j = 0; j < ballCount; j++)
            {
                addCirclingPoint(); // add game object to our object_pool    4
            }
            spawningList.Add(new int[3] { i - 1, ballCount, ball_list_count }); // just take  the numbers which refer to the arrangement of the balls, and save them in a list

            // dictionary  , expand the dictionary which name is Switcher by the rings number
            Switcher.Add(i - 1, false);
        }
    }
    IEnumerator AutoSwitch()
    {
        for (int i = 0; i < spawningList.Count;i++)
        {
            Switcher[i] = !Switcher[i];  // make the value of the i'th key true (as we made all the values <value> false at the first )
            yield return new WaitForSeconds(1); // wait one second and continue 
        }
        
    }
    void spawning_layouts()
    {
        if (!OkayToPlay)  // this boolen variable exist to operate the spawning iteration while it is false
                          // the spawnin iteration will complete and then we'll make it true to stop that and start our movement codes 
            for (int indexer = 0; indexer < spawningList.Count; indexer++)
                if (Switcher[indexer])  // if the value is true 
                    layout(spawningList[indexer][0], spawningList[indexer][1], spawningList[indexer][2]);
    }

    void addCirclingPoint()
    {
        GameObject newGameObject = Instantiate(PointPrefab, default, Quaternion.identity, this.transform);
        newGameObject.GetComponent<PointCicling>().V_angle_degree = 90; // make the ball at the top of the visual sphere by making the angle 90 degrees
        
        circlingPoints.Add(newGameObject);
        

    }
    void layout(int index, int ballCount , int ball_list_count)
    {
        int l = 0;
        for (int k = ball_list_count-ballCount; k < ball_list_count; k++)  // k starts with 0   ,  index starts with 0 ends with 10 so we have 11 rings
        {
            if (index % 2 == 0)
            {
                circlingPoints[k].GetComponent<PointCicling>().Ballcolor = InputData.Instance.second; // when the index is even the color of the ball will be the second color
                circlingPoints[k].GetComponent<PointCicling>().Scale =Vector3.one * InputData.Instance.Scale_second;
            }
            circlingPoints[k].GetComponent<PointCicling>().H_angle_degree = 360/ballCount *l;     // average the angles and assign the <angle variable> of the ball to its specific angle

            //circlingPoints[k].gameObject.transform.localScale = Vector3.one * 3;   // change the scale of this ball by its localScale variable
            circlingPoints[k].GetComponent<PointCicling>().Scale = Vector3.one * 3;  // // INHERITANCE  // change the scale of this ball by its 'Scale' variable of its script
            circlingPoints[k].gameObject.SetActive(true);

            if (circlingPoints[k].GetComponent<PointCicling>().V_angle_degree < 18 * (15 - index)) // in the virtual sphere we'r making equally seperated lines to obtain the rings of balls
                circlingPoints[k].GetComponent<PointCicling>().V_angle_degree += AngleChangeSpeed; // by increasing the value of <V_angle_degree> the ball will move in a circle on the vertical plane
            else circlingPoints[k].GetComponent<PointCicling>().V_angle_degree = 18 * (15 - index);
            
            l++;
        }
        if (index == 10)  // when the last ball in the list is active the 'OkayToPlay' boolen will change to true
            StartCoroutine(oneSec());
    }
    private void Update()
    {
        if(OkayToPlay)
        foreach(GameObject point in circlingPoints)
        {
            point.GetComponent<PointCicling>().H_angle_degree -=  AngleChangeSpeed; //  change the angles  to rotate the ball horizontally
                point.GetComponent<PointCicling>().V_angle_degree -=  AngleChangeSpeed; // change the angles  to rotate the ball vertically
            }
    }

}                                                                              
                                                                               