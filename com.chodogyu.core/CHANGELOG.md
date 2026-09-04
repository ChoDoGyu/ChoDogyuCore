\# Changelog



CDG Core의 주요 변경 사항을 기록합니다.



\## \[0.1.0]



\### Added



\- `ResultError` 추가

&#x20; - 오류 코드와 메시지를 통한 실패 정보 표현

&#x20; - 오류 없음 상태를 나타내는 `ResultError.None` 제공



\- `Result` 추가

&#x20; - 반환값이 없는 작업의 성공 및 실패 표현

&#x20; - 실패 시 `ResultError` 전달 지원



\- `Result<T>` 추가

&#x20; - 성공 시 값을 포함하는 결과 표현

&#x20; - 실패 상태에서 `Value` 접근 방지

&#x20; - 참조 타입의 null 성공값 지원



\- `CDG.Core` Runtime Assembly 추가

&#x20; - UnityEngine 비의존 구조

&#x20; - 다른 CDG 패키지 및 외부 라이브러리 의존성 없음



\- Runtime 테스트 추가

&#x20; - `ResultError` 테스트

&#x20; - `Result` 테스트

&#x20; - `Result<T>` 테스트

&#x20; - 총 17개 테스트 구성



\- UPM 패키지 구조 및 메타데이터 구성



\- README 및 상세 Documentation 추가

