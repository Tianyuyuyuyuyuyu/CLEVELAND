# 访问者模式

## 定义

GoF：“定义一个能够在一个对象结构中对于所有元素执行的操作。

访问者让你可以定义一个新的操作，而不必更改到被操作元素的类接口”

简单来说，访问者是一个考虑了所有“被访问者”可能会需要的接口（功能），被访问者需要放入访问者的它所需的接口中进行处理

### 对定义这么理解

有这么一个操作，它是作用于一些元素之上的，而这些元素属于某一个对象结构。

同时这个操作是**在不改变各元素类的前提下，在这个前提下定义新操作是访问者模式精髓中的精髓**

## 本质

- **预留通路，回调实现**。
- 它的实现主要就是通过预先定义好调用的通路，在被访问的对象上定义accept方法，在访问者的对象上定义visit方法；
- 然后在调用真正发生的时候，通过两次分发的技术，利用预先定义好的通路，回调到访问者具体的实现上

## 使用场景

- 对象结构比较稳定，但经常需要在此对象结构上定义新的操作。
- 需要对一个对象结构中的对象进行很多不同的且不相关的操作，而需要避免这些操作“污染”这些对象的类，也不希望在增加新操作时修改这些类。

## 优点

- 增加操作很容易，因为增加操作意味着增加新的访问者。
- 访问者模式将有关行为集中到一个访问者对象中，其改变不影响系统数据结构

## 缺点

- 增加新的数据结构很困难
- 增加新的 ConcreteElement类很困难
    - 每添加一个新的 ConcreteElement都要在 Vistor中添加一个新的抽象操作，并在每一个 ConcretVisitor类中实现相应的操作。
    - 在应用访问者模式时考虑关键的问题是系统的哪个部分会经常变化,是作用于对象结构上的算法呢还是构成该结构的各个对象的类。如果老是有新的 ConcretElement类加入进来的话, Vistor类层次将变得难以维护。
- 破坏封装
    
    访问者方法假定ConcreteElement接口的功能足够强，足以让访问者进行它们的工作。
    
    结果是：该模式常常迫使你提供访问元素内部状态的公共操作，这可能会破坏它的封装性
    

## 实际问题如下：

假设有Enemy敌人类 和 Solider士兵类 它们均继承于Character基类。

现在需求是统计每一个敌人的防御力求平均值 和 统计每一个士兵的攻击力求平均值 至于求出的数据放哪可以先不管。

一般做法是在士兵类Solider 和 敌人类Enemy中 分别写一个方法来进行处理对应的问题，这样就会改动了2个原有类，**违背了开闭原则**，而且可能还会提高耦合度。

假设又有一个类似的需求出现，那还需要再继续增加原有类接口进行处理！

最终原有类会越来越庞大变得难以维护，用访问者模式就可以避免这种情况，对照这个需求创建一个访问者类VistorA

VisitSolider(List<Solider> soliderList){  ...   }

VisitEnemy(List<Enemy> enemyList){  ...  }

调用时： VistorA  va = new VistorA();

va.VisitSolider( GetSoliderList() );//GetSoliderList()获取所有士兵

va.VisitEnemy( GetEnemyList() );//GetEnemyList()获取所有敌人

假设又有一个类似的需求，需要访问原有类Enemy或Solider ，而且也同样是访问所有士兵和敌人，此时你就可以再创一个VistorB来处理这个需求，而VistorA和VistorB是十分类似的，

为此我们可以写一个接口Vistor来进行抽象化，每一个需求VistorX访问者都要继承于Vistor，**让实现和调用分离开来，从而降低耦合（这就是面向接口编程思想）**