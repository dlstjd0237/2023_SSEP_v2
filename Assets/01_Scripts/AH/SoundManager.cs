using System.Collections.Generic;
using UnityEngine;


public enum Sound {
    Bgm,
    Effect,
    MaxCount //�׳� enum�� ������ ���� ���� ����(�ƹ��͵� �ƴ�)
}
public class SoundManager : MonoBehaviour {
    AudioSource[] _audioSources = new AudioSource[(int)Sound.MaxCount];
    Dictionary<string, AudioClip> _audioClip = new Dictionary<string, AudioClip>();

    public void Init() {
        GameObject root = GameObject.Find("SoundManager"); // "SoundManager��� �̸��� ������Ʈ�� ã��
        if (root == null) { // ���ٸ�
            root = new GameObject { name = "SoundManager" }; // SoundManager������Ʈ�� ����� 
            Object.DontDestroyOnLoad(root); // �ı� ��ȣ ����

            string[] soundName = System.Enum.GetNames(typeof(Sound)); // BGM Effect
            for (int i = 0; i < soundName.Length - 1; i++) { // -1 : MaxCount����
                GameObject go = new GameObject { name = soundName[i] }; // �̸� �θ�� ��� Bgm, Effect��� �̸��� ������Ʈ��
                _audioSources[i] = go.GetComponent<AudioSource>(); // AudioSource�� ���δ�
                go.transform.parent = root.transform;
            }

            _audioSources[(int)Sound.Bgm].loop = true; // bgm ���� �ݺ� ���
        }
    }
    /// <summary> Clear �Լ� �����
    /// public void LoadScene(Define.Scene type){
    ///     Managers.Clear();
    ///     SceneManager.LoadScene(GetSceneName(type));
    /// }
    ///
    /// public void Clear() {
    ///     CurrentScene.Clear();
    /// }
    /// </summary> ���� �ٲ� �� ȣ������!
public void Clear() {
        // ����� ���� ��� ����, ���� ����
        foreach (AudioSource audioSource in _audioSources) {
            audioSource.clip = null;
            audioSource.Stop();
        }
        // ȿ���� Dictionary ����
        _audioClip.Clear(); // �׷��Ͼ����� ������ �ʹ� ���� ���� �� _audioClip�� Dictionary�� ��� �߰��Ǿ� �޸𸮰� �������� �� ����
    }

    public void Play(AudioClip audioClip, Sound type = Sound.Effect, float pitch = 1.0f) { // ������ audioClip�� �޾� �����Ŵ
        if (audioClip == null) {
            return;
        }
        if (type == Sound.Bgm) { // bgm���� ���
            AudioSource audioSource = _audioSources[(int)Sound.Bgm]; // _audioSources[(int)Sound.Bgm]�� ���� ���
            if (audioSource.isPlaying) { // ���࿡ ������̶�� ���߰�
                audioSource.Stop();
            }
            audioSource.pitch = pitch;
            audioSource.clip = audioClip;
            audioSource.Play();
        }
        else if (type == Sound.Effect) {
            AudioSource audioSource = _audioSources[(int)(Sound.Effect)];// _audioSources[(int)Sound.Bgm]�� ���� ���
            // ȿ������ ��ø�Ǿ �Ǳ� ������ if���� ����
            audioSource.pitch = pitch;
            audioSource.PlayOneShot(audioClip); // ���ϴ� Ŭ���� ��ø�ؼ� ��� �� �� �ְ� PlayOneShot�Լ� ���
        }
    }
    /// <summary> (path)Play �Լ� �����
    /// Managers.Sound.Play("UnityChan/univ0001", Define.Sound.Effect); 
    /// Managers.Sound.Play("UnityChan/univ0002"); // Effect �� ����Ʈ
    /// </summary>
    /// <param name="path">���</param>
    /// <param name="type">Sound type</param>
    /// <param name="pitch">��� �ӵ�</param>
    public void Play(string path, Sound type = Sound.Effect, float pitch = 1.0f) { // ������ path�� �޾Ƽ� �����Ŵ
        AudioClip audioClip = GetOrAddAudioClip(path, type);
        Play(audioClip, type, pitch);
    }

    private AudioClip GetOrAddAudioClip(string path, Sound type = Sound.Effect) {

    }
}