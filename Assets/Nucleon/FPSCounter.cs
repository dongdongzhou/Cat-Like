using System.Linq;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    private int[] fpsBuffer;
    private int fpsBufferIndex;
    public int frameRange = 60;
    public int AverageFPS { get; private set; }
    public int HighestFPS { get; private set; }
    public int LowestFPS { get; private set; }

    // Update is called once per frame
    private void Update()
    {
        if (fpsBuffer == null || fpsBuffer.Length != frameRange)
            InitializeBuffer();
        UpdateBuffer();
        CalculateFPS();
    }

    private void InitializeBuffer()
    {
        if (frameRange <= 0)
            frameRange = 1;
        fpsBuffer = new int[frameRange];
        fpsBufferIndex = 0;
    }

    private void UpdateBuffer()
    {
        fpsBuffer[fpsBufferIndex++] = (int) (1f / Time.unscaledDeltaTime);
        if (frameRange<=fpsBufferIndex)
        {
            fpsBufferIndex = 0;
        }
    }

    private void CalculateFPS()
    {
        AverageFPS = (int) fpsBuffer.Average();
        HighestFPS = fpsBuffer.Max();
        LowestFPS = fpsBuffer.Min();
    }
}