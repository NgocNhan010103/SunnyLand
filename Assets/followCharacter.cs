using UnityEngine;

public class followCharacter : MonoBehaviour
{
        public Transform target; // Tham chiếu đến đối tượng nhân vật

        private void Update()
        {
            transform.position = target.position; // Cập nhật vị trí của đối tượng theo vị trí của nhân vật
        }
    
}
