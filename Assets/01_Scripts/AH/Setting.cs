using UnityEngine;

public class Setting : MonoBehaviour {
    [SerializeField] private AudioClip testEffectClip;
    [SerializeField] private AudioClip testBgmClip;
    private void Awake() {
        SoundManager.Instance.Init();
    }
    private void Start() {
        // Ŭ���� �޾Ƽ� ����
        //SoundManager.Instance.Play(testEffectClip, Sound.Effect, 1); // Play(����� Ŭ��, Ŭ���� Ÿ��, ��ġ(��� �ӵ�))
        SoundManager.Instance.Play(testBgmClip, Sound.Bgm, 1); // Play(����� Ŭ��, Ŭ���� Ÿ��, ��ġ(��� �ӵ�))

        // ��� �ޱ�
        // SoundManager.Instance.Play("Assets/08_Audios/AH/Sound", Sound.Effect ,1); // ������ ��ġ�� ��θ� �����ؼ� �ٿ��ֱ�

    }
    public void PlayEffect() {
        SoundManager.Instance.Play(testEffectClip, Sound.Effect, 1); // Play(����� Ŭ��, Ŭ���� Ÿ��, ��ġ(��� �ӵ�))
    }
}
