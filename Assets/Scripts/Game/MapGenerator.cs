using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameManager GameManager;
    public int MaxHeight;
    public int MaxWidth;
    public List<Hazard> hazards = new List<Hazard>();
    public List<float> hazardsWeight = new List<float>();

    public List<Wave> Waves = new List<Wave>();
    public List<float> WavesWeight = new List<float>();

    public GameObject fish;

    public float hazardDensity = 0.01f;
    public float waveDensity = 0.01f;
    public float fishDensity = 0.01f;

    public float OffScreenRangeGeneration;
    public int OffScreenLenght;
    public float GenerationTick = 1;
    public float NextGenerationAllowed;

    private int _currentHeightIndex;
    private int _currentWidthIndex;
    private Dictionary<Wave, float> WeightedWave = new Dictionary<Wave, float>();
    private Dictionary<Hazard, float> WeightedHazard = new Dictionary<Hazard, float>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Waves.Count; i++)
        {
            WeightedWave.Add(Waves[i], WavesWeight[i]);
        }
        for (int j = 0; j < hazards.Count; j++)
        {
            WeightedHazard.Add(hazards[j], hazardsWeight[j]);
        }
        NextGenerationAllowed = 0;
        //GenerateMap();
        CreateOffScreen();
    }

    void Update()
    {
        if (GameManager.GameStarted == true)
        {
            OverlapCheck();
            /*if (Time.time > NextGenerationAllowed)
            {
                NextGenerationAllowed = Time.time + GenerationTick;
                CreateOffScreen();
            }*/
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

    public void CreateElement(float x, float y)
    {
        float PositionVariationX = Random.Range(0.0f, 1.0f);
        float PositionVariationY = Random.Range(0.0f, 1.0f);

        float HazardCreation = Random.Range(0.0000f, 1.0000f);
        float WaveCreation = Random.Range(0.0000f, 1.0000f);
        float FishCreation = Random.Range(0.0000f, 1.0000f);

        if (HazardCreation <= hazardDensity)
        {
            Hazard hazard = Instantiate(WeightedHazard.RandomElementByWeight(v => v.Value).Key,
                        new Vector3(transform.position.x + x + PositionVariationX, transform.position.y - y - PositionVariationY, 1), Quaternion.identity);
        }

        if (WaveCreation <= waveDensity)
        {
            Wave wave = Instantiate(WeightedWave.RandomElementByWeight(v => v.Value).Key,
                        new Vector3(transform.position.x + x, transform.position.y - y, 1), Quaternion.identity);
        }
        if (FishCreation <= fishDensity)
        {
            GameObject instFish = Instantiate(fish, new Vector3(transform.position.x + x, transform.position.y - y, 1), Quaternion.identity);
        }
    }

    public void CreateOffScreen()
    {
        float minX = transform.localPosition.x - OffScreenRangeGeneration;
        float maxX = transform.localPosition.x + OffScreenRangeGeneration;
        float minY = transform.localPosition.y - OffScreenRangeGeneration;
        float maxY = transform.localPosition.y + OffScreenRangeGeneration;

        float minRangeX = minX - OffScreenLenght;
        float maxRangeX = maxX + OffScreenLenght;
        float minRangeY = minY - OffScreenLenght;
        float maxRangeY = maxY + OffScreenLenght;

        for (float i = minRangeY; i < maxRangeY; i++)
        {
            for (float j = minRangeX; j < maxRangeX; j++)
            {
                if ((j <= minX || j >= maxX) && (i <= minY || i >= maxY))
                {
                    CreateElement(j, i);
                }
            }
        }
    }

    public void OverlapCheck()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 35, 1 << 0);
        if (hitColliders.Length < 5)
        {
            CreateOffScreen();
        }
    }
}
