# cy-personal-website-api

The backend for my personal website, [tancheeyang.com](https://tancheeyang.com). The frontend lives in [cy-personal-website](https://github.com/cyTan-714/cy-personal-website).

For now it's a small ASP.NET Core API that the site's "Ping the API" button calls. It will grow into the backend for my exercise tracker.

## Tech stack

- ASP.NET Core (.NET 10) with minimal APIs
- Docker, using a multi-stage build
- Hosted on Render's free plan, deployed automatically on every push to `main`

## Endpoints

| Method | Path | Returns |
|---|---|---|
| GET | `/` | Plain text: "My API is running" |
| GET | `/api/hello` | JSON with a `message` and the server's current UTC time (`serverTime`) |

## Configuration

`AllowedOrigins` in `appsettings.json` lists the websites that may call the API from a browser (CORS). Secrets, like database passwords once there are any, never go in this repo. They live in Render's environment settings.

## Run it locally

```bash
dotnet run
```

The API starts on http://localhost:5016.

Or with Docker:

```bash
docker build -t cy-personal-website-api .
docker run -p 8080:8080 cy-personal-website-api
```

## Copyright

© 2026 Tan Chee Yang. All rights reserved.
This code is public so you can see how the API is built. It isn't licensed for reuse.
