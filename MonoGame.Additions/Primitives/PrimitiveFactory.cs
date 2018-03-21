using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace MonoGame.Additions.Primitives
{
    public static class PrimitiveFactory
    {
        public static Circle CreateCircle(float radius, Color color, int sides = 360)
        {
            var vertices = new List<VertexPositionColor>();

            for (int i = 0; i <= 360; i += 360 / sides)
            {
                var heading = MathHelper.ToRadians(i);

                vertices.Add(new VertexPositionColor(new Vector3((float)Math.Cos(heading) * radius, (float)Math.Sin(heading) * radius, 0f), color));
            }

            return new Circle(vertices.ToArray(), PrimitiveType.LineStrip, false);
        }

        public static Circle CreateFilledCircle(float radius, Color color, int sides = 360)
        {
            var vertices = new List<VertexPositionColor>();

            for (int i = 0; i <= 360; i += 360 / sides)
            {
                var heading = MathHelper.ToRadians(i);
                vertices.Add(new VertexPositionColor(new Vector3(0, 0, 0), color));
                vertices.Add(new VertexPositionColor(new Vector3((float)Math.Cos(heading) * radius, (float)Math.Sin(heading) * radius, 0f), color));
            }

            return new Circle(vertices.ToArray(), PrimitiveType.TriangleStrip, true);
        }
    }
}