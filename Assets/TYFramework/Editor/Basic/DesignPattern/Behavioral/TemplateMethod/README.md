# 模板方法模式

## 定义

模板方法模式**在一个方法中定义一个算法的骨架，而将一些步骤的实现延迟到子类中**。

模板方法**使得子类可以在不改变算法结构的情况下，重新定义算法中某些步骤的具体实现**

模板方法模式却是一个例外，**你要关注的就是一个方法而已**

确实非常简单，**仅仅使用继承机制**，但是它是一个应用非常广泛的模式

## 应用场景

当系统中算法的**骨架是固定的时候，而算法的实现可能有很多种的时候**，就需要使用模板方法模式。

- 多个子类有共有的方法，并且逻辑基本相同
- 重要、复杂的算法，可以把核心算法设计为模板方法，周边的相关细节功能则由各个子类实现
- 重构时，模板方法是一个经常使用的方法，**把相同的代码抽取到父类中，然后通过构造函数约束其行为**。

### 举例

需要做一个报表打印程序，用户规定需要表头，正文，表尾。

但是客户的需求会变化，一会希望这样显示表头，一会希望那样显示。

这时候采用模板方式就合适。

## 优缺点

### 优点

- 封装不变部分，扩展可变部分。
    
    把认为不变部分的算法封装到父类中实现，而可变部分的则可以通过继承来继续扩展。
    
- 提取公共部分代码，便于维护。
- 行为由父类控制，子类实现

### 缺点

- 算法骨架需要改变时需要修改抽象类。
- 按照设计习惯，抽象类负责声明最抽象、最一般的事物属性和方法，实现类负责完成具体的事务属性和方法，但是模板方式正好相反，子类执行的结果影响了父类的结果，会**增加代码阅读的难度**。

## 基本实现

```csharp
abstract class AbstractClass
{
    //一些抽象行为放到子类去实现
    public abstract void PrivateOperation1();
    public abstract void PrivateOperation2():
    
    //模板方法，给出了逻辑的骨架，而逻辑的组成是一些相应的抽象操作，它们都推迟到子类实现
    public void Templatelethod()
    {
        PrivateOperation1();
        PrivateOperation2();
        Console.Writeline("");
    }
}
```

## 总结

- 重复=易错+难改
- 模板方法模式是
    1. **通过父类建立框架**
    2. **子类在重写了父类部分方法之后**
    3. 再**调用从父类继承的方法**
    4. **产生不同的效果**
    5. **通过修改子类，影响父类行为的结果**
- 模板方法在一些开源框架中应用非常多，它提供了一个抽象类，然后开源框架写了一堆子类，如果需要扩展功能，可以继承此抽象类，然后覆写protected基本方法，然后在调用一个类似TemplateMethod()的模板方法，完成扩展开发