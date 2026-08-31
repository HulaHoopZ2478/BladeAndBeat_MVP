using UnityEngine;

public class EnemyMove : MonoBehaviour
{
	public float speed = 5f; // ปรับตัวเลขเพื่อเปลี่ยนความเร็วของศัตรูได้

	void Update()
	{
		// คำสั่งนี้จะทำให้ตัวศัตรูเลื่อนไปทางซ้ายเรื่อยๆ
		transform.Translate(Vector2.left * speed * Time.deltaTime);
	}
}