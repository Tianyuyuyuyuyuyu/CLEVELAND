using System;
using UnityEngine;

namespace TYFramework.Editor.Basic.DesignPattern.Creational.Builder.Form2
{
    public class Form2Example : MonoBehaviour
    {
        void Start()
        {
            var d = User.Builder()
                .Name("foo")
                .Password("pAss12345")
                .Age(25)
                .Build();
        }
    }

    public class User {
        // 下面是“一堆”的属性
        private string name;
        private string password;
        private string nickName;
        private int age;

        // 构造方法私有化，不然客户端就会直接调用构造方法了
        public User(string name, string password, string nickName, int age) {
            this.name = name;
            this.password = password;
            this.nickName = nickName;
            this.age = age;
        }
        // 静态方法，用于生成一个 Builder，这个不一定要有，不过写这个方法是一个很好的习惯，
        // 有些代码要求别人写 new User.UserBuilder().a()...build() 看上去就没那么好
        public static UserBuilder Builder() {
            return new UserBuilder();
        }
    }
    
    public class UserBuilder {
        // 下面是和 User 一模一样的一堆属性
        private string  name;
        private string password;
        private string nickName;
        private int age;

        public UserBuilder() {
        }

        // 链式调用设置各个属性值，返回 this，即 UserBuilder
        public UserBuilder Name(string name) {
            this.name = name;
            return this;
        }

        public UserBuilder Password(string password) {
            this.password = password;
            return this;
        }

        public UserBuilder NickName(string nickName) {
            this.nickName = nickName;
            return this;
        }

        public UserBuilder Age(int age) {
            this.age = age;
            return this;
        }

        // build() 方法负责将 UserBuilder 中设置好的属性“复制”到 User 中。
        // 当然，可以在 “复制” 之前做点检验
        public User Build() {
            if (name == null || password == null) {
                throw new NullReferenceException("用户名和密码必填");
            }
            if (age <= 0 || age >= 150) {
                throw new NullReferenceException("年龄不合法");
            }
            // 还可以做赋予”默认值“的功能
            if (nickName == null) {
                nickName = name;
            }
            return new User(name, password, nickName, age);
        }
    }
}