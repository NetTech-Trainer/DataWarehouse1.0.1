STEP 1> Install .NET Runtime on EC2
sudo dnf update -y
sudo dnf install -y dotnet-sdk-9.0
STEP 2> Install git Runtime on EC2
sudo yum install git -y
STEP 3> Upload Your Application to EC2
git clone <your-repo-url>
STEP 3> Configure appsettings.json
nano appsettings.json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=<RDS-ENDPOINT>;Port=3306;Database=DataWarehouse;User=dbuser;Password=StrongPassword;"
  }
}
STEP 9️⃣ Run the Application
dotnet restore
dotnet build
dotnet run --urls "http://0.0.0.0:5000"
