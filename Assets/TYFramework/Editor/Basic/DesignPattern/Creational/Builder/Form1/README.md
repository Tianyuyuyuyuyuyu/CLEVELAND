# 建造者模式【形式1】

# 定义

将一个**复杂对象的构建与它的表示分离**，使得同样的构建过程可以创建不同的表示（依赖倒转）

- 产品类：一般是一个较为复杂的对象，也就是说创建对象的**过程比较复杂**，一般会有比较多的代码量。在本类图中，产品类是一个具体的类，而非抽象类。
  
    实际编程中，产品类可以是由一个抽象类与它的不同实现组成，也可以是由多个抽象类与他们的实现组成。
    
- 抽象建造者：引入抽象建造者的目的，是**为了将建造的具体过程交与它的子类来实现**。这样更容易扩展。一般至少会有两个抽象方法，一个用来建造产品，一个是用来返回产品。
- 建造者：实现抽象类的所有未实现的方法，具体来说一般是两项任务：组建产品；返回组建好的产品。
- 指挥类：负责调用适当的建造者来组建产品，指挥类一般不与产品类发生依赖关系，与指挥类直接交互的是建造者类。一般来说，指挥类被用来封装程序中易变的部分。

# 应用场景

1. 创建复杂对象的算法独立于组成对象的部件
2. 同一个创建过程需要有不同的内部表象的产品对象
   
    例子：建房子，不管建什么房子，它们都离不开地基、柱子、层面和墙体这些组成部分，建筑工人就是把这些组成部分一个个建起来，最后连成一体建出一栋栋楼房。
    

# 优缺点

## 优点

1. 客户端不必知道产品内部组成的细节，将产品本身与产品的创建过程解耦，使得**相同的创建过程可以创建不同的产品对象**。
2. 每一个具体建造者都独立，因此可以方便地替换具体建造者或增加新的具体建造者， 用户使用不同的具体建造者即可得到不同的产品对象 。
3. 可以更加精细地控制产品的创建过程 。将复杂产品的创建步骤分解在不同的方法中，使得创建过程更加清晰，也更方便使用程序来控制创建过程。
4. 增加新的具体建造者无须修改原有类库的代码，指挥者类针对抽象建造者类编程，系统扩展方便，符合“开闭”。

## 缺点

1. 当建造者过多时，会产生很多类，难以维护。
2. 建造者模式所创建的产品一般具有较多的共同点，其组成部分相似，若产品之间的差异性很大，则不适合使用该模式，因此其使用范围受到一定限制。
3. 若产品的内部变化复杂，可能会导致需要定义很多具体建造者类来实现这种变化，导致系统变得很庞大。

# 工厂模式和建造者模式的对比

工厂模式用于处理 **如何获取实例对象** 问题，建造者模式用于**处理如何建造实例对象** 问题

建造者模式与工厂模式是极为相似的，总体上，建造者模式仅仅只比工厂模式多了一个“指挥类”的角色。在建造者模式的类图中，假如把这个指挥类看做是最终调用的客户端，那么剩余的部分就可以看作是一个简单的工厂模式了。

与工厂模式相比，**建造者模式一般用来创建更为复杂的对象**，因为对象的创建过程更为复杂，因此将对象的创建过程独立出来组成一个新的类——指挥类。

也就是说，工厂模式是将对象的全部创建过程封装在工厂类中，由工厂类向客户端提供最终的产品；

而建造者模式中，建造者类一般只提供产品类中各个组件的建造，而将具体建造过程交付给指挥类。由指挥类负责将各个组件按照特定的规则组建为产品，然后将组建好的产品交付给客户端。

# 实现

Product类---产品类，由多个部件组成

```csharp
public class Product
{
    //Product类，由多个部件组成
    private List<string> parts = new List<string>();
    
    //添加产品部件
    public void Add(string part)
    {
        parts.Add(part);
    }

    public void Show()
    {
        Debug.LogError("\n创建产品");
        foreach (var part in parts)
        {
            Debug.LogError(part);
        }
    }
}
```

Builder类---抽象建造者类，确定产品由两个部件PartA和PartB组成

并声明一个得到产品建造后结果的方法GetResult

```csharp
abstract class Builder
{
    public abstract void BuilderPartA();
    public abstract void BuilderPartB();
    public abstract Product GetResult();
}
```

具体建造者类

```csharp
class ConcreteBuilder1 : Builder
{
    private Product _product = new Product();
    public override void BuilderPartA()
    {
        _product.Add("部件A");
    }

    public override void BuilderPartB()
    {
        _product.Add("部件B");
    }

    public override Product GetResult()
    {
        return _product;
    }
}

class ConcreteBuilder2 : Builder
{
    private Product _product = new Product();
    public override void BuilderPartA()
    {
        _product.Add("部件X");
    }

    public override void BuilderPartB()
    {
        _product.Add("部件Y");
    }

    public override Product GetResult()
    {
        return _product;
    }
}
```

Director类---指挥者类

```csharp
class Director
{
    public void Construct(Builder builder)
    {
        builder.BuilderPartA();
        builder.BuilderPartB();
    }
}
```

客户端代码---客户不需知道具体的建造过程

```csharp
public class Form1Example : MonoBehaviour
{
    void Start()
    {
        var director = new Director();
        var builder1 = new ConcreteBuilder1();
        var builder2 = new ConcreteBuilder2();

        director.Construct(builder1);
        var p1 = builder1.GetResult();
        p1.Show();
        
        director.Construct(builder2);
        var p2 = builder2.GetResult();
        p2.Show();
    }
}
```