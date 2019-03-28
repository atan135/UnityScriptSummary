# UnityScriptSummary
Summary the unity script usaged

所有测试均为2018.3版本测试

## UnityEngine

* [Camera](#Camera)
* [Debug](#Debug)
* [Hash128](#Hash128)
* [Input](#Input)
* [Ping](#Ping)
* [Texture2D](#Texture2D)
* [Time](#Time)



































































### Camera

静态属性：

```ini
allCameras = 返回当前场景中所有enabled camera
allCamerasCount = 返回allCameras的数量
current = 当前正在渲染的摄像机，一般用不上。
main = 第一个enabled名字为"Main Camera"的摄像机
onPostRender = 任意一个摄像机完成渲染的事件
onPreCull = 任意一个摄像机开始culling的事件
onPreRender = 任意一个摄像机开始渲染的事件
```




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



### Texture2D

用来处理texture纹理，

`blackTexture` 和 `whiteTexture`

是Texture2D的静态属性，生成一个纯白/纯黑的texture资源

`format` 和 `isReadable`

两个重要的属性，format是texture的格式，只读不可修改，isReadable在资源导入的时候可以设置，代码生成的必然为True，在调用Texture2D的大部分方法时，需要这个属性为true。

```c#
// 构造方法, 后面三个参数选填
public Texture2D(int width, int height, TextureFormat format, bool mipChain, bool linear);
```

`GetPixel` `GetPixelBilinear` `GetPixels` `GetPixels32` `GetRawTextureData`

```c#
// 获取单个点的Color值
public Color GetPixel(int x, int y);
// 获取单个点（适配UV的）的Color值
public Color GetPixelBilinear(int x, int y);
// 获取整个texture的Color值，获取某块区域的Color值
public Color[] GetPixels(int miplevel);
public Color[] GetPixels(int x, int y, int blockWidth, int blockHeight, int miplevel);
// 获取Color32格式的返回值
public Color32[] GetPixels32(int miplevel);
// 获取rawdata的返回值
public NativeArray<T> GetRawTextureData();
```

`SetPixel` `SetPixels` `SetPixels32`

```c#
// 设置单点的值
public void SetPixel(int x, int y, Color color);
// 设置整个texture或者区域的Color值, SetPixels32用法相同
public void SetPixels(Color[] colors, int miplevel);
public void SetPixels(int x, int y, int blockWidth, int blockHeight, Color[] colors, int miplevel);

```

`Apply`

使所有Set操作生效，一般情况下，在所有Set完成后再调用Apply，因为这个操作代价很大，尽量少调用。

```c#
public void Apply(bool updateMipmaps = true, bool makeNoLongerReadable = false);
// 参数updateMipMaps是否更新mipmaps， makeNoLongerReadable如果为true，apply之后texture的系统内存拷贝会释放。
```

`Compress`

压缩texture使用

`LoadRawTextureData`

使用rawdata填充texture，填充数据量必须和texture的宽、高、格式、mipmapcout相匹配，否则会报错。

```c#
public void LoadRawTextureData(byte[] data);
public void LoadRawTextureData(NativeArray<T> data);
public void LoadRawTextureData(IntPtr data, int size);
```

`ReadPixels`

用于读取屏幕一片区域的pixel到texture中，可以用于截屏处理，一般要求texture格式为rgba32，argb32或者rgb24

```c#
public void ReadPixels(Rect source, int destX, int destY, bool recalculateMipMaps);
```

`Resize`

重新调整texture的大小，和构造方式类似。

`PackTextures`

打包多个texture生成一个atlas。

```c#
// 特别需要注意的是，padding不能用1，会报错。网上别人也有提到，直接程序崩溃。应该是有bug
public Rect[] PackTextures(Texture2D[] textures, int padding, int maxAtlasSize, bool makeNoLongerReadable);
```



### Time

<s>搞不了，Time.time一直是错的，和真实时间不一致，不晓得怎么回事</s>

出错原因是设置了captureFramerate，通过Time.captureFramerate = 0，可以归位。否则游戏时间相当于captureFramerate / 真实游戏帧率

```ini
Time.captureFramerate=设置游戏帧率，不考虑真实时间
Time.deltaTime=完成最后一帧所使用的时间
Time.fixedDeltaTime=FixedUpdate的刷新帧率，物理系统或者其他的。
Time.fixedTime=游戏开始至今的时间，截止至最后一个FixedUpdate调用。
Time.fixedUnscaledDeltaTime=timescale-independent的最后一帧使用的时间
Time.time=游戏开始至今所使用的时间
Time.unscaledTime=游戏开始至今的真实时间
Time.readtimeSinceStartup=游戏开始至今的真实时间，即使暂停也会增加
Time.frameCount=真实总帧数
Time.maximumDeltaTime=每帧最大时长，物理系统和其他fixedupdate的行为只会在这个时间段执行
Time.maximumParticleDeltaTime=粒子系统更新的最大每帧时长，如果超过这个值了，update会拆分为多帧执行
Time.smoothDeltaTime=加权平滑的deltaTime
```

