# AGENTS.md

DotNet-Native is the multi-client DotNet foundation. The API is DotNet and follows [CONTRACT.md](../../../CONTRACT.md). The only installable client today is the Svelte web client.

`__ctrl__/clients.json` is the single client registry. `web use` installs an enabled client into `frontend/web`. `android` and `windows` are reserved. Do not add a second registry, and do not invent WinUI or Compose apps until a client is enabled.

Do not reshape the API as FastAPI, Hono, Elysia, or Go. Backend layout: `backend/src/modules/{apps,base,system}`, `backend/src/core`, and `backend/worker`. Layers: Router (minimal API group) → Service → Repository (interface, EF Core) → PostgreSQL. Migrations are plain SQL in `backend/migrations`. Run `__ctrl__\dotnet-native-ctrl.bat test backend` before calling a stage done.
