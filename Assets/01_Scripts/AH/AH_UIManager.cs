using UnityEngine;
using UnityEngine.UI;

public class AH_UIManager : MonoBehaviour {
    [SerializeField] private AudioClip testEffectClip;
    [SerializeField] private AudioClip testBgmClip;
    [SerializeField] private GameObject settingPanel;

    private AudioSource bgm_source;
    private AudioSource effect_source;

    private void Awake() {
        SoundManager.Instance.Init();
        bgm_source = GameObject.Find("Sound").transform.Find("Bgm").GetComponent<AudioSource>();
        effect_source = GameObject.Find("Sound").transform.Find("Effect").GetComponent<AudioSource>();
    }
    private void Start() {
        SoundManager.Instance.Play(testBgmClip, Sound.Bgm, 1); // Play(사용할 클립, 클립의 타입, 피치(재생 속도))
    }
    /// <summary>
    /// 태스트용
    /// </summary>
    public void PlayEffect() {
        SoundManager.Instance.Play(testEffectClip, Sound.Effect, 1); // Play(사용할 클립, 클립의 타입, 피치(재생 속도))
    }
    public void BgmAudioControl(Scrollbar slider) {
        float sound = slider.value;

        bgm_source.volume = sound;
    }
    public void EffectAudioControl(Scrollbar slider) {
        float sound = slider.value;

        effect_source.volume = sound;
    }




    public void OpenPanel() {
        settingPanel.SetActive(true);
    }
    public void ClosePanel() {
        settingPanel.SetActive(false);
    }
}
