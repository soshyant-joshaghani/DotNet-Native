# Tests

```bat
__ctrl__\dotnet-native-ctrl.bat test all
__ctrl__\dotnet-native-ctrl.bat test backend
__ctrl__\dotnet-native-ctrl.bat test frontend
```

`test backend` runs `dotnet test backend` from the kit root. xUnit tests live in `tests/backend/`. `backend/*.sln` includes that project, so `dotnet test backend` runs them.

`test frontend` runs `svelte-check` inside `frontend/web` when a kit is installed.
