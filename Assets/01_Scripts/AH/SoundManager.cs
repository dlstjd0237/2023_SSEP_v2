using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SoundManager : MonoBehaviour {
    AudioSource[] _audioSource = new AudioSource[(int)Define.Sound.MaxCount];
    Dictionary<string, AudioClip> _audioClip = new Dictionary<string, AudioClip>();

    public void Init() {
        GameObject root = GameObject.Find("SoundManager"); // "SoundManager��� �̸��� ������Ʈ�� ã��
        if (root == null) { // ���ٸ�
            root = new GameObject { name = "SoundManager" }; // SoundManager������Ʈ�� ����� 
            Object.DontDestroyOnLoad(root); // �ı� ��ȣ ����

            string[] soundName = System.Enum.GetNames(typeof(Define.Sound)); // BGM Effect
            for(int i= 0; i < soundName.Length - 1; i++) { // -1 : MaxCount����
                GameObject go = new GameObject { name = soundName[i] }; // �̸� �θ�� ��� Bgm, Effect��� �̸��� ������Ʈ��
                _audioSource[i] = go.GetComponent<AudioSource>(); // AudioSource�� ���δ�
                go.transform.parent = root.transform;
            }

            _audioSource[(int)Define.Sound.Bgm].loop = true; // bgm ���� �ݺ� ���
        }
    }
    public void Clear() {
        // ����� ���� ��� ����, ���� ����
        foreach(AudioSource audioSource in _audioSource) {
            audioSource.clip = null;
            audioSource.Stop();
        }
        // ȿ���� Dictionary ����
        _audioClip.Clear(); // �׷��Ͼ����� ������ �ʹ� ���� ���� �� _audioClip�� Dictionary�� ��� �߰��Ǿ� �޸𸮰� �������� �� ����
    }
    
    public void Play(AudioClip audioClip, Define.Sound type, float pitch = 1.0f) {
        if(audioClip == null) {
            return;

            if(type == Define.Sound.Bgm) { // bgm���� ���

            }
        }
    }
}
