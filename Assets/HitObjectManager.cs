using UnityEngine;
using OsuParsers;
using System.Collections.Generic;

public class HitObjectManager : MonoBehaviour
{
    private List<OsuParsers.Beatmaps.Objects.HitObject> hits = new List<OsuParsers.Beatmaps.Objects.HitObject>();
    public HitObject prefab;
    private int ptr;

    void Start()
    {
        var beatmap = OsuParsers.Decoders.BeatmapDecoder.Decode(System.IO.Path.Combine(Application.persistentDataPath, "level.osu"));
        hits = beatmap.HitObjects;
    }

    void Update()
    {
        print(Clock.Instance.CurrentTime);
        if (hits.Count > ptr)
        {
            if (Clock.Instance.CurrentTime < hits[ptr].StartTime * 0.001f - HitObject.Duration) return;
            var obj = Instantiate(prefab);
            obj.time = hits[ptr].StartTime * 0.001f;

            obj.transform.position = new Vector3((hits[ptr].Position.X - 512f / 2f) * 0.03f, (hits[ptr].Position.Y - 384f / 2f) * 0.03f + 1.6f, obj.transform.position.z);
            ptr++;
        }
    }
}
