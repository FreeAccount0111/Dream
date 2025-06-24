using System.Collections;
using UnityEngine;

namespace Gameplay.Controllers.Sheep
{
    public class SheepMovement : MonoBehaviour
    {
        [SerializeField] private float speedJump;
        [SerializeField] private float speedRun;
        [SerializeField] private GameObject shadow;
        
        private float _x1, _y1, _x2, _y2, _x3, _y3;
        private Vector3 _vectorA;
        private Vector3 _vectorB;
        private Vector3 _vectorC;
        
        private RaycastHit _hit;
        [SerializeField] private LayerMask fenceLayer;
        private bool _isJumping;

        private Coroutine _coroutine;

        private void Update()
        {
            if(_isJumping)
                return;
            else
            {
                transform.Translate(Vector3.right*2*Time.deltaTime);
            }
            
            if (CheckFence())
            {
                SetupMovingJump();
                _coroutine = StartCoroutine(JumpingCoroutine());
            }
        }

        private bool CheckFence()
        {
            if (Physics2D.Raycast(transform.position, Vector2.right, 0.75f, fenceLayer))
            {
                return true;
            }

            return false;
        }
        
        private void SetupMovingJump()
        {
            _vectorA = transform.position;
            _vectorB = new Vector3(0, _vectorA.y + 0.5f, _vectorA.z);
            _vectorC = new Vector3(-_vectorA.x, _vectorA.y, _vectorA.z);
        }

        IEnumerator JumpingCoroutine()
        {
            _x1 = Mathf.Abs(_vectorA.x - _vectorC.x) > 0.01f ? _vectorA.x : _vectorA.z; _y1 = _vectorA.y;
            _x2 = Mathf.Abs(_vectorA.x - _vectorC.x) > 0.01f ? _vectorB.x : _vectorB.z; _y2 = _vectorB.y;
            _x3 = Mathf.Abs(_vectorA.x - _vectorC.x) > 0.01f ? _vectorC.x : _vectorC.z; _y3 = _vectorC.y;
            
            float amount = 0;
            _isJumping = true;
            
            float[] coefficients = FindParabolaEquation(new Vector2(_x1,_y1),
                new Vector2(_x2,_y2),
                new Vector2(_x3,_y3));
            
            while (amount < 1)
            {
                amount = amount + Time.deltaTime * speedJump > 1 ? 1 : amount + Time.deltaTime * speedJump;
                float x = Mathf.Lerp(_vectorA.x, _vectorC.x, amount);
                float z = Mathf.Lerp(_vectorA.z, _vectorC.z, amount);
                float alpha = Mathf.Lerp(_x1, _x3, amount);
                float y = coefficients[0] * alpha * alpha + coefficients[1] * alpha + coefficients[2];
                transform.position = new Vector3(x, y, z);
                shadow.transform.position = Vector2.Lerp(_vectorA, _vectorC, amount);
                yield return null;
            }

            transform.position = _vectorC;
            shadow.transform.position = _vectorC;
            _isJumping = false;
        }
        
        float[] FindParabolaEquation(Vector2 A, Vector2 B, Vector2 C)
        {
            float x1 = A.x, y1 = A.y;
            float x2 = B.x, y2 = B.y;
            float x3 = C.x, y3 = C.y;
            
            float[,] matrix = {
                { x1 * x1, x1, 1, y1 },
                { x2 * x2, x2, 1, y2 },
                { x3 * x3, x3, 1, y3 }
            };

            return SolveLinearSystem(matrix);
        }

        float[] SolveLinearSystem(float[,] matrix)
        {
            int n = 3;
            for (int i = 0; i < n; i++)
            {
                int maxRow = i;
                for (int k = i + 1; k < n; k++)
                    if (Mathf.Abs(matrix[k, i]) > Mathf.Abs(matrix[maxRow, i]))
                        maxRow = k;
                
                for (int k = i; k <= n; k++)
                {
                    (matrix[maxRow, k], matrix[i, k]) = (matrix[i, k], matrix[maxRow, k]);
                }
                
                for (int k = i + 1; k < n; k++)
                {
                    float factor = matrix[k, i] / matrix[i, i];
                    for (int j = i; j <= n; j++)
                        matrix[k, j] -= factor * matrix[i, j];
                }
            }
            
            float[] solution = new float[n];
            for (int i = n - 1; i >= 0; i--)
            {
                solution[i] = matrix[i, n] / matrix[i, i];
                for (int k = i - 1; k >= 0; k--)
                    matrix[k, n] -= matrix[k, i] * solution[i];
            }
            return solution;
        }
    }
}
