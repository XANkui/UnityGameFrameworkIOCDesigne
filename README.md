# UnityGameFrameworkIOCDesigne
## Unity IOC 简单游戏框架 

### 一、架构分为四个层级:

•表现层：IController 接口，负责接收输入和当状态变化时更新表现，一般情况下 MonoBehaviour 均为表现层对象。

•系统层：ISystem 接口，帮助 IController 承担一部分逻辑，在多个表现层共享的逻辑，比如计时系统、商城系统、成就系统等。

•模型层：IModel 接口，负责数据的定义以及数据的增删改查方法的的提供。

•工具层：IUtility 接口，负责提供基础设施，比如存储方法、序列化方法、网络链接方法、蓝牙方法、SDK、框架集成等。

### 二、使用规则：

•IController 更改 ISystem、IModel 的状态必须用 Command。

•ISystem、IModel 状态发生变更后通知 IController 必须用事件 或 BindableProeprty。

•IController 可以获取 ISystem、IModel 对象来进行数据查询。

•ICommand 不能有状态。

•上层可以直接获取下层对象，下层不能获取上层对象。

•下层像上层通信用事件。

•上层向下层通信用方法调用，IController 的交互逻辑为特使情况，只能用 Command。

### 三、分层功能的补充说明

#### 1、表现层：

•可以获取 System

•可以获取 Model

•可以发送 Command

•可以监听 Event

•可以发送 Query

#### 2、系统层：

•可以获取 System

•可以获取 Model

•可以监听、发送 Event

•可以获取 Utility

•可以发送 Query

#### 3、数据层：

•可以获取 Utility

•可以发送 Event

•可以发送 Query

#### 4、工具层：

•啥都干不了，可以集成第三方库，或者封装 API。

除了四个层级，还有一个核心概念就是 Command, Query。

#### 5、Command：

•可以获取 System

•可以获取 Model

•可以发送 Event

•可以获取 Utility

•可以发送 Command

#### 6、Query

•可以获取 System

•可以获取 Model

•可以发送 Event

•可以获取 Utility

•可以发送 Command

