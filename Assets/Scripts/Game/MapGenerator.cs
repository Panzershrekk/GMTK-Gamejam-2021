using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public Transform Player;
    public int MaxHeight;
    public int MaxWidth;
    public List<Hazard> hazards = new List<Hazard>();
    public List<Wave> Waves = new List<Wave>();
    public List<float> WavesWeight = new List<float>();
    public float hazardDensity = 0.01f;
    public float waveDensity = 0.01f;

    public float OffScreenRangeGeneration;
    public float OffScreenLenght;
    public int OffScreenIteration;
    public float GenerationTick = 1;
    public float NextGenerationAllowed;

    private int _currentHeightIndex;
    private int _currentWidthIndex;
    private Dictionary<Wave, float> WeightedWave = new Dictionary<Wave, float>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Waves.Count; i++)
        {
            WeightedWave.Add(Waves[i], WavesWeight[i]);
        }
        NextGenerationAllowed = Time.time + GenerationTick;
        GenerateMap();
    }

    void Update()
    {
        if (Time.time > NextGenerationAllowed)
        {
            NextGenerationAllowed = Time.time + GenerationTick;
            CreateOffScreen();
        }
    }

    public void GenerateMap()
    {
        int y = 0;
        int x = 0;
        for (y = 0; y < MaxHeight; y++)
        {
            for (x = 0; x < MaxHeight; x++)
            {
                CreateElement(_currentWidthIndex, _currentHeightIndex);
                _currentWidthIndex += 1;
            }
            x = 0;
            _currentWidthIndex = 0;
            _currentHeightIndex += 1;
        }
    }

    public void CreateElement(int x, int y)
    {
        float PositionVariationX = Random.Range(0.0f, 1.0f);
        float PositionVariationY = Random.Range(0.0f, 1.0f);

        float HazardCreation = Random.Range(0.00f, 1.00f);
        float WaveCreation = Random.Range(0.00f, 1.00f);

        if (HazardCreation <= hazardDensity)
        {
            Hazard hazard = Instantiate(hazards[0],
                        new Vector3(transform.position.x + x + PositionVariationX, transform.position.y - y - PositionVariationY, 1), Quaternion.identity);
        }

        if (WaveCreation <= waveDensity)
        {
            Wave wave = Instantiate(WeightedWave.RandomElementByWeight(v => v.Value).Key,
                        new Vector3(transform.position.x + x, transform.position.y - y, 1), Quaternion.identity);
        }
    }

    public void CreateOffScreen()
    {
        float minX = Player.position.x - OffScreenRangeGeneration;
        float maxX = Player.position.x + OffScreenRangeGeneration;
        float minY = Player.position.y - OffScreenRangeGeneration;
        float maxY = Player.position.y + OffScreenRangeGeneration;

    }
}
