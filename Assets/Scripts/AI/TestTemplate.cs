using UnityEngine;

public class TestTemplate : MonoBehaviour
 {	
 public bool IsScale;
 
	private void OnDrawGizmos() 
	{
		Gizmos.DrawIcon(transform.position, "bot.jpg", IsScale);
	}
}
