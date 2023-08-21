# 策略模式

## 定义

- 策略模式**定义了一系列算法，并将每个算法封装起来，使他们可以相互替换，且算法的变化不会影响到使用算法的客户**。
- 需要设计一个接口，为一系列实现类提供统一的方法，多个实现类实现该接口，设计一个抽象类（可有可无，属于辅助类），提供辅助函数。

策略模式定义和封装了一系列的算法，它们是可以相互替换的，也就是说它们具有共性，而它们的共性就体现在策略接口的行为上，另外为了达到最后一句话的目的，也就是说让算法独立于使用它的客户而独立变化，我们需要让客户端依赖于策略接口。

### 一种很简单的解释

**在我们的开发过程中，经常会遇到大量的if...else或者switch...case语句，当这些语句在开发中只是为了起到分流作用，这些分流和业务逻辑无关，那么这个时候就可以考虑用策略模式**。

### 这个模式涉及到三个角色：

- 上下文环境(Context)角色：持有一个Strategy的引用。
- 抽象策略(Strategy)角色：这是一个抽象角色，通常由一个接口或抽象类实现。

此角色给出所有的具体策略类所需的接口。

- 具体策略(ConcreteStrategy)角色：包装了相关的算法或行为

## 应用场景

1. 多个类只区别在表现行为不同，可以使用Strategy模式，在运行时动态选择具体要执行的行为。
2. 需要在不同情况下使用不同的策略(算法)，或者策略还可能在未来用其它方式来实现。
3. 对客户隐藏具体策略(算法)的实现细节，彼此完全独立。

### 举一个例子

商场搞促销--打8折，满200送50，满1000送礼物，这种促销就是策略。

再举一个例子，dota里面的战术，玩命四保一，三伪核体系，推进体系，大招流体系等，这些战术都是一种策略。

## 优缺点

### 优点

- 结构清晰，把策略分离成一个个单独的类「**替换了传统的 if else**」
- 代码耦合度降低，安全性提高「**各个策略的细节被屏蔽**」

### 缺点

- 客户端必须要知道所有的策略类，否则你不知道该使用那个策略
  
    所以策略模式**适用于提前知道所有策略的情况下**
    
- 策略类数量增多（每一个策略类复用性很小，如果需要增加算法，就只能新增类）

## 实现

### Strategy类，定义所有支持的算法的公共接口

```csharp
//Strategy类，定义所有支持算法的公共接口
abstract class Strategy
{
		//算法方法
    public abstract void AlgorithmInterface();
}
```

### ConcreteStrategy，封装了具体的算法或行为，继承于Strategy

```csharp
class ConcreteStrategyA : Strategy
{
    public override void AlgorithmInterface()
    {
        Console.Writeline("算法A的实现");
    }
}

class ConcreteStrategyB : Strategy
{
    public override void AlgorithmInterface()
    {
        Console.Writeline("算法B的实现");
    }
}
```



### Context，用一个ConcreteStrategy来配置，维护一个对Strategy对象的引用

```csharp
class Context
{
    private Strategy Strategy;
    public Context(Strategy strategy)
    {
        this.Strategy = strategy;
    }
    
    //上下文接口
    public ContextInterface()
    {
        Strategy.AlgorithmInterface();
    }
}
```

### 客户端代码

```csharp
static void Main(string[] args)
{
    Context Context;
    Context = new Context(new ConcretestrategyA());
    Context.ContextInterface();
    
    Context = new Context(new Concretestrategyb());
    Context.ContextInterface();
    
    Context = new Context (new Concretestrategyc());
    Context.ContextInterface();

    Console.Read();
}
```