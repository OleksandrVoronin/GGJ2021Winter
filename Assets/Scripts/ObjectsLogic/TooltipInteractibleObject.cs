using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TooltipInteractibleObject : MonoBehaviour {
    private CanvasGroup HintCanvas {
        get { return m_HintCanvas ??= GetComponentInChildren<CanvasGroup>(); }
    }

    private CanvasGroup m_HintCanvas;

    protected bool m_TooltipActive = false;

    private void Awake() {
        this.HintCanvas.transform.localScale = Vector3.zero;
        this.HintCanvas.alpha = 0;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        PlayerController playerController = other.gameObject.GetComponentInChildren<PlayerController>();
        if (playerController != null) {
            m_TooltipActive = true;
            this.HintCanvas.DOKill();
            this.HintCanvas.transform.DOScale(1, 0.3f);
            this.HintCanvas.DOFade(1, 0.1f);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        PlayerController playerController = other.gameObject.GetComponentInChildren<PlayerController>();
        if (
            playerController != null) {
            m_TooltipActive = false;
            this.HintCanvas.DOKill();
            this.HintCanvas.transform.DOScale(0, 0.3f);
            this.HintCanvas.DOFade(0, 0.1f);
        }
    }
}