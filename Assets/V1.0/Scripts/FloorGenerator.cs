using System.Collections;
using Kentro;
using UnityEngine;
using Grid = Kentro.Grid;

public class FloorGenerator : MonoBehaviour
{
    private int Row { get; set; }
    private int Column { get; set; }

 
    private Position Center;

    [SerializeField] private float waitTime=0.5f;

    [SerializeField] private GameObject _floorUnitPrefab;


    public Vector3 InitialPosition;

    public Vector3 CurrentPosition;


    private Grid _gameGrid;

    public void GenerateMap(Grid gameGrid)
    {
        _gameGrid = gameGrid;
        Row = _gameGrid.GridSize;
        Column = _gameGrid.GridSize;
        Center = _gameGrid.Goal;
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
                CardBehaviour cardBehaviour = floor.GetComponentInChildren<CardBehaviour>();
                cardBehaviour.RegisterCard(new Card(new Position(i, j)));


                _gameGrid.SetCard(cardBehaviour.Card);
                if (i==Center.X && j==Center.Y)
                {
                    cardBehaviour.MakeCenter();
                }
                floor.transform.parent = floorRoot.transform;
            }
            
        }
        PlayerManager.Instance.CreatePawns();

    }

}
