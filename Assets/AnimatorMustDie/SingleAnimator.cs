using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]
public class SingleAnimator : MonoBehaviour {

	[SerializeField]
	AnimationClip clip;

	[SerializeField, DisappearAttachedFieldAttribute]
	AnimatorOverrideController overrideController;

	[SerializeField, DisappearAttachedFieldAttribute]
	AnimationClip originalClip;

	[SerializeField, DisappearAttachedFieldAttribute]
	RuntimeAnimatorController originalAnimationController;

#if UNITY_EDITOR
	void Reset()
	{
		Setup();
	}
#endif

	void OnValidate()
	{
		overrideController[originalClip] = clip;
	}

	public void Play(AnimationClip overrideClip)
	{
		if( overrideClip == overrideController[originalClip] ){
			return;
		}
		clip = overrideClip;
		overrideController[originalClip] = clip;
	}

#if UNITY_EDITOR
	[ContextMenu("HideAnimator")]
	void HideAnimator()
	{
		GetComponent<Animator>().hideFlags = HideFlags.HideInInspector;
	}

	[ContextMenu("ShowAnimator")]
	void ShowAnimator()
	{
		GetComponent<Animator>().hideFlags = HideFlags.None;
	}

	[ContextMenu("Resetup")]
	void Setup()
	{
		var animator = GetComponent<Animator>();
		HideAnimator();
		overrideController = new AnimatorOverrideController();
		overrideController.runtimeAnimatorController = originalAnimationController;
		animator.runtimeAnimatorController = overrideController;
	}
#endif
}
