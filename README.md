# Car Rental System

Lightweight WinForms app for running a car rental desk. Highlights:

- Unified screens for customers, vehicles, bookings, transactions, maintenance, and returns.
- SQL Server + ADO.NET data layer with a dedicated business layer separating UI concerns.
- Bilingual labels, dashboard stats, and role-aware menus for day-to-day operations.

## Setup

1. Apply the SQL scripts under `DatabaseScripts` and update the connection string in `CarRental_DataAccess/clsDataAccessSettings.cs`.
2. Open `CarRental/CarRental.sln` in Visual Studio 2022, restore NuGet packages if prompted, then build (Any CPU | Debug).
3. Run the `CarRental` project and sign in with the seeded admin user to explore the features.

Bug reports and improvements are welcome via issues or pull requests.
