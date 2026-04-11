**SmartHealthcare**

Architecture & Developer Guide

*How the app works, how data flows, and how to extend it*

# **1\. The Two-Project Structure**

The app is split into two separate ASP.NET projects that communicate over HTTP. They share a common class library for models and DTOs.

| Project | Type | Responsibility |
| :---- | :---- | :---- |
| SmartHealthcare.MVC | ASP.NET MVC | Razor Pages, Controllers, session-based auth, calls API via HttpClient |
| SmartHealthcare.API | ASP.NET Web API | REST endpoints, JWT auth, business logic, EF Core \+ SQL Server |
| SmartHealthcare.Models | Class Library (shared) | Entities, DTOs — referenced by both projects |

The MVC project never touches the database directly. It always goes through the API over HTTP, attaching the JWT token from the session on every request.

# **2\. Layers Inside the API Project**

Every request that hits the API travels through a strict chain of layers. Each layer has exactly one responsibility and only communicates with the layer directly below it.

| Layer | File location | Responsibility |
| :---- | :---- | :---- |
| Controller | API/Controllers/XxxController.cs | Receives HTTP request, checks auth/roles, validates ModelState, calls service, returns IActionResult |
| Service | API/Services/XxxService.cs | Business logic, orchestration between repositories, AutoMapper DTO \<-\> Entity conversion |
| Repository | API/Repositories/XxxRepository.cs | Data access only — wraps EF Core DbSet, contains LINQ queries |
| DbContext | API/Data/ApplicationDbContext.cs | EF Core context — translates LINQ to SQL, manages migrations |
| Database | SQL Server | Persistent storage — tables mirror your entity classes |

Key rule: the controller never touches EF Core. The repository never contains business logic. This separation is what makes the codebase maintainable and testable.

# **3\. Full Request Lifecycle**

Here is exactly what happens when a doctor submits the Suggest Prescription form, traced from button click all the way to the database and back.

### **Step-by-step trace**

1. Doctor fills in the form on Details.cshtml and clicks Submit

2. Browser POSTs to /Appointment/SuggestPrescription (MVC controller)

3. AppointmentController reads the JWT from HttpContext.Session, builds a CreatePrescriptionDTO, calls ApiService.PostAsync()

4. ApiService attaches the Bearer token to the Authorization header and sends HTTP POST to /api/prescriptions/suggest

5. JWT middleware on the API validates the token and sets the User claims (role, userId)

6. PrescriptionsController checks \[Authorize(Roles="Doctor")\] and validates ModelState

7. PrescriptionService checks appointment status — throws if already Completed, then maps DTO to Prescription entity

8. PrescriptionRepository calls AddAsync() and SaveAsync() — EF Core issues INSERT to SQL Server

9. Response travels back: 200 OK with PrescriptionResponseDTO JSON

10. ApiService deserializes JSON into PrescriptionResponseDTO

11. AppointmentController sets TempData\["Success"\] and redirects to Details

12. Details page reloads, fetches prescription from API again, renders it

### **Auth flow detail**

The MVC project stores the JWT in the ASP.NET session (not a cookie or localStorage). On every API call, ApiService.AttachToken() reads it from the session and sets the Authorization: Bearer \<token\> header. The API validates this token on every single request via the JWT middleware — no server-side session on the API side.

# **4\. Entity Relationships**

These are the core entities and how they relate to each other in the database.

| Entity | Relates to | Cardinality | Key fields |
| :---- | :---- | :---- | :---- |
| User | Doctor / Patient | 1:1 each | Email, PasswordHash, Role |
| Doctor | Appointment | 1:many | ConsultationFee, LicenseNumber, IsAvailable |
| Patient | Appointment | 1:many | DateOfBirth, Gender, BloodGroup |
| Appointment | Prescription, Bill | 1:1 each | Status (Pending/Completed/Cancelled), AppointmentDate |
| Prescription | Medicine | 1:many | Status (Suggested/Finalized), Diagnosis |
| Medicine | Prescription | many:1 | Name, Dosage, Duration, Instructions |
| Bill | Appointment | 1:1 | ConsultationFee, MedicineCharges, TotalAmount, PaymentStatus |

One Appointment has one Patient, one Doctor, optionally one Prescription, and optionally one Bill. One Prescription has many Medicine rows.

# **5\. Status Flows**

## **Appointment status**

| Status | Meaning | Triggered by |
| :---- | :---- | :---- |
| Pending | Appointment booked, no prescription yet | Patient books appointment |
| Completed | Prescription finalized, bill generated | Doctor finalizes the prescription |
| Cancelled | Appointment cancelled | Manual update |

## **Prescription status**

| Status | Meaning | Triggered by |
| :---- | :---- | :---- |
| Suggested | Doctor has drafted medicines, not yet confirmed | POST /api/prescriptions/suggest |
| Finalized | Confirmed — visible to patient, bill auto-created | PATCH /api/prescriptions/{id}/finalize |

## **Bill payment status**

