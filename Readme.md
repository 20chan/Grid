# Grid

## Grid.Framework

### Summary

유니티같은 인터페이스를 가진 컴포넌트 기반 게임엔진 프레임워크입니다. 하드코딩해서 성능은 기대 못함

```csharp
GameObject obj = new GameObject("square");
var render = obj.AddComponent<Renderable2D>();
render.Texture = Content.Load<Texture2D>("square");
obj.Scale = new Vector2(0.1f, 0.1f);
obj.AddComponent<Movable>();
Instantiate(obj);
```

### 사용법

[위키](https://github.com/phillyai/Grid/wiki) ㄱㄱ

### TODO

- GUI
    - [ ] ContextMenuStrip
    - [ ] TextBox

## Grid

프레임워크 어느정도 만들면 작업 시작할건데 우선은 정수 좌표에서 정수 크기의 블럭들이 서로 상호작용하는 게임이라고 하겠음