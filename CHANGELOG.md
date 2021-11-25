# Changelog

## [0.5.2] - 2021-11-25
[Fixed]
- Components and Systems are now correctly being re-added to the Actors LifeCycle after reset

## [0.5.1] 2021-11-15
[Fixed]
- Adds missing binding for `MonoActor` prefab factory

## [0.5.0] 2021-11-12
[Removed]
- Removes partial views and controllers. MonoComponents naturally take the role of PartialViews and Systems the role of controllers. The partial VC stack was an unnecessary baggage.
- Removes actor registration. The registrar was needed to finish setup of a standalone actor by creating the controllers and tying things together. With the With the partial VC stack gone, this can now be done simply in `StandaloneMonoActor`

[Added]
- `StandaloneMonoActor` to replace `StandaloneActorView` and related classes.

[Changed]
- Above changes simplify standalone creation significantly

## [0.4.0] 2021-11-11
[Changed]
- Renames assembly from `Smaleck.ActorSystem` to `Smaleck.ActorSystemRx`
- Renames root namespace from `ActorSystem` to `ActorSystemRx`

## [0.3.0] 2021-11-08
[Changed]
- Renames repo and package to `actor-system-rx`

## [0.2.0] 2021-10-28
[Removed]
- Removes obsolete code from `ActorLifeCycle`

[Added]
- Adds documentation

## [0.1.0] 2021-10-15
[Added]
- Package creation
