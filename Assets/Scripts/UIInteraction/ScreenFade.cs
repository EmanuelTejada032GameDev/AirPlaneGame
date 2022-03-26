using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ScreenFade : MonoBehaviour
{

    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Awake()
    {
     
    }

    [ContextMenu("FadeIn")]
    private void FadeIn()
    {
        spriteRenderer.DOFade(1,3);
    }

    [ContextMenu("FadeOut")]
    public void FadeOut()
    {
        spriteRenderer.DOFade(0, 3).OnComplete(()=>{ Debug.Log("FadeOut Completed"); });
    }

    public void Start()
    {
        FadeOut();
    }
}
