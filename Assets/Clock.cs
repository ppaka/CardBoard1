using UnityEngine;

public class Clock : MonoBehaviour
{
    public static Clock Instance;

    public float CurrentTime => Time.time - _startTime;
    private float _startTime;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _startTime = Time.time;
    }
}