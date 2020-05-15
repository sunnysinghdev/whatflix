# whatflix
A problem given by geektrust

## Swagger Configuration

Changes Version 5.0.0

>using Microsoft.OpenApi.Models;

>`OpenApiInfo` replaced `Info`

```csharp
services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo  { Title = "Awesome API", Version = "v1" });
    });
```