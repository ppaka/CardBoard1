using UnityEngine;
using DG.Tweening;

public class HitObject : MonoBehaviour
{
    public float time = 10;
    public static float Duration = 3f;
    private Vector3 _defaultScale;
    private bool _enter;
    public MeshRenderer meshRenderer;
    private Material _material;
    private bool _clear;

    private void Start()
    {
        _defaultScale = transform.localScale;
        transform.localScale = Vector3.zero;
        _material = meshRenderer.material = Instantiate(meshRenderer.material);
    }

    private void Update()
    {
        transform.localScale = Mathf.Clamp01((Clock.Instance.CurrentTime - time + Duration) / Duration) * _defaultScale;
        if (Clock.Instance.CurrentTime >= time && !_clear)
        {
            _clear = true;
            gameObject.layer = 0;
            if (_enter)
            {
                _material.DOFade(0, 0.5f).OnComplete(() =>
                {
                    gameObject.SetActive(false);
                    Destroy(gameObject, 1f);
                });
            }
            else
            {
                transform.DOShakePosition(0.5f, 0.3f);
                _material.DOFade(0, 0.5f).OnComplete(() =>
                {
                    gameObject.SetActive(false);
                    Destroy(gameObject, 1f);
                });
            }
        }
    }

    public void OnPointerEnter()
    {
        _enter = true;
    }

    public void OnPointerExit()
    {
        _enter = false;
    }
}
