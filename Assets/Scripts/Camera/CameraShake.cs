using UnityEngine;
using System.Collections;
using Zenject;
using System;
using UniRx;
using Assets.Scripts.Events;

public class CameraShake : MonoBehaviour
{
	[Inject]
	private IObservable<ShakeCamera> _cameraShake;

	[Inject]
	public void Initialized()
	{
		_cameraShake.Subscribe(e => { shakeDuration = 3f; Debug.Log("shake"); });
	}

	// Transform of the camera to shake. Grabs the gameObject's transform
	// if null.
	public Transform camTransform;

	// How long the object should shake for.
	public float shakeDuration = 0f;

	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.7f;
	public float decreaseFactor = 1.0f;

	Vector3 originalPos;

	void Awake()
	{
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}

	void OnEnable()
	{
		originalPos = camTransform.localPosition;
	}

	void Update()
	{
		if (shakeDuration > 0)
		{
			camTransform.localPosition = originalPos + UnityEngine.Random.insideUnitSphere * shakeAmount;

			shakeDuration -= Time.deltaTime * decreaseFactor;
		}
		else
		{
			shakeDuration = 0f;
			camTransform.localPosition = originalPos;
		}
	}
}