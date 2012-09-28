blazey.registry
===
Why?
===
Applying some recommended practices such as favour polymorphism over conditions can sometimes sounds pithy but how might one actually practices this? Blazey.registry extends Castle Windsor to automatically apply the specification with a predicate parameter if you inject all candidates like so:

```c#

public class CarQuery
{
    private readonly Registrar<ICar> _carRegistry;

    public CarQuery(Registrar<ICar> carRegistry)
    {
        _carRegistry = carRegistry;
    }

    public ICar GetRedCar()
    {
        return _carRegistry.Get(Color.Red);
    }
}
```
What is this doing?
===
It is a custom sub resolver that injects all instances of a service returning the first match for the predicate parameter. It uses reflection to identify a member in your interface that matches a whitelist of predicate names by order: 
issatisfiedby, satisfied, cansatisfy, satisfy, ismatch, match

How do I use it?
===
Add the registrar sub resolver:
```c#
container.Kernel.Resolver.AddSubResolver(new RegistrarResolver(container.Kernel));
```
Register dependencies and services as normal:
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