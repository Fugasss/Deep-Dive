﻿using System;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ButtonDoorOpener : DoorOpener
{
    [SerializeField] private Transform _buttonVfx;
    [SerializeField] private AudioClip _pushSound;
    [SerializeField] private Vector3 _pressedPosition;

    private AudioSource _source;
    private Vector3 _startVfxPosition;

    private void Awake()
    {
        _source = FindObjectOfType<AudioSource>();

        var starter = FindObjectOfType<GameStarterWindow>();
        starter.GameStarted += () => { _buttonVfx.DOLocalMove(_startVfxPosition, 0.5f); };
    }

    private void Start()
    {
        _startVfxPosition = _buttonVfx.localPosition;
    }

    protected override bool MatchRule(Collider2D col)
    {
        return col.TryGetComponent<Player>(out _);
    }

    protected override void OnTriggerEnter2D(Collider2D col)
    {
        base.OnTriggerEnter2D(col);

        _buttonVfx.DOLocalMove(_pressedPosition, 0.5f);
        _source.PlayOneShot(_pushSound);
    }
#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_buttonVfx.position + _buttonVfx.rotation * _pressedPosition, 0.15f);
    }
#endif
}