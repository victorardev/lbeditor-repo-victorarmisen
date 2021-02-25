using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PathCreate : MonoBehaviour
{
    public GameObject pointPrefab, towerPrefab;
    public GameManager manager;
    private LineRenderer lines;
    public static bool play = false, pathReady = false, tower = false;
    public GameObject enemySpawn, basePlayer;
    public Transform posSpawn;
    public GameObject insertParticle;

    public GameObject hordeObject;
    bool enemyReady = false;
    int stateTower = 0;

    public Camera maincamera;

    GameObject towerCopy = null;
    void Start()
    {
        lines = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if(!play)
        {
            if (!pathReady)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    //if (EventSystem.current.IsPointerOverGameObject())
                    //    return;
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out hit))
                    {
                        Instantiate(pointPrefab, hit.point, pointPrefab.transform.rotation);
                        GameObject par = Instantiate(insertParticle, hit.point, insertParticle.transform.rotation);
                        Destroy(par, 3.0f);
                        manager.pointList.Add(hit.point);
                    }
                    lines.positionCount = manager.pointList.ToArray().Length;
                    lines.SetPositions(manager.pointList.ToArray());
                }
            } 

            if (!tower)
            {
                switch(stateTower) {
                    case -1:
                        //Do nothing. 
                        break;
                    case 0: 
                        if(Input.GetKeyDown(KeyCode.F))
                        {
                            towerCopy = Instantiate(towerPrefab, Vector3.zero, towerPrefab.transform.rotation);
                            stateTower = 1;
                        }
                        break;
                    case 1:
                        //Vector3 mousePos = new Vector3();
                        //mousePos = Input.mousePosition;
                        //Vector3 point = maincamera.ScreenToWorldPoint(new Vector3(mousePos.x, 0.2f, mousePos.y));
                        RaycastHit hit;
                        Ray ray = maincamera.ScreenPointToRay(Input.mousePosition);
                        if (Physics.Raycast(ray, out hit) && Input.GetKeyDown(KeyCode.F))
                        {
                            Debug.DrawRay(transform.position, transform.TransformDirection(Input.mousePosition) * hit.distance, Color.yellow);
                            towerCopy.transform.position = hit.point;
                            Debug.Log("Did Hit");
                        }

                        //if (Input.GetMouseButtonDown(0))
                        //{
                        //    stateTower = -1;
                        //    //towerCopy.transform.position = Vector3.Lerp(towerCopy.transform.position, hit.point, Time.deltaTime);
                        //    tower = true;
                        //}
                        break;
                }
            }
            
        }
        else
        {
            int index = manager.pointList.Count - 1;
            Instantiate(basePlayer, manager.pointList[index], basePlayer.transform.rotation);
            play = false;
            tower = true;
            Instantiate(hordeObject, Vector3.zero, hordeObject.transform.rotation);
        }
    }
}
