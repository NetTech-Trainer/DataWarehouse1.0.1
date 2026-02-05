Here’s a **clean, production-style, super-professional README.md** you can directly drop into your repo. I’ve written it the way real-world DevOps / backend teams expect it to look—clear, structured, and deployment-focused.

---

# DataWarehouse .NET Application Deployment on AWS EC2

This repository contains a **.NET application** designed to run on an **AWS EC2 instance** with a **MySQL backend**.
This document provides a **step-by-step guide** to set up the runtime, configure the database, deploy the application, and make it accessible over the network.

---

## Architecture Overview

* **Application**: ASP.NET Core (.NET 9)
* **Operating System**: Amazon Linux (EC2)
* **Database**: MySQL
* **Deployment Type**: Standalone EC2 (non-containerized)
* **Port**: 5000 (HTTP)

---

## Prerequisites

Before you begin, ensure you have:

* An **AWS EC2 instance** (Amazon Linux)
* **Inbound access** to port `5000` in the Security Group
* **MySQL Server** installed and running
* Git repository access for the application source code

---

## Step 1: Install .NET SDK on EC2

Update system packages and install the .NET 9 SDK:

```bash
sudo dnf update -y
sudo dnf install -y dotnet-sdk-9.0
```

Verify installation:

```bash
dotnet --version
```

---

## Step 2: Install Git

Git is required to clone the application repository:

```bash
sudo yum install git -y
```

Verify installation:

```bash
git --version
```

---

## Step 3: Upload / Clone Application Source Code

Clone your application repository into the EC2 instance:

```bash
git clone <your-repo-url>
cd <project-directory>
```

---

## Step 4: Create Database and Table

Log in to MySQL:

```bash
mysql -u root -p
```

Create the database and table:

```sql
CREATE DATABASE DataWarehouse;
USE DataWarehouse;

CREATE TABLE Orders (
  Id INT AUTO_INCREMENT PRIMARY KEY,
  OrderDate DATETIME NOT NULL,
  Amount DECIMAL(18,2) NOT NULL
);
```

Exit MySQL:

```sql
EXIT;
```

---

## Step 5: Configure Database Connection

Edit the `appsettings.json` file:

```bash
nano appsettings.json
```

Update the connection string:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=127.0.0.1;Port=3306;Database=DataWarehouse;User=root;Password=root123;"
  }
}
```

> ⚠️ **Security Note**
> Do not hardcode credentials in production. Use **environment variables** or **AWS Secrets Manager**.

---

## Step 6: Build and Run the Application

Restore dependencies:

```bash
dotnet restore
```

Build the application:

```bash
dotnet build
```

Run the application and bind it to all interfaces:

```bash
dotnet run --urls "http://0.0.0.0:5000"
```

The application will now be accessible via:

```
http://<EC2-PUBLIC-IP>:5000
```

---

## Step 7: Configure AWS Security Group

Ensure the EC2 Security Group allows inbound traffic:

| Type | Protocol | Port | Source    |
| ---- | -------- | ---- | --------- |
| HTTP | TCP      | 5000 | 0.0.0.0/0 |

> 🔒 For production, restrict access to trusted IP ranges only.

---

## Common Troubleshooting

### Application Not Accessible

* Verify EC2 Security Group inbound rules
* Ensure application is listening on `0.0.0.0`
* Check EC2 instance firewall (if configured)

### Database Connection Errors

* Confirm MySQL service is running
* Validate username, password, and database name
* Ensure MySQL is listening on `127.0.0.1:3306`

---

## Production Recommendations

* Run the app using **systemd** or **PM2-like supervisor**
* Enable **HTTPS** using Nginx + SSL
* Store secrets securely
* Enable logging and monitoring
* Consider Docker or ECS for scalable deployments

---

## Author

**Sagar**
Cloud | DevOps | .NET | AWS Trainer

---



