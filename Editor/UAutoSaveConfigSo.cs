using UnityEngine;

namespace UCommon.AutoSave
{
	/// <summary>
	/// Configuration for auto save in Unity.
	/// </summary>
	[CreateAssetMenu(menuName = "UCommon/Save/AutoSaveConfiguration")]
	public class UAutoSaveConfigSo : ScriptableObject
	{
		/// <summary>
        /// Value of wether auto save should be enabled or not.
        /// </summary>
		[Tooltip("Autosave enabled or not.")]
		public bool enabled = false;
		/// <summary>
        /// Auto save frequency, the frequency in minutes when to autosave.
        /// </summary>
		[Tooltip("The frequency specified in minutes when to autosave.")]
		public int saveFrequency = 1;
		/// <summary>
        /// Auto save logging, wether to log when auto save has happend.
        /// </summary>
		[Tooltip("Get notified in logg when auto saved has been triggered.")]
		public bool logOnSave = false;
	}
}
