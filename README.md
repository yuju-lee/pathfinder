## 개발 배경

![image](https://user-images.githubusercontent.com/78521423/191063425-08260f7e-fba3-44e2-ba1c-0c3204fb8cdb.png)

군중 시뮬레이션이란?

군중 처리 라고도 하며, 군중의 행동을 처리하는 시뮬레이션 - 군중 시뮬레이션은 주로 게임과 영화 등 엔터테인먼트 산업에서 많이 사용되며, 특히 게임에서는 이를 표현하기 위해 실시간으로 많은 계산을 필요로 한다.
기존에 존재하는 군중 시뮬레이션 알고리즘 중 하나인 Flocking 알고리즘은 각 개체의 움직임을 도출하는 방법은 간단하지만 각 개체에 부여된 상태가 없다(Stateless).

Flocking 알고리즘은 군집을 갖춰 움직이는 모양을 보여지고 있으나,
1. 객체의 단순한 움직임

2. 홀로 떨어지는 객체가 발생

3. 움직이는 방향의 예측이 불가

하기 때문에 알고리즘의 이용 범위가 제한적이다.

따라서 flocking 알고리즘의 특징인 상태 없음(stateless)을 보완하여 사용자가 모든 객체를 제어할 수 있도록 특정 상태를 부여하며 기존의 알고리즘에서 개선된 군중 시뮬레이션을 개발하고, 
알고리즘의 사용 목적을 다양화한다.

## 개발 목표
- 사용자가 지정한 위치로 이동할 수 있도록 개발

- Flocking 알고리즘의 세 가지 법칙을 기반으로 두고 계산하도록 개발

- 가장 짧은 길로 이동할 수 있도록 A* 알고리즘과 Flocking 알고리즘이 함께 작용하도록 개발


## 기존 알고리즘의 동작 방식
### Flocking 알고리즘의 세 가지 법칙

![image](https://user-images.githubusercontent.com/78521423/191064345-ca66fd0e-c7f7-49f5-823c-f331446da629.png)

### A* 알고리즘의 개념

- 주어진 출발 꼭짓점에서부터 목표 꼭짓점까지 가는 최단 경로를 찾아내는 그래프/트리 탐색 알고리즘

- 넓이 우선과 깊이 우선 탐색을 조합하고 목적지까지의 거리를 고려하여 최적의 비용을 찾아 가는 휴리스틱(Heuristic)한 기법을 이용


#### 휴리스틱 추정 값 사용 

- 휴리스틱 추정 값  F = H + G 

  - H = 새로운 노드까지의 거리

  - G = 도착 노드까지의 예상비용

  - F  = 둘의 합 ( H + G )


- OpenList , ClosedList , PathList를 이용하여 노드 관리

  - OpenList - 검색대상들을 집어넣는 리스트 

     - ClosedList에있는 노드들과 , 장애물들은 제외한 노드들을 넣어서 검사

     - 도착노드까지 가장 비용이 저렴한 노드를 선택

  - ClosedList - 검색을 마친 노드들을 집어넣는 리스트

     - 더이상 검사를 하지 않아도 되는 노드들의 리스트

  - PathList – 시작 지점부터 목표 지점까지 최단경로가 담긴 리스트

     - 여기에 담긴 경로를 따라 움직이면 최단 경로가 된다


## Algorithm Overview

![image](https://user-images.githubusercontent.com/78521423/191065406-d4fe7aaa-f232-4cd2-8e32-8ea8df03cdc0.png)

### 기존 알고리즘의 동작에서의 개선

![image](https://user-images.githubusercontent.com/78521423/191065593-d91ebddb-f48c-4309-a3c9-4bdb4780bdc1.png)

(Cohesion-Force*weight) + (Separation-Force*weight) + (move to Leader-Force*weight)


각 벡터에 가해지는 중량을 다르게 해 Leader를 향한 벡터의 힘을 가장 크게, flocking 알고리즘을 구성하는 세 가지의 법칙 중 cohesion과 separation의 가중치는 비교적 낮게 설정하여 
Leader를 따르면서도 서로 부딪히지 않는 군집의 모양을 만들어낸다.

## 핵심구조

![image](https://user-images.githubusercontent.com/78521423/191065741-9cea736e-03ab-44f7-94e6-ffbdaa0c7b0a.png)

![image](https://user-images.githubusercontent.com/78521423/191065788-3a844bab-717b-4868-a95a-81f5d8c8aa28.png)


## result

