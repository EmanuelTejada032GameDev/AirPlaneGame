using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ShipMovementt : MonoBehaviour
{
    public Ease ease;
    private void Start()
    {
        transform.DOMoveX(0,10).SetEase(ease);
    }
}
