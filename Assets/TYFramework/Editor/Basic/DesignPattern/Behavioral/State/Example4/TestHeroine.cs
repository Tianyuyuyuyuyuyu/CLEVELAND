using UnityEngine;

namespace TYFramework.Editor.Basic.DesignPattern.Behavioral.State.Example4
{
	public class TestHeroine : MonoBehaviour
	{
		private Heroine _heroine;

		void Start ( )
		{
			_heroine = new Heroine();
		}

		void Update ( )
		{
			_heroine.Update();
		}
	}
}
