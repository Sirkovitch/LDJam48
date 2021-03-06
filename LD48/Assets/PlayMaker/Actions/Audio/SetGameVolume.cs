// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.Audio)]
	[Tooltip("Sets the global sound volume.")]
	public class SetGameVolume : FsmStateAction
	{
		[RequiredField]
		[HasFloatSlider(0,1)]
        [Tooltip("Volume level (0-1).")]
		public FsmFloat volume;

        [Tooltip("Perform this action every frame. Useful if Volume is changing e.g., to fade up/down.")]
        public bool everyFrame;
		
		public override void Reset()
		{
			volume = 1.0f;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			AudioListener.volume = volume.Value;
			
			if (!everyFrame)
				Finish();		
		}
		
		public override void OnUpdate()
		{
			AudioListener.volume = volume.Value;
		}

#if UNITY_EDITOR
	    public override string AutoName()
	    {
	        return ActionHelpers.AutoName(this, volume);
	    }
#endif

	}
}