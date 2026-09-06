## Installation

### Git URL

GitHub에 배포된 버전은 Unity Package Manager에서 Git URL을 통해 설치할 수 있습니다.

1. `Window > Package Manager`를 엽니다.
2. 좌측 상단의 `+` 버튼을 선택합니다.
3. `Install package from git URL...`을 선택합니다.
4. 다음 URL을 입력합니다.

```text
https://github.com/ChoDoGyu/ChoDogyuCore.git?path=/com.chodogyu.core#v1.0.0
```

Git URL을 통한 설치를 사용하려면 Git이 시스템에 설치되어 있고 PATH에 등록되어 있어야 합니다.

### Local Package

로컬에서 개발 중인 패키지는 다음 순서로 설치할 수 있습니다.

1. `Window > Package Manager`를 엽니다.
2. 좌측 상단의 `+` 버튼을 선택합니다.
3. `Install package from disk...`를 선택합니다.
4. `com.chodogyu.core/package.json`을 선택합니다.

설치 후 다음 Namespace를 사용할 수 있습니다.

```csharp
using CDG.Core.Results;
```