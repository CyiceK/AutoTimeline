# AutoTimeline

代码基于GPLv3开源，仅供交流winapi如ReadProcessMemory的使用方法，禁止用于其他用途以及任何形式的商业用途，否则后果自负。

[lua分享站](http://pcr.youtobechina.com/)  

仅适配x64模拟器 x32的app

(什么?你不想写代码就想用?请打开auto)

## 用法

### 编写timeline.lua

AutoPcrApi:

- `void autopcr.calibrate(id)` 对站位id进行校准（可以为字符串或者数字）
- `void autopcr.press(id)` 点击站位为id的角色，不占用时间，但可能点不上
- `void autopcr.framePress(id)` 点击站位为id的角色，保证点上，占用两帧，一般用于连点

- `long autopcr.getUnitAddr(unit_id, rarity, rank)` 根据数据获取角色的句柄，请务必保证搜索时该角色tp为0且满血，否则会搜索失败
- `long autopcr.getBossAddr(unit_id)` 获取公会战boss的id
- `float autopcr.getTp(unit_handle)` 根据获得的句柄返回角色当前tp
- `long autopcr.getHp(unit_handle)` 根据获得的句柄返回角色当前hp
- `long autopcr.getMaxHp(unit_handle)` 根据获得的句柄返回角色最大hp
- `int autopcr.getPhysicalCritical(unit_handle)` 根据获得的句柄返回角色物理暴击
- `int autopcr.getMagicCritical(unit_handle)` 根据获得的句柄返回角色法术暴击
- `int autopcr.getDef(unit_handle)` 根据获得的句柄返回角色物理防御
- `int autopcr.getMagicDef(unit_handle)` 根据获得的句柄返回角色法术防御
- `int autopcr.getLevel(unit_handle)` 根据获得的句柄返回角色等级
- `int autopcr.getFrame()` 返回当前帧数
- `float autopcr.getTime()` 返回当前时间
- `void autopcr.waitFrame(frame)` 暂停程序直到帧数达到
- `void autopcr.waitTime(frame)` 暂停程序直到时间达到
- `void autopcr.setOffset(frame_offset, time_offset)` 设定延迟校准参数
- `float autopcr.getCrit(unit_handle, target_handle, isMagic)` 获取对某个target攻击的暴击率
- `uint[] autopcr.predRandom(count)` 获取下count个随机数的值

- `float autopcr.nextCrit()` 获取用于下一次攻击判定的随机数，如果小于critrate则暴击
- `float[] autopcr.nextNCrit(count)` 返回下n次攻击判定的随机数，如果小于critrate则暴击（如果ub带随机效果则可能结果不正确，如病娇）
- `float[] autopcr.nextCrits(critlist)` 返回下几个攻击判定的随机数，用来对抗带随即效果的ub，比如病娇ub的critlist填{4,6,12}，更多多段顺序见critlist.md，如果小于critrate则暴击

- `void autopcr.waitTillCrit(unit_handle, target_handle, isMagic, frameMax)` 等待至多到frameMax, 直到unit下一段伤害必定暴击
- `void autopcr.waitTillNCrit(unit_handle, target_handle, isMagic, frameMax, m, n)` 等待直到下次n段伤害有m个暴击（如果ub带随机效果则可能结果不正确，如病娇）
- `void autopcr.waitTillCrits(unit_handle, target_handle, isMagic, frameMax, m, critlist)` 等待直到下几个攻击判定有m个暴击
- `string autopcr.getActionState(unit_handle)` 获取单位当前状态，取值如下：IDLE, ATK, SKILL_1, SKILL, WALK, DAMAGE, SUMMON, DIE, GAME_START, LOSE

MiniTouchApi:

- `void minitouch.getMaxX()` 返回最大X
- `void minitouch.getMaxY()` 返回最大Y
- `void minitouch.connect(host, port)` 链接minitouch server
- `void minitouch.write(text)` 写minitouch指令
- `void minitouch.setPos(id, x, y)` 注册站位id（可以为字符串或者数字）
- `void minitouch.press(id)` 点击站位为id的角色，不占用时间，但可能点不上
- `void minitouch.framePress(id)` 点击站位为id的角色，保证点上，占用两帧，一般用于连点

InputApi:

- `void input.keyPressed(key)` 返回键盘是否被按下

MonitorApi: (experimental)

- `void monitor.add(unit_handle)` 把单位加入检测列表中，必须在start前调用
- `void monitor.start()` 开始检测，必须在除了add意外所有函数前调用
- `void monitor.waitAction(unit_handle, action_id)` 等待unit执行完毕action_id
- `int monitor.getSkillId(unit_handle)` 获取当前角色的技能id，普攻为1
- `string monitor.getActionState(unit_handle)` 同autopcr同名函数，但是速度更快

### 依赖

项目依赖于`.net 5.0 runtime`，请自行百度

### 延迟校准

校准代表着模拟器处理造成的延迟，一般会保持不变，技能释放时，如果打开技能动画，帧数会暂停，你可以根据暂停时候的值和预期值做出帧数的校准

### 运行程序

1. 必须使用管理员模式运行，设置帧率为60，先进入对战，然后在开始时暂停
3. 输入模拟器主程序的PID(不要输错成前台ui程序)
4. 等待扫描，结束后会显示当前帧数和剩余时间
5. 继续模拟器运行脚本，脚本中进行站位校准和自动打轴
6. 继续运行后不要乱动鼠标！！！

### 关于Minitouch

Minitouch可以显著减小模拟器层触控延迟，repo内附带bin版minitouch，[使用说明](https://github.com/DeviceFarmer/minitouch)  
如果有的菜鸡弄不明白怎么用，也可以使用传统方法。  
如果adb在path中可以用minitouch文件夹下的两个bat直接把minitouch开到1111端口(先运行adbshell再运行adbforwarding, adbshell不要关)
