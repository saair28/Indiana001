using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDeEscenario : MonoBehaviour
{
    public GameObject[] tiles;
    public int length;

    public int[,] map = new int[5, 5] {
        {1, 0, 0, 0, 0},
        {0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0},
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
                clone.transform.position += new Vector3((row * 1), 0, (-col * 1));
            }
        }
    }
}
