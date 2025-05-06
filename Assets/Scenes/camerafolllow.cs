using UnityEngine;

public class camerafolllow : MonoBehaviour
{
    public Transform target; // 玩家
    public Vector2 centerOffset = new Vector2(2f, 1f); // 中心範圍大小（越小越緊跟）
    public Vector3 cameraOffset = new Vector3(0, 0, -10f); // 攝影機跟玩家Z偏移
    public Vector2 minBounds; // 地圖左下界限
    public Vector2 maxBounds; // 地圖右上界限

    public float smoothSpeed = 0.125f; // 攝影機平滑度

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = transform.position;

            // 檢查X軸超出中心區域
            float xDifference = target.position.x - transform.position.x;
            if (Mathf.Abs(xDifference) > centerOffset.x)
            {
                targetPosition.x = target.position.x - Mathf.Sign(xDifference) * centerOffset.x;
            }

            // 檢查Y軸超出中心區域（通常2D卷軸只限制X）
            float yDifference = target.position.y - transform.position.y;
            if (Mathf.Abs(yDifference) > centerOffset.y)
            {
                targetPosition.y = target.position.y - Mathf.Sign(yDifference) * centerOffset.y;
            }

            // 套上Offset (通常是-10的Z軸)
            targetPosition.z = cameraOffset.z;

            // 平滑移動
            Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);

            // 限制攝影機在地圖邊界內
            smoothPosition.x = Mathf.Clamp(smoothPosition.x, minBounds.x, maxBounds.x);
            smoothPosition.y = Mathf.Clamp(smoothPosition.y, minBounds.y, maxBounds.y);

            transform.position = smoothPosition;
        }
    }
}

