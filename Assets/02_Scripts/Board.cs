using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Board : MonoBehaviour
{
   private Tilemap _tileMap;

   [SerializeField] private int width;
   [SerializeField] private int height;
   [SerializeField] private Tile groundTile;
   [SerializeField] private Tile sideTile;

   private void Awake() => _tileMap = GetComponentInChildren<Tilemap>();
   
   private void Start()
   {
      for (int y = 0; y < height; y++)
      {
         for (int x = 0; x < width; x++)
         {
            _tileMap.SetTile(new Vector3Int(x,y,0), groundTile);
            
            if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
            {
               _tileMap.SetTile(new Vector3Int(x, y, 0), sideTile);
            }
         }
      }
   }
}
