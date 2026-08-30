using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager Instance;

    [Header("Audio Source")]
    [SerializeField] private AudioSource BGMAudioSource;
    [SerializeField] private AudioSource[] SEAudioSources;

    [Header("BGM")]

    [SerializeField] private BGMData[] BGMSounds;

    [Header("SE")]

    [SerializeField] private SEData[] SESounds;

    [System.Serializable]

    public class BGMData

    {

        public BGM_Sound sound;
        public AudioClip clip;
    }

    [System.Serializable]
    public class SEData
    {
        public SE_Sound sound;
        public AudioClip clip;
    }


    private float baseBGMVolume = 1.0f;
    private float baseSEVolume = 1.0f;
    private float masterVolume = 1.0f;


    private int currentSEIndex = 0;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public static float BGMVolume
    {
        get => Instance.baseBGMVolume;

        set
        {
            Instance.baseBGMVolume = value;
            Instance.UpdateBGMVolume();
        }
    }

    public static float SEVolume
    {
        get => Instance.baseSEVolume;

        set
        {
            Instance.baseSEVolume = value;
            Instance.UpdateSEVolume();
        }
    }

    public static float MasterVolume
    {
        get => Instance.masterVolume;

        set
        {
            Instance.masterVolume = value;

            Instance.UpdateBGMVolume();
            Instance.UpdateSEVolume();
        }
    }

    private void UpdateBGMVolume()
    {
        BGMAudioSource.volume =
            baseBGMVolume * masterVolume;
    }

    private void UpdateSEVolume()
    {
        foreach (AudioSource source in SEAudioSources)
        {
            source.volume =
                baseSEVolume * masterVolume;
        }
    }
    public static void PlayBGM(BGM_Sound sound)
    {
        int index = (int)sound;

        Instance.BGMAudioSource.clip = Instance.BGMSounds[index].clip;

        Instance.BGMAudioSource.Play();
    }
    public static void PlaySE(SE_Sound sound)
    {
        int soundIndex = (int)sound;

        Instance.SEAudioSources[Instance.currentSEIndex].PlayOneShot(Instance.SESounds[soundIndex].clip);
        Instance.currentSEIndex = (Instance.currentSEIndex + 1) % Instance.SEAudioSources.Length;
    }
}