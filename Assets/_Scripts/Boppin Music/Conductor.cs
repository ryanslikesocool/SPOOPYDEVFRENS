using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using Chihya.Tempo;

public class Conductor : MonoBehaviour
{
    public static Conductor instance;

    [SerializeField]
    public MusicData music = null;
    private AudioSource musicSource;

    [SerializeField]
    private bool useOffbeat = false;
    private bool offbeatReady = false;

    private float secPerBeat,
                  songPosition,
                  songPositionBeats,
                  dspSongTime;

    [HideInInspector]
    public UnityEvent beatEvent = new UnityEvent(),
                      offbeatEvent = new UnityEvent();

    void Awake()
    {
        instance = this;
        musicSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        musicSource.clip = music.clip;

        CalculateBPM();

        secPerBeat = 60f / music.beatsPerMinute;
        dspSongTime = (float)AudioSettings.dspTime;

        musicSource.Play();
    }

    void Update()
    {
        int previousBeat = (int)songPositionBeats;
        float beatPosition = Mathf.Repeat(songPositionBeats, 1f);
        songPosition = (float)(AudioSettings.dspTime - dspSongTime);
        songPositionBeats = songPosition / secPerBeat;

        if ((int)songPositionBeats > previousBeat)
        {
            beatEvent.Invoke();
            offbeatReady = true;
        }
        if (useOffbeat && offbeatReady && beatPosition > 0.5f)
        {
            offbeatEvent.Invoke();
            offbeatReady = false;
        }
    }

    void CalculateBPM()
    {
        if (music.beatsPerMinute == 0)
        {
            int sampleCount = music.clip.samples;

            float[] audioFloats = new float[sampleCount];
            music.clip.GetData(audioFloats, 0);
            byte[] audioBytes = new byte[sampleCount * 4];
            Buffer.BlockCopy(audioFloats, 0, audioBytes, 0, sampleCount * 4);

            SignalProperties signalProperties = new SignalProperties(music.clip.channels, sampleCount, 44100, SignalSampleFormat.Float32Bit);
            EnergyTempoDetector tempoDetector = new EnergyTempoDetector(audioBytes, signalProperties, EnergyTempoDetectorConfig.For44KHz);
            tempoDetector.Sensivity = 0.2f;
            TempoDetectionResult result = tempoDetector.Detect();
            music.beatsPerMinute = result.BeatsPerMinute;
        }
    }
}