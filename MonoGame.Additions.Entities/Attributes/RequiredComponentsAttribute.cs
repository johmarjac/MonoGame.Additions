using System;
using System.Collections.Generic;

namespace MonoGame.Additions.Entities.Attributes
{
    public sealed class RequiredComponentsAttribute : Attribute
    {
        public RequiredComponentsAttribute(params Type[] components)
        {
            RequiredComponents = new List<Type>();
            RequiredComponents.AddRange(components);
        }

        public List<Type> RequiredComponents { get; }
    }
}