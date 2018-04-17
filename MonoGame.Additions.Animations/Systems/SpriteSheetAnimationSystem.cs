using MonoGame.Additions.Entities;
using MonoGame.Additions.Entities.Attributes;
using MonoGame.Additions.Entities.Components;

namespace MonoGame.Additions.Animations.Systems
{
    [ComponentSystem]
    [RequiredComponents(typeof(SpriteSheetAnimationComponent), typeof(TransformComponent))]
    public class SpriteSheetAnimationSystem : ComponentSystem
    {

    }
}