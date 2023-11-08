using UnityEngine;
using UnityEngine.UI;

public class AH_UIManager : MonoBehaviour {
    [SerializeField] private AudioClip testEffectClip;
    [SerializeField] private AudioClip testBgmClip;
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private GameObject _panelBackground;

    private AudioSource bgm_source;
    private AudioSource effect_source;

    private void Awake() {
        SoundManager.Instance.Init();
        bgm_source = GameObject.Find("Sound").transform.Find("Bgm").GetComponent<AudioSource>();
        effect_source = GameObject.Find("Sound").transform.Find("Effect").GetComponent<AudioSource>();
    }
    private void Start() {
        SoundManager.Instance.Play(testBgmClip, Sound.Bgm, 1); // Play(����� Ŭ��, Ŭ���� Ÿ��, ��ġ(��� �ӵ�))
    }
    ///// <summary>
    ///// �½�Ʈ��
    ///// </summary>
    //public void PlayEffect() {
    //    SoundManager.Instance.Play(testEffectClip, Sound.Effect, 1); // Play(����� Ŭ��, Ŭ���� Ÿ��, ��ġ(��� �ӵ�))
    //}
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
        _panelBackground.SetActive(true);
    }
    public void ClosePanel() {
        settingPanel.SetActive(false);
        _panelBackground.SetActive(false);
    }
}
