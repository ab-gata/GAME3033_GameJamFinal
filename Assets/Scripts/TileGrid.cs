using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileGrid : MonoBehaviour
{
    [SerializeField, Header("Tile Set Up")]
    private GameObject cubePrefab;
    [SerializeField]
    private int dimentions = 10;
    [SerializeField]
    private float distanceBetween = 3;


    private int[,] gridArray;
    List<CubeBehaviour> allCubes = new List<CubeBehaviour>();
    List<CubeBehaviour> emptyCubes = new List<CubeBehaviour>();

    void Start()
    {
        gridArray = new int[dimentions, dimentions];
        int n = 0;

        // Create the squares and set their value by chance
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int z = 0; z < gridArray.GetLength(1); z++)
            {
                // Instantiate square
                GameObject temp = Instantiate(cubePrefab);
                temp.transform.SetParent(gameObject.transform);
                temp.transform.position = new Vector3(x * distanceBetween + (distanceBetween * dimentions / 8), 0, z * distanceBetween + (distanceBetween * dimentions / 8));
                temp.GetComponent<CubeBehaviour>().Number = n;
                n++;
                allCubes.Add(temp.GetComponent<CubeBehaviour>());
            }
        }
        emptyCubes = allCubes;
    }

    public Transform GetPickUpSpawnPos()
    {
        int rand = (int)Random.Range(0.0f, emptyCubes.Count);

        return emptyCubes[rand].PickUpTransform;
    }
}
