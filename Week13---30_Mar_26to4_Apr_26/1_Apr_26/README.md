# 🛒 Product Inventory API — .NET 8

A secure, fully tested Product Management REST API built with ASP.NET Core 8.

---

## 📁 Folder Structure

```
ProductApi/
├── ProductApi.sln
├── ProductApi/
│   ├── ProductApi.csproj
│   ├── Program.cs                        ← DI, JWT, Swagger setup
│   ├── appsettings.json
│   ├── Models/
│   │   └── Product.cs                    ← Product entity
│   ├── Data/
│   │   └── AppDbContext.cs               ← EF Core DbContext
│   ├── Repositories/
│   │   ├── IProductRepository.cs         ← Repository interface
│   │   └── ProductRepository.cs          ← EF Core implementation
│   ├── Services/
│   │   ├── IProductService.cs            ← Service interface
│   │   └── ProductService.cs             ← Business logic
│   ├── Auth/
│   │   └── JwtTokenService.cs            ← JWT token generator
│   └── Controllers/
│       ├── AuthController.cs             ← POST /api/auth/login
│       └── ProductsController.cs         ← CRUD endpoints
│
└── ProductApi.Tests/
    ├── ProductApi.Tests.csproj
    ├── xUnitTests/
    │   ├── ProductControllerXUnitTests.cs ← Controller tests (xUnit + Moq)
    │   └── ProductServiceXUnitTests.cs    ← Service tests (xUnit + Moq)
    ├── NUnitTests/
    │   └── ProductControllerNUnitTests.cs ← Controller tests (NUnit + Moq)
    └── IntegrationTests/
        └── ProductIntegrationTests.cs     ← InMemory DB integration tests
```

---

## 🚀 Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- Visual Studio 2022 / VS Code / Rider

### Run the API

```bash
cd ProductApi
dotnet run
```

Open browser at: **http://localhost:5000** (Swagger UI loads at root)

---

## 🔐 JWT Authentication Flow

### Step 1 — Get a Token

**POST** `/api/auth/login`

```json
{
  "username": "admin",
  "password": "admin123"
}
```

Response:
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "message": "Login successful!"
}
```

### Step 2 — Authorize in Swagger

1. Click the **Authorize 🔒** button in Swagger UI
2. Enter: `Bearer <paste-your-token-here>`
3. Click **Authorize** → now all endpoints are accessible

---

## 📡 API Endpoints

| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| POST | `/api/auth/login` | Get JWT token | ❌ |
| GET | `/api/products` | Get all products | ✅ |
| GET | `/api/products/{id}` | Get product by ID | ✅ |
| POST | `/api/products` | Add new product | ✅ |
| PUT | `/api/products/{id}` | Update product | ✅ |
| DELETE | `/api/products/{id}` | Delete product | ✅ |

---

## 🧪 Running Tests

```bash
cd ProductApi.Tests
dotnet test
```

Expected output:
```
Passed! - Failed: 0, Passed: 15, Skipped: 0
```

### Test Categories

| File | Framework | Type | Tests |
|------|-----------|------|-------|
| `ProductControllerXUnitTests.cs` | xUnit + Moq | Unit | 6 |
| `ProductServiceXUnitTests.cs` | xUnit + Moq | Unit | 4 |
| `ProductControllerNUnitTests.cs` | NUnit + Moq | Unit | 6 |
| `ProductIntegrationTests.cs` | xUnit | Integration | 5 |

---

## 🔑 Key Concepts Demonstrated

### Dependency Injection
```
Controller → IProductService → IProductRepository → AppDbContext
```

### Mocking with Moq (xUnit example)
```csharp
var mockService = new Mock<IProductService>();
mockService.Setup(s => s.GetProductByIdAsync(1)).ReturnsAsync(product);

var result = await controller.GetProduct(1);
Assert.IsType<OkObjectResult>(result);
```

### Same test in NUnit
```csharp
_mockService.Setup(s => s.GetProductByIdAsync(1)).ReturnsAsync(product);

var result = await _controller.GetProduct(1);
Assert.That(result, Is.InstanceOf<OkObjectResult>());
```

### xUnit vs NUnit Comparison

| Feature | xUnit | NUnit |
|---------|-------|-------|
| Test attribute | `[Fact]` | `[Test]` |
| Setup method | Constructor | `[SetUp]` method |
| Assertion style | `Assert.IsType<T>()` | `Assert.That(x, Is.InstanceOf<T>())` |
| Test class attr | _(none needed)_ | `[TestFixture]` |

---

## ⚠️ Common Errors & Fixes

| Error | Cause | Fix |
|-------|-------|-----|
| `IDX10653: The encryption algorithm 'HS256'... key size must be >= 256 bits` | JWT key too short | Use a key with 32+ characters |
| `401 Unauthorized` in Swagger | Missing Bearer prefix | Enter `Bearer <token>` not just `<token>` |
| `No authenticationScheme was specified` | Missing `AddAuthentication` | Ensure `UseAuthentication()` is before `UseAuthorization()` |

---

## 📦 NuGet Packages Used

**ProductApi:**
- `Microsoft.EntityFrameworkCore.InMemory`
- `Microsoft.AspNetCore.Authentication.JwtBearer`
- `Swashbuckle.AspNetCore`

**ProductApi.Tests:**
- `xunit` + `xunit.runner.visualstudio`
- `NUnit` + `NUnit3TestAdapter`
- `Moq`
- `Microsoft.EntityFrameworkCore.InMemory`
