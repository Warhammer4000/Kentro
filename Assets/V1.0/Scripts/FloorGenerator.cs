using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
    private int Row { get; set; }
    private int Column { get; set; }

    //todo Refactor this
    private int CenterX;
    private int CenterY;


    [SerializeField] private float waitTime=0.5f;

    [SerializeField] private GameObject _floorUnitPrefab;


    public Vector3 InitialPosition;

    public Vector3 CurrentPosition;


    public void Start()
    {
        CenterX = 4;
        CenterY = 4;
        GenerateMap(9,9);
    }

    public void GenerateMap(int row,int column)
    {
        Row = row;
        Column = column;
        CurrentPosition = InitialPosition;
        StartCoroutine(GenerateRoutin());
    }


    IEnumerator GenerateRoutin()
    {
        yield return null;
        GameObject floorRoot=new GameObject("FloorRoot");
        for (int i = 0; i < Row; i++)
        {
            for (int j = 0; j < Column; j++)
            {
                yield return new WaitForSeconds(waitTime);
                CurrentPosition = new Vector3(j, 0, i);
                var floor=Instantiate(_floorUnitPrefab, CurrentPosition, Quaternion.identity);
                if (i==CenterX && j==CenterY)
                {
                    CardBehaviour cardBehaviour = floor.GetComponentInChildren<CardBehaviour>();
                    cardBehaviour.MakeCenter();
                }
                floor.transform.parent = floorRoot.transform;
            }
            
        }

    }

}
