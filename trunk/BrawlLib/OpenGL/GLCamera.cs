using System;

namespace BrawlLib.OpenGL
{
    public unsafe class GLCamera
    {
        public Matrix _matrix;
        public Matrix _matrixInverse;

        public Vector3 _rotation;
        public Vector3 _scale;

        public GLCamera()
        {
            _matrix = _matrixInverse = Matrix.Identity;
            _scale = new Vector3(1);
        }

        public Vector3 GetPoint() { return _matrixInverse.Multiply(new Vector3()); }

        public void Scale(float x, float y, float z)
        {
            //Grab vertex from matrix
            Vector3 point = _matrixInverse.Multiply(new Vector3());

            //Multiply scale
            _scale._x *= x;
            _scale._y *= y;
            _scale._z *= z;

            //Reset matrices using new scale
            _matrix = Matrix.ReverseTransformMatrix(_scale, _rotation, point);
            _matrixInverse = Matrix.TransformMatrix(_scale, _rotation, point);
        }
        internal float _z = 0.0f;
        public void Translate(float x, float y, float z)
        {
            _matrix = Matrix.TranslationMatrix(-x, -y, -z) * _matrix;
            _matrixInverse.Translate(x, y, z);
            _z += z;
        }

        public void Rotate(float x, float y, float z)
        {
            //Grab vertex from matrix
            Vector3 point = _matrixInverse.Multiply(new Vector3());

            //Increment rotations
            _rotation._x += x;
            _rotation._y += y;
            _rotation._z += z;

            //Reset matrices using new rotations
            _matrix = Matrix.ReverseTransformMatrix(_scale, _rotation, point);
            _matrixInverse = Matrix.TransformMatrix(_scale, _rotation, point);
        }
        public void Rotate(float x, float y) { Rotate(x, y, 0); }
        public void Pivot(float radius, float x, float y)
        {
            Translate(0, 0, -radius);
            Rotate(x, y);
            Translate(0, 0, radius);
        }

        public void Reset()
        {
            _matrix = _matrixInverse = Matrix.Identity;
            _rotation = new Vector3();
            _scale = new Vector3(1);
        }
    }
}
