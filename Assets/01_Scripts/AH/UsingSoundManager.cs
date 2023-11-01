using UnityEngine;

public class UsingSoundManager : MonoBehaviour {
    [SerializeField] private AudioClip testEffectClip;
    [SerializeField] private AudioClip testBgmClip;
    private void Awake() {
        SoundManager.Instance.Init();
    }
    private void Start() {
        // 클립을 받아서 실행
        //SoundManager.Instance.Play(testEffectClip, Sound.Effect, 1); // Play(사용할 클립, 클립의 타입, 피치(재생 속도))
        //SoundManager.Instance.Play(testBgmClip, Sound.Bgm, 1); // Play(사용할 클립, 클립의 타입, 피치(재생 속도))

        // 경로 받기
        SoundManager.Instance.Play("Assets/08_Audios/AH/Sound", Sound.Effect ,1); // 저장할 위치의 경로를 복사해서 붙여주기

    }
}
