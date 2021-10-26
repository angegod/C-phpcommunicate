<?php
//DB_Server, DB_Name, DB_Username, DB_Password	
$serverName = "TR\SQLEXPRESS";
$connectionInfo = array( "Database"=>"Account", "UID"=>"ange", "PWD"=>"ange0909", "CharacterSet"=>"UTF-8" );
$conn = sqlsrv_connect( $serverName, $connectionInfo);
if( $conn === false ) {
     die( print_r( sqlsrv_errors(), true));
}
$classcode=$_GET["Classcode"];

$sql="select * from Account where classcode='$classcode'";
$result=sqlsrv_query($conn,$sql)or die("sql error".sqlsrv_errors());

while($row=sqlsrv_fetch_array($result)){
     echo ("<table border=1px><tr>");
     echo ("<td>編號：").$row["Id"].("</td>");
     echo ("<td>輸入值1：").$row["Accountname"].("</td>");
     echo ("<td>輸入值2：").$row["Username"].("</td>");
     echo ("</tr></table>");
     
}





?>