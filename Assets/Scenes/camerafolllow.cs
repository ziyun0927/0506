using UnityEngine;

public class camerafolllow : MonoBehaviour
{
    public Transform target; // ���a
    public Vector2 centerOffset = new Vector2(2f, 1f); // ���߽d��j�p�]�V�p�V���^
    public Vector3 cameraOffset = new Vector3(0, 0, -10f); // ��v���򪱮aZ����
    public Vector2 minBounds; // �a�ϥ��U�ɭ�
    public Vector2 maxBounds; // �a�ϥk�W�ɭ�

    public float smoothSpeed = 0.125f; // ��v�����ƫ�

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = transform.position;

            // �ˬdX�b�W�X���߰ϰ�
            float xDifference = target.position.x - transform.position.x;
            if (Mathf.Abs(xDifference) > centerOffset.x)
            {
                targetPosition.x = target.position.x - Mathf.Sign(xDifference) * centerOffset.x;
            }

            // �ˬdY�b�W�X���߰ϰ�]�q�`2D���b�u����X�^
            float yDifference = target.position.y - transform.position.y;
            if (Mathf.Abs(yDifference) > centerOffset.y)
            {
                targetPosition.y = target.position.y - Mathf.Sign(yDifference) * centerOffset.y;
            }

            // �M�WOffset (�q�`�O-10��Z�b)
            targetPosition.z = cameraOffset.z;

            // ���Ʋ���
            Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);

            // ������v���b�a����ɤ�
            smoothPosition.x = Mathf.Clamp(smoothPosition.x, minBounds.x, maxBounds.x);
            smoothPosition.y = Mathf.Clamp(smoothPosition.y, minBounds.y, maxBounds.y);

            transform.position = smoothPosition;
        }
    }
}

