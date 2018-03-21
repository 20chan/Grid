# Grid

## Grid.Framework

유니티같은 인터페이스를 가진 컴포넌트 기반 2D 게임엔진 프레임워크입니다.

```csharp
GameObject obj = new GameObject("nam");
var render = obj.AddComponent<SpriteAnimator>();
render.Textures = new[] {
    Content.Load<Texture2D>("anim/ideal"),
    Content.Load<Texture2D>("anim/left-1"),
    Content.Load<Texture2D>("anim/left-2"),
    Content.Load<Texture2D>("anim/right-1"),
    Content.Load<Texture2D>("anim/right-2"),
    Content.Load<Texture2D>("anim/down-1"),
    Content.Load<Texture2D>("anim/down-2"),
    Content.Load<Texture2D>("anim/up-1"),
    Content.Load<Texture2D>("anim/up-2"),
};
obj.AddComponent<Movable>();
Instantiate(obj);
```

어느정도 완성되면 [위키](https://github.com/phillyai/Grid/wiki) 에 문서화를 해야 하는데 에궁 귀찮다

## Grid

사실 게임 만드려고 프레임워크 작성하던 거였는데 프레임워크에 몰두해버림 프로젝트 분리해야할듯