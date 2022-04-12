#------------------------------------------------------
# Work with the "Package Manager console"

## Prerequisites:

#1. Add packages:
#   - Microsoft.EntityFrameworkCore (Entity Framework)
#   - Microsoft.EntityFrameworkCore.SqlServer (Data Provider)
#   - Microsoft.EntityFrameworkCore.Tools (Powershell tools)

#2. Open "Package Manager Console"
#   - Menu tools -> NuGet Package Manager -> Package Manager Console

#path should be where the project file is. (project.csproj)
cd principal

#Call the following command: 
Scaffold-DbContext `
  -Connection "Name=ConnectionStrings:AW" `
  -Provider Microsoft.EntityFrameworkCore.SqlServer `
  -OutputDir Models2 `
  -ContextDir Data `
  -Context AwContext `
  -Tables @("Product", "ProductCategory", "ProductModel") `
  -DataAnnotations `
  -Force 
  
#Single Line
Scaffold-DbContext  -Connection "Name=ConnectionStrings:AW" -Provider Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models2   -ContextDir Data -Context AwContext  -Tables @("Product", "ProductCategory", "ProductModel")   -DataAnnotations -Force 



#-------------------------------------------------------------------------------------------------------------------------
# Work with the Entity Framework CLI

#1. install the Entity Framework CLI 
dotnet tool install --global dotnet-ef

#2. Path should be where the project file is (project.csproj)
cd principal

#3. Add the design package. 
#   (Part of the Tools.  Unecessary if you already have 
#    the Microsoft.EntityFrameworkCore.Tools package 
#    referenced
#   )
dotnet add package Microsoft.EntityFrameworkCore.Design

#4. Call the scaffolding.

dotnet ef dbcontext scaffold `
	"Name=ConnectionStrings:AW" `
	Microsoft.EntityFrameworkCore.SqlServer `
	--output-dir Models2 `
	--context-dir Data `
	--context AwContext `
	--data-annotations `
	--table Product `
	--table ProductCategory `
	--table ProductModel `
	--force









#Install the Entity Framework CLI







