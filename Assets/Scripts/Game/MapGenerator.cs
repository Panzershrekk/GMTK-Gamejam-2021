using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int MaxHeight;
    public int MaxWidth;
    public List<Hazard> hazards = new List<Hazard>();
    public List<Wave> Waves = new List<Wave>();

    public Dictionary<Wave, float> test = new Dictionary<Wave, float>();
    public float hazardDensity = 0.50f;
    private int _currentHeightIndex;
    private int _currentWidthIndex;
    // Start is called before the first frame update
    void Start()
    {
        GenerateMap();
    }

    void Update()
    {

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

        float HazardCreation = Random.Range(0.00f, 1.00f);
        if (HazardCreation <= hazardDensity)
        {
            Hazard hazard = Instantiate(hazards[0],
                        new Vector3(transform.position.x + _currentWidthIndex + PositionVariationX, transform.position.y - _currentHeightIndex - PositionVariationY, 1), Quaternion.identity);
        }
    }

    public void ChooseByWeight()
    {
        Dictionary<Wave, float> WeightedWave = new Dictionary<Wave, float>();

        for (int i = 0; i < Waves.Count; i++)
        {
            WeightedWave.Add(Waves[i], 1);
        }

        Wave wave = WeightedWave.RandomElementByWeight(v => v.Value).Key;
    }
}
