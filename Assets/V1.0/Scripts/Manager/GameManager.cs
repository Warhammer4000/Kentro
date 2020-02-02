using System.Collections.Generic;
using Kentro;
using UnityEngine;
using Grid = Kentro.Grid;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    [SerializeField] private FloorGenerator FloorGenerator;



    [SerializeField]private Grid _gameGrid;

   


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        CreateGrid();
    }

    public void CreateGrid()
    {
        _gameGrid=new Grid(9);
        FloorGenerator.GenerateMap(_gameGrid);
       
    }

    public Card GetCard(Position position)
    {
        return _gameGrid.GetCard(position);
    }

    //todo Refactor
    public List<Position> GetPlayer1PawnPositions()
    {
        return new List<Position>()
        {
            new Position(0,0),
            new Position(0,GameManager.Instance._gameGrid.Goal.Y),
            new Position(0,_gameGrid.GridSize-1)
        };
    }

    public List<Position> GetPlayer2PawnPositions()
    {
        return new List<Position>()
        {
            new Position(_gameGrid.GridSize-1,_gameGrid.GridSize-1),
            new Position(_gameGrid.GridSize-1,_gameGrid.Goal.Y),
            new Position(_gameGrid.GridSize-1,0)
        };
    }


}
