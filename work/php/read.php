<?php

include('./database_connection/db_conn.php');

$sql = "SELECT * FROM tech";
$result = mysqli_query($conn, $sql);
$rows = mysqli_fetch_all($result, MYSQLI_ASSOC);

mysqli_free_result($result);
mysqli_close($conn);

 ?>

 <?php
 include('./view/header.php');
 include('./view/nav.php');
 ?>



<table style="border-collapse: collapse; text-align: center; margin-left: auto; margin-right: auto;
              margin-top: 7%; width: 50%;">
  <tr>
      <th>ID</th>
      <th>LABEL</th>
      <th>TYPE</th>
  </tr>
<?php foreach($rows as $row){?>

  <tr>
      <td><?= $row["id"] ?></td>
      <td><?= $row["label"] ?></td>
      <td><?= $row["type"] ?></td>
  </tr>
<?php }?>
</table>


  <?php include('./view/footer.php'); ?>
