# 备忘录模式

## 定义

在不破坏封闭的前提下，捕获一个对象的内部状态，并在该对象之外保存这个状态。

这样以后就可将该对象恢复到原先保存的状态。

该模式**用于保存对象当前状态，并且在之后可以再次恢复到此状态**。

备忘录模式实现的方式需要**保证被保存的对象状态不能被对象从外部访问**

**目的**是为了保护被保存的这些对象状态的完整性以及内部实现不向外暴露

### 涉及角色

1. Originator(发起人)
    
    负责创建一个备忘录Memento，
    
    用以记录当前时刻自身的内部状态，并可使用备忘录恢复内部状态
    
    Originator可以根据需要决定Memento存储自己的哪些内部状态
    
2. Memento(备忘录)
    
    负责存储Originator对象的内部状态，并可以防止Originator以外的其他对象访问备忘录
    
    备忘录有两个接口：
    
    - Caretaker只能看到备忘录的窄接口，他只能将备忘录传递给其他对象。
    - Originator却可看到备忘录的宽接口，允许它访问返回到先前状态所需要的所有数据。
3. Caretaker(管理者)
    
    负责备忘录Memento，不能对Memento的内容进行访问或者操作。
    

## 使用场景

- 需要保存和恢复数据的相关状态场景。
- 提供一个可**回滚**（rollback）的操作。
- 数据库连接的事务管理就是用的备忘录模式。

## 优缺点

### 优点

1. 有时一些发起人对象的内部信息必须保存在发起人对象以外的地方，但是必须要由发起人对象自己读取，这时，使用备忘录模式可以把复杂的发起人内部信息对其他的对象屏蔽起来，从而可以恰当地保持封装的边界。
2. 本模式简化了发起人类。
    
    发起人不再需要管理和保存其内部状态的一个个版本，客户端可以自行管理他们所需要的这些状态的版本。
    
3. 当发起人角色的状态改变的时候，有可能这个状态无效，这时候就可以使用暂时存储起来的备忘录将状态复原。

### 缺点

1. 如果发起人角色的状态需要完整地存储到备忘录对象中，那么在资源消耗上面备忘录对象会很昂贵。
2. 当负责人角色将一个备忘录 存储起来的时候，负责人可能并不知道这个状态会占用多大的存储空间，从而无法提醒用户一个操作是否很昂贵。
3. 当发起人角色的状态改变的时候，有可能这个协议无效。

**如果状态改变的成功率不高的话，不如采取“假如”协议模式**。

## 实现

《备份电话本》

1.联系人--需要备份的数据，是状态数据，没有操作

```csharp
public sealed class ContactPerson
{
    //姓名
    public string Name { get; set; }

    //电话号码
    public string MobileNumber { get; set; }
}
```

2.发起人--相当于【发起人角色】Originator

```csharp
public sealed class MobileBackOriginator
{
    //发起人需要保存的内部状态
    private List<ContactPerson> _personList;

    public List<ContactPerson> ContactPersonList
    {
        get => this._personList;
        set => this._personList = value;
    }

    //初始化需要备份的电话名单
    public MobileBackOriginator(List<ContactPerson> personList)
    {
        if (personList != null)
        {
            this._personList = personList;
            return;
        }
        
        throw new ArgumentNullException("参数不能为空！")
    }

    //创建备忘录对象实例，将当期需要保存的联系人列表保存到备忘录对象中
    public ContactPersonMemento CreateMemento()
    {
        return new ContactPersonMemento(new List<ContactPerson>(this._personList));
    }

    //将备忘录中的数据备份还原到联系人列表中
    public void RestoreMemento(ContactPersonMemento memento)
    {
        this.ContactPersonList = memento.ContactPersonListBack;
    }

    public void Show()
    {
        Console.WriteLine($"联系人列表共有{0}个人，他们是：", ContactPersonList.Count);
        foreach (var p in ContactPersonList)
        {
            Console.WriteLine($"姓名：{0} 号码：{1}", p.Name, p.MobileNumber);
        }
    }
}
```

3.备忘录对象，用于保存状态数据，保存的是当时对象具体状态数据--相当于【备忘录角色】Memeto

```csharp
public sealed class ContactPersonMemento
{
    //保存发起人创建的电话名单数据，就是所谓的状态
    public List<ContactPerson> ContactPersonListBack { get; private set; }

    public ContactPersonMemento(List<ContactPerson> personList)
    {
        ContactPersonListBack = personList;
    }
}
```

4.管理角色，它可以管理【备忘录】对象，如果是保存多个【备忘录】对象，当然可以对保存的对象进行增、删等管理处理---相当于【管理者角色】Caretaker

```csharp
public sealed class MementoManager
{
    //如果想要保存多个【备忘录】对象，可以通过字典或者堆栈来保存，堆栈对象可以反应保存对象的先后顺序
    //比如：public Dictionary<string, ContactPersonMemento> ContactPersonMementoDictionary {get; set;}
    public ContactPersonMemento ContactPersonMemento { get; set; }
}
```

5.客户端代码

```csharp
class Program
{
    static void Main(string[] args)
    {
        List<ContactPerson> persons = new List<ContactPerson>()
        {
            new ContactPerson() {Name = "黄飞鸡", MobileNumber = "13533332222"},
            new Contactperson() {Name = "方世玉", MobileNumber = "13966554433"},
            new Contactperson() {Name = "洪照官", MobileNumber = "13198765544"},
        };
                
        //手机名单发起人
        MobileBackOriginator mobile0riginator = new Mobilebackoriginator(persons);
        mobileOriginator.show();
            
        // 创建备忘录并保存备忘录对急
        MementoManager manager = new MementoManager();
        manager.ContactPersonMemento = mobileOriginator.CreateMemento();
            
        // 更改发起人联系人列表
        Console.WrteLine("----移除最后一个联系人--------");
        mobileOriginator.ContactPersonlist.RemoveAt(2);
        mobileOriginator.Show();
            
        // 恢复到原始状态
        Console.Writeline("-------恢复联系人列表------");
        mobileOriginator.RestoreMemento(manager, ContactpersonMemento);
        mobileOriginator.Show();
        Console.Read():
    }
}
```