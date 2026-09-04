\# CDG Core



CDG Core는 Unity 프로젝트와 다른 CDG 패키지에서 공통으로 사용할 수 있는 최소한의 기반 타입을 제공하는 UPM 패키지입니다.



현재 버전은 작업의 성공/실패와 오류 정보를 일관된 방식으로 표현하기 위한 Result 타입을 제공합니다.



\## Features



\- `ResultError`

&#x20; - 실패 원인을 오류 코드와 메시지로 표현합니다.



\- `Result`

&#x20; - 반환값이 없는 작업의 성공 또는 실패를 표현합니다.



\- `Result<T>`

&#x20; - 성공 시 값을 함께 반환하는 작업의 결과를 표현합니다.



\## Design Goals



CDG Core는 다음 원칙을 기준으로 설계되었습니다.



\- 최소한의 책임만 가집니다.

\- 특정 게임이나 장르에 종속되지 않습니다.

\- 특정 시스템의 실제 동작을 구현하지 않습니다.

\- 다른 CDG 패키지에 의존하지 않습니다.

\- UnityEngine 및 UnityEditor에 의존하지 않습니다.

\- 실제 공통 사용 가치가 확인된 기능만 포함합니다.

\- Utility 또는 Manager 모음으로 확장하지 않습니다.



\## Requirements



\- Unity 6.3 이상



\## Installation



\### Local Package



Unity에서 다음 순서로 설치할 수 있습니다.



1\. `Window > Package Manager`를 엽니다.

2\. 좌측 상단의 `+` 버튼을 선택합니다.

3\. `Install package from disk...`를 선택합니다.

4\. `com.chodogyu.core/package.json`을 선택합니다.



설치 후 다음 Namespace를 사용할 수 있습니다.



```csharp

using CDG.Core.Results;

