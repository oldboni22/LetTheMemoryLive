using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public interface IAnimationManager
{
    public bool BlinkEnded { get; }
    public bool FlashEnded { get; }
    public void StartAnimation(bool correct, bool finalize);
}
public class AnimationManager : MonoBehaviour, IAnimationManager
{
    [SerializeField] private Image _transitionImage;
    [SerializeField] private Image _panelImage;
    [SerializeField] private GameObject _transitionCanvas;


    private bool _infoWindowClosed;
    [SerializeField] private float _fadeDuration;

    private bool _blinkEnded;
    private bool _flashEnded;

    public bool BlinkEnded => _blinkEnded;

    public bool FlashEnded => _flashEnded;

    public void OnInfoWindowClosed() => _infoWindowClosed = true;

    public void StartAnimation(bool correct, bool finalize)
    {
        _blinkEnded = false;


        Color frameColor = correct ? Color.green : Color.red;
        frameColor.a = .1f;
        _panelImage.DOColor(frameColor, .35f).SetLoops(3, LoopType.Yoyo).OnComplete(() =>
        {
            _panelImage.DORewind();
            _blinkEnded = true;

            StartCoroutine(Animation(_fadeDuration, finalize, correct));
        }
        );
    }

    IEnumerator Animation(float duration, bool finalize, bool correct)
    {

        _flashEnded = false;

        if (correct is false)
        {
            _infoWindowClosed = false;
            yield return new WaitWhile(() => _infoWindowClosed is false);

            yield return new WaitForSeconds(.45f);
        }
        

        if (finalize is true)
        {
            _flashEnded = true;
        }
        else
        {
            Color color = _transitionImage.color;
            _transitionCanvas.SetActive(true);
            _transitionImage.DOColor(Color.white, duration).SetAutoKill(false);

            yield return new WaitForSeconds(duration);

            _transitionImage.DOColor(color, duration).SetAutoKill(false);
            _flashEnded = true;

            yield return new WaitForSeconds(duration);

            _transitionImage.DOKill();
            _transitionCanvas.SetActive(false);

        }
    }
}