| Status | Meaning | Triggered by |
| :---- | :---- | :---- |
| Unpaid | Bill generated, awaiting payment | Auto-created when prescription is finalized |
| Paid | Patient has confirmed payment | PATCH /api/bills/{id}/pay |

# **6\. API Endpoints Reference**

## **Appointments**

| Method | Route | Auth | Description |
| :---- | :---- | :---- | :---- |
| GET | /api/appointments | Admin | All appointments (paged) |
| GET | /api/appointments/my-appointments | Patient | Patient's own appointments |
| GET | /api/appointments/doctor-appointments | Doctor | Doctor's own appointments |
| GET | /api/appointments/{id} | Any | Single appointment |
| POST | /api/appointments | Patient | Book appointment |

## **Prescriptions**

| Method | Route | Auth | Description |
| :---- | :---- | :---- | :---- |
| GET | /api/prescriptions/appointment/{id} | Any | Get prescription for appointment |
| POST | /api/prescriptions | Doctor | Create finalized prescription directly |
| POST | /api/prescriptions/suggest | Doctor | Create suggested prescription |
| PATCH | /api/prescriptions/{id}/finalize | Doctor | Finalize suggestion — triggers bill creation |

## **Bills**

| Method | Route | Auth | Description |
| :---- | :---- | :---- | :---- |
| GET | /api/bills/appointment/{id} | Any | Get bill for appointment |
| PATCH | /api/bills/{id}/pay | Patient | Mark bill as paid |

# **7\. How to Add a New Feature**

Every new feature follows exactly the same pattern. Work through these steps in order — skipping one causes compile or runtime errors.

## **Step 1 — SmartHealthcare.Models (shared library)**

* Add the entity class under Entities/YourEntity.cs

* Add DTOs under DTOs/YourEntityDTO.cs — one DTO for creating (CreateXxxDTO) and one for responses (XxxDTO or XxxResponseDTO)

## **Step 2 — SmartHealthcare.API**

13. Repositories/Interfaces/IYourEntityRepository.cs — extend IGenericRepository\<YourEntity\>, declare any custom query methods

14. Repositories/YourEntityRepository.cs — extend GenericRepository\<YourEntity\>, implement custom EF Core queries with Include() and AsSplitQuery()

15. Services/Interfaces/IYourEntityService.cs — declare your business methods

16. Services/YourEntityService.cs — inject IYourEntityRepository plus any other services needed, implement business logic

17. Controllers/YourEntityController.cs — inject IYourEntityService, map routes, handle exceptions, return IActionResult

18. Data/ApplicationDbContext.cs — add DbSet\<YourEntity\> YourEntities { get; set; }

19. Mappings/MappingProfile.cs — add CreateMap\<YourEntity, YourEntityDTO\>()

20. Program.cs — register services.AddScoped\<IYourEntityRepository, YourEntityRepository\>() and services.AddScoped\<IYourEntityService, YourEntityService\>()

21. Run: dotnet ef migrations add AddYourEntity then dotnet ef database update

## **Step 3 — SmartHealthcare.MVC**

* Controllers/ — add new actions to an existing controller, or create a new XxxController.cs

* Views/ — add new .cshtml views, or update existing ones

* No DI registration needed — ApiService handles all HTTP calls generically via GetAsync, PostAsync, PatchAsync, DeleteAsync

No changes to IApiService or ApiService are needed for new features unless you need a new HTTP verb that is not already implemented.

## **Naming conventions to follow**

| Thing | Pattern | Example |
| :---- | :---- | :---- |
| Entity | PascalCase noun | BillPayment |
| Repository interface | I \+ Entity \+ Repository | IBillPaymentRepository |
| Service interface | I \+ Entity \+ Service | IBillPaymentService |
| Controller | Plural entity \+ Controller | BillPaymentsController |
| Create DTO | Create \+ Entity \+ DTO | CreateBillPaymentDTO |
| Response DTO | Entity \+ DTO or Entity \+ ResponseDTO | BillPaymentDTO |
| Migration | Verb \+ description | AddBillPaymentEntity |

# **8\. Common Pitfalls & Fixes**

| Problem | Root cause | Fix |
| :---- | :---- | :---- |
| 405 Method Not Allowed on form submit | Missing \[HttpPost\] or AntiForgeryToken | Add @Html.AntiForgeryToken() inside the form and \[ValidateAntiForgeryToken\] on the action |
| 'Failed to create' error even though data saved | API returns 201 CreatedAtAction but response body is empty | Return Ok(result) instead of CreatedAtAction in the API controller |
| Prescription shown twice on the page | EF Core duplicates parent row when using Include() with multiple child rows | Add .AsSplitQuery() to all queries that Include() a collection |
| PatchAsync sends null body and fails | JsonSerializer.Serialize(null) creates invalid JSON | Check patchData \!= null before setting request.Content |
| Appointment status changes at wrong time | Business logic placed in wrong service method | Put status transitions in the service method that logically owns them (e.g. Finalize, not Suggest) |
| AutoMapper throws at startup | Missing CreateMap registration | Add CreateMap\<Entity, DTO\>() in MappingProfile.cs |

*SmartHealthcare Architecture Guide*