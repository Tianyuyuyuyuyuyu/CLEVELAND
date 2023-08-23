# 解释器模式

## 定义

给定一个语言，定义一个文法的一种表示， 并定义一个解释器，

这个解释器使用该表示来解释语言中的句子

## 使用场景

1. 当有一个语言需要解释执行，并且你可将该语言中的句子表示为一个抽象语法树，可以使用解释器模式。而当存在以下情况时该模式效果最好
2. 该**文法的类层次结构变得庞大而无法管理**。
    
    此时语法分析程序生成器这样的工具是最好的选择。
    
    他们无需构建抽象语法树即可解释表达式，这样可以节省空间而且还可能节省时间。
    
3. **效率不是一个关键问题**，最高效的解释器通常不是通过直接解释语法分析树实现的，而是首先将他们装换成另一种形式
    
    例如，正则表达式通常被装换成状态机，即使在这种情况下，转换器仍可用解释器模式实现，该模式仍是有用的
    

## 优缺点

### 优点

1. 可以很容易地改变和扩展方法， 因为该模式使用类来表示方法规则， 你可以使用继承来改变或扩展该方法。
2. 也比较容易实现方法， 因为定义抽象语法树总各个节点的类的实现大体类似， 这些类都易于直接编写。
3. 解释器模式就是**将一句话，转变为实际的命令程序执行**而已。 而不用解释器模式本身也可以分析， 但通过继承抽象表达式的方式， 由于依赖转置原则， 使得文法的扩展和维护都带来的方便。

### 缺点

- 解释器模式为方法中的每一条规则至少定义了一个类， 因此包含许多规则的方法可能难以管理和维护。 因此当方法非常复杂时， 使用其他的技术如 语法分析程序 或 编译器生成器来处理。