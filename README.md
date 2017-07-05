# 介绍

![Expire app](https://user-images.githubusercontent.com/132692/27844427-46b9255a-6154-11e7-8997-837f431e45fb.jpeg)

我们认为，每个东西随着日常使用都会产生损耗，直到最终不能工作为止。我们希望在添置新的东西时给它预估使用期限，并监控和管理它的日常损耗，在它不能工作之前及时提醒我们寻找新的替代。如果这些东西在有效期到来之时状态依然良好，我们可以考虑延长服役时间，但不要让它们过分超期服役，以免带来额外的非预期的成本。

# 功能

Expire仍处于Preview阶段，目前仅供学习和研究。以下是已经实现的功能：

1. 添加已经购买的物品
2. 设置物品的购买日期，默认为今天
3. 设置物品的到期日期，默认为一年之后
4. 设置物品的购买价格，自动计算每日折旧价值以及总折旧率

# 构建

若想从代码构建Expire，你需要安装Visual Studio for Mac或Visual Studio 2017和Xamarin开发包。若想研究Expire的代码，你需要了解以下知识和技术：

- [XAML](https://developer.xamarin.com/guides/xamarin-forms/xaml/)
- [C# 6.0](https://developer.xamarin.com/guides/cross-platform/advanced/csharp_six/)
- MVVM模式
- [Realm数据库](https://realm.io/docs/xamarin/latest/)
