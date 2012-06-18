blazey.windsor
===

Facilitate applying IoC easier with Castle Windsor

Registrar
===

Why?
===
Favouring composition over inheritance and replace conditional with polymorphism are object-orientated programming techniques. This C# Windsor SubResolver is provided to help a programmer achieve these goals with low friction.
The registrar pattern can easily be abused, if perceived as a large bag of global behaviour. However in conjunction with the specification pattern it can be a powerful yet simple mechanism for selecting behaviour at runtime. In conjunction with a container (in this example Castle Windsor) this can be implemented trivially.

Take this simple contract:

```c#
public interface IDependency
{
    void DoSomething();
    bool IsSatisfiedBy(string key);
}
```

An array of the dependency is injected into a service. When the serviceDoSomething() method is invoked, the service iterates through the dependency array elements invoking the specification predicate (IsSatisfied method). The first element to return true invokes the DoSomething method on the selected element.

```c#
public class Service 
{
    private readonly IDependency[] _services;

    public Service(IDependency[] services)
    {
        _services = services;
    }

    public void DoSomething()
    {
        var selected = _services.First(service => service.IsSatisfiedBy("key"));
        
        selected.DoSomething();          
 	}

}
```

To inject arrays in Castle Windsor one adds the ArrayResolver sub resolver like so:
```c#
container.Kernel.Resolver.AddSubResolver(new ArrayResolver(container.Kernel));
```
The dependencies need registering like so:
```c#
container.Register(
    AllTypes.FromThisAssembly().BasedOn<IDependency>().WithServiceAllInterfaces(),
    Component.For<Service>());
```
As you can see this code is somewhat naïve. The code needs to be resilient to side effects such as what if no dependency elements satisfy the predicate? What if one wanted to null coalesce to a default implementation to take advantage of the null object pattern.
```c#
public void DoSomething()
{
    var selected = _services.FirstOrDefault(service => service.IsSatisfiedBy("key")) ?? new NullObjectDependency();
    
    selected.DoSomething();
}

public class NullObjectDependency : IDependency
{
    public void DoSomething() 
    {
        //null object do nothing.
    }

    public bool IsSatisfiedBy(string key)
    {
        return false;
    }
}
```
Blazey.Windsor allows one to take advantage of these patterns trivially.

Usage
==

Add the registrar sub resolver:
```c#
container.Kernel.Resolver.AddSubResolver(new RegistrarResolver(container.Kernel));
```
Register dependencies and service:
```c#
_container.Register(
    AllTypes.FromThisAssembly().BasedOn<IDependency>().WithServiceAllInterfaces(),
    Component.For<Service>());
```
Instead of injecting an array of IDependency inject the Registrar type with the dependency type as an open genric parameter like so:
```c#
public class Service
{
    private readonly Registrar<IDependency> _registrar;

    public Service(Registrar<IDependency> registrar)
    {
        _registrar = registrar;
    }
    .
    .
}
```
The Registrar type has behaviour to assist us in selecting the correct dependency:
```c#
IDependency selectedDependency = registrar.Get<string>(param);
```
This action iterates over all container resolved instances of type IDependency. If an IDependency method contains a method that has one parameter, whose type matches the Registrar::Get<T> open generic parameter and whose method name can be homogenised to match any of this sequence ordered in preference: issatisfiedby, satisfied, cansatisfy, satisfy, ismatch or match.  

