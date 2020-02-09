<?php


include('./database_connection/db_conn.php');


$search = $_POST["search"] ?? null;

$sql = "SELECT * FROM tech Where id LIKE '%$search%' OR label LIKE '%$search%'
OR type LIKE '%$search%' ";

$result = mysqli_query($conn, $sql);

$rows = mysqli_fetch_all($result, MYSQLI_ASSOC);

mysqli_free_result($result);
mysqli_close($conn);

?>

<?php include('./view/header.php')?>

<div style="text-align: center; padding:15px; margin-left: auto; margin-right:auto;">
  <h2>SEARCH ENGINE</h2>

  <form action='search.php', method='POST' style="padding:15px;">
  <label>Search:</label>
  <input type = 'text' name='search' value='<?php $search?>'>
  </form>

  <?php if($search){?>
  <table style="border-collapse: collapse; text-align: center; margin-left: auto; margin-right: auto; ">
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
  <?php }?>
</div>



<?php include('./view/footer.php')?>
