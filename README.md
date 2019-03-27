# UnityScriptSummary
Summary the unity script usaged

所有测试均为2018.3版本测试

## UnityEngine

* [Debug](#Debug)

* [Hash128](#Hash128)

* [Input](#Input)

* [Ping](#Ping)






































































### Debug

`Debug.developerConsoleVisible` 

文档说明是用于控制development console的可见性的，但是通过测试，这个值不能被修改，测试代码如下

```c#
// 修改这个值没有效果，仍然为false
Debug.Log("set developerConsoleVisible true");
Debug.developerConsoleVisible = true;
Debug.Log(Debug.developerConsoleVisible);	// 输出false
```

`Debug.isDebugBuild`

用于判定是否为Debug build版本，在editor中该值为true。在打包的时候，**Development Build** 勾选，则也为true。

`Debug.unityLogger` 

获得unity默认的logger，打log时候可以携带tag，例如

`Debug.unityLogger.Log("Tag", "balabala")`

输出为：Tag: balabala

`Debug.Assert` 和 `Debug.AssertFormat`

断言，如果为false，则logerror出错误信息，需要宏UNITY_ASSERTIONS 有定义，如果想在编译的dll中也使用，需要预先定义。

`Debug.break`

用于中断程序进行。

`Debug.ClearDeveloperConsole`

用于清空控制台error日志，但是没效果，unity 论坛给了个实际有效的方法

```c#
using UnityEditor;
using System.Reflection;
			var assembly = Assembly.GetAssembly(typeof(SceneView));
            var type = assembly.GetType("UnityEditor.LogEntries");
            var method = type.GetMethod("Clear");
            method.Invoke(new object(), null);
```

`Debug.DrawLine` 和 `Debug.DrawRay` 

在gameview下绘制，但是只有在debugging mode下有效，<font color="red">没有实现出来</font>

`Debug.Log`

```c#
// 通用的输出日志方式
Debug.Log(object message);
// 后面的为位于Hierarchy的对象，这样当点击这个日志的时候，会高亮显示这个对象
Debug.Log(object message, Object content);
```

`Debug.LogAssertion`

类似`Debug.Assert`

`Debug.Log`

`Debug.LogFormat`

`Debug.LogError`

`Debug.LogErrorFormat`

`Debug.LogWarning`

`Debug.LogWarningFormat`

这6个用法基本一样，有两种形式

```c#
// 1. 普通调用
Debug.Log(object message);
// 2. 带对象调用
Debug.Log(object message, Object content);
// 3. format普通调用
Debug.LogFormat(string format, params object[] args);
// 4. format带对象调用
Debug.LogFormat(Object content, string format, params object[] args);
```



### Hash128

用于计算哈希值的，两个静态方法，`Hash128.Compute` 和 `Hash128.Parse`

还有个初始构造方法，没看出来用途。感觉就是计算哈希值的用途，如下

```c#
var hs = Hash128.Compute(str);
string hashStr = hs.ToString();
```



### Input





### Ping

用于ping一个ip，仅限ip，url无效，开个协程算这个可能好点。

```c#
Ping ping = new Ping(ip);
while(!ping.isDone);
Log.LogInfo("Ping ip {0} isDone {1} time {2}", ping.ip, ping.isDone, ping.time);
```

