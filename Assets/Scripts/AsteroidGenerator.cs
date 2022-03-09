using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;
using UnityEditor.Tilemaps;

public class AsteroidGenerator : MonoBehaviour
{
    [SerializeField] Grid _grid;
    [SerializeField] Tilemap asteroidTilemap;
    [SerializeField] PrefabBrush asteroidBrush;
    private GameObject _clone;

    private int asteroidAmount;
    private int mapWidth = 316;
    private int mapHeight = 316;
    private Vector3 tileGap;
    private Vector3 asteroidClone;
    // Start is called before the first frame update
    void Start()
    {
        tileGap = asteroidTilemap.cellGap;
        GenerateScene();
    }

    //private void initPosition()
    //{
    //    mapWidth = asteroidTilemap.x;
    //}

    private void GenerateScene()
    {
        for (int x = 0; x < mapWidth; x += (int)tileGap.x)
        {
            for (int y = 0; y < mapHeight; y += (int)tileGap.y)
            {
                asteroidClone = new Vector3(x ,y, 0);
                
            }
        }
    }
    
}
