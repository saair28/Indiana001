using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDeParedesHorizontales : MonoBehaviour
{
    public GameObject[] tiles;
    //public int length;

    public int[,] map = new int[22, 21]
    {
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 4, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 4, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 4, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 4, 0, 2, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 4, 3, 2, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 4, 0, 0, 0, 4, 2, 0, 4, 1, 3, 1, 1, 1, 1, 2, 0},
        {0, 0, 0, 4, 3, 2, 0, 0, 0, 4, 2, 0, 4, 0, 0, 0, 2, 0, 0, 2, 0},
        {0, 4, 3, 2, 0, 0, 0, 0, 4, 3, 3, 0, 4, 0, 4, 0, 2, 0, 3, 2, 0},
        {0, 0, 0, 4, 1, 0, 1, 1, 2, 0, 0, 0, 4, 0, 0, 0, 2, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 4, 0, 0, 2, 0, 0, 0, 4, 4, 0, 2, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 4, 0, 3, 3, 0, 0, 0, 3, 3, 0, 2, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 4, 0, 0, 4, 1, 1, 2, 0, 2, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 4, 1, 0, 2, 0, 4, 0, 0, 2, 0, 2, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 4, 0, 0, 2, 0, 4, 3, 3, 3, 3, 2, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 4, 3, 3, 2, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 2, 0, 0, 0, 4, 3, 2, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 4, 1, 1, 2, 0, 0, 0, 2, 0, 2, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 2, 0, 2, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 4, 3, 3, 3, 3, 3, 2, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
    };
    

    // Start is called before the first frame update
    void Start()
    {
        GenerateMap();

        
    }

    // Update is called once per frame
    void Update()
    {
        //map.GetLength
    }

    private void GenerateMap()
    {
        for (int col = 0; col < map.GetLength(1); col++)
        {
            for (int row = 0; row < map.GetLength(0); row++)
            {
                GameObject clone = Instantiate(tiles[map[row,col]], transform.position, transform.rotation);
                clone.transform.position += new Vector3((row * 3), 0, (-col * 3));
            }
        }
    }
}
