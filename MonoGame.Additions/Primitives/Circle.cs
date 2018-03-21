using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace MonoGame.Additions.Primitives
{
    public sealed class Circle : Primitive
    {        
        public static Circle Create(float radius, Color color, int sides = 180)
        {
            var vertices = new List<VertexPositionColor>();

            for(int i = 0; i <= 360; i += 361 / sides)
            {
                var angle = MathHelper.ToRadians(i);
                var vertex = new VertexPositionColor(new Vector3((float)Math.Cos(angle) * radius, (float)Math.Sin(angle) * radius, 0), color);

                vertices.Add(vertex);
            }

            var circle = new Circle()
            {
                Vertices = vertices.ToArray(),
                Type = PrimitiveType.LineStrip,
                PrimitiveCount = vertices.Count - 1
            };

            return circle;
        }
    }
}