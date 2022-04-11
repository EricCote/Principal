$ProjectFolder = "$PSScriptRoot"
$sqlName="(localdb)\MSSQLLocalDB";


[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12
$ProgressPreference = 'SilentlyContinue'


function Get-SqlCmdPath
{
    $cmdpath=""
    if (test-path "C:\Program Files\Microsoft SQL Server\110\Tools\Binn\sqlcmd.exe")
    {$cmdpath="C:\Program Files\Microsoft SQL Server\110\Tools\Binn\sqlcmd.exe";}

    if (test-path "C:\Program Files\Microsoft SQL Server\Client SDK\ODBC\110\Tools\Binn\SQLCMD.EXE")
    {$cmdpath="C:\Program Files\Microsoft SQL Server\Client SDK\ODBC\110\Tools\Binn\SQLCMD.EXE";}

    if (test-path "C:\Program Files\Microsoft SQL Server\Client SDK\ODBC\130\Tools\Binn\SQLCMD.EXE")
    {$cmdpath="C:\Program Files\Microsoft SQL Server\Client SDK\ODBC\130\Tools\Binn\SQLCMD.EXE";}

    if (test-path "C:\Program Files\Microsoft SQL Server\Client SDK\ODBC\170\Tools\Binn\SQLCMD.EXE")
    {$cmdpath="C:\Program Files\Microsoft SQL Server\Client SDK\ODBC\170\Tools\Binn\SQLCMD.EXE";}

    if ($cmdpath -eq "") {
        $cmdpath=(Get-Command sqlcmd).Source;
    }

    return $cmdpath;
}

function Run-Sql
{
    param 
    (
         [parameter(position=1,mandatory=$true)] $svr
        ,[parameter(position=2,mandatory=$true)] $sqlString
    )   


    return & $sqlcmd -S $svr -E -Q $SqlString;
}

#start sql localdb
& "C:\Program Files\Microsoft SQL Server\150\Tools\Binn\SqlLocalDB.exe" start



$sqlcmd= Get-SqlCmdPath

$url="https://github.com/Microsoft/sql-server-samples/releases/download/adventureworks/AdventureWorksLT2019.bak"  

Invoke-WebRequest -UseBasicParsing -uri $url -OutFile "$ProjectFolder\AdventureWorksLT2019.bak"

$cmd="
DROP DATABASE IF EXISTS AdventureWorksLT;
RESTORE DATABASE AdventureWorksLT
    FROM DISK = '$ProjectFolder\AdventureWorksLT2019.bak'
WITH   
    MOVE 'AdventureWorksLT2012_Data' 
    TO '$ProjectFolder\AdventureWorksLT2019_data.mdf', 
    MOVE 'AdventureWorksLT2012_Log' 
    TO '$ProjectFolder\AdventureWorksLT2019_log.ldf';
GO

ALTER AUTHORIZATION ON DATABASE::AdventureWorksLT TO sa;
"

run-sql $sqlName $cmd

Remove-Item -path "$ProjectFolder\AdventureWorksLT2019.bak" -Force

& "C:\Program Files\Microsoft SQL Server\150\Tools\Binn\SqlLocalDB.exe" stop

 