# 🍪 CookieTour – Travel Agency Information System

## 📌 Overview

CookieTour is a desktop application developed in C# using WPF and Microsoft SQL Server.
The system is designed for managing and booking travel tours in a турист agency.

It allows users to search, view, and book tours, while administrators can manage the database content.

---

## ⚙️ Technologies Used

* **C# (.NET, WPF)**
* **SQL Server (SSMS)**
* **ADO.NET**
* **Visual Studio 2019**

---

## 🏗️ Architecture

The application follows a **client-server architecture**:

* **Client (WPF application)** – user interface and logic
* **Server (SQL Server)** – data storage and processing

---

## 🗄️ Database Structure

Main entities:

* **Countries** – list of countries
* **Cities** – cities linked to countries
* **Tours** – available tours (dates, duration, availability)
* **Vouchers** – bookings
* **Clients** – personal user data
* **Users** – authentication data
* **Roles** – user roles (Admin / User)

The database is normalized up to the **third normal form (3NF)**.

---

## 👤 User Features

* Registration and login
* Search for available tours
* Book tours
* View personal bookings
* Enter and edit personal data

---

## 🛠️ Admin Features

* View, add, and edit database records
* Manage users and roles

---

## 🔍 Booking Logic

1. User selects:

   * destination city
   * date
   * number of days
   * number of people

2. The system calculates the cost:

   ```
   Cost = 4200 × number_of_people × number_of_days
   ```

3. The system checks:

   * availability of tours
   * number of free places
   * valid dates

4. If available:

   * booking is saved in the database
   * available places are updated
