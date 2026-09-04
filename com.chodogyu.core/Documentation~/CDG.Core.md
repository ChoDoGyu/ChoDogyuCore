\# CDG Core Documentation



\## Overview



CDG Core는 Unity 프로젝트와 독립적인 CDG 패키지에서 공통으로 사용할 수 있는 최소한의 기반 타입을 제공하는 UPM 패키지입니다.



현재 버전의 Core는 작업의 성공과 실패를 일관된 방식으로 표현하기 위한 Result 계열 타입에 집중합니다.



제공되는 Runtime 타입은 다음과 같습니다.



\- `ResultError`

\- `Result`

\- `Result<T>`



CDG Core는 특정 게임, 장르 또는 시스템의 실제 동작을 구현하지 않습니다.



\---



\## Design Principles



\### 최소 책임



Core에는 여러 독립 패키지에서 실제로 공통 사용할 가치가 있는 최소한의 기반 타입만 포함합니다.



기능이 유용해 보인다는 이유만으로 Core에 추가하지 않습니다.



새 기능은 실제로 둘 이상의 독립 패키지에서 동일한 의미로 필요하다는 근거가 있을 때 Core 포함 여부를 검토합니다.



\### 낮은 결합도



CDG Core Runtime은 다음에 의존하지 않습니다.



\- UnityEngine

\- UnityEditor

\- 다른 CDG 패키지

\- 외부 라이브러리



이를 통해 Core가 다른 시스템의 구현이나 Unity 실행 구조를 강제하지 않도록 합니다.



\### 특정 시스템 비종속



Core는 작업 결과를 표현할 수 있지만 해당 작업 자체를 수행하지 않습니다.



예를 들어 Core는 저장 실패를 표현할 수 있지만 저장 기능을 구현하지 않습니다.



```text

CDG Core

→ 성공 / 실패 결과 표현



Save Package

→ 실제 저장 기능 구현

