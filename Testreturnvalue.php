<?php
header("content-type:text/html;charset=utf-8");
 $Classcode = $_POST["Classcode"];
 $lastname = $_POST["lastname"];
 
 $aCli[]=  array("id"=>$Classcode,"username"=>$lastname);

 echo json_encode($aCli);

?>