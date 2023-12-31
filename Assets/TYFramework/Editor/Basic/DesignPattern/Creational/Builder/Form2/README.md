# 建造者模式【形式2】

经常碰见的 XxxBuilder 的类，通常都是建造者模式的产物。

建造者模式其实**有很多的变种**，但是对于客户端来说，我们的使用通常都是一个模式的：

```csharp
Food food = new FoodBuilder().a().b().c().build();
Food food = Food.builder().a().b().c().build();
```

### 套路

就是先 new 一个 Builder，然后可以链式地调用一堆方法，

最后再调用一次 build() 方法，我们需要的对象就有了。

### 核心

先把所有的属性都设置给 Builder，然后 build() 方法的时候，将这些属性**赋值**给实际产生的对象。

## 优缺点

说实话，建造者模式的**链式写法**很吸引人，但是，多写了很多“无用”的 builder 的代码，感觉这个模式没什么用。不过，当属性很多，而且有些必填，有些选填的时候，这个模式会使代码清晰很多。

我们可以在 **Builder 的构造方法** 中强制让调用者提供必填字段，还有在 build() 方法中校验各个参数比在 User 的构造方法中校验，代码要优雅一些。