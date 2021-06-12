using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int MaxHeight;
    public int MaxWidth;
    public List<Hazard> hazards = new List<Hazard>();
    public float hazardDensity = 70;
    private int _currentHeightIndex;
    private int _currentWidthIndex;
    // Start is called before the first frame update
    void Start()
    {
        GenerateMap();
    }

    public void GenerateMap()
    {
        int y = 0;
        int x = 0;
        for (y = 0; y < MaxHeight; y++)
        {
            for (x = 0; x < MaxHeight; x++)
            {
                CreateElement();
                _currentWidthIndex += 1;
            }
            x = 0;
            _currentWidthIndex = 0;
            _currentHeightIndex += 1;
        }
    }

    public void CreateElement()
    {
        float PositionVariationX = Random.Range(0.0f, 1.0f);
        float PositionVariationY = Random.Range(0.0f, 1.0f);

        int HazardCreation = Random.Range(0, 100);
        if (HazardCreation <= hazardDensity)
        {
            Hazard hazard = Instantiate(hazards[0],
                        new Vector3(transform.position.x + _currentWidthIndex + PositionVariationX, transform.position.y - _currentHeightIndex - PositionVariationY, 1), Quaternion.identity);
        }
    }
}
