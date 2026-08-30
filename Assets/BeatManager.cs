using UnityEngine;

public class BeatManager : MonoBehaviour
{
    [Header("Settings")]
    public float bpm = 120f;
    public float timingWindow = 0.15f; // ช่วงเวลากดติด (วินาที)

    private float beatInterval;
    private float nextBeatTime;
    private bool hasInputThisBeat = false;

    void Start()
    {
        beatInterval = 60f / bpm;
        nextBeatTime = (float)AudioSettings.dspTime + beatInterval;
    }

    void Update()
    {
        // เมื่อข้ามเข้าสู่บีทถัดไป
        if (AudioSettings.dspTime >= nextBeatTime)
        {
            if (!hasInputThisBeat)
            {
                Debug.Log("<color=red>[MISS] </color>");
            }

            nextBeatTime += beatInterval;
            hasInputThisBeat = false;
        }

        // เช็กการกดปุ่ม Spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (hasInputThisBeat) return;

            hasInputThisBeat = true;
            float currentDsp = (float)AudioSettings.dspTime;

            float diffPrevious = Mathf.Abs(currentDsp - (nextBeatTime - beatInterval));
            float diffNext = Mathf.Abs(currentDsp - nextBeatTime);
            float minDiff = Mathf.Min(diffPrevious, diffNext);

            if (minDiff <= timingWindow)
            {
                Debug.Log("<color=green>[PERFECT PARRY] </color>");
            }
            else
            {
                Debug.Log("<color=red>[MISS] </color>");
            }
        }
    }
}