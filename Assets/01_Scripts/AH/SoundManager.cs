using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SoundManager : MonoBehaviour {
    AudioSource[] _audioSource = new AudioSource[(int)Define.Sound.MaxCount];
    Dictionary<string, AudioClip> _audioClip = new Dictionary<string, AudioClip>();

    public void Init() {
        GameObject root = GameObject.Find("SoundManager"); // "SoundManager라는 이름의 오브젝트를 찾아
        if (root == null) { // 없다면
            root = new GameObject { name = "SoundManager" }; // SoundManager오브젝트를 만들고 
            Object.DontDestroyOnLoad(root); // 파괴 보호 방지

            string[] soundName = System.Enum.GetNames(typeof(Define.Sound)); // BGM Effect
            for(int i= 0; i < soundName.Length - 1; i++) { // -1 : MaxCount빼기
                GameObject go = new GameObject { name = soundName[i] }; // 이를 부모로 삼는 Bgm, Effect라는 이름의 오브젝트에
                _audioSource[i] = go.GetComponent<AudioSource>(); // AudioSource를 붙인다
                go.transform.parent = root.transform;
            }

            _audioSource[(int)Define.Sound.Bgm].loop = true; // bgm 무한 반복 재생
        }
    }
    public void Clear() {
        // 재생기 전부 재생 정지, 음반 빼기
        foreach(AudioSource audioSource in _audioSource) {
            audioSource.clip = null;
            audioSource.Stop();
        }
        // 효과음 Dictionary 비우기
        _audioClip.Clear(); // 그럴일없지만 게임이 너무 오래 진행 시 _audioClip에 Dictionary가 계속 추가되어 메모리가 부족해질 수 있음
    }
    
    public void Play(AudioClip audioClip, Define.Sound type, float pitch = 1.0f) {
        if(audioClip == null) {
            return;

            if(type == Define.Sound.Bgm) { // bgm음악 재생

            }
        }
    }
}
