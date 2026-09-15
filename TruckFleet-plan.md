# TruckFleet：12 周 .NET 后端作品集学习计划

> Coursera + Microsoft Learn + Scania/rFMS 领域对齐版  
> 从 C# / Unity 开发转向现代 .NET 后端开发  
> 建议投入：每周 8–10 小时  
> 版本：2026 年 9 月

---

## 目录

1. [学习目标](#1-学习目标)
2. [项目定位与边界](#2-项目定位与边界)
3. [学习策略](#3-学习策略)
4. [课程与资料范围](#4-课程与资料范围)
5. [Scania 与 rFMS 对齐原则](#5-scania-与-rfms-对齐原则)
6. [项目架构与技术栈](#6-项目架构与技术栈)
7. [领域模型](#7-领域模型)
8. [用户角色](#8-用户角色)
9. [12 周计划总览](#9-12-周计划总览)
10. [逐周实施计划](#10-逐周实施计划)
11. [Scania Data Access 与开放 API 策略](#11-scania-data-access-与开放-api-策略)
12. [关键技术决策](#12-关键技术决策)
13. [最终验收清单](#13-最终验收清单)
14. [README 与作品集结构](#14-readme-与作品集结构)
15. [GitHub 项目描述与 CV Bullet Points](#15-github-项目描述与-cv-bullet-points)
16. [五分钟面试讲解结构](#16-五分钟面试讲解结构)
17. [每周复盘模板](#17-每周复盘模板)
18. [第一天 90 分钟启动计划](#18-第一天-90-分钟启动计划)

---

## 1. 学习目标

12 周后，你应该能够独立完成并讲解一个面向欧洲商用车与车队运营场景的 TruckFleet 后端项目，包括：

- 使用 ASP.NET Core 构建 REST API；
- 使用 PostgreSQL 和 Entity Framework Core 管理业务数据；
- 使用 JWT、Identity 和 RBAC 实现认证与权限控制；
- 实现多租户数据隔离；
- 使用 xUnit 和集成测试验证业务规则；
- 接收、验证并处理模拟车辆遥测数据；
- 使用接近 rFMS 的数据模型表达车辆状态和累计数据；
- 使用 SignalR 实现近实时车辆状态和告警；
- 建立 Fleet Position、Vehicle Performance、Driver Performance 和 Service Planning 能力；
- 使用 Docker 搭建可重复运行的环境；
- 使用 GitHub Actions 建立 CI；
- 部署到 Azure；
- 编写专业 README、架构图、API 文档和作品集 Case Study。

最终目标不是声称复制了 Scania 的产品，而是证明你理解以下真实行业问题：

- Connected vehicle data；
- Fleet position and operations；
- Vehicle uptime and downtime；
- Driver behaviour and fuel efficiency；
- Service planning；
- OEM data integration；
- Reliable telemetry ingestion；
- Multi-tenant fleet management。

---

## 2. 项目定位与边界

### 2.1 项目定位

TruckFleet 是一个多租户车队运营后端。它管理车辆、司机、运输任务、车辆数据、驾驶表现、告警与维护计划，并通过实时 Dashboard 展示车队状态。

项目使用公开的行业术语和 rFMS 规范进行数据模型设计，同时参考 Scania Connected Services 的公开业务分类，例如：

- Fleet Position；
- Vehicle Performance；
- Driver Evaluation；
- Service Planning；
- Data Access；
- Uptime；
- Geofencing。

### 2.2 免责声明

在 README 中明确写明：

> TruckFleet is an independent portfolio project inspired by publicly documented commercial fleet-management concepts and the rFMS standard. It is not affiliated with, endorsed by, or connected to Scania.

不要：

- 使用 Scania Logo；
- 把项目命名为 Scania Fleet；
- 声称实现了 Scania 专有的 Performance Evaluation Model；
- 在没有真实授权调用的情况下写“Integrated with Scania API”；
- 复制 My Scania 的界面设计或品牌视觉。

### 2.3 MVP 暂不包含

- 真实 CAN Bus 接入；
- 真实 ECU 或车载硬件；
- 真实 GPS 设备连接；
- 完整路线导航或路线优化；
- 复杂微服务架构；
- Kubernetes；
- 支付或订阅系统；
- 完整生产级前端；
- 真实驾驶员合规或运输公司合规系统；
- Scania 专有评分算法；
- 必须依赖付费 Scania Data Access 的功能。

第一版前端只需要：

- Swagger/OpenAPI；
- 简单 HTML/JavaScript、React 或 Blazor Dashboard；
- 一张车辆列表和一张车辆详情页；
- 可选的简单地图。

---

## 3. 学习策略

由于你已经有 C# 和 Unity 开发经验，本计划不会要求完整学习所有基础语法。

### 3.1 每周时间分配

| 类型 | 建议时间 |
|---|---:|
| Coursera | 2 小时 |
| Microsoft Learn / 官方文档 | 1–1.5 小时 |
| rFMS / 商用车领域资料 | 0.5–1 小时 |
| TruckFleet 实现 | 4–5 小时 |
| 测试、文档和复盘 | 1–1.5 小时 |

### 3.2 核心原则

1. 每周必须留下一个可以运行、测试或演示的项目增量。
2. 学习资料服务于项目，不用课程完成率代替项目进度。
3. 先实现可靠 MVP，再增加消息队列、MQTT 或真实 OEM 集成。
4. 使用行业标准命名，但不伪装成 Scania 官方系统。
5. 对每个关键规则至少编写一个自动化测试。
6. 对所有外部数据源使用 Adapter，避免业务逻辑依赖某一家 OEM。

---

## 4. 课程与资料范围

### 4.1 Coursera 主线

主要使用 [Microsoft Back-End Developer Professional Certificate](https://www.coursera.org/professional-certificates/microsoft-back-end-developer/)。

| 编号 | 课程方向 | 本计划策略 |
|---|---|---|
| Course 1 | [Foundations of Coding Back-End](https://www.coursera.org/learn/foundations-of-coding-back-end) | 选择性学习 |
| Course 2 | [Introduction to Programming With C#](https://www.coursera.org/learn/introduction-to-programming-with-c-sharp) | 只复习后端相关内容 |
| Course 3 | [Back-End Development with .NET](https://www.coursera.org/learn/back-end-development-with-dotnet) | 重点学习 |
| Course 4 | [Database Integration and Management](https://www.coursera.org/learn/database-integration-and-management) | 重点学习 |
| Course 5 | [Security and Authentication](https://www.coursera.org/learn/security-and-authentication) | 重点学习 |
| Course 6 | [Performance Optimization and Scalability](https://www.coursera.org/learn/performance-optimization-and-scalability) | 选择性学习 |
| Course 7 | [Data Structures and Algorithms](https://www.coursera.org/learn/msft-data-structures-and-algorithms) | 只学项目相关部分 |
| Course 8 | [Deployment and DevOps](https://www.coursera.org/learn/deployment-and-devops) | 重点学习 |

课程可能调整模块标题。本计划按照主题匹配，不依赖某个固定视频名称。

> 链接与课时说明：Coursera 使用课程主页链接，便于 Module 调整后仍可访问。逐周表格列出本路线实际要求学习的每个视频课时，而不是照搬整个证书；时长按 2026 年 9 月 15 日公开课程目录核对。Microsoft Learn 同时包含正式 Training Module 和官方技术文档，计划中会按实际类型标注。

### 4.2 Microsoft Learn 补充方向

- [Create web APIs with ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-10.0)；
- [Handle errors in ASP.NET Core APIs](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/error-handling-api?view=aspnetcore-10.0)；
- [EF Core documentation](https://learn.microsoft.com/en-us/ef/core/)：relationships、migrations、transactions 和 concurrency；
- [ASP.NET Core authentication overview](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/?view=aspnetcore-10.0)、claims 和 policy-based authorization；
- [Unit testing C# with xUnit](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-csharp-with-xunit) 与 [ASP.NET Core integration testing](https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-10.0)；
- [Worker Services in .NET](https://learn.microsoft.com/en-us/dotnet/core/extensions/workers) 与 BackgroundService；
- [ASP.NET Core SignalR overview](https://learn.microsoft.com/en-us/aspnet/core/signalr/introduction?view=aspnetcore-10.0)；
- [Rate limiting middleware](https://learn.microsoft.com/en-us/aspnet/core/performance/rate-limit?view=aspnetcore-10.0) 与 [HTTP resilience](https://learn.microsoft.com/en-us/dotnet/core/resilience/http-resilience)；
- [Logging in .NET](https://learn.microsoft.com/en-us/dotnet/core/extensions/logging/overview)、[Health Checks](https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/health-checks?view=aspnetcore-10.0) 与 [OpenTelemetry Training Module](https://learn.microsoft.com/en-us/training/modules/implement-observability-cloud-native-app-with-opentelemetry/)；
- [ASP.NET Core Docker containers](https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/docker/building-net-docker-images?view=aspnetcore-10.0)、[GitHub Actions for .NET](https://learn.microsoft.com/en-us/dotnet/devops/dotnet-build-github-action) 与 [Azure Container Apps](https://learn.microsoft.com/en-us/azure/container-apps/)。

### 4.3 车辆与行业资料

- [Scania Developer Portal](https://developer.scania.com/)
- [Scania Data Access](https://www.scania.com/uk/en/home/services/connected-services/data-access.html)
- [Scania Fleet Position](https://www.scania.com/uk/en/home/services/connected-services/control-package/fleet-position.html)
- [Scania Vehicle Performance](https://www.scania.com/uk/en/home/services/connected-services/control-package/vehicle-performance.html)
- [Scania Driver Evaluation](https://www.scania.com/uk/en/home/services/connected-services/control-package/driver-evaluation.html)
- [FMS/rFMS specifications](https://www.fms-standard.com/Truck/down_load/download_ok.htm)

---

## 5. Scania 与 rFMS 对齐原则

### 5.1 业务语言映射

| 原 TruckFleet 概念 | 对齐后的表达 | 用途 |
|---|---|---|
| Telemetry Dashboard | Fleet Position | 位置、路线、速度和车辆状态 |
| Statistics | Vehicle Performance | 油耗、怠速、驾驶和排放数据 |
| Driver Score | Driver Performance | 驾驶行为汇总；不复制 Scania PEM |
| Maintenance | Service Planning | 按日期与里程安排服务活动 |
| Offline Truck | Vehicle Not Reporting | 车辆超过阈值未上报 |
| Alert | Event / Alarm | 区分原始事件与需要处理的告警 |
| GPS Zone | Geofence | 进入、离开或违反区域规则 |
| Vehicle Availability | Uptime | 车辆可投入运营的时间 |
| Cost Dashboard | Total Operating Economy Summary | 作品集中的简化业务指标 |
| External telemetry | Data Access | OEM 或第三方车辆数据接入 |

### 5.2 rFMS 术语

优先理解：

- `VehicleStatus`；
- `AccumulatedData`；
- `SnapshotData`；
- `Trigger`；
- `TellTale`；
- `DriverIdentification`；
- `TachographData`；
- `WheelBasedSpeed`；
- `EngineTotalFuelUsed`；
- `EngineTotalHoursOfOperation`；
- `Odometer`；
- `FuelLevel`；
- `CatalystFuelLevel` / reductant / AdBlue；
- `Trailer` 和 `AxleLoad`。

### 5.3 Scania 风格的业务指标

Driver Performance 可包含：

- Idling；
- Anticipation 的简化代理指标；
- Speeding；
- Powertrain coasting；
- Driving with cruise control；
- Harsh braking；
- Harsh acceleration；
- Driving outside optimum engine speed band。

Vehicle Performance 可包含：

- Distance driven；
- Engine running time；
- Fuel consumed；
- Fuel consumed while idling；
- Average fuel consumption；
- AdBlue/reductant level；
- Uptime percentage；
- Vehicle not reporting duration；
- Maintenance due status。

---

## 6. 项目架构与技术栈

### 6.1 建议技术栈

- .NET / C#；
- ASP.NET Core Web API；
- PostgreSQL；
- Entity Framework Core；
- ASP.NET Core Identity；
- JWT Authentication；
- Role-Based 和 Policy-Based Authorization；
- xUnit；
- FluentAssertions；
- `WebApplicationFactory`；
- Testcontainers for PostgreSQL；
- SignalR；
- BackgroundService；
- Docker / Docker Compose；
- GitHub Actions；
- Azure Container Apps 或 Azure App Service；
- OpenTelemetry / Application Insights。

### 6.2 Solution 结构

```text
TruckFleet.sln
├── src/
│   ├── TruckFleet.Api/
│   ├── TruckFleet.Application/
│   ├── TruckFleet.Domain/
│   └── TruckFleet.Infrastructure/
├── tests/
│   ├── TruckFleet.UnitTests/
│   └── TruckFleet.IntegrationTests/
├── tools/
│   ├── TruckFleet.Simulator/
│   └── TruckFleet.MockRfmsServer/        # 可选
└── docs/
    ├── architecture/
    └── adr/
```

### 6.3 数据接入抽象

```csharp
public interface IVehicleDataProvider
{
    Task<IReadOnlyList<VehicleStatusSnapshot>> GetVehicleStatusesAsync(
        DateTimeOffset? since,
        CancellationToken cancellationToken);
}
```

实现：

```text
IVehicleDataProvider
├── SimulatorVehicleDataProvider
├── RfmsVehicleDataProvider
└── ScaniaDataAccessProvider      # 未来获得权限后再实现
```

业务规则必须位于 Application/Domain 层，不能直接写入 Provider 或 Controller。

---

## 7. 领域模型

### 7.1 Organization

运输公司，也是多租户数据隔离边界。

建议字段：

```text
Id
Name
CreatedAt
Status
```

### 7.2 Fleet

Organization 下的车辆分组。

```text
Id
OrganizationId
Name
OperationType
```

`OperationType` 示例：

- LongHaulage；
- RegionalDistribution；
- UrbanDistribution；
- Construction；
- WasteCollection；
- PassengerTransport。

### 7.3 Vehicle

代码中可以保留 `Truck`，但 API 与文档优先解释它是一个 commercial vehicle。

```text
Id
OrganizationId
FleetId
Vin
RegistrationNumber
CustomerVehicleName
Make
Model
ModelYear
PropulsionType
OdometerKm
EngineTotalHours
FuelCapacityLitres
AdBlueCapacityLitres
Status
ConnectivityStatus
LastReportedAt
```

状态：

```text
Available
Assigned
InOperation
Maintenance
OutOfService
Retired
```

连接状态：

```text
Reporting
Delayed
NotReporting
Unknown
```

### 7.4 Driver

```text
Id
OrganizationId
Name
LicenseNumber
LicenseExpiryDate
TachographDriverIdentification
Status
```

### 7.5 Trip

```text
Id
OrganizationId
TruckId
DriverId
Origin
Destination
PlannedStartTime
PlannedEndTime
ActualStartTime
ActualEndTime
DistanceKm
PayloadKg
Status
```

生命周期：

```text
Draft → Scheduled → InProgress → Completed
  └───────────────→ Cancelled
```

### 7.6 VehicleStatusSnapshot

车辆最新状态，面向快速 Dashboard 查询。

```text
TruckId
RecordedAt
ReceivedAt
Latitude
Longitude
WheelBasedSpeedKph
EngineSpeedRpm
FuelLevelPercent
AdBlueLevelPercent
OdometerKm
EngineTotalHours
CruiseControlActive
BrakePedalActive
TrailerConnected
```

### 7.7 TelemetryRecord

保存完整历史数据。

```text
Id
OrganizationId
TruckId
MessageId
SequenceNumber
RecordedAt
ReceivedAt
PayloadVersion
Telemetry values...
```

唯一约束：

```text
TruckId + MessageId
```

### 7.8 FleetEvent 与 Alert

`FleetEvent` 是发生过的事实，`Alert` 是需要用户关注或处理的状态。

FleetEvent 示例：

- VehicleEnteredGeofence；
- VehicleExitedGeofence；
- SpeedThresholdExceeded；
- HarshBrakeDetected；
- FuelLevelChanged；
- TrailerConnected；
- TrailerDisconnected。

Alert 示例：

- VehicleNotReporting；
- LowFuel；
- HighCoolantTemperature；
- Overspeed；
- MaintenanceDue；
- DiagnosticFaultDetected。

### 7.9 ServicePlan 与 ServiceActivity

```text
ServicePlan
├── Id
├── OrganizationId
├── TruckId
├── Status
├── NextDueDate
├── NextDueOdometerKm
└── EstimatedDurationMinutes

ServiceActivity
├── Id
├── ServicePlanId
├── ActivityType
├── Status
├── ScheduledAt
├── CompletedAt
└── Notes
```

状态：

```text
Planned
DueSoon
Overdue
InProgress
Completed
Cancelled
```

### 7.10 DriverPerformanceSummary

```text
DriverId
PeriodStart
PeriodEnd
DistanceDrivenKm
EngineRunningSeconds
IdlingPercent
SpeedingPercent
CoastingPercent
CruiseControlPercent
HarshBrakingPer100Km
HarshAccelerationPer100Km
EfficiencyScore
```

`EfficiencyScore` 是项目自定义的透明规则，不使用 Scania PEM 名称。

---

## 8. 用户角色

| 角色 | 主要权限 |
|---|---|
| FleetAdmin | 管理用户、车辆、司机、权限和全部车队数据 |
| Dispatcher | 安排行程、分配车辆和司机、处理告警 |
| FleetManager | 查看 Fleet Position、Vehicle Performance、Driver Performance 和报告 |
| ServicePlanner | 管理 Service Plans 和 Service Activities |
| Driver | 查看自己的行程、车辆信息和驾驶表现 |
| Viewer | 只读访问 Dashboard 和报告 |

---

## 9. 12 周计划总览

| 周 | 主题 | 可演示结果 | Scania/rFMS 对齐点 |
|---:|---|---|---|
| 1 | 项目骨架与领域模型 | Solution、实体、README、ER 草图 | Transport Operation、Connected Vehicle、Uptime |
| 2 | REST API | 车辆、司机和行程 CRUD | Vehicle 与 Fleet 资源命名 |
| 3 | PostgreSQL 与 EF Core | 持久化和 Migration | VIN、最新状态与历史数据分离 |
| 4 | 行程生命周期与业务规则 | 状态转换、冲突检查、历史查询 | Vehicle availability 与 operation rules |
| 5 | JWT、RBAC 与多租户 | 登录、角色权限和数据隔离 | 多组织车队数据边界 |
| 6 | 自动化测试与 CI | Unit、Integration Test、GitHub Actions | OEM 数据适配器 contract tests |
| 7 | rFMS 风格遥测与 Simulator | 多车持续发送可靠遥测 | VehicleStatus、AccumulatedData、FMS 字段 |
| 8 | Fleet Position 与 SignalR | 浏览器实时显示车辆状态 | Near real-time、geofence、events |
| 9 | Driver Performance、告警与 Service Planning | 驾驶指标、告警去重、维护计划 | Driver Evaluation Lite、uptime |
| 10 | Vehicle Performance 与可观测性 | KPI、日志、Health Check、性能对比 | Vehicle Performance、TOE Summary |
| 11 | Docker、CI/CD 与 Azure | 容器化和线上 Demo | 可替换 Data Access Provider |
| 12 | 作品集包装 | README、视频、Case Study | rFMS alignment 和 Scania API 边界说明 |

---

## 10. 逐周实施计划

### Week 1：项目骨架与商用车领域模型

#### 本周目标

- 建立专业的 .NET Solution；
- 明确 TruckFleet MVP 范围；
- 建立第一版领域模型；
- 使用商用车和车队运营语言描述问题；
- 建立 GitHub 项目和开发规范。

#### 学习内容

Coursera：

**[Course 1：Foundations of Coding Back-End](https://www.coursera.org/learn/foundations-of-coding-back-end)**

| Module | 课时 | 时长 |
|---|---|---:|
| Module 1 — Introduction to Back-End Development | What is Back-End Development? | 6 分钟 |
| Module 1 | Roles and Responsibilities of a Back-End Engineer | 6 分钟 |
| Module 1 | Scope and Workflow of Back-End Engineering | 6 分钟 |
| Module 1 | Project Planning Fundamentals for Back-End Development | 5 分钟 |
| Module 1 | Resource Management and Documentation in Back-End Projects | 6 分钟 |
| Module 1 | Basics of Git for Back-End Development | 6 分钟 |
| Module 1 | Using GitHub for Collaborative Back-End Development | 4 分钟 |
| Module 2 — Logical Thinking and Problem-Solving | Problem Decomposition | 5 分钟 |
| Module 2 | Techniques for Problem Decomposition | 4 分钟 |
| Module 2 | Top-Down Problem-Solving Approach | 5 分钟 |
| Module 2 | Bottom-Up Problem-Solving Approach | 6 分钟 |
| Module 2 | Comparing Top-Down and Bottom-Up Approaches | 5 分钟 |
| Module 2 | Introduction to Pseudocode | 5 分钟 |

**[Course 2：Introduction to Programming With C#](https://www.coursera.org/learn/introduction-to-programming-with-c-sharp)**

| Module | 课时 | 时长 |
|---|---|---:|
| Module 1 — Foundations of .NET Development | Project Creation | 4 分钟 |
| Module 1 | Project Structure | 4 分钟 |
| Module 1 | Best Practices for File Organization | 6 分钟 |
| Module 3 — Object-Oriented Programming | Fundamental Concepts of Objects and Classes | 5 分钟 |
| Module 3 | Theoretical Understanding of OOP Principles | 6 分钟 |
| Module 3 | Inheritance | 3 分钟 |
| Module 3 | Polymorphism | 4 分钟 |
| Module 3 | Design Patterns | 5 分钟 |
| Module 3 | Creating Classes and Objects | 6 分钟 |
| Module 3 | Implementing Classes and Objects | 3 分钟 |

Coursera 预计：约 1 小时 55 分钟。你已有 C# / Unity 经验，因此跳过变量、循环等入门内容。

Microsoft Learn：

这些是官方文档，不是带进度记录的 Training Module。按以下章节阅读：

| 顺序 | 资源 | 类型 | 具体章节 | 建议用时 |
|---:|---|---|---|---:|
| 1 | [ASP.NET Core fundamentals](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/?view=aspnetcore-10.0) | 文档 | The `Program` file | 10 分钟 |
| 2 | 同上 | 文档 | Dependency injection (services) | 15 分钟 |
| 3 | 同上 | 文档 | Environments | 10 分钟 |
| 4 | 同上 | 文档 | Middleware | 15 分钟 |
| 5 | 同上 | 文档 | Host | 10 分钟 |
| 6 | 同上 | 文档 | Configuration | 10 分钟 |
| 7 | 同上 | 文档 | Logging 与 Routing | 15 分钟 |
| 8 | [Create web APIs with ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-10.0) | 文档 | Controller-based APIs 与 `ControllerBase` 概览 | 15 分钟 |
| 9 | [.NET application architecture guidance](https://learn.microsoft.com/en-us/dotnet/architecture/) | 文档集合 | Modern web applications 与 common architectures 概览 | 20 分钟 |

Microsoft Learn 建议用时：约 2 小时。

领域知识：

- VIN 与 Registration Number；
- Tractor、Rigid Truck 与 Trailer；
- Vehicle、Fleet 与 Connected Asset；
- Odometer、Engine Hours、Payload 与 Axle Load；
- Propulsion Type；
- Vehicle Availability、Uptime 与 Downtime；
- Transport Operation。

#### 实现任务

1. 创建 GitHub Repository 和 `TruckFleet.sln`。
2. 创建 Api、Application、Domain、Infrastructure 和测试项目。
3. 配置 Project References 与 `.editorconfig`。
4. 创建 Organization、Fleet、Truck、Driver、Trip 实体。
5. 创建 VehicleStatus、ConnectivityStatus、TripStatus 枚举。
6. 在 README 中写清：用户、问题、MVP、非目标和免责声明。
7. 画第一版 ERD。
8. 创建 ADR：
   - 为什么使用 Modular Monolith；
   - 为什么使用 PostgreSQL；
   - 为什么采用 rFMS-aligned model，而不依赖真实 OEM API；
   - 为什么使用 SignalR，而不是 Socket.IO。

#### 验收标准

- Solution 成功编译；
- 测试项目可以运行；
- GitHub 至少有 5 次有意义的提交；
- README 能解释项目问题、用户和边界；
- 能说明 Truck、Fleet、Organization 和 Transport Operation 的关系；
- 没有使用 Scania 商标或暗示官方合作。

---

### Week 2：REST API 与错误处理

#### 本周目标

- 掌握 ASP.NET Core 请求处理流程；
- 实现第一批 REST API；
- 正确处理验证和错误状态；
- 将 API Contract 与 Domain Entity 分离。

#### 学习内容

Coursera：

**[Course 3：Back-End Development with .NET](https://www.coursera.org/learn/back-end-development-with-dotnet)**

| Module | 课时 | 时长 | 优先级 |
|---|---|---:|---|
| Module 2 — Building Web APIs | Features of ASP.NET Core for Web API Development | 5 分钟 | 必修 |
| Module 2 | Setting Up a Web API Project | 7 分钟 | 必修 |
| Module 2 | Implementing Basic API Endpoints | 22 分钟 | 必修 |
| Module 2 | Introduction to Routing | 8 分钟 | 必修 |
| Module 2 | Advanced Routing Techniques | 18 分钟 | 必修 |
| Module 2 | CRUD APIs | 18 分钟 | 必修 |
| Module 2 | Concept of Dependency Injection | 5 分钟 | 必修 |
| Module 2 | Implementing Dependency Injection in ASP.NET Core | 11 分钟 | 必修 |
| Module 2 | Error Handling in ASP.NET Core | 7 分钟 | 必修 |
| Module 2 | Logging Best Practices | 6 分钟 | 必修 |
| Module 2 | Implementing Error Handling and Logging | 7 分钟 | 必修 |
| Module 4 — Middleware and OpenAPI | Concept of Middleware | 4 分钟 | 必修 |
| Module 4 | Middleware Pipeline | 4 分钟 | 必修 |
| Module 4 | Custom Middleware | 14 分钟 | 选修；Week 6 也会复习 |
| Module 4 | Introduction to OpenAPI and Swagger | 5 分钟 | 必修 |
| Module 4 | Integrating Swagger with ASP.NET Core | 14 分钟 | 必修 |

Coursera 预计：约 2 小时 35 分钟。时间不足时，把 `Custom Middleware` 移到 Week 6。

Microsoft Learn：

| 顺序 | 资源 | 类型 | 具体章节 | 建议用时 |
|---:|---|---|---|---:|
| 1 | [Create web APIs with ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-10.0) | 文档 | `ControllerBase` class | 10 分钟 |
| 2 | 同上 | 文档 | Attributes、`[ApiController]` 与 attribute routing requirement | 15 分钟 |
| 3 | 同上 | 文档 | Automatic HTTP 400 responses | 10 分钟 |
| 4 | 同上 | 文档 | Binding source parameter inference | 15 分钟 |
| 5 | 同上 | 文档 | Problem details for error status codes | 15 分钟 |
| 6 | [Handle errors in ASP.NET Core APIs](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/error-handling-api?view=aspnetcore-10.0) | 文档 | Error responses、Problem Details service 与 `IExceptionHandler` | 25 分钟 |
| 7 | 同上 | 文档 | Client and server error responses | 10 分钟 |
| 8 | [OpenAPI support in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/openapi/overview?view=aspnetcore-10.0) | 文档 | OpenAPI packages、`AddOpenApi` 与 `MapOpenApi` | 20 分钟 |
| 9 | 同上 | 文档 | Generate documents at run time / build time | 15 分钟 |

Microsoft Learn 建议用时：约 2 小时 15 分钟。

重点概念：

- DTO；
- DataAnnotations；
- Middleware；
- ProblemDetails；
- HTTP status codes；
- Pagination、filtering 和 sorting；
- CancellationToken。

#### 实现任务

- 实现 Trucks CRUD；
- 实现 Drivers CRUD；
- 实现 Trips 基础 CRUD；
- 实现 Fleets CRUD；
- 将 DTO 与 Domain Entity 分离；
- 添加请求验证；
- 使用 ProblemDetails 统一错误格式；
- 配置 Swagger/OpenAPI；
- 创建 `.http` 或 Postman 测试文件。

建议资源命名：

```http
GET    /api/fleets
GET    /api/trucks
GET    /api/trucks/{truckId}
GET    /api/trucks/{truckId}/latest-status
GET    /api/drivers
GET    /api/trips
```

#### 验收标准

- 能通过 Swagger 完成车辆 CRUD；
- 不直接返回 EF 或 Domain Entity；
- 不存在的资源返回 404；
- 无效输入返回 400；
- 业务冲突返回 409；
- OpenAPI 列出主要响应状态；
- 异步 endpoint 接受 `CancellationToken`。

---

### Week 3：PostgreSQL 与 Entity Framework Core

#### 本周目标

- 将 API 从内存存储迁移到 PostgreSQL；
- 掌握 EF Core 建模和 Migration；
- 建立可重复初始化的开发数据库；
- 分开建模“车辆最新状态”和“完整历史遥测”。

#### 学习内容

Coursera：

**[Course 4：Database Integration and Management](https://www.coursera.org/learn/database-integration-and-management)**

| Module | 课时 | 时长 |
|---|---|---:|
| Module 1 — Foundations of Database Integration | Introduction to ORM and EF Core | 6 分钟 |
| Module 1 | Basic Structure of Relational Databases | 4 分钟 |
| Module 1 | Principles of Relational Database Design | 6 分钟 |
| Module 1 | Choosing a Database Management System (DBMS) | 6 分钟 |
| Module 1 | Practical Example: Initial Database Setup and Configuration | 6 分钟 |
| Module 1 | Setting Up a Relational Database | 6 分钟 |
| Module 2 — Data Modeling and Database Operations | Introduction to Data Modeling in EF Core | 4 分钟 |
| Module 2 | Creating and Configuring Entity Classes | 8 分钟 |
| Module 2 | Modeling a Simple Database with EF Core | 5 分钟 |
| Module 2 | Performing CRUD Operations with EF Core | 4 分钟 |
| Module 2 | Implementing CRUD Operations in EF Core | 5 分钟 |
| Module 3 — Basics of SQL | Understanding SQL Syntax | 5 分钟 |
| Module 3 | Describe the Functionalities of Core SQL Commands | 5 分钟 |
| Module 3 | Basic Data Retrieval with SELECT | 3 分钟 |
| Module 3 | Filtering and Sorting Data | 6 分钟 |
| Module 3 | Writing SELECT Statements | 5 分钟 |
| Module 3 | Inserting Data with INSERT Statements | 5 分钟 |
| Module 3 | Updating and Deleting Data | 6 分钟 |
| Module 3 | Introduction to SQL JOINs | 6 分钟 |
| Module 3 | Practical Examples of Using JOINs | 9 分钟 |
| Module 3 | Introduction to SQL Functions | 6 分钟 |
| Module 3 | Using Aggregate Functions in SQL | 6 分钟 |
| Module 3 | Implementing SQL Functions and Aggregate Functions | 7 分钟 |

Coursera 预计：约 2 小时 13 分钟。

Microsoft Learn：

| 顺序 | 资源 | 类型 | 具体章节 | 建议用时 |
|---:|---|---|---|---:|
| 1 | [EF Core overview](https://learn.microsoft.com/en-us/ef/core/) | 文档集合 | Model、Querying data 与 Saving data 概览 | 20 分钟 |
| 2 | [Managing database schemas with migrations](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/) | 文档 | Getting started、Add a migration、Update the database | 20 分钟 |
| 3 | 同上 | 文档 | Remove a migration、Revert a migration 与 production deployment | 20 分钟 |
| 4 | [Relationships in EF Core](https://learn.microsoft.com/en-us/ef/core/modeling/relationships) | 文档集合 | Navigations、foreign keys、required/optional relationships | 20 分钟 |
| 5 | 同上 | 文档集合 | One-to-many、one-to-one、many-to-many 与 cascade delete | 30 分钟 |
| 6 | [Indexes in EF Core](https://learn.microsoft.com/en-us/ef/core/modeling/indexes) | 文档 | Composite index、unique index、index sort order 与 naming | 20 分钟 |
| 7 | [Npgsql Entity Framework Core Provider](https://www.npgsql.org/efcore/) | 第三方官方文档 | Provider setup、connection string 与 PostgreSQL-specific behavior | 20 分钟 |

Microsoft Learn / 官方文档建议用时：约 2 小时 30 分钟。

领域规则：

- Odometer 是累计值，通常不能倒退；
- VIN 在系统内应保持唯一；
- Registration Number 可能变化，不应替代 VIN；
- Telemetry 是时间序列数据；
- 最新状态和历史数据有不同查询模式。

#### 实现任务

- 使用 Docker 启动 PostgreSQL；
- 创建 `TruckFleetDbContext`；
- 配置实体关系和 Delete Behavior；
- 使用 Fluent API 添加约束和索引；
- 创建 Initial Migration；
- 创建可重复执行的 Demo Seed；
- 将 Fleets、Trucks、Drivers、Trips API 迁移到数据库；
- 使用 User Secrets 或环境变量保存连接串。

示例唯一索引：

```csharp
builder.Entity<Truck>()
    .HasIndex(x => new { x.OrganizationId, x.Vin })
    .IsUnique();
```

#### 验收标准

- 删除数据库后能通过 Migration 重建；
- Seed 可以重复执行；
- API 数据在服务重启后仍存在；
- Repository 中没有密码；
- 能解释 VehicleStatusSnapshot 与 TelemetryRecord 为什么分开；
- 能解释每个唯一约束和基础索引。

---

### Week 4：行程生命周期、事务与并发

#### 本周目标

- 实现真实业务规则；
- 掌握 transaction、optimistic concurrency 和高效查询；
- 防止非法派车和状态转换。

#### 学习内容

Coursera：

**[Course 4：Database Integration and Management](https://www.coursera.org/learn/database-integration-and-management)**

| Module | 课时 | 时长 |
|---|---|---:|
| Module 4 — Advanced Data Handling | Introduction to Subqueries and Common Table Expressions (CTEs) | 7 分钟 |
| Module 4 | Advanced Filtering and Query Techniques | 9 分钟 |
| Module 4 | Introduction to SQL Performance Tuning | 4 分钟 |
| Module 4 | Techniques for Optimizing SQL Queries | 5 分钟 |
| Module 4 | Introduction to SQL Transactions | 6 分钟 |
| Module 4 | Concurrency Control in SQL | 8 分钟 |
| Module 4 | Introduction to Stored Procedures and Functions | 5 分钟 |
| Module 4 | Creating and Managing Stored Procedures and Functions | 6 分钟 |
| Module 4 | Advanced SQL, Transactions, and Stored Procedures | 8 分钟 |
| Module 4 | Introduction to SQL Database Security | 5 分钟 |
| Module 4 | Protecting Against SQL Injection and Other Attacks | 4 分钟 |

**[Course 7：Data Structures and Algorithms](https://www.coursera.org/learn/msft-data-structures-and-algorithms)**

| Module | 课时 | 时长 |
|---|---|---:|
| Module 1 — Data Structures | Introduction to Big O Notation | 4 分钟 |
| Module 1 | Applying Big O Notation to Data Structures | 5 分钟 |
| Module 2 — Sorting and Searching | Linear Search in Data Structures | 3 分钟 |
| Module 2 | Binary Search in Sorted Data Structures | 5 分钟 |
| Module 2 | Applying Binary Search in Sorted Data Structures | 6 分钟 |
| Module 2 | Implementing Binary Search in .NET Core | 5 分钟 |
| Module 2 | Applying Binary Search in Back-End Systems | 4 分钟 |
| Module 2 | Comparing Time and Space Complexities | 5 分钟 |
| Module 2 | Identifying Best-Use Cases for Sorting Algorithms in Back-End Systems | 5 分钟 |

Coursera 预计：约 1 小时 49 分钟。

Microsoft Learn：

| 顺序 | 资源 | 类型 | 具体章节 | 建议用时 |
|---:|---|---|---|---:|
| 1 | [Efficient querying with EF Core](https://learn.microsoft.com/en-us/ef/core/performance/efficient-querying) | 文档 | Use indexes properly | 15 分钟 |
| 2 | 同上 | 文档 | Project only properties you need 与 limit result-set size | 15 分钟 |
| 3 | 同上 | 文档 | Efficient pagination | 15 分钟 |
| 4 | 同上 | 文档 | Avoid cartesian explosion、load related entities 与 N+1 | 20 分钟 |
| 5 | 同上 | 文档 | Buffering and streaming、tracking and no-tracking queries | 15 分钟 |
| 6 | [Handling concurrency conflicts](https://learn.microsoft.com/en-us/ef/core/saving/concurrency) | 文档 | Optimistic concurrency 与 concurrency tokens | 20 分钟 |
| 7 | 同上 | 文档 | Resolving concurrency conflicts | 20 分钟 |
| 8 | [Using transactions with EF Core](https://learn.microsoft.com/en-us/ef/core/saving/transactions) | 文档 | Default transaction behavior 与 controlling transactions | 20 分钟 |
| 9 | 同上 | 文档 | Savepoints 与 cross-context transactions | 15 分钟 |

Microsoft Learn 建议用时：约 2 小时 35 分钟。

#### 实现任务

- 实现 Trip 状态转换；
- 阻止非法状态跳转；
- 检查司机时间冲突；
- 检查车辆时间冲突；
- 阻止 Maintenance、OutOfService 或 Retired 车辆被分配；
- 使用 transaction 完成 Trip 创建与资源分配；
- 给 Truck、Trip 和 ServicePlan 添加 concurrency token；
- 实现分页以及日期、状态、司机和车辆筛选；
- 添加 Trip History endpoint；
- 为高频查询添加索引。

#### 验收标准

- 非法状态转换返回 409；
- 时间重叠的司机不能重复分配；
- 时间重叠的车辆不能重复分配；
- 两个并发更新不会静默覆盖；
- API 不会一次返回全部历史数据；
- 可以解释每个索引的用途。

---

### Week 5：JWT、RBAC 与多租户

#### 本周目标

- 实现用户登录；
- 建立角色权限；
- 保证不同运输公司之间的数据隔离。

#### 学习内容

Coursera：

**[Course 5：Security and Authentication](https://www.coursera.org/learn/security-and-authentication)**

| Module | 课时 | 时长 |
|---|---|---:|
| Module 1 — Securing APIs with ASP.NET Identity | Overview of ASP.NET Identity | 5 分钟 |
| Module 1 | Architecture of ASP.NET Identity | 4 分钟 |
| Module 1 | User Registration Process | 3 分钟 |
| Module 1 | User Authentication Process | 3 分钟 |
| Module 1 | Implementing User Registration and Authentication | 2 分钟 |
| Module 1 | Introduction to User Roles in ASP.NET Identity | 4 分钟 |
| Module 1 | Claims-Based Authorization in ASP.NET Identity | 5 分钟 |
| Module 1 | Demonstrating Roles and Claims in an ASP.NET Application | 24 分钟 |
| Module 1 | Managing Roles and Claims in an ASP.NET Application | 4 分钟 |
| Module 1 | Overview of Token-Based Authentication | 5 分钟 |
| Module 1 | Demonstrating Token-Based Authentication in ASP.NET | 7 分钟 |
| Module 1 | Implementing Token-Based Authentication in an ASP.NET Application | 4 分钟 |
| Module 2 — RBAC and JWT | Overview of Role-Based Access Control (RBAC) | 5 分钟 |
| Module 2 | What are JSON Web Tokens (JWTs)? | 5 分钟 |
| Module 2 | Creating and Decoding JWTs | 6 分钟 |
| Module 2 | Overview of JWT Authentication in ASP.NET Core | 4 分钟 |
| Module 2 | Implementing JWT Authentication | 8 分钟 |
| Module 2 | Securing API Endpoints with JWTs | 3 分钟 |
| Module 2 | Securing API Endpoints with JWTs（演示） | 7 分钟 |
| Module 2 | Best Practices for JWT Authentication | 5 分钟 |
| Module 2 | Implementing Security Best Practices for JWTs | 16 分钟 |
| Module 3 — Data Protection | Core Principles of Data Protection | 4 分钟 |
| Module 3 | Threats to Data Protection | 4 分钟 |
| Module 3 | What is Encryption? | 5 分钟 |
| Module 3 | Best Practices for Secure Data Storage | 3 分钟 |
| Module 3 | Implementing Secure Data Storage | 11 分钟 |
| Module 3 | Encryption Protocols for Data in Transit | 5 分钟 |
| Module 3 | Methods for Securing Network Data | 3 分钟 |

Coursera 预计：约 2 小时 44 分钟。External authentication provider 暂不属于 MVP，可跳过。

Microsoft Learn：

| 顺序 | 资源 | 类型 | 具体章节 | 建议用时 |
|---:|---|---|---|---:|
| 1 | [ASP.NET Core authentication overview](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/?view=aspnetcore-10.0) | 文档 | Authentication concepts、schemes 与 handlers | 20 分钟 |
| 2 | [ASP.NET Core Identity](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-10.0) | 文档 | Identity overview、user store 与 service configuration | 20 分钟 |
| 3 | [JWT bearer authentication](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/configure-jwt-bearer-authentication?view=aspnetcore-10.0) | 文档 | JWT validation、issuer、audience、signature 与 token lifetime | 25 分钟 |
| 4 | [Claims-based authorization](https://learn.microsoft.com/en-us/aspnet/core/security/authorization/claims?view=aspnetcore-10.0) | 文档 | Add claims checks 与 multiple claim values | 15 分钟 |
| 5 | [Policy-based authorization](https://learn.microsoft.com/en-us/aspnet/core/security/authorization/policies?view=aspnetcore-10.0) | 文档 | Requirements、handlers 与 policy registration | 25 分钟 |
| 6 | [Role-based authorization](https://learn.microsoft.com/en-us/aspnet/core/security/authorization/roles?view=aspnetcore-10.0) | 文档 | Add role services、authorize by role 与 role policies | 15 分钟 |
| 7 | [Multitenant solution architecture](https://learn.microsoft.com/en-us/azure/architecture/guide/multitenant/overview) | 架构指南 | Tenant definition、isolation models、identity 与 data isolation | 30 分钟 |
| 8 | [OWASP API Security Top 10](https://api-security.owasp.org/) | 外部标准 | Broken Object Level Authorization、Broken Authentication 与 Security Misconfiguration | 25 分钟 |

Microsoft Learn / 标准资料建议用时：约 2 小时 55 分钟。

#### 实现任务

- 创建 Identity user；
- 实现登录和 JWT；
- Token 包含 `sub`、`organization_id` 和 roles；
- 创建 `ICurrentTenant`；
- 建立角色和 policy；
- 所有业务查询应用 Organization 过滤；
- 可选使用 EF Core Global Query Filter；
- 禁止相信客户端传来的 OrganizationId；
- SignalR 连接预留相同租户隔离方式。

#### 验收标准

- 无 Token 返回 401；
- 权限不足返回 403；
- Organization A 无法读取或更新 B 的数据；
- 用户不能通过修改 request body 改变租户；
- 自动化测试覆盖 cross-tenant access。

---

### Week 6：自动化测试与 CI

#### 本周目标

- 证明业务规则可靠；
- 使用真实 PostgreSQL 测试关键数据库行为；
- 建立自动运行的 CI。

#### 学习内容

Microsoft Learn / 官方文档：

| 顺序 | 资源 | 类型 | 具体章节 | 建议用时 |
|---:|---|---|---|---:|
| 1 | [Unit testing C# with xUnit](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-csharp-with-xunit) | Tutorial | Create the solution | 15 分钟 |
| 2 | 同上 | Tutorial | Create a test、run `dotnet test` | 20 分钟 |
| 3 | 同上 | Tutorial | Add more tests：`Fact`、`Theory`、`InlineData` | 20 分钟 |
| 4 | [Integration tests in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-10.0) | 文档 | Introduction to integration tests | 15 分钟 |
| 5 | 同上 | 文档 | ASP.NET Core integration tests 与 test app prerequisites | 20 分钟 |
| 6 | 同上 | 文档 | Basic tests with default `WebApplicationFactory` | 25 分钟 |
| 7 | 同上 | 文档 | Customize `WebApplicationFactory` | 30 分钟 |
| 8 | 同上 | 文档 | Authentication、service replacement 与 test organization 相关章节 | 25 分钟 |
| 9 | [Testing EF Core applications](https://learn.microsoft.com/en-us/ef/core/testing/) | 文档集合 | Involving the database、testing against production database system | 20 分钟 |
| 10 | 同上 | 文档集合 | SQLite fake、InMemory limitations 与 repository considerations | 20 分钟 |
| 11 | [GitHub Actions for .NET](https://learn.microsoft.com/en-us/dotnet/devops/dotnet-build-github-action) | Tutorial | Workflow file、setup-dotnet、restore/build/test | 25 分钟 |

Microsoft Learn 建议用时：约 3 小时 55 分钟。

[Testcontainers for .NET](https://dotnet.testcontainers.org/) 使用其官方文档补充。

Coursera 复习（不增加新 Module）：

| 课程 | Module | 复习课时 | 时长 |
|---|---|---|---:|
| [Course 3](https://www.coursera.org/learn/back-end-development-with-dotnet) | Module 2 | Concept of Dependency Injection | 5 分钟 |
| Course 3 | Module 2 | Implementing Dependency Injection in ASP.NET Core | 11 分钟 |
| Course 3 | Module 2 | Testing with Dependency Injection | 5 分钟 |
| Course 3 | Module 2 | Error Handling in ASP.NET Core | 7 分钟 |
| Course 3 | Module 2 | Logging Best Practices | 6 分钟 |
| Course 3 | Module 2 | ASP.NET Core Logging Providers & Framework | 4 分钟 |
| Course 3 | Module 2 | Implementing Error Handling and Logging | 7 分钟 |
| Course 3 | Module 4 | Built-in Middleware Components | 5 分钟 |
| Course 3 | Module 4 | Custom Middleware | 14 分钟 |
| Course 3 | Module 4 | Designing Middleware for Performance | 5 分钟 |
| Course 3 | Module 4 | Securing Middleware | 4 分钟 |
| [Course 5](https://www.coursera.org/learn/security-and-authentication) | Module 4 | Overview of Authentication and Authorization | 4 分钟 |
| Course 5 | Module 4 | Identifying Security Issues in Code | 3 分钟 |

Coursera 复习预计：约 1 小时 20 分钟。测试主体仍以 Microsoft Learn 和项目实践为准。

#### 实现任务

Unit Test 覆盖：

- 维修车辆不能分配；
- Driver 不能同时执行两个行程；
- Truck 不能同时执行两个行程；
- 已完成行程不能重新开始；
- Odometer 不能倒退；
- 非法状态转换；
- 告警阈值规则。

Integration Test 覆盖：

```text
POST /api/trucks → 201
重复 VIN → 409
无 Token → 401
错误 Role → 403
跨 Organization 访问 → 404 或 403
非法请求 → 400
并发冲突 → 409
Transaction rollback → 数据未部分保存
```

另外为 `IVehicleDataProvider` 编写 contract test，确保不同 Provider 返回统一应用模型。

#### 验收标准

- 本地 `dotnet test` 全部通过；
- CI 在 push 和 pull request 时运行；
- 至少 10 个 Unit Test；
- 至少 6 个 Integration Test；
- Integration Test 使用真实 PostgreSQL container；
- 不使用 EF Core InMemory 假装完成数据库集成测试。

---

### Week 7：rFMS 风格遥测与 Truck Simulator

#### 本周目标

- 让项目从普通管理系统进入 connected vehicle 领域；
- 理解 CAN、J1939、FMS 与 rFMS 的层次；
- 可靠接收批量车辆数据；
- 使用 rFMS-aligned contract，但不伪装成完整认证实现。

#### 学习内容

Coursera：

**[Course 2：Introduction to Programming With C#](https://www.coursera.org/learn/introduction-to-programming-with-c-sharp)**

| Module | 课时 | 时长 |
|---|---|---:|
| Module 4 — Asynchronous Programming | Fundamentals of Asynchronous Programming | 6 分钟 |
| Module 4 | Benefits and Challenges of Asynchronous Programming | 5 分钟 |
| Module 4 | Syntax and Usage of Async and Await | 4 分钟 |
| Module 4 | Practical Implementation | 6 分钟 |
| Module 4 | Using async and await in C# | 4 分钟 |
| Module 4 | Designing Asynchronous Solutions | 5 分钟 |
| Module 4 | Using Practical Asynchronous Programming Solutions | 4 分钟 |
| Module 4 | Role in Modern Applications | 4 分钟 |
| Module 4 | Industry Examples | 6 分钟 |
| Module 4 | Debugging Asynchronous Code | 6 分钟 |
| Module 4 | Debugging and Creating Asynchronous Programs | 6 分钟 |

**[Course 3：Back-End Development with .NET](https://www.coursera.org/learn/back-end-development-with-dotnet)**

| Module | 课时 | 时长 |
|---|---|---:|
| Module 3 — Serialization & Deserialization | The Concept of Serialization | 4 分钟 |
| Module 3 | Use Cases of Serialization | 3 分钟 |
| Module 3 | Serialization Techniques | 4 分钟 |
| Module 3 | Implementing Serialization in .NET | 18 分钟 |
| Module 3 | Concept of Deserialization | 3 分钟 |
| Module 3 | Implementing Deserialization in .NET | 15 分钟 |
| Module 3 | Performance Impact of Serialization | 4 分钟 |
| Module 3 | Optimizing Serialization Performance | 4 分钟 |
| Module 3 | Security Risks in Serialization | 3 分钟 |
| Module 3 | Implementing Security Best Practices | 4 分钟 |

Coursera 预计：约 1 小时 58 分钟。

Microsoft Learn：

| 顺序 | 资源 | 类型 | 具体章节 | 建议用时 |
|---:|---|---|---|---:|
| 1 | [Worker Services in .NET](https://learn.microsoft.com/en-us/dotnet/core/extensions/workers) | 文档 | Worker Service template、`BackgroundService` 与 `ExecuteAsync` | 20 分钟 |
| 2 | 同上 | 文档 | App configuration、dependency injection 与 graceful shutdown | 15 分钟 |
| 3 | [`IHttpClientFactory`](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) | 文档 | Basic usage、named clients 与 typed clients | 25 分钟 |
| 4 | 同上 | 文档 | Handler lifetime、DNS behavior 与 logging | 15 分钟 |
| 5 | [Rate limiting middleware](https://learn.microsoft.com/en-us/aspnet/core/performance/rate-limit?view=aspnetcore-10.0) | 文档 | Fixed window、sliding window、token bucket 与 concurrency limiter | 30 分钟 |
| 6 | 同上 | 文档 | Named policies、partitioned limiter、429 response 与 testing | 20 分钟 |
| 7 | [HTTP resilience](https://learn.microsoft.com/en-us/dotnet/core/resilience/http-resilience) | 文档 | Standard resilience handler、retry、timeout 与 circuit breaker | 25 分钟 |
| 8 | 同上 | 文档 | Disable retries for unsafe methods 与 custom resilience pipeline | 15 分钟 |

Microsoft Learn 建议用时：约 2 小时 45 分钟。

领域知识：

- CAN Bus；
- ECU；
- SAE J1939；
- FMS 与 rFMS；
- Snapshot 与 accumulated data；
- Trigger 与 telltale；
- Tachograph 和 driver identification；
- Vehicle、trailer 与 axle load。

#### 实现任务

1. 创建 `TruckFleet.Simulator`。
2. 同时模拟至少三辆卡车。
3. 每 5 秒生成车辆状态。
4. 每条消息包含 `MessageId`、`SequenceNumber`、`RecordedAt` 和 `ReceivedAt`。
5. 实现：

```http
POST /api/trucks/{truckId}/telemetry/batch
```

6. 每个 batch 接受 1–100 条记录。
7. 使用 `TruckId + MessageId` 保证幂等。
8. 使用 transaction，坏数据不能导致 batch 部分保存。
9. 允许迟到和乱序数据，但旧数据不能覆盖 `VehicleStatusSnapshot`。
10. 创建 `SimulatorVehicleDataProvider`。
11. 可选：创建只读、简化的 rFMS 风格 endpoint：

```http
GET /api/rfms/vehicle-statuses?startTime=...
```

#### 示例 payload

```json
{
  "messageId": "018f7f65-8f77-7a00-a0d2-9cc42f62ab11",
  "sequenceNumber": 1042,
  "vin": "YS2R4X20001234567",
  "recordedAt": "2026-09-15T18:30:00Z",
  "position": {
    "latitude": 59.3293,
    "longitude": 18.0686
  },
  "wheelBasedSpeedKph": 82.4,
  "engineSpeedRpm": 1350,
  "engineTotalFuelUsedLitres": 48352.7,
  "fuelLevelPercent": 63.0,
  "adBlueLevelPercent": 71.0,
  "odometerKm": 318450,
  "engineTotalHours": 7821.5,
  "cruiseControlActive": true,
  "brakePedalActive": false,
  "trailerConnected": true
}
```

#### 验证规则

- 时间不能明显来自未来；
- speed 不能为负；
- fuel 和 AdBlue level 必须在 0–100；
- odometer 与 engine hours 不能倒退；
- sequence number 和 message ID 必须有效；
- 已 Retired 的车辆不能上传普通遥测；
- 不认识的 Truck ID 返回 404；
- 重复消息不重复存储或触发告警。

#### 验收标准

- Simulator 连续运行 10 分钟；
- 多辆车可以并发发送；
- 相同消息发送两次只保存一次；
- 乱序数据不会让最新位置倒退；
- 无效 batch 不会部分保存；
- 可以查询最新状态和历史遥测；
- README 能解释 CAN、FMS、rFMS 和 REST API 的区别。

---

### Week 8：Fleet Position、SignalR 与 Geofence

#### 本周目标

- 将车辆最新状态实时推送到浏览器；
- 建立接近 Fleet Position 场景的运营 Dashboard；
- 区分遥测保存与实时通知；
- 建立基础 geofence event。

#### 学习内容

Microsoft Learn：

| 顺序 | 资源 | 类型 | 具体章节 | 建议用时 |
|---:|---|---|---|---:|
| 1 | [Introduction to ASP.NET Core SignalR](https://learn.microsoft.com/en-us/aspnet/core/signalr/introduction?view=aspnetcore-10.0) | 文档 | What is SignalR、transports、Hubs 与 target audiences | 20 分钟 |
| 2 | [Use hubs in ASP.NET Core SignalR](https://learn.microsoft.com/en-us/aspnet/core/signalr/hubs?view=aspnetcore-10.0) | 文档 | Create and configure a Hub | 20 分钟 |
| 3 | 同上 | 文档 | Send messages、`Clients`、`Caller`、`Others` | 20 分钟 |
| 4 | 同上 | 文档 | Strongly typed hubs 与 `Hub<T>` | 15 分钟 |
| 5 | 同上 | 文档 | Handle events、`Context`、Groups 与 connection lifecycle | 25 分钟 |
| 6 | [SignalR JavaScript client](https://learn.microsoft.com/en-us/aspnet/core/signalr/javascript-client?view=aspnetcore-10.0) | 文档 | Install client、connect、call hub methods 与 receive messages | 25 分钟 |
| 7 | 同上 | 文档 | Error handling 与 automatic reconnect | 20 分钟 |
| 8 | [Authentication and authorization in SignalR](https://learn.microsoft.com/en-us/aspnet/core/signalr/authn-and-authz?view=aspnetcore-10.0) | 文档 | Authenticate users、bearer tokens、authorize hub methods | 25 分钟 |
| 9 | 同上 | 文档 | Custom authorization handlers 与 security considerations | 20 分钟 |

Microsoft Learn 建议用时：约 3 小时 10 分钟。

Coursera：本周没有直接覆盖 SignalR 的课时，不为了凑课程而安排无关内容。使用上述 Microsoft Learn 官方教程完成本周学习。

Scania 领域资料：

- Fleet Position；
- Near real-time positioning；
- Routes、events、locations 和 driver history；
- Geofence entry/exit alarms。

#### 实现任务

- 创建强类型 `FleetHub`；
- 按 Organization、Fleet 和 Truck 建立 Groups；
- 从 JWT claim 获取 Organization ID；
- 遥测保存后广播最新状态；
- SignalR 失败不能导致 telemetry transaction 失败；
- Dashboard 显示：
  - Vehicle name 和 registration number；
  - Reporting / Delayed / NotReporting；
  - Latest position；
  - Wheel-based speed；
  - Fuel 和 AdBlue level；
  - Current trip；
  - Active alerts；
- 实现自动重连；
- 创建 `Geofence` 和 `GeofenceEvent`；
- 支持 VehicleEnteredGeofence 与 VehicleExitedGeofence。

#### 验收标准

- 浏览器实时显示至少三辆卡车；
- 不刷新页面也能看到更新；
- 断线后可以自动重连；
- Organization A 收不到 B 的事件；
- 进入或离开区域只产生一次对应事件；
- 能解释 SignalR、WebSocket、REST 和 rFMS 的不同职责。

---

### Week 9：Driver Performance、告警与 Service Planning

#### 本周目标

- 根据遥测计算驾驶和车辆运营指标；
- 自动创建并去重告警；
- 实现按日期和里程触发的服务计划；
- 以 uptime 为业务目标组织功能。

#### 学习内容

Coursera：

**[Course 6：Performance Optimization and Scalability](https://www.coursera.org/learn/performance-optimization-and-scalability)**

| Module | 课时 | 时长 |
|---|---|---:|
| Module 1 — Caching Strategies | What is Caching? | 3 分钟 |
| Module 1 | How Caching Enhances Performance | 3 分钟 |
| Module 1 | In-Memory Caching Overview | 4 分钟 |
| Module 1 | Distributed Caching Overview | 3 分钟 |
| Module 1 | Configuring In-Memory Caching | 5 分钟 |
| Module 1 | Managing Cache Operations With IMemoryCache | 4 分钟 |
| Module 1 | Implementing In-Memory Caching in .NET | 4 分钟 |
| Module 1 | Setting Up Redis for Distributed Caching | 8 分钟 |
| Module 1 | Managing Data With Redis | 6 分钟 |
| Module 1 | Configuring Redis Caching in .NET | 7 分钟 |
| Module 1 | Overview of Cache Expiration Strategies | 3 分钟 |
| Module 1 | Implementing Cache Expiration Policies in .NET | 6 分钟 |
| Module 1 | Applying Cache Expiration Policies in .NET | 8 分钟 |

**[Course 7：Data Structures and Algorithms](https://www.coursera.org/learn/msft-data-structures-and-algorithms)**

| Module | 课时 | 时长 |
|---|---|---:|
| Module 1 — Data Structures | Use Cases for Stacks and Queues | 4 分钟 |
| Module 1 | Stacks and Queues Implementation With .NET Core | 4 分钟 |
| Module 1 | Introduction to Big O Notation | 4 分钟 |
| Module 1 | Applying Big O Notation to Data Structures | 5 分钟 |

Coursera 预计：约 1 小时 21 分钟。

Microsoft Learn：

| 顺序 | 资源 | 类型 | 具体章节 | 建议用时 |
|---:|---|---|---|---:|
| 1 | [Worker Services in .NET](https://learn.microsoft.com/en-us/dotnet/core/extensions/workers) | 文档 | Worker lifecycle、`BackgroundService` 与 cancellation | 20 分钟 |
| 2 | [Background tasks with hosted services](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-10.0) | 文档 | Timed background tasks | 15 分钟 |
| 3 | 同上 | 文档 | Consuming a scoped service in a background task | 20 分钟 |
| 4 | 同上 | 文档 | Queued background tasks 与 graceful shutdown | 20 分钟 |
| 5 | [Cache in-memory in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/performance/caching/memory?view=aspnetcore-10.0) | 文档 | `IMemoryCache`、cache options 与 expiration | 25 分钟 |
| 6 | 同上 | 文档 | Cache dependencies、callbacks 与 size limits | 20 分钟 |
| 7 | [Logging in .NET](https://learn.microsoft.com/en-us/dotnet/core/extensions/logging/overview) | 文档 | `ILogger`、log levels、providers 与 configuration | 25 分钟 |
| 8 | 同上 | 文档 | Structured logging、message templates 与 scopes | 20 分钟 |

Microsoft Learn 建议用时：约 2 小时 45 分钟。

Scania 领域资料：

- Driver Evaluation；
- Vehicle Performance；
- Service Planning；
- Idling、speeding、coasting、cruise control；
- Harsh braking 与 harsh acceleration；
- Uptime 和 workshop downtime。

#### 实现任务

1. 建立 `TelemetryRuleEngine`。
2. 创建以下规则：
   - Overspeed；
   - HighCoolantTemperature；
   - LowFuel；
   - VehicleNotReporting；
   - MaintenanceDue。
3. 实现 Alert cooldown、deduplication 和 acknowledge。
4. 创建 `TruckOfflineDetectionWorker`。
5. 创建 ServicePlan 和 ServiceActivity CRUD。
6. 同时支持 date-based 和 odometer-based service due。
7. 创建 `DriverPerformanceSummary`。
8. 第一版只计算：
   - Idling percentage；
   - Speeding percentage；
   - Coasting percentage；
   - Cruise control percentage；
   - Harsh braking per 100 km；
   - Harsh acceleration per 100 km。
9. 创建透明、可解释的自定义 `EfficiencyScore`。
10. 在 README 中说明它不是 Scania PEM。

#### 验收标准

- Simulator 可以触发不同告警；
- 持续超速不会每秒创建新告警；
- 用户可以 acknowledge 告警；
- 车辆恢复上报后关闭或解决 NotReporting 告警；
- 服务计划可按日期或里程进入 DueSoon/Overdue；
- 相同输入产生相同 Driver Performance 结果；
- 所有评分公式有测试和文档。

---

### Week 10：Vehicle Performance、TOE 与可观测性

#### 本周目标

- 建立 Vehicle Performance 概览；
- 用简化指标表达 Uptime 与 Total Operating Economy；
- 找出并优化一个真实性能问题；
- 建立日志、Tracing 和健康检查。

#### 学习内容

Coursera：

**[Course 6：Performance Optimization and Scalability](https://www.coursera.org/learn/performance-optimization-and-scalability)**

| Module | 课时 | 时长 |
|---|---|---:|
| Module 2 — Optimizing Database Queries | What is Query Optimization? | 4 分钟 |
| Module 2 | How Databases Optimize Queries Automatically | 3 分钟 |
| Module 2 | Introduction to Indexing | 4 分钟 |
| Module 2 | Indexing Trade-offs and Challenges | 4 分钟 |
| Module 2 | Creating Clustered and Non-Clustered Indexes in SQL | 7 分钟 |
| Module 2 | Evaluating the Impact of Indexes on Query Performance | 4 分钟 |
| Module 2 | Applying Indexing Techniques to Optimize Queries | 7 分钟 |
| Module 2 | Identifying Bottlenecks in SQL Queries | 6 分钟 |
| Module 2 | Optimization Techniques for Complex SQL Queries | 4 分钟 |
| Module 2 | Identify Best Practices for Writing Efficient SQL Queries | 6 分钟 |
| Module 2 | Continuous Query Optimization in Production | 7 分钟 |
| Module 3 — Designing Scalable Applications | Introduction to Scalability | 4 分钟 |
| Module 3 | Scalability vs. Performance | 2 分钟 |
| Module 3 | Event-Driven Architecture | 4 分钟 |
| Module 3 | Stateless Design and Load Balancing | 4 分钟 |
| Module 3 | Integrating Caching and Asynchronous Tasks into Architecture | 6 分钟 |
| Module 3 | Introduction to Asynchronous Processing Concepts | 3 分钟 |
| Module 3 | Configuring Asynchronous Tasks With Queues | 5 分钟 |
| Module 3 | Implementing Asynchronous Tasks in .NET | 5 分钟 |

**[Course 7：Data Structures and Algorithms](https://www.coursera.org/learn/msft-data-structures-and-algorithms)**

| Module | 课时 | 时长 |
|---|---|---:|
| Module 3 — Trees and Graphs | Directed vs. Undirected Graphs | 3 分钟 |
| Module 3 | Implementing Graph Traversal Algorithms in .NET Core | 5 分钟 |
| Module 3 | Introduction to Asynchronous Processing | 6 分钟 |
| Module 3 | Implementing Asynchronous Tasks in .NET Core | 7 分钟 |
| Module 3 | Asynchronous Processing in Back-End Systems | 5 分钟 |

Coursera 预计：约 1 小时 55 分钟。

Microsoft Learn：

文档章节：

| 顺序 | 资源 | 类型 | 具体章节 | 建议用时 |
|---:|---|---|---|---:|
| 1 | [Logging in .NET](https://learn.microsoft.com/en-us/dotnet/core/extensions/logging/overview) | 文档 | Logging providers、configuration、categories、levels 与 scopes | 25 分钟 |
| 2 | [Health checks in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/health-checks?view=aspnetcore-10.0) | 文档 | Basic health probe、register services 与 `MapHealthChecks` | 20 分钟 |
| 3 | 同上 | 文档 | Separate readiness and liveness probes | 20 分钟 |
| 4 | 同上 | 文档 | Database checks、custom checks、failure status 与 response writer | 25 分钟 |
| 5 | [Application Insights overview](https://learn.microsoft.com/en-us/azure/azure-monitor/app/app-insights-overview) | 文档 | Application dashboard、application map、live metrics、failures 与 performance | 25 分钟 |
| 6 | [EF Core performance](https://learn.microsoft.com/en-us/ef/core/performance/) | 文档集合 | Efficient querying、advanced performance topics 与 diagnosis | 25 分钟 |

正式 Training Module：**[Implement observability in a cloud-native .NET application with OpenTelemetry](https://learn.microsoft.com/en-us/training/modules/implement-observability-cloud-native-app-with-opentelemetry/)**

| Unit | 官方 Unit 名称 | 完成要求 |
|---:|---|---|
| 1 | Introduction | 阅读 |
| 2 | What is observability? | 阅读 |
| 3 | Add observability to a cloud-native application | 阅读并记录三大支柱 |
| 4 | Exercise — Add OpenTelemetry to a cloud-native application | 完成练习 |
| 5 | View telemetry with Azure Monitor and third-party tools | 阅读 |
| 6 | Exercise — Use OpenTelemetry data in a cloud-native application | 完成练习 |
| 7 | Exercise — Extend telemetry in .NET 8 | 完成练习，并按项目实际 .NET 版本调整 |
| 8 | Module assessment | 通过测验 |
| 9 | Summary | 阅读 |

Microsoft Learn 建议用时：文档约 2 小时 20 分钟；Training Module 约 1–1.5 小时。官方页面当前未显示各 Unit 的独立分钟数，因此不虚构精确时长。

#### Vehicle Performance 指标

```text
DistanceDrivenKm
EngineRunningHours
FuelConsumedLitres
FuelConsumedWhileIdlingLitres
AverageFuelConsumptionLitresPer100Km
IdlingPercent
CoastingPercent
VehicleUptimePercent
UnplannedDowntimeHours
ActiveAlertCount
MaintenanceDueCount
```

#### 简化 TOE Summary

不要虚构完整财务模型。只展示可解释的组成部分：

```text
FuelEfficiency
VehicleUptime
UnplannedDowntime
MaintenanceCompliance
DriverEfficiency
```

如果没有真实成本数据，就不要生成货币金额。

#### 实现任务

- 创建 Vehicle Performance summary endpoint；
- 创建 Fleet-level aggregate endpoint；
- 使用 DTO projection 和 `AsNoTracking`；
- 检查 N+1 queries；
- 为 Dashboard summary 添加短 TTL cache；
- 添加 structured logging；
- 为每个请求添加 Correlation ID；
- 创建 `/health/live` 和 `/health/ready`；
- 添加 HTTP、EF Core 和 Background Worker traces；
- 使用 k6 或 Bombardier 做简单压力测试；
- 记录 P50、P95、RPS 和 database query time；
- 绘制 Telemetry Ingestion Flow 和 Provider Architecture。

#### 验收标准

- README 有优化前后测量结果；
- 能通过 Correlation ID 追踪请求；
- `/health/ready` 可以反映 PostgreSQL 状态；
- 日志不包含 Token、密码或完整敏感驾驶员数据；
- 可以解释 Uptime 与 API server uptime 的区别；
- TOE Summary 不伪造不存在的成本数据。

---

### Week 11：Docker、CI/CD、Azure 与 Provider 配置

#### 本周目标

- 建立完整容器运行环境；
- 自动构建和测试；
- 部署可访问 Demo；
- 证明系统能够切换不同车辆数据来源。

#### 学习内容

Coursera：

**[Course 8：Deployment and DevOps](https://www.coursera.org/learn/deployment-and-devops)**

| Module | 课时 | 时长 |
|---|---|---:|
| Module 1 — Deploying Applications to Azure | Overview of Azure Cloud Services and Infrastructure | 4 分钟 |
| Module 1 | Scalability and Reliability in Azure Cloud Services | 4 分钟 |
| Module 1 | Configuring Applications With Open-Source Tools | 4 分钟 |
| Module 1 | Preparing Applications for Cloud Environments | 5 分钟 |
| Module 1 | Prepare Applications for Cloud Environments | 10 分钟 |
| Module 1 | Deployment Tools and Methods for Azure | 4 分钟 |
| Module 1 | Hands-On Deployment of a Basic Web App Using Azure CLI | 10 分钟 |
| Module 1 | Deploying a Basic Web App with Azure CLI | 5 分钟 |
| Module 1 | Monitoring Application Performance and Resource Usage | 10 分钟 |
| Module 1 | Monitor Application Performance and Resource Usage | 4 分钟 |
| Module 1 | Securing Applications With Identity and Access Management | 4 分钟 |
| Module 1 | Secure Applications With Identity and Access Management | 5 分钟 |
| Module 1 | Data Encryption and Network Security | 5 分钟 |
| Module 1 | Compliance and Security Audits on Azure | 4 分钟 |
| Module 1 | Demonstrate Compliance and Security Audits on Azure | 7 分钟 |
| Module 2 — CI/CD Pipelines | Overview and Benefits of CI/CD | 4 分钟 |
| Module 2 | Core Components of CI/CD Pipelines | 4 分钟 |
| Module 2 | CI/CD Workflow Example | 10 分钟 |
| Module 2 | Overview of GitHub Actions | 5 分钟 |
| Module 2 | Configuring Workflows With YAML Files | 10 分钟 |
| Module 2 | Implementing a CI/CD Pipeline Using GitHub Actions | 4 分钟 |
| Module 2 | Monitoring Tools for CI/CD Pipelines | 4 分钟 |
| Module 2 | Maintaining CI/CD Pipelines | 7 分钟 |

Coursera 预计：约 2 小时 13 分钟。

Microsoft Learn：

| 顺序 | 资源 | 类型 | 具体章节 | 建议用时 |
|---:|---|---|---|---:|
| 1 | [Run an ASP.NET Core app in Docker containers](https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/docker/building-net-docker-images?view=aspnetcore-10.0) | Tutorial | Build image、multi-stage Dockerfile、run container 与 publish | 35 分钟 |
| 2 | [Docker Compose documentation](https://docs.docker.com/compose/) | 第三方官方文档 | Compose file、services、volumes、networks、environment 与 healthcheck | 30 分钟 |
| 3 | [GitHub Actions for .NET](https://learn.microsoft.com/en-us/dotnet/devops/dotnet-build-github-action) | Tutorial | Create workflow、setup .NET、restore/build/test 与 artifacts | 30 分钟 |
| 4 | [Azure Container Apps documentation](https://learn.microsoft.com/en-us/azure/container-apps/) | 文档集合 | Overview、quickstart、environments、revisions 与 ingress | 30 分钟 |
| 5 | 同上 | 文档集合 | Secrets、environment variables、health probes、logging 与 scaling | 30 分钟 |
| 6 | [Host ASP.NET Core on Azure App Service](https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/azure-apps/?view=aspnetcore-10.0) | 文档 | Publish、configuration、logging 与 troubleshooting | 25 分钟 |
| 7 | [Azure Key Vault documentation](https://learn.microsoft.com/en-us/azure/key-vault/) | 文档集合 | Secrets、managed identity、access control 与 secret rotation | 25 分钟 |

Microsoft Learn / 官方文档建议用时：约 3 小时 25 分钟。部署目标只选 Container Apps 或 App Service 之一，不需要同时实现。

#### 实现任务

- 创建 multi-stage Dockerfile；
- 使用非 root 用户运行；
- 创建 Docker Compose；
- Compose 至少启动 API 和 PostgreSQL；
- 可选加入 Redis、RabbitMQ/MQTT broker 和 Simulator；
- 使用环境变量配置 Provider：

```text
VehicleData__Provider=Simulator
VehicleData__Provider=Rfms
VehicleData__Provider=ScaniaDataAccess
```

- GitHub Actions 执行 restore、build、test 和 image build；
- 部署到 Azure；
- 设置 secrets；
- 部署后调用 `/health/ready`；
- 确定 Migration 执行策略；
- 验证 Repository 不包含生产凭据。

#### Scania Provider 规则

如果没有真实 Data Access 权限：

- 只保留配置、接口和 stub；
- 默认禁用；
- 不提交虚假 Client ID 或 Secret；
- 不把 simulator 数据描述为 Scania 数据。

如果未来获得合法权限：

- 使用单独 secret store；
- 增加 token caching 和 expiry handling；
- 增加 rate limit、retry 和 timeout；
- 对日志中的 VIN、driver ID 和 credential 脱敏；
- 只访问被授权的车辆。

#### 验收标准

- 新电脑按照 README 可启动完整环境；
- `docker compose up` 可以运行；
- Azure Demo endpoint 可访问；
- CI/CD 不依赖本地电脑；
- Provider 可通过配置选择；
- 未配置 Scania 凭据时系统清晰失败或保持禁用；
- 没有 secrets 被提交到 Git。

---

### Week 12：作品集包装与面试演示

#### 本周目标

- 将技术项目整理成容易理解的作品集；
- 建立完整演示故事；
- 准备面试讲解；
- 准确表达与 Scania/rFMS 的关系。

#### 学习内容

**[Course 8：Deployment and DevOps](https://www.coursera.org/learn/deployment-and-devops)**

| Module | 课时 | 时长 | 用途 |
|---|---|---:|---|
| Module 3 — Application Monitoring | Overview of Monitoring Techniques and Tools | 4 分钟 | 复盘监控体系 |
| Module 3 | Monitoring Metrics and Their Impact on Performance | 5 分钟 | 选择 Demo 指标 |
| Module 3 | Key Features of Azure Monitor | 3 分钟 | Azure 监控入口 |
| Module 3 | Configuring Azure Monitor Alerts and Dashboards | 7 分钟 | Demo 告警 |
| Module 3 | Core Logging Strategies for Back-End Systems | 4 分钟 | 日志复盘 |
| Module 3 | Using Logs for Troubleshooting and Auditing | 7 分钟 | 面试案例 |
| Module 3 | Overview of Azure Automation Services | 4 分钟 | 了解即可 |
| Module 3 | Automating Maintenance Tasks With Runbooks | 4 分钟 | 了解即可 |
| Module 3 | Routine Updates and Security Patching | 3 分钟 | 运维边界 |
| Module 3 | Performance Tuning and Optimization in Azure | 8 分钟 | 性能结果包装 |
| Module 4 — Copilot for DevOps | Overview of Deployment Automation with Copilot | 4 分钟 | 选修 |
| Module 4 | Generating Deployment Scripts with Copilot | 5 分钟 | 选修 |
| Module 4 | Writing and Executing Deployment Scripts With Copilot | 6 分钟 | 选修 |
| Module 4 | Understanding CI/CD Pipeline Automation With Copilot | 5 分钟 | 选修 |
| Module 4 | Creating CI/CD Pipeline Scripts With Copilot | 6 分钟 | 选修 |
| Module 4 | Automating CI/CD Pipelines With Copilot | 7 分钟 | 选修 |
| Module 4 | Overview of Debugging Deployment Scripts With Copilot | 4 分钟 | 选修 |
| Module 4 | Debugging Deployment Scripts in VS Code Using Copilot | 6 分钟 | 选修 |
| Module 4 | Debugging and Optimizing Deployment Processes With Copilot | 4 分钟 | 选修 |
| Module 4 | Overview of DevOps Automation With Copilot | 5 分钟 | 选修 |
| Module 4 | Automating DevOps Workflows With Copilot in VS Code | 7 分钟 | 选修 |
| Module 4 | Automating and Optimizing DevOps Workflows | 9 分钟 | 选修 |

Coursera 必修约 49 分钟；Module 4 选修约 1 小时 8 分钟。优先完成作品集，选修内容不得挤占 README、演示和部署验证时间。

Microsoft Learn 复习清单：

| 顺序 | 资源 | 复习内容 | 产出 |
|---:|---|---|---|
| 1 | [OpenAPI support in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/openapi/overview?view=aspnetcore-10.0) | API document generation 与 endpoint metadata | 检查 Swagger/OpenAPI 完整性 |
| 2 | [Integration tests in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-10.0) | `WebApplicationFactory` 与 authentication tests | 测试策略说明 |
| 3 | [Health checks in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/health-checks?view=aspnetcore-10.0) | Liveness 与 readiness | 部署 smoke test |
| 4 | [Azure Container Apps documentation](https://learn.microsoft.com/en-us/azure/container-apps/) | Revisions、secrets、probes 与 logs | 部署检查清单 |
| 5 | [Azure Key Vault documentation](https://learn.microsoft.com/en-us/azure/key-vault/) | Secret handling 与 managed identity | Security considerations |

Microsoft Learn 复习建议用时：约 1 小时；重点是验证项目，不是再次通读全文。

#### 演示故事

1. FleetAdmin 登录。
2. Dispatcher 创建车辆和司机。
3. Dispatcher 创建并安排 Trip。
4. Simulator 通过 rFMS-aligned payload 发送车辆状态。
5. Fleet Position Dashboard 实时更新。
6. 车辆进入 geofence，系统记录事件。
7. 车辆出现超速、低油量或高温。
8. 系统创建并去重告警。
9. FleetManager 查看 Vehicle Performance。
10. FleetManager 查看 Driver Performance。
11. ServicePlanner 查看即将到期的服务计划。
12. 用户查看历史遥测和行程。

#### 实现任务

- 清理无用代码并统一命名；
- 补充 XML/API documentation；
- 完善 README；
- 添加 Architecture Diagram；
- 添加 ERD；
- 添加 Permission Matrix；
- 添加 API 示例；
- 添加 Postman Collection 或 `.http` 文件；
- 添加 Demo Seed 和 Demo Script；
- 录制 90–120 秒演示视频；
- 编写 Portfolio Case Study；
- 添加 Known Limitations 和 Next Steps；
- 创建 GitHub Issues 和 Milestones；
- 发布 `v1.0.0`。

#### 必须解释的边界

- rFMS 是行业标准，不是 Scania 专有协议；
- Scania Data Access 是需要订阅和授权的服务；
- 项目当前使用 simulator/mock data；
- Scania adapter 是可扩展边界，不是假装完成的生产集成；
- Driver score 是透明的自定义算法，不是 Scania PEM。

#### 验收标准

- 陌生人 10 分钟内能理解项目；
- README 包含运行命令、架构、测试和 API 示例；
- 所有 CI 检查为绿色；
- Demo 数据不包含真实个人信息；
- 已准备 5 分钟面试讲解；
- 能准确回答“你是否真的使用了 Scania API”。

---

## 11. Scania Data Access 与开放 API 策略

### 11.1 结论

Scania 有 Developer Portal 和 server-to-server 车辆数据 API，但真实车辆数据访问通常依赖：

- Scania/Data Access 用户身份；
- 已授权车辆；
- 对应 Data Access subscription；
- 应用凭据；
- 合法的数据使用权限。

它不应被当作一个无需合同、无需车辆、免费匿名调用的公共 Open Data API。

### 11.2 Data Access 层级

| 层级 | 公开说明中的主要数据 |
|---|---|
| Service Planning | Vehicle information、odometer、dates、schedule status、activities、duration |
| Location | 包含 Service Planning，并增加 specification、positioning、fuel、AdBlue、wheel-based speed |
| Performance | 包含 Location，并增加历史 driving time、braking、acceleration、uptime-related data 和更多 API |

### 11.3 项目采用方式

MVP：

```text
TruckFleet.Simulator
    → Telemetry Ingestion API
    → Application Service
    → PostgreSQL
    → SignalR
    → Dashboard
```

rFMS 演示版：

```text
Mock rFMS Server
    → RfmsVehicleDataProvider
    → Application Service
```

未来真实集成：

```text
Scania Data Access API
    → ScaniaDataAccessProvider
    → Normalized Vehicle Data
    → Application Service
```

### 11.4 README 推荐表述

可以写：

> The telemetry model is aligned with publicly available rFMS concepts, including vehicle status, accumulated operational values, driver identification, telltales and trailer data.

可以写：

> The provider abstraction is designed to support OEM data services such as Scania Data Access when valid credentials and vehicle permissions are available.

没有真实调用时不要写：

> TruckFleet integrates with Scania vehicles.

---

## 12. 关键技术决策

| 决策 | 当前选择 | 暂不选择 | 升级条件 |
|---|---|---|---|
| 车辆数据模型 | rFMS-aligned internal model | 复制某一家 OEM 私有 schema | 获得正式合同和文档 |
| 真实数据来源 | Simulator / Mock rFMS | 强依赖 Scania API | 获得合法 Data Access 权限 |
| 管理 API | REST | GraphQL | 前端出现复杂聚合需求 |
| 实时 UI | SignalR | Socket.IO | 必须对接现有 Socket.IO 系统 |
| 设备通信 | HTTP batch | MQTT / IoT Hub | 接入真实设备或大规模数据 |
| 数据库 | PostgreSQL | 专用时序数据库 | 遥测量显著增加 |
| ORM | EF Core | 全面使用 Dapper | 测量证明特定查询需要优化 |
| 架构 | Modular Monolith | Microservices | 团队和部署边界真正独立 |
| 后台处理 | BackgroundService | 消息队列 | 需要可靠重试和水平扩展 |
| 本地环境 | Docker Compose | Kubernetes | 出现真实集群运维需求 |
| 云平台 | Azure | 多云 | 岗位或项目明确要求 |
| Driver score | 可解释规则 | 模仿 Scania PEM | 从未公开算法不能复制 |

---

## 13. 最终验收清单

### 13.1 Functional

- [ ] 用户能够登录；
- [ ] 能管理 Fleet、Truck 和 Driver；
- [ ] 能创建和安排 Trip；
- [ ] 能阻止车辆或司机时间冲突；
- [ ] 能接收批量遥测；
- [ ] 能处理重复、迟到和乱序数据；
- [ ] 能查看 VehicleStatusSnapshot；
- [ ] 能查看历史 TelemetryRecord；
- [ ] Fleet Position Dashboard 实时更新；
- [ ] 能创建 geofence 和 entry/exit event；
- [ ] 能自动生成、去重和确认告警；
- [ ] 能查看 Driver Performance；
- [ ] 能管理 Service Planning；
- [ ] 能查看 Vehicle Performance 和 Fleet Summary。

### 13.2 Engineering Quality

- [ ] DTO 与 Domain Entity 分离；
- [ ] 业务规则不堆在 Controller；
- [ ] 外部车辆数据使用 Provider abstraction；
- [ ] 至少 15 个有意义的测试；
- [ ] 包含 Unit Tests 和 Integration Tests；
- [ ] Integration Tests 使用真实 PostgreSQL；
- [ ] 使用 Migration；
- [ ] 支持分页；
- [ ] 避免明显 N+1 query；
- [ ] 幂等和乱序处理有测试；
- [ ] 代码命名一致；
- [ ] Git commits 清晰。

### 13.3 Security

- [ ] 使用 JWT；
- [ ] 使用 RBAC/policies；
- [ ] 实现 tenant isolation；
- [ ] 不相信客户端 OrganizationId；
- [ ] Password 由 Identity 管理；
- [ ] Secrets 不进入 Git；
- [ ] 错误信息不泄露内部细节；
- [ ] 日志不记录 Token、API secret 或完整 driver identifier；
- [ ] Scania/OEM Provider 只能读取授权车辆。

### 13.4 Reliability

- [ ] 相同 MessageId 不会重复写入；
- [ ] 重复消息不会生成重复 Alert；
- [ ] 旧数据不会覆盖最新车辆状态；
- [ ] batch 失败不会部分保存；
- [ ] 并发更新不会静默覆盖；
- [ ] SignalR 失败不影响遥测持久化；
- [ ] BackgroundService 正确响应 cancellation；
- [ ] 外部 API 调用包含 timeout 和有限 retry。

### 13.5 Operations

- [ ] Dockerfile；
- [ ] Docker Compose；
- [ ] GitHub Actions；
- [ ] Azure deployment；
- [ ] Health Checks；
- [ ] Structured Logging；
- [ ] OpenTelemetry；
- [ ] Environment configuration；
- [ ] Migration strategy；
- [ ] Demo seed。

### 13.6 Presentation

- [ ] 专业 README；
- [ ] Architecture Diagram；
- [ ] ERD；
- [ ] Telemetry Sequence Diagram；
- [ ] Permission Matrix；
- [ ] API Documentation；
- [ ] Postman Collection 或 `.http` 文件；
- [ ] Demo Video；
- [ ] Case Study；
- [ ] Known Limitations；
- [ ] Next Steps；
- [ ] Release `v1.0.0`；
- [ ] Scania/rFMS 关系描述准确。

---

## 14. README 与作品集结构

建议 README：

```text
1. Problem
2. Users and transport operations
3. Product demo
4. Architecture
5. Domain model
6. Scania/rFMS domain alignment
7. Technology decisions
8. Running locally
9. API examples
10. Authentication, roles and tenant isolation
11. Telemetry ingestion and idempotency
12. Fleet Position and SignalR
13. Driver and Vehicle Performance
14. Alerts and Service Planning
15. Testing strategy
16. CI/CD and deployment
17. Performance results
18. Security and privacy
19. Scania Data Access integration boundary
20. Known limitations
21. Future improvements
```

Case Study 重点回答：

1. 为什么选择车队运营问题？
2. 为什么普通 CRUD 不足以展示后端能力？
3. rFMS 如何影响数据模型？
4. 如何处理重复、迟到和乱序遥测？
5. 如何保证 Organization 隔离？
6. 为什么使用 SignalR？
7. 如何从 telemetry 产生 events、alerts 和 summaries？
8. 如何在没有真实 Scania API 权限时保持设计可信？
9. 哪个性能问题被实际测量和优化？
10. 如果接入真实 OEM 数据，哪些部分不需要改？

---

## 15. GitHub 项目描述与 CV Bullet Points

### GitHub Description

> TruckFleet is a multi-tenant fleet-operations backend built with ASP.NET Core, PostgreSQL and SignalR. It uses an rFMS-aligned vehicle-data model to demonstrate secure APIs, reliable telemetry ingestion, real-time fleet position, driver and vehicle performance, service planning, automated testing, containerisation and cloud deployment.

### CV Bullet Points

- Built a portfolio fleet-operations backend with ASP.NET Core, EF Core and PostgreSQL, covering vehicles, drivers, trips, rFMS-aligned telemetry, alerts and service planning.
- Implemented JWT/RBAC authorization, tenant-scoped data access, idempotent batch ingestion, automated tests and a GitHub Actions CI pipeline.
- Developed simulated connected-vehicle data ingestion and a SignalR Fleet Position dashboard, including driver-performance metrics, geofence events and uptime-related alerts.
- Designed an OEM-neutral vehicle-data provider abstraction that can support services such as Scania Data Access when valid subscriptions and credentials are available.

---

## 16. 五分钟面试讲解结构

| 部分 | 时间 | 内容 |
|---|---:|---|
| Problem | 30 秒 | 车队需要统一掌握车辆、司机、行程、位置、告警和服务计划 |
| Domain | 45 秒 | Organization、Fleet、Truck、Trip、VehicleStatus、Alert、ServicePlan |
| Industry alignment | 45 秒 | rFMS、Fleet Position、Vehicle Performance、Uptime |
| Architecture | 60 秒 | API、PostgreSQL、Simulator、Provider、SignalR、BackgroundService |
| Hard parts | 75 秒 | 多租户、派车冲突、幂等、乱序、告警去重 |
| Quality | 30 秒 | 测试、CI、Docker、日志和 Health Checks |
| API boundary | 30 秒 | rFMS 标准可公开使用；Scania Data Access 需要授权 |
| Demo | 30 秒 | 从遥测进入到实时 Dashboard、告警和 Service Planning |

面试中推荐表述：

> I did not have access to production Scania vehicle data, so I designed the ingestion layer around an OEM-neutral provider interface and an rFMS-aligned internal model. The current demo uses simulated data, while a real Scania Data Access adapter can be added without changing the domain rules.

---

## 17. 每周复盘模板

### 本周成果

- 本周我可以演示什么？
- 我是否能不看教程解释它？
- 哪个自动化测试证明业务规则正确？
- 本周增加的行业知识是什么？
- 我的实现是行业标准、Scania 公开概念，还是项目自定义设计？
- 有没有不准确地暗示真实 OEM 集成？
- 下周最大的一个风险是什么？

### 进度表

| 功能 | Not started | Learning | Implemented | Tested | Documented |
|---|:---:|:---:|:---:|:---:|:---:|
| 功能名称 |  |  |  |  |  |

---

## 18. 第一天 90 分钟启动计划

### 0–15 分钟

- 创建 GitHub Repository；
- 创建 `TruckFleet.sln`；
- 添加 `.gitignore`；
- 创建 README。

### 15–35 分钟

创建：

```text
TruckFleet.Api
TruckFleet.Application
TruckFleet.Domain
TruckFleet.Infrastructure
TruckFleet.UnitTests
TruckFleet.IntegrationTests
```

配置 Project References。

### 35–55 分钟

创建第一批 Domain Models：

```text
Organization
Fleet
Truck
Driver
Trip
TruckStatus
ConnectivityStatus
TripStatus
```

### 55–70 分钟

- 建立 ASP.NET Core API；
- 添加 `/health/live`；
- 启用 Swagger；
- 验证项目可以启动。

### 70–80 分钟

- 创建第一个 xUnit Smoke Test；
- 执行 `dotnet test`。

### 80–90 分钟

- 更新 README；
- 写明 rFMS alignment 和非官方项目声明；
- Commit；
- Push 到 GitHub。

建议第一个 commit：

```text
chore: initialize TruckFleet solution and domain projects
```

---

## 结语

每周必须留下一个可运行、可测试、可演示的增量。

TruckFleet 的重点不是堆叠尽可能多的技术，也不是模仿某一家公司的产品，而是证明你能够：

- 理解真实的商用车与车队运营领域；
- 使用 rFMS 等公开标准设计稳定的数据边界；
- 处理遥测系统中的重复、延迟、乱序和连接中断；
- 将位置、驾驶表现、车辆表现、告警和服务计划组合成完整产品；
- 在没有生产数据和商业 API 权限时，诚实而专业地设计可扩展集成。

Coursera 和 Microsoft Learn 负责提供结构化知识；TruckFleet 负责证明你能把这些知识应用到接近真实 connected transport 的系统中。
