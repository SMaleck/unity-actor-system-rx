# **Actor System**
The Actor System is based on some ECS-like concepts without being a n actual ECS.

You can see a reference implementation in [Wizard Tower](https://github.com/SMaleck/wizard-tower/tree/master/Assets/Source/Features/Actors).

## Actors & Components
The basic concept is that an `Actor` does not hold any concrete state and is merely a container to hold and manage `ActorComponents`.

Those `ActorComponents` are very small and hold very focused state for one concern. 
For example a `TransformComponent` to expose the GameObject transform and position, 
or a `MovementComponent` to hold state regarding speed and locomotion intention.

Since an actor will typically accumulate many small concerns as the project becomes more complex, 
using a monolithic `ActorModel` quickly becomes unwieldy. 
Using a component based approach enables us to have a clear separation and encapsulation of state per concern, 
while keeping that state neatly organized within a single `Actor`.

Ideally components do not do any significant work and are rather updated by **Systems** (see below).

## Systems
`Systems` can be attached to an `Actor` and operate on its `ActorComponents`. 
Basically they are updating component state from the outside or tying it up across components. 

For example a `MovementSystem` could take locomotion intentions from a `MovementComponent` and update the `TransformComponent`'s position with it.