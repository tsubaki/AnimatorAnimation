using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {

	[SerializeField]
	SingleAnimator[] animators;

	[SerializeField]
	AnimationClip[] animationClips;

	void Reset()
	{
		animators = FindObjectsOfType<SingleAnimator>();
	}

	void OnGUI()
	{
		foreach( var clip in animationClips ){
			if( GUILayout.Button(clip.name)){
				foreach( var animator in animators ){
					animator.Play(clip);
				}
			}
		}
	}
}
