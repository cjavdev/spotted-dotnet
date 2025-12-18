# Unofficial Spotify API Library

> [!NOTE]
> The Unofficial Spotify API Library is currently in **beta** and we're excited for you to experiment with it!
>
> This library has not yet been exhaustively tested in production environments and may be missing some features you'd expect in a stable release. As we continue development, there may be breaking changes that require updates to your code.
>
> **We'd love your feedback!** Please share any suggestions, bug reports, feature requests, or general thoughts by [filing an issue](https://www.github.com/cjavdev/spotted-dotnet/issues/new).

The Unofficial Spotify SDK provides convenient access to the [Spotted REST API](https://spotted.stldocs.com) from applications written in C#.

It is generated with [Stainless](https://www.stainless.com/).

The REST API documentation can be found on [spotted.stldocs.com](https://spotted.stldocs.com).

## Installation

Install the package from [NuGet](https://www.nuget.org/packages/Spotted):

```bash
dotnet add package Spotted
```

## Requirements

This library requires .NET Standard 2.0 or later.

## Usage

See the [`examples`](examples) directory for complete and runnable examples.

```csharp
using System;
using Spotted;
using Spotted.Models.Albums;

SpottedClient client = new();

AlbumRetrieveParams parameters = new() { ID = "4aawyAB9vmqN3uQ7FjRGTy" };

var album = await client.Albums.Retrieve(parameters);

Console.WriteLine(album);
```

## Client configuration

Configure the client using environment variables:

```csharp
using Spotted;

// Configured using the SPOTIFY_CLIENT_ID, SPOTIFY_CLIENT_SECRET, SPOTIFY_ACCESS_TOKEN and SPOTTED_BASE_URL environment variables
SpottedClient client = new();
```

Or manually:

```csharp
using Spotted;

SpottedClient client = new()
{
    ClientID = "My Client ID",
    ClientSecret = "My Client Secret",
};
```

Or using a combination of the two approaches.

See this table for the available options:

| Property       | Environment variable    | Required | Default value                  |
| -------------- | ----------------------- | -------- | ------------------------------ |
| `ClientID`     | `SPOTIFY_CLIENT_ID`     | false    | -                              |
| `ClientSecret` | `SPOTIFY_CLIENT_SECRET` | false    | -                              |
| `AccessToken`  | `SPOTIFY_ACCESS_TOKEN`  | false    | -                              |
| `BaseUrl`      | `SPOTTED_BASE_URL`      | true     | `"https://api.spotify.com/v1"` |

### Modifying configuration

To temporarily use a modified client configuration, while reusing the same connection and thread pools, call `WithOptions` on any client or service:

```csharp
using System;

var album = await client
    .WithOptions(options =>
        options with
        {
            BaseUrl = "https://example.com",
            Timeout = TimeSpan.FromSeconds(42),
        }
    )
    .Albums.Retrieve(parameters);

Console.WriteLine(album);
```

Using a [`with` expression](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/with-expression) makes it easy to construct the modified options.

The `WithOptions` method does not affect the original client or service.

## Requests and responses

To send a request to the Spotted API, build an instance of some `Params` class and pass it to the corresponding client method. When the response is received, it will be deserialized into an instance of a C# class.

For example, `client.Albums.Retrieve` should be called with an instance of `AlbumRetrieveParams`, and it will return an instance of `Task<AlbumRetrieveResponse>`.

## Binary responses

The SDK defines methods that return binary responses, which are used for API responses that shouldn't necessarily be parsed, like non-JSON data.

These methods return `HttpResponse`:

```csharp
using System;
using System.Text;
using Spotted.Models.Playlists.Images;

ImageUpdateParams parameters = new()
{
    PlaylistID = "3cEYpjA9oz9GiPac4AsH4n",
    Body = Encoding.UTF8.GetBytes("text"),
};

var image = await client.Playlists.Images.Update(parameters);

Console.WriteLine(image);
```

To save the response content to a file, or any [`Stream`](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream?view=net-9.0), use the [`CopyToAsync`](<https://learn.microsoft.com/en-us/dotnet/api/system.io.stream.copytoasync?view=net-9.0#system-io-stream-copytoasync(system-io-stream)>) method:

```csharp
using System.IO;

using var response = await client.Playlists.Images.Update(parameters);
using var contentStream = await response.ReadAsStream();
using var fileStream = File.Open(path, FileMode.OpenOrCreate);
await contentStream.CopyToAsync(fileStream); // Or any other Stream
```

## Error handling

The SDK throws custom unchecked exception types:

- `SpottedApiException`: Base class for API errors. See this table for which exception subclass is thrown for each HTTP status code:

| Status | Exception                              |
| ------ | -------------------------------------- |
| 400    | `SpottedBadRequestException`           |
| 401    | `SpottedUnauthorizedException`         |
| 403    | `SpottedForbiddenException`            |
| 404    | `SpottedNotFoundException`             |
| 422    | `SpottedUnprocessableEntityException`  |
| 429    | `SpottedRateLimitException`            |
| 5xx    | `Spotted5xxException`                  |
| others | `SpottedUnexpectedStatusCodeException` |

Additionally, all 4xx errors inherit from `Spotted4xxException`.

false

- `SpottedIOException`: I/O networking errors.

- `SpottedInvalidDataException`: Failure to interpret successfully parsed data. For example, when accessing a property that's supposed to be required, but the API unexpectedly omitted it from the response.

- `SpottedException`: Base class for all exceptions.

## Network options

### Retries

The SDK automatically retries 2 times by default, with a short exponential backoff between requests.

Only the following error types are retried:

- Connection errors (for example, due to a network connectivity problem)
- 408 Request Timeout
- 409 Conflict
- 429 Rate Limit
- 5xx Internal

The API may also explicitly instruct the SDK to retry or not retry a request.

To set a custom number of retries, configure the client using the `MaxRetries` method:

```csharp
using Spotted;

SpottedClient client = new() { MaxRetries = 3 };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var album = await client
    .WithOptions(options =>
        options with { MaxRetries = 3 }
    )
    .Albums.Retrieve(parameters);

Console.WriteLine(album);
```

### Timeouts

Requests time out after 1 minute by default.

To set a custom timeout, configure the client using the `Timeout` option:

```csharp
using System;
using Spotted;

SpottedClient client = new() { Timeout = TimeSpan.FromSeconds(42) };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var album = await client
    .WithOptions(options =>
        options with { Timeout = TimeSpan.FromSeconds(42) }
    )
    .Albums.Retrieve(parameters);

Console.WriteLine(album);
```

## Undocumented API functionality

The SDK is typed for convenient usage of the documented API. However, it also supports working with undocumented or not yet supported parts of the API.

### Response validation

In rare cases, the API may return a response that doesn't match the expected type. For example, the SDK may expect a property to contain a `string`, but the API could return something else.

By default, the SDK will not throw an exception in this case. It will throw `SpottedInvalidDataException` only if you directly access the property.

If you would prefer to check that the response is completely well-typed upfront, then either call `Validate`:

```csharp
var album = client.Albums.Retrieve(parameters);
album.Validate();
```

Or configure the client using the `ResponseValidation` option:

```csharp
using Spotted;

SpottedClient client = new() { ResponseValidation = true };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var album = await client
    .WithOptions(options =>
        options with { ResponseValidation = true }
    )
    .Albums.Retrieve(parameters);

Console.WriteLine(album);
```

## Semantic versioning

This package generally follows [SemVer](https://semver.org/spec/v2.0.0.html) conventions, though certain backwards-incompatible changes may be released as minor versions:

1. Changes to library internals which are technically public but not intended or documented for external use. _(Please open a GitHub issue to let us know if you are relying on such internals.)_
2. Changes that we do not expect to impact the vast majority of users in practice.

We take backwards-compatibility seriously and work hard to ensure you can rely on a smooth upgrade experience.

We are keen for your feedback; please open an [issue](https://www.github.com/cjavdev/spotted-dotnet/issues) with questions, bugs, or suggestions.
