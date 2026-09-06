## 🗺️ minimap
- [server](https://github.com/TajCummings/PhiladelphiaFishEye/tree/main/DollyTacoTracker/DollyTacoTracker.Server) in ASP.NET
- [client](https://github.com/TajCummings/PhiladelphiaFishEye/tree/main/DollyTacoTracker/dollytacotracker.client) in React
  - [SPECS.md](https://github.com/TajCummings/PhiladelphiaFishEye/blob/main/DollyTacoTracker/dollytacotracker.client/SPECS.md) for the ui plan

## 🌮 setup for DollyTacoTracker

Prerequisites:
- [.NET](https://dotnet.microsoft.com/en-us/download)
- [Node.js](https://nodejs.org/en/download)
  - or [nvm](https://github.com/nvm-sh/nvm), a version manager for node.js

### server

1. cd into the `.Server` folder
1. Trust the certificates: `dotnet dev-certs https --trust` (watch the output in the terminal for an option to opt out of the telemetry)
1. `dotnet watch run` to build the server (hot-reload)

### client

1. cd into the `.client` folder
1. Install the packages with `npm i`
1. `npm run dev` to start the vite server (also hot-reload)
