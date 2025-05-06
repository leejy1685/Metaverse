using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField][Range(0f, 1f)] private float soundEffectVolume;// ȿ���� ����
    [SerializeField][Range(0f, 1f)] private float soundEffectPitchVariance;// ȿ���� ��ġ ������
    [SerializeField][Range(0f, 1f)] private float musicVolume;// ��� ���� ����

    private AudioSource musicAudioSource;// ��� ���ǿ� AudioSource
    public AudioClip stdBGMClip;// �⺻ ��� ���� Ŭ��
    public AudioClip gameBGMClip;//���� ��� ���� Ŭ��

    public SoundSource soundSourcePrefab;// ȿ������ ����� ������ (SoundSource ���)

    private void Awake()
    {
        instance = this;

        // ����� ����� AudioSource ����
        musicAudioSource = GetComponent<AudioSource>();
        musicAudioSource.volume = musicVolume;
        musicAudioSource.loop = true;
    }

    private void Start()
    {
        // �⺻ ��� ���� ����
        ChangeBackGroundMusic(stdBGMClip);
    }

    // ��� ������ �ٸ� Ŭ������ ��ü�ϴ� �Լ�
    public void ChangeBackGroundMusic(AudioClip clip)
    {
        musicAudioSource.Stop();
        musicAudioSource.clip = clip;
        musicAudioSource.Play();
    }

    // ȿ������ ����ϴ� ���� �޼��� (�ܺ� ��𼭵� ȣ�� ����)
    public static void PlayClip(AudioClip clip)
    {
        // SoundSource ������ �ν��Ͻ� ���� �� ���
        SoundSource obj = Instantiate(instance.soundSourcePrefab);
        SoundSource soundSource = obj.GetComponent<SoundSource>();
        soundSource.Play(clip, instance.soundEffectVolume, instance.soundEffectPitchVariance);
    }
}
