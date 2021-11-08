# Unity Actor System Rx
Provides an ECS-like Actor System for Unity. Based around Reactive Programming using UniRx

## Quick Start
> This package uses the [OpenUPM](https://openupm.com/) scoped registry.

To use this package in your Unity project, you have to manually add it to you `manifest.json`.

1. Go to `YourProject/Packages/`
2. Open `manifest.json`
3. Add the OpenUPM scoped registry
3. Add this packages git repository to the dependencies object in the JSON:

### Example:
```json
{
  "dependencies": {
    "com.smaleck.actor-system-rx": "git://github.com/SMaleck/unity-actor-system-rx.git#v0.3.0"
  }
}
```

### With Scoped Registry Dependencies
```json
{
  "dependencies": {
    "com.smaleck.actor-system-rx": "git://github.com/SMaleck/unity-actor-system.git#v1.0.0"
  },
  "scopedRegistries": [
      {
        "name": "package.openupm.com",
        "url": "https://package.openupm.com",
        "scopes": [
          "com.openupm",
          "com.neuecc.unirx",
          "com.svermeulen.extenject",
        ]
      }
    ]
  }
```

## How To
See the [documentation](./Documentation/ActorSystem.md) for details.