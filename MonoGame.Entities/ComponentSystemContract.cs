using System;

namespace MonoGame.Entities
{
    internal sealed class ComponentSystemContract
    {
        public ComponentSystemContract(ComponentSystem system, Type[] requiredComponents)
        {
            ComponentSystem = system;
            RequiredComponents = requiredComponents;
        }

        public ComponentSystem ComponentSystem { get; }
        public Type[] RequiredComponents { get; }
    }
}