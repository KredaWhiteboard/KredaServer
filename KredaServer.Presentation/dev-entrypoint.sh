#!/bin/sh

ASPNETCORE_ENVIRONMENT=Development ASPNETCORE_HTTPS_PORTS=8443 dotnet watch --project KredaServer.Presentation --no-hot-reload