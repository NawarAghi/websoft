<?php

include('./database_connection/db_conn.php');

// to protect database from injection
$label = mysqli_real_escape_string($conn, $_POST['label']??null);
$type = mysqli_real_escape_string($conn, $_POST['type']??null);
$create = $_POST['create'] ?? null;

if ($create){
  $sql = "INSERT INTO tech(label, type) VALUES('$label', '$type')";
  $querySent = mysqli_query($conn, $sql);
  if($querySent){
    $fetch = "SELECT * FROM tech";
    $result = mysqli_query($conn, $fetch);
    $rows = mysqli_fetch_all($result, MYSQLI_ASSOC);
    mysqli_free_result($result);
    mysqli_close($conn);
  }

}

 ?>


 <?php
 include('./view/header.php');
 include('./view/nav.php');
 ?>

<div style="text-align: center; padding:15px; margin-left: auto; margin-right:auto;" >
  <h2>Create</h2>
  <form  action="create.php" method="post" style="padding:20px;">
    <label>Label:
      <input type="text" name="label" placeholder="Enter a label">
    </label>
    <label>Type:
      <input type="text" name="type" placeholder="Enter a type">
    </label>
    <input type="submit" name="create" value="create">
  </form>
</div>

<?php if($create){ ?>
<?php if ($querySent){ ?>
<table>
  <tr>
    <th>ID</th>
    <th>Label</th>
    <th>Type</th>
  </tr>
  <?php foreach ($rows as $row ) {?>
    <tr>
           <td><?= $row["id"] ?></td>
           <td><?= $row["label"] ?></td>
           <td><?= $row["type"] ?></td>
       </tr>
  <?php } ?>
</table>
<?php }else{ ?>
  <h4><?php echo "Error in: " . mysqli_error($conn) ?></h4>
<?php } ?>

<?php } ?>


 <?php include('./view/footer.php'); ?>
